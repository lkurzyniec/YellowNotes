using System.Web.Http.Filters;
using YellowNotes.Api.Controllers;

namespace YellowNotes.Api.Attributes
{
    internal class RequestExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionContext)
        {
            string message =
                $"[{actionContext.Request.Method}] {actionContext.Request.RequestUri}";

            var baseApiController = actionContext.ActionContext.ControllerContext.Controller as NotesControllerBase;
            baseApiController?.Logger.Error(actionContext.Exception, message);

            base.OnException(actionContext);
        }
    }
}