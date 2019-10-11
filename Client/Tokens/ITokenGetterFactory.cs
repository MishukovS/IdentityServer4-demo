namespace Client.Tokens
{
    public interface ITokenGetterFactory
    {
        ITokenGetter GetInstanse(TokenType type);
    }
}
