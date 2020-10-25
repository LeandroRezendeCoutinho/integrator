using System;
using System.Linq;
using RestSharp;
using System.Text.Json;
using System.Collections.Generic;

namespace Integrator.WebService
{
  class DataFetcher
  {
    public void FetchData()
    {
      var client = new RestClient("http://localhost:4567");
      var request = new RestRequest("data", DataFormat.Json);
      var response = client.Get(request);
      DeserializeRequest(response);
    }

    private void DeserializeRequest(IRestResponse response)
    {
      var SaleList = JsonSerializer.Deserialize<List<Sale>>(response.Content);
      var computedList = new List<Sale>();
      var GroupeList = SaleList.GroupBy(x => new { x.data_venda, x.vendedor_cpf });
      foreach (var groupItem in GroupeList)
      {
        var sale = new Sale()
        {
          data_venda = groupItem.First().data_venda,
          loja_cnpj = groupItem.First().loja_cnpj,
          vendedor_cpf = groupItem.First().vendedor_cpf,
          vendedor_id = groupItem.First().vendedor_id,
          valor_vendas = groupItem.Sum(x => x.valor_vendas),
          quantidade_pecas = groupItem.Sum(x => x.quantidade_pecas),
          quantidade_vendas = groupItem.Sum(x => x.quantidade_vendas)
        };
        computedList.Add(sale);
      }
      Console.WriteLine(computedListSale);
    }
  }
}
