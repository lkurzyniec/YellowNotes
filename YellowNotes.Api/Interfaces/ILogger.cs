using System;

namespace YellowNotes.Api.Interfaces
{
    internal interface ILogger
    {
        void Error(Exception ex, string additionalInfo = null);
    }
}