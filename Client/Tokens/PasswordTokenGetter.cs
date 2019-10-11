using System;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Api;
using IdentityModel.Client;

namespace Client.Tokens
{
    public class PasswordTokenGetter : ITokenGetter
    {
        private readonly IDiscoveryService discoveryGetter;

        public PasswordTokenGetter(IDiscoveryService discoveryGetter)
        {
            this.discoveryGetter = discoveryGetter;
        }

        public async Task<TokenResponse> GetTokenAsync()
        {
            // discover endpoints from metadata
            var client = new HttpClient();

            var disco = await discoveryGetter.GetAsync();

            // request token
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "ro.client",
                ClientSecret = "secret",

                UserName = "alice",
                Password = "password",
                Scope = "api1"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return null;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            return tokenResponse;
        }
    }
}
