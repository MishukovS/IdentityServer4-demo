using Client.Api;
using Client.Tokens;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        private static IServiceProvider serviceProvider;

        private static async Task Main()
        {
            RegisterServices();

            var tokenGetterFactory = serviceProvider.GetService<ITokenGetterFactory>();
            var apiCaller = serviceProvider.GetService<IApiCaller>();

            await apiCaller.CallApiWithTokenAsync(tokenGetterFactory.GetInstanse(TokenType.ClientCredentials));
            await apiCaller.CallApiWithTokenAsync(tokenGetterFactory.GetInstanse(TokenType.PasswordToken));

            Console.ReadLine();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<IDiscoveryService, DiscoveryService>();
            collection.AddSingleton<ITokenGetterFactory, TokenGetterFactory>();
            collection.AddSingleton<IApiCaller, ApiCaller>();

            serviceProvider = collection.BuildServiceProvider();
        }


        private static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable) serviceProvider).Dispose();
            }
        }




    }
}