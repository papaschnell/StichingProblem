using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    class Program
    {
        private const string StichingService = "http://localhost:3001/graphql";
        private const string GraphQLService = "http://localhost:3000/graphql";
        
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDefaultScalarSerializers();
            serviceCollection.AddtestClient();
            serviceCollection.AddHttpClient("TestClient").ConfigureHttpClient(client =>
                client.BaseAddress = new Uri(GraphQLService));
            
            IServiceProvider services = serviceCollection.BuildServiceProvider();
            ITestClient client = services.GetRequiredService<ITestClient>();
            
            int t = 0;
            
            int numberOfCalls = 30;

            while (t < numberOfCalls)
            {
                // Default very high timeout (don't cancel)
                int cancelAfter = 30000;
                
                // Every second call should cancel faster then request takes to process
                if (t % 2 == 0)
                {
                    cancelAfter = 50;
                }
                
                var token = new CancellationTokenSource(cancelAfter).Token;

                try
                {
                    var result = await client.GetValuesAsync(token);
                            
                    // Expect this result everytime
                    var data = $"{result.Data?.Data?.Value1}{result.Data?.Data?.Value2}{result.Data?.Data?.Value3}";
                            
                    if (data != "Value1Value2Value3")
                    {
                        Console.WriteLine("DATA IS WRONG : " + data);
                    }
                    else
                    {
                        Console.WriteLine("Data is ok");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Operation canceled");
                }
                
                t++;
            }
            Console.WriteLine("Done");
        }
    }
}