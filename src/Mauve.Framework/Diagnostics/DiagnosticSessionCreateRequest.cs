namespace Mauve.Diagnostics
{
    public class DiagnosticSessionCreateRequest<T> : IRequest
    {
        public T State { get; private set; }
        public DiagnosticSessionCreateRequest(T state) =>
            State = state;
    }
}
