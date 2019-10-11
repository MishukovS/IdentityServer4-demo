using Client.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Api
{
    public class ApiCaller : IApiCaller
    {        
        private const string API_URL = "http://localhost:5001/identity"; 

        public async Task CallApiWithTokenAsync(ITokenGetter tokenGetter)
        {
            var tokenResponse = await tokenGetter.GetTokenAsync();

            if (tokenResponse == null)
            {
                return;
            }

            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync(API_URL);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }  
        }
    }
}
