using System;

namespace Integrator.WebService
{
  class Sale
  {
    public string data_venda { get; set; }
    public Decimal valor_vendas { get; set; }
    public int quantidade_vendas { get; set; }
    public int quantidade_pecas { get; set; }
    public string loja_cnpj { get; set; }
    public string vendedor_cpf { get; set; }
    public string vendedor_id { get; set; }
  }
}
