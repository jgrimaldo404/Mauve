using System;

namespace Mauve.Serialization
{
    /// <summary>
    /// Represents a <see cref="SerializationProvider"/> focused on serializing and deserializing data using <see cref="SerializationMethod.None"/>.
    /// </summary>
    /// <inheritdoc/>
    internal class RawSerializationProvider : SerializationProvider
    {
        /// <summary>
        /// Creates a new instance of <see cref="RawSerializationProvider"/>.
        /// </summary>
        public RawSerializationProvider() : base(SerializationMethod.None) { }
        /// <inheritdoc/>
        public override T Deserialize<T>(string input) => (T)Convert.ChangeType(input, typeof(T));
        /// <inheritdoc/>
        public override string Serialize<T>(T input) => input.ToString();
    }
}
