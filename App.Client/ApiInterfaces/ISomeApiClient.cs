using System.Net.Http;
using System.Threading.Tasks;
using App.Web.Api.Contracts;
using Refit;

namespace App.Client.ApiInterfaces
{
    public interface ISomeApiClient
    {
        [Get("/Some/{id}")]
        Task<HttpResponseMessage> Get(int id);

        [Put("/Some/{id}")]
        Task<string> Put(int id, SomeDto entity, [Header("If-Match")] string eTag);
    }
}
