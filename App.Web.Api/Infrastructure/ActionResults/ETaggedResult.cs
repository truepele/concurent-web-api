using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace App.Web.Api.Infrastructure.ActionResults
{
    public class ETaggedResult : IHttpActionResult
    {
        private readonly IHttpActionResult _actionResult;
        private readonly string _eTag;
        private readonly bool _isWeak;

        public ETaggedResult(IHttpActionResult actionResult, string eTag, bool isWeak = false)
        {
            _eTag = eTag;
            _isWeak = isWeak;
            _actionResult = actionResult;
        }


        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await _actionResult.ExecuteAsync(cancellationToken);
            response.Headers.ETag = new EntityTagHeaderValue($"\"{_eTag}\"", _isWeak);
            return response;
        }
    }
}