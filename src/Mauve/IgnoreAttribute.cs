using System;

namespace Mauve
{
    /// <summary>
    /// Represents an <see cref="Attribute"/> for denoting that the target should be ignored.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class IgnoreAttribute : Attribute
    {
        /// <summary>
        /// The reason the target should be ignored.
        /// </summary>
        public string Reason { get; private set; }
        /// <summary>
        /// Creates a new <see cref="IgnoreAttribute"/> instance.
        /// </summary>
        public IgnoreAttribute() =>
            Reason = "Unspecified.";
        /// <summary>
        /// Creates a new <see cref="IgnoreAttribute"/> instance with the specified reason.
        /// </summary>
        /// <param name="reason">The reason the target should be ignored.</param>
        public IgnoreAttribute(string reason) =>
            Reason = reason;
    }
}
