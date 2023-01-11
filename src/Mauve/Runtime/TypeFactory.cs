using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Mauve.Runtime
{
    /// <summary>
    /// A factory for creating types.
    /// </summary>
    public class TypeFactory
    {
        private Type _instanceType;
        private readonly Type _type;
        private readonly List<Assembly> _assemblies;
        private readonly List<Type> _implementingCollection;
        private readonly Dictionary<Type, Func<Attribute, bool>> _attributePredicates;
        private readonly List<Func<Type, bool>> _predicates;
        private static readonly IServiceProvider _serviceProvider;
        private static IEnumerable<Assembly> _preloadedAssemblies;
        private static readonly List<Type> _typeCache;
        private TypeFactory(Type type)
        {
            _type = type;
            _assemblies = new List<Assembly>();
            _implementingCollection = new List<Type>();
            _attributePredicates = new Dictionary<Type, Func<Attribute, bool>>();
            _predicates = new List<Func<Type, bool>>();
        }
        /// <summary>
        /// Creates a new <see cref="TypeFactory"/> instance focused creating the specified type with the specified parameters.
        /// </summary>
        /// <typeparam name="T">Specifies the <see cref="Type"/> the factory is focused on creating.</typeparam>
        /// <param name="parameters">The parameters for the instance to be created.</param>
        /// <returns>A <see cref="TypeFactory"/> instance focused on creating the specified type.</returns>
        public static TypeFactory Create<T>()
        {
            var factory = new TypeFactory(typeof(T));
            return factory;
        }
        public static T CreateInstance<T>(params object[] parameters) => default;
        public static void Configure(IServiceProvider serviceProvider, params Assembly[] assemblies) => _preloadedAssemblies = assemblies;
        /// <summary>
        /// Creates an instance of the specified type using the specified parameters.
        /// </summary>
        /// <typeparam name="T">Specifies the type to instantiate.</typeparam>
        /// <param name="parameters">The parameters for the instance to be created.</param>
        /// <returns>The newly created instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if more than one match was identified for the specified type.</exception>
        public T Instantiate<T>(params object[] parameters)
        {
            // If we haven't identified a type, then attempt to.
            if (_instanceType is null)
            {
                // Get an initial collection of types.
                var types = new List<Type>();
                foreach (Assembly assembly in _assemblies)
                    types.AddRange(assembly.GetTypes());

                // Apply the implementation rules.
                foreach (Type type in _implementingCollection)
                    types = types.Where(t => type.IsAssignableFrom(t)).ToList();

                // Apply the attribute rules.
                foreach (Type attributeType in _attributePredicates.Keys)
                {
                    types = types.Where(t =>
                    {
                        IEnumerable<Attribute> attributes = t.GetCustomAttributes(attributeType);
                        return attributes.All(a => _attributePredicates[attributeType](a));
                    }).ToList();
                }

                // Apply the predicate rules.
                foreach (Func<Type, bool> predicate in _predicates)
                    types = types.Where(t => predicate(t)).ToList();

                // Ensure there's only one type remaining.
                if (types.Count > 1)
                    throw new InvalidOperationException("The type factory could not find a unique type to instantiate.");

                // Set the instance type.
                _instanceType = types.Count == 0
                    ? _type
                    : types.SingleOrDefault();
            }

            // Create an instance of the identified type.
            return _serviceProvider is null
                ? (T)Activator.CreateInstance(_instanceType, parameters.ToArray())
                : (T)ActivatorUtilities.CreateInstance(_serviceProvider, _type, parameters);
        }
        /// <summary>
        /// Registers the specified assembly as a source of types to create from.
        /// </summary>
        /// <param name="assembly">The assembly to reference for types.</param>
        /// <returns>The current <see cref="TypeFactory"/> instance.</returns>
        public TypeFactory FromAssembly(Assembly assembly)
        {
            _assemblies.Add(assembly);
            return this;
        }
        /// <summary>
        /// Specifies that the type to be created must implement the specified type.
        /// </summary>
        /// <typeparam name="T">Specifies the <see cref="Type"/> that must be implemented.</typeparam>
        /// <returns>The current <see cref="TypeFactory"/> instance.</returns>
        public TypeFactory Implementing<T>() where T : class
        {
            _implementingCollection.Add(typeof(T));
            return this;
        }
        /// <summary>
        /// Specifies that the type to be created must have the specified attribute.
        /// </summary>
        /// <typeparam name="T">Specifies the type of attribute that the type must have.</typeparam>
        /// <returns>The current <see cref="TypeFactory"/> instance.</returns>
        public TypeFactory WithAttribute<T>() where T : Attribute
        {
            _attributePredicates.Add(typeof(T), (attribute) => true);
            return this;
        }
        /// <summary>
        /// Specifies that the type to be created must have the specified attribute.
        /// </summary>
        /// <typeparam name="T">Specifies the type of attribute that the type must have.</typeparam>
        /// <returns>The current <see cref="TypeFactory"/> instance.</returns>
        public TypeFactory WithAttribute<T>(Func<T, bool> predicate) where T : Attribute
        {
            _attributePredicates.Add(typeof(T), attribute => predicate((T)attribute));
            return this;
        }
        /// <summary>
        /// Adds a predicate to the factory that must be satisfied for the type to be created.
        /// </summary>
        /// <param name="predicate">The predicate used to further restrict which types are compatible for instantiation.</param>
        /// <returns>The current <see cref="TypeFactory"/> instance.</returns>
        public TypeFactory Where(Func<Type, bool> predicate)
        {
            _predicates.Add(predicate);
            return this;
        }
    }
}
