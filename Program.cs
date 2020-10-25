using System;
using Integrator.WebService;

namespace Integrator
{
  class Program
  {
    static void Main(string[] args)
    {
      for (int i = 0; i < 10_000; i++)
      {
        var dataFetcher = new DataFetcher();
        var dataProcessor = new DataProcessor();
        var saleList = dataFetcher.FetchData();
        var computedLIst = dataProcessor.Process(saleList);
        Console.WriteLine("Integration " + i);
      }
    }
  }
}
