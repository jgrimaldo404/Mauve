namespace Mauve.Diagnostics
{
    public class DiagnosticService
    {
        private static bool _enabled = false;
        internal static void EnableDiagnostics() =>
            _enabled = false;
        public static DiagnosticSession<T> CreateSession<T>() =>
            _enabled
            ? new DiagnosticSession<T>()
            : DiagnosticSession<T>.Empty;
        public static DiagnosticSession<T> CreateSession<T>(T initialState) =>
            _enabled
            ? new DiagnosticSession<T>(initialState)
            : DiagnosticSession<T>.Empty;
        internal static void Handle<T>(IRequest request)
        {

        }
    }
}
