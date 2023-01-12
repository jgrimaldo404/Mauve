namespace Mauve.Diagnostics
{
    public class DiagnosticSessionUpdateRequest<T> : IRequest
    {
        public T State { get; private set; }
        public DiagnosticSessionUpdateRequest(T finalState) =>
            State = finalState;
    }
}
