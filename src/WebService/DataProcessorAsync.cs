using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integrator.WebService
{
  class DataProcessorAsync
  {
    public async Task<List<Sale>> ProcessAsync(List<Sale> saleList)
    {
      var resultList = new List<Sale>();

      var GroupeList = saleList.GroupBy(x => new { x.data_venda, x.vendedor_cpf });

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

        resultList.Add(sale);
      }

      await Task.Delay(0);
      return resultList;
    }
  }
}