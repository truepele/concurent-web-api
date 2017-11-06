using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace App.Web.Api.Infrastructure
{
    public class ETaggedResponseAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response =
                actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, "ETaggedResponseAttribute");
        }
    }
}