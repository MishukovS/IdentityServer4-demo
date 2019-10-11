using IdentityModel.Client;
using System.Threading.Tasks;

namespace Client.Api
{
    public interface IDiscoveryService
    {
        Task<DiscoveryResponse> GetAsync();
    }
}
