using System.Collections.Generic;
using System.Linq;

using Mauve.Serialization;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods that are applicable to all types utilizing generics for type safety.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Determines if a specified value is present in a specified collection using a specified equality comparer.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data in the collection.</typeparam>
        /// <param name="input">The value to search the collection for.</param>
        /// <param name="collection">The collection to look through.</param>
        /// <returns><see langword="true"/> if the specified collection contains the specified input, otherwise <see langword="false"/>.</returns>
        public static bool In<T>(this T input, params T[] collection) =>
            collection?.Any(a => a.Equals(input)) == true;
        /// <summary>
        /// Determines if a specified value is present in a specified collection using a specified equality comparer.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data in the collection.</typeparam>
        /// <param name="input">The value to search the collection for.</param>
        /// <param name="equalityComparer">The comparer that should be used to check equality.</param>
        /// <param name="collection">The collection to look through.</param>
        /// <returns><see langword="true"/> if the specified collection contains the specified input, otherwise <see langword="false"/>.</returns>
        public static bool In<T>(this T input, IEqualityComparer<T> equalityComparer, params T[] collection) =>
            collection?.Any(a => equalityComparer.Equals(a, input)) == true;
        /// <summary>
        /// Translates the specified input to a specified output type using a specified <see cref="IAdapter{T1, T2}"/>.
        /// </summary>
        /// <typeparam name="TIn">Specifies the type of input.</typeparam>
        /// <typeparam name="TOut">Specifies the type of output expected.</typeparam>
        /// <param name="input">The input to translate.</param>
        /// <param name="adapter">The adapter to perform the translation with.</param>
        /// <returns>Returns the input translated to the specified output type.</returns>
        public static TOut Translate<TIn, TOut>(this TIn input, IAdapter<TIn, TOut> adapter) =>
            adapter.Convert(input);
        /// <summary>
        /// Translates the specified input to a specified output type using a specified <see cref="IAdapter{T1, T2}"/>.
        /// </summary>
        /// <typeparam name="TIn">Specifies the type of input.</typeparam>
        /// <typeparam name="TOut">Specifies the type of output expected.</typeparam>
        /// <param name="input">The input to translate.</param>
        /// <param name="adapter">The adapter to perform the translation with.</param>
        /// <returns>Returns the input translated to the specified output type.</returns>
        public static TOut Translate<TIn, TOut>(this TIn input, IAdapter<TOut, TIn> adapter) =>
            adapter.Convert(input);
        /// <summary>
        /// Serializes the current state of the specified input utilizing the specified <see cref="SerializationMethod"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data to be serialized.</typeparam>
        /// <param name="input">The data to be serialized.</param>
        /// <param name="serializationMethod">The <see cref="SerializationMethod"/> that should be utilized for serialization.</param>
        /// <returns>Returns the input data serialized using the specified <see cref="SerializationMethod"/>.</returns>
        public static string Serialize<T>(this T input, SerializationMethod serializationMethod)
        {
            SerializationProvider serializationProvider = serializationMethod switch
            {
                SerializationMethod.Binary => new BinarySerializationProvider(),
                SerializationMethod.Xml => new XmlSerializationProvider(),
                SerializationMethod.Json => new JsonSerializationProvider(),
                SerializationMethod.Yaml => new YamlSerializationProvider(),
                _ => new RawSerializationProvider(),
            };
            return serializationProvider.Serialize(input);
        }
    }
}
