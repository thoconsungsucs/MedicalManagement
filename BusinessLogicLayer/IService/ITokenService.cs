namespace BusinessLogicLayer.IService
{
    public interface ITokenService
    {
        string GenerateToken(string email);
    }
}
