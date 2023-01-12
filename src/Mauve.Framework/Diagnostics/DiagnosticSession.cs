using System;
using System.Collections.Generic;

namespace Mauve.Diagnostics
{
    public class DiagnosticSession<T>
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<T> States { get; private set; }
        public List<object> Data { get; private set; }
        /// <summary>
        /// Represents an empty diagnostic session.
        /// </summary>
        public static DiagnosticSession<T> Empty => new DiagnosticSession<T>();
        internal DiagnosticSession()
        {
            StartDate = DateTime.Now;
            States = new List<T>();
            Data = new List<object>();
        }
        internal DiagnosticSession(T initialState) :
            this() =>
            States.Add(initialState);
        public DiagnosticSession<T> Append<TIn>(TIn data)
        {
            if (this != Empty)
                DiagnosticService.Handle<T>(new DiagnosticSessionAppendRequest(data));

            return this;
        }
        public DiagnosticSession<T> Update(T currentState)
        {
            if (this != Empty)
                DiagnosticService.Handle<T>(new DiagnosticSessionUpdateRequest<T>(currentState));

            return this;
        }
        public void EndSession()
        {
            EndDate = DateTime.Now;
            if (this != Empty)
                DiagnosticService.Handle<T>(new DiagnosticSessionEndRequest<T>());
        }
    }
}
