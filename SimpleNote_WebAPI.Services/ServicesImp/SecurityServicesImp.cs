


using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace SimpleNote_WebAPI.Services.ServicesImp
{
    public class SecurityServicesImp : ISecurityServices
    {
        protected readonly IGenericServices<UsersDto, UsersEntity> genericServices;
        private IConfiguration _config;
        public SecurityServicesImp(IGenericServices<UsersDto, UsersEntity> _genericServices, IConfiguration config)
        {
            _config = config;
            genericServices = _genericServices;
        }
        public UsersDto Authenticate(UserLoginDto userLogin)
        {
            var users =  genericServices.GetAll();

            var currentUser = (from user in users
                              where user.UserName == userLogin.UserName && user.Password == userLogin.Password
                              select user).FirstOrDefault();
            return currentUser;
        }
        public string GenerateToken(UsersDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //claims is way to store some data about the user

            var claims = new[]
            {
                new Claim("id",user.User_Id.ToString()), // grapping that id so i can know which user is has access to the current token 
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.GivenName,user.UserName),

            };

            //define the token objects , Generate the token
            var token = new JwtSecurityToken( // what the api will validate 
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

    }
}
