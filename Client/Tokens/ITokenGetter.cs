using IdentityModel.Client;
using System.Threading.Tasks;

namespace Client.Tokens
{
    public interface ITokenGetter
    {
        Task<TokenResponse> GetTokenAsync();
    }
}
