using System;

namespace YellowNotes.Api.Interfaces
{
    public interface ILogger
    {
        void Error(Exception ex, string additionalInfo = null);
    }
}