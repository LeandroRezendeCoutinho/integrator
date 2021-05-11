using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Integrator.WebService
{
    class DataFetcher
    {
        public List<Sale> FetchData()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:4567/data").Result;
                var stream = response.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<List<Sale>>(stream);
            }
        }
    }
}
