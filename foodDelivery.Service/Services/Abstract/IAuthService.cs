using foodDelivery.Services.Models;
using IdentityModel.Client;
namespace foodDelivery.Services.Abstract;
public interface IAuthService
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);
}