using Client.Api;
using System;

namespace Client.Tokens
{
    public class TokenGetterFactory : ITokenGetterFactory
    {
        private readonly IDiscoveryService discoveryGetter;

        public TokenGetterFactory(IDiscoveryService discoveryGetter)
        {
            this.discoveryGetter = discoveryGetter;
        }

        public ITokenGetter GetInstanse(TokenType type)
        {
            switch (type)
            {
                case TokenType.ClientCredentials:
                    return new ClientCredentialsTokenGetter(discoveryGetter);
                case TokenType.PasswordToken:
                    return new PasswordTokenGetter(discoveryGetter);
                default:
                    throw new Exception("Unknow token type");
            }
        }
    }
}
