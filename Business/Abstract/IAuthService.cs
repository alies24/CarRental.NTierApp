using Core.Entities.Concrete;
using Core.Security.JWT;
using Core.Utilities.Results;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IAuthService
    {
        User Register(UserForRegisterDto userForRegisterDto, string password);
        User Login(UserForLoginDto userForLoginDto);
        void UserExists(string email);
        AccessToken CreateAccessToken(User user);
    }
}
