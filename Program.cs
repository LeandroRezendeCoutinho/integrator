using System;
using Integrator.WebService;

namespace Integrator
{
  class Program
  {
    static void Main(string[] args)
    {
      var dataFetcher = new DataFetcher();
      dataFetcher.FetchData();
    }
  }
}
