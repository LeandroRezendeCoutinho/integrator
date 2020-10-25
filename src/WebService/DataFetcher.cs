using RestSharp;
using System.Text.Json;
using System.Collections.Generic;

namespace Integrator.WebService
{
  class DataFetcher
  {
    public List<Sale> FetchData()
    {
      var client = new RestClient("http://localhost:4567");
      var request = new RestRequest("data", DataFormat.Json);
      var response = client.Get(request);

      return DeserializeRequest(response);
    }

    private List<Sale> DeserializeRequest(IRestResponse response)
    {
      return JsonSerializer.Deserialize<List<Sale>>(response.Content);
    }
  }
}
