using Client.Tokens;
using System.Threading.Tasks;

namespace Client.Api
{
    public interface IApiCaller
    {
        Task CallApiWithTokenAsync(ITokenGetter tokenGetter);
    }
}
