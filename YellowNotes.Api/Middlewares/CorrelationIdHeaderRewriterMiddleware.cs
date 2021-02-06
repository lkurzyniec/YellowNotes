using System.Threading.Tasks;
using System.Linq;
using Microsoft.Owin;
using Owin;

namespace YellowNotes.Api.Middlewares
{
    public class CorrelationIdHeaderRewriterMiddleware : OwinMiddleware
    {
        public CorrelationIdHeaderRewriterMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            if (context.Request.Headers.TryGetValue("x-correlation-id", out var values) && !context.Response.Headers.ContainsKey("x-correlation-id"))
            {
                context.Response.Headers.Add("x-correlation-id", new[] { values.First() });
            }
            return Next.Invoke(context);
        }
    }

    public static class CorrelationIdHeaderRewriterMiddlewareExtensions
    {
        public static IAppBuilder UseCorrelationIdHeaderRewriterMiddleware(this IAppBuilder builder)
        {
            return builder.Use<CorrelationIdHeaderRewriterMiddleware>();
        }
    }
}
