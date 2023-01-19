namespace Mauve.Serialization
{
    /// <summary>
    /// Represents a <see cref="SerializationMethod"/> for the serialization and deserialization of data.
    /// </summary>
    public enum SerializationMethod
    {
        /// <summary>
        /// Represents an unspecified or unsupported serialization method.
        /// </summary>
        None = 0,
        /// <summary>
        /// <see href="https://en.wikipedia.org/wiki/XML">Extensible Markup Language</see> is a markup language and file format for storing, transmitting, and reconstructing arbitrary data.
        /// </summary>
        Xml = 2,
        /// <summary>
        /// JavaScript Object Notation is an open standard file format and data interchange format that uses human-readable text to store and transmit data objects consisting of attribute–value pairs and arrays (or other serializable values).
        /// </summary>
        /// <remarks>Mauve utilizes <see href="https://www.newtonsoft.com/json">Newtonsoft.Json</see> for handling JSON.</remarks>
        /// <see href="https://en.wikipedia.org/wiki/JSON"/>
        Json = 3,
        /// <summary>
        /// <see href="https://en.wikipedia.org/wiki/YAML">YAML Ain't Markup Language</see> is a human-readable data-serialization language. It is commonly used for configuration files and in applications where data is being stored or transmitted.
        /// </summary>
        Yaml = 4
    }
}
