namespace Mauve.Diagnostics
{
    public class DiagnosticSessionAppendRequest : IRequest
    {
        public object Data { get; private set; }
        public DiagnosticSessionAppendRequest(object data) =>
            Data = data;
    }
}
