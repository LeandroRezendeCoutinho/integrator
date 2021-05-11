using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integrator.WebService.Async
{
    class DataFetcherAsync
    {
        public async Task<List<Sale>> FetchDataAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:4567/data");
            var stream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<List<Sale>>(stream);
        }
    }
}
