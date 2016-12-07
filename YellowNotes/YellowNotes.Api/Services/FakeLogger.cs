using System;
using System.Diagnostics;
using YellowNotes.Api.Interfaces;

namespace YellowNotes.Api.Services
{
    public class FakeLogger : ILogger
    {
        public void Error(Exception ex, string additionalInfo = null)
        {
            Trace.TraceError($"{additionalInfo ?? "Exception info"}:{Environment.NewLine}{ex}");
        }
    }
}