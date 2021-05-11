using System;
using System.Threading.Tasks;
using Integrator.WebService;

namespace Integrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 0; i < 100_000; i++)
            {
                await ProcessAsync(i);
            }
        }

        private static async Task ProcessAsync(int number)
        {
            var dataFetcher = new DataFetcher();
            var dataProcessor = new DataProcessor();
            var sender = new DataSender();
            var saleList = await dataFetcher.FetchDataAsync();
            var computedLIst = dataProcessor.Process(saleList);
            var result = await sender.Send(computedLIst);
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Integration " + number);
            }
        }
    }
}
