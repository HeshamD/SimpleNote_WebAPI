

namespace SimpleNote_WebAPI.Services.IServices
{
    public interface ISecurityServices
    {
        public string GenerateToken(UsersDto user);
        public UsersDto Authenticate(UserLoginDto userLogin);

    }
}
