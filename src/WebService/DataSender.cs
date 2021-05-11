using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Integrator.WebService
{
    class DataSender
    {
        public async Task<HttpResponseMessage> Send(List<Sale> list)
        {
            using (var client = new HttpClient())
            {
                var content = JsonContent.Create(list);
                return await client.PostAsync("http://localhost:4567/receive", content);
            }
        }
    }
}