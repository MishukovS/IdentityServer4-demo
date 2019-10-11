using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;


namespace Client.Api
{
    public class DiscoveryService : IDiscoveryService
    {
        private readonly HttpClient client;       
        private DiscoveryResponse cache;

        private const string ID_URL = "http://localhost:5000";

        public DiscoveryService()
        {
            client = new HttpClient();
        }

        public async Task<DiscoveryResponse> GetAsync()
        {
            if (cache != null)
            {
                return await Task.FromResult(cache);
            }

            var disco = await client.GetDiscoveryDocumentAsync(ID_URL);
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                throw new Exception("Error in discovery");
            }

            cache = disco;

            return disco;            
        }
    }
}
