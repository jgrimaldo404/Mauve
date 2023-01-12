using System;
using System.Linq;
using System.Reflection;

namespace Mauve.Extensibility
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether the specified type is a concrete type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <param name="includeStruct">Specifies whether a <see langword="struct"/> should be considered concrete.</param>
        /// <returns><see langword="true"/> if <paramref name="type"/> is a concrete type, otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        public static bool IsConcrete(this Type type, bool includeStruct = false) =>
            type is null
                ? throw new ArgumentNullException("`type` cannot be null.")
                : type.IsValueType
                    ? includeStruct
                    : !type.IsInterface && !type.IsAbstract;
        public static bool DerivesFrom<T>(this Type child) =>
            DerivesFrom(child, typeof(T));
        public static bool DerivesFrom(this Type child, Type parent)
        {
            if (child == parent)
                return false;

            if (child.IsSubclassOf(parent))
                return true;

            Type[] parameters = parent.GetGenericArguments();
            bool isParameterLessGeneric = !(parameters != null && parameters.Length > 0 &&
                ((parameters[0].Attributes & TypeAttributes.BeforeFieldInit) == TypeAttributes.BeforeFieldInit));

            while (child != null && child != typeof(object))
            {
                Type cur = GetFullTypeDefinition(child);
                if (parent == cur || (isParameterLessGeneric && cur.GetInterfaces().Select(i => GetFullTypeDefinition(i)).Contains(GetFullTypeDefinition(parent))))
                    return true;
                else if (!isParameterLessGeneric)
                    if (GetFullTypeDefinition(parent) == cur && !cur.IsInterface)
                    {
                        if (VerifyGenericArguments(GetFullTypeDefinition(parent), cur))
                            if (VerifyGenericArguments(parent, child))
                                return true;
                    } else
                        foreach (Type item in child.GetInterfaces().Where(i => GetFullTypeDefinition(parent) == GetFullTypeDefinition(i)))
                            if (VerifyGenericArguments(parent, item))
                                return true;

                child = child.BaseType;
            }

            return false;
        }
        private static Type GetFullTypeDefinition(Type type) => type.IsGenericType ? type.GetGenericTypeDefinition() : type;
        private static bool VerifyGenericArguments(Type parent, Type child)
        {
            Type[] childArguments = child.GetGenericArguments();
            Type[] parentArguments = parent.GetGenericArguments();
            if (childArguments.Length == parentArguments.Length)
                for (int i = 0; i < childArguments.Length; i++)
                    if (childArguments[i].Assembly != parentArguments[i].Assembly || childArguments[i].Name != parentArguments[i].Name || childArguments[i].Namespace != parentArguments[i].Namespace)
                        if (!childArguments[i].IsSubclassOf(parentArguments[i]))
                            return false;

            return true;
        }
    }
}
