using System;
using System.Diagnostics;

namespace YellowNotes.Api.Services
{
    public interface ILogger
    {
        void Error(Exception ex, string additionalInfo = null);
    }

    public class FakeLogger : ILogger
    {
        public void Error(Exception ex, string additionalInfo = null)
        {
            Trace.TraceError($"{additionalInfo ?? "Exception info"}:{Environment.NewLine}{ex}");
        }
    }
}
