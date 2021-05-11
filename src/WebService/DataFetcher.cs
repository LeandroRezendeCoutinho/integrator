using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Integrator.WebService
{
    class DataFetcher
    {
        public async System.Threading.Tasks.Task<List<Sale>> FetchDataAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:4567/data");
                var stream = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Sale>>(stream);
            }
        }
    }
}
