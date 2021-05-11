using System;
using System.Threading.Tasks;
using Integrator.WebService;
using Integrator.WebService.Async;

namespace Integrator
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     for (int i = 0; i < 100_000; i++)
        //     {
        //         Process(i);
        //         Console.WriteLine("Integration " + i);
        //     }
        //     Console.WriteLine("Terminado ");

        // }

        // private static void Process(int number)
        // {
        //     var fetcher = new DataFetcher();
        //     var processor = new DataProcessor();
        //     var sender = new DataSender();
        //     var saleList = fetcher.FetchData();
        //     var computedLIst = processor.Process(saleList);
        //     var result = await sender.Send(computedLIst);
        // }

        static async Task Main(string[] args)
        {
            for (int i = 0; i < 100_000; i++)
            {
                await ProcessAsync(i);
            }
            await Task.Delay(0);
        }

        private static async Task ProcessAsync(int number)
        {
            var dataFetcher = new DataFetcherAsync();
            var dataProcessor = new DataProcessorAsync();
            var sender = new DataSender();
            var saleList = await dataFetcher.FetchDataAsync();
            var computedLIst = await dataProcessor.ProcessAsync(saleList);
            var result = await sender.Send(computedLIst);
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Integration " + number);
            }
        }
    }
}
