using ALTA_BE_BT2.Models;

namespace ALTA_BE_BT2.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}