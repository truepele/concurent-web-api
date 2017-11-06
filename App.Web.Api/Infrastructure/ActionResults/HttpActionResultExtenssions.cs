using System.Web.Http;
using App.Web.Api.Infrastructure.ActionResults;

namespace App.Web.Api.Infrastructure.ETag
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