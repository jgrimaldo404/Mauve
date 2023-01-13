using System.Text;

namespace Mauve.Extensibility
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendIf(this StringBuilder builder, string input, bool condition) =>
            condition
            ? builder.Append(input)
            : builder;
    }
}
