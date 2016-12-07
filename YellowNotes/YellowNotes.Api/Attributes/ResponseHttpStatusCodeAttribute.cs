using System;
using System.Net;

namespace YellowNotes.Api.Attributes
{
    /// <summary>
    /// Help attribute to generate HTTP Status Codes in documentation
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ResponseHttpStatusCodeAttribute : Attribute
    {
        /// <summary>
        /// HTTP Status Codes
        /// </summary>
        public HttpStatusCode[] HttpStatusCodes { get; set; }

        public ResponseHttpStatusCodeAttribute(params HttpStatusCode[] httpStatusCodes)
        {
            HttpStatusCodes = httpStatusCodes;
        }
    }
}