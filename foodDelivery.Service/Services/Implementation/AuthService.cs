using AutoMapper;
using foodDelivery.Entity.Models;
using foodDelivery.Repository;
using foodDelivery.Services.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using foodDelivery.Services.Abstract;
using foodDelivery.Shared.Exceptions;
using foodDelivery.Shared.ResultCodes;

namespace foodDelivery.Services.Implementation;

public class AuthService : IAuthService
{
    #region Fields
    private readonly IRepository<User> usersRepository;
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IMapper mapper;
    private readonly string identityUri;

    #endregion
    public AuthService(
        IRepository<User> usersRepository, UserManager<User> userManager, SignInManager<User> signInManager,
        IMapper mapper, IConfiguration configuration)
    {
        this.usersRepository = usersRepository;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.mapper = mapper;
       // this.configuration = configuration;
        identityUri = configuration.GetValue<string>("IdentityServer:Uri");
    }
    public async Task<UserModel> RegisterUser(RegisterUserModel model)
    {
        var existingUser = usersRepository.GetAll()
         .Where(x => x.Email.ToLower() == model.Email.ToLower())
        .FirstOrDefault();
        if (existingUser != null)
        {
            throw new LogicException(ResultCode.USER_ALREADY_EXISTS);
        }

        var user = new User()
        {
            Email = model.Email,
            UserName = model.Email, // обязательно
            Name = model.Name ?? "",
            Surname =model.Surname,
            BirthDate=model.BirthDate,
            IsBlocked=model.IsBlocked,
           
            EmailConfirmed = true //to make it easier
        };

        var result = await userManager.CreateAsync(user, model.PasswordHash);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        var createdUser = usersRepository.GetAll()
        .Where(x => x.Email.ToLower() == model.Email.ToLower())
        .FirstOrDefault();

        return mapper.Map<UserModel>(createdUser);
    }

    public async Task<IdentityModel.Client.TokenResponse> LoginUser(LoginUserModel model)
    {
        var user = usersRepository.GetAll()
        .Where(x => x.Email.ToLower() == model.Email.ToLower())
        .FirstOrDefault();
        if (user == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, model.PasswordHash, false);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.EMAIL_OR_PASSWORD_IS_INCORRECT);
        }

        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(identityUri);
        if (disco.IsError)
        {
            throw new Exception(disco.Error);
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = model.ClientId,
            ClientSecret = model.ClientSecret,
            UserName = model.Email,
            Password = model.PasswordHash,
            Scope = "api offline_access"
        });

        if (tokenResponse.IsError)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        return tokenResponse;
    }
}