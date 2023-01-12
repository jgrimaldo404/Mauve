namespace Mauve.Diagnostics
{
    public class DiagnosticSessionEndRequest<T> : IRequest
    {
        public T FinalState { get; private set; }
        public DiagnosticSessionEndRequest() { }
        public DiagnosticSessionEndRequest(T finalState) =>
            FinalState = finalState;
    }
}
