using System;
using System.Threading.Tasks;
using Integrator.WebService;

namespace Integrator
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     for (int i = 0; i < 50_000; i++)
        //     {
        //         Process(i);
        //         Console.WriteLine("Integration " + i);
        //     }
        // }
        
        static async Task Main(string[] args)
        {
            for (int i = 0; i < 50_000; i++)
            {
                await ProcessAsync(i);
                Console.WriteLine("Integration " + i);
            }
            await Task.Delay(0);
        }
        
        private static void Process(int number)
        {
            var dataFetcher = new DataFetcher();
            var dataProcessor = new DataProcessor();
            var saleList = dataFetcher.FetchData();
            var computedLIst = dataProcessor.Process(saleList);
        }

        private static async Task ProcessAsync(int number)
        {
            var dataFetcher = new DataFetcherAsync();
            var dataProcessor = new DataProcessorAsync();
            var saleList = await dataFetcher.FetchDataAsync();
            var computedLIst = await dataProcessor.ProcessAsync(saleList);
        }
    }
}
