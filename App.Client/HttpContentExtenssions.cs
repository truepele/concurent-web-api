using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App.Client
{
    public static class HttpContentExtenssions
    {
        public static async Task<T> ReadAsync<T>(this HttpContent content)
        {
            return JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync());
        }
    }
}
