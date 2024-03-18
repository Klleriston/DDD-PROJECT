using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace WebApplication.Token
{
    public class JWTSecurity
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
