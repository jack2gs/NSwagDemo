using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Melon.Net.Http.DependencyInjection;
using Melon.Net.Http.HttpClientConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NSwagClientDemo.Contracts;
using IHttpClientFactory = Melon.Net.Http.IHttpClientFactory;

namespace NSwagClientDemo.Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        { 
            //HttpClient.DefaultProxy = new WebProxy(new Uri("http://localhost:8888"), false);
            ServiceCollection sc = new ServiceCollection();
            sc.AddHttpClientServices()
                .AddHttpClient("NSwagClientDemo", client =>
                    {
                        client.BaseAddress = new Uri("https://localhost:44364/");
                    },
                    configuration => { configuration.HttpRequestMessageHeaders = new Dictionary<string, string>(){{"Bearer", "MyToken"}}; });

            var serviceProvider = sc.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var httpClientFactory = scope.ServiceProvider.GetService<IHttpClientFactory>();
            var weatherForecastClient = httpClientFactory.Create<IWeatherForecastClient>();

            var result = await  weatherForecastClient.GetAsync();
            Console.WriteLine($"Weather: {JsonConvert.SerializeObject(result)}");

            var orderLineClient = httpClientFactory.Create<IOrderLineClient>();
            Console.WriteLine($"Get Order Result: {JsonConvert.SerializeObject( await orderLineClient.GetAsync(100))}");
            var createdOrderLine = await orderLineClient.PostAsync(new OrderLineContract()
            {
                Id = 0,
                OrderId = 10,
                Price = 100.5m,
                ProductId = 2,
                Quantity = 50
            });
            Console.WriteLine($"Post Order Result: {JsonConvert.SerializeObject(createdOrderLine)}");

            var putOrderLine = await orderLineClient.PutAsync(10, new OrderLineContract()
            {
                Id = 0,
                OrderId = 10,
                Price = 100.5m,
                ProductId = 2,
                Quantity = 50
            });
            Console.WriteLine($"Post Order Result: {JsonConvert.SerializeObject(putOrderLine)}");

            Console.ReadKey();
        }
    }
}
