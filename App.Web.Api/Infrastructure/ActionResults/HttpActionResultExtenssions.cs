using System.Web.Http;

namespace App.Web.Api.Infrastructure.ActionResults
{
    public static class HttpActionResultExtenssions
    {
        public static ETaggedResult ETagged<T>(this T actionResult, string eTag, bool isWeak = false)
            where T : IHttpActionResult
        {
            return new ETaggedResult(actionResult, eTag, isWeak);
        }
    }
}