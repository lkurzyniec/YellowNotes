using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace YellowNotes.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    internal class SimpleAuthorizeAttribute : AuthorizeAttribute
    {
        public string Devices { get; set; } = string.Empty;

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                "CUSTOM: Authorization has been denied for this request");
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var baseIsAuthorized = base.IsAuthorized(actionContext);
            if (!baseIsAuthorized)
            {
                return false;
            }

            var simpleAuthorizeAttribute =
                actionContext.ActionDescriptor.GetCustomAttributes<SimpleAuthorizeAttribute>(false).FirstOrDefault() ??
                actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<SimpleAuthorizeAttribute>(true).FirstOrDefault();
            if (simpleAuthorizeAttribute == null)
            {
                return true;
            }

            var allowedDevices = simpleAuthorizeAttribute.Devices.Split(new char[','], StringSplitOptions.RemoveEmptyEntries);
            if (allowedDevices.Length < 1)
            {
                return true;
            }

            var claimsIdentity = actionContext.RequestContext.Principal.Identity as ClaimsIdentity;
            string device = claimsIdentity.FindFirst(ApiConstants.ClaimDevice).Value;
            return allowedDevices.Contains(device);
        }
    }
}