using foodDelivery.Services.Abstract;
using foodDelivery.Services.Implementation;
using foodDelivery.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;
namespace foodDelivery.Services;

public static partial class ServicesExtensions
{
public static void AddBusinessLogicConfiguration(this IServiceCollection services)
{
services.AddAutoMapper(typeof(ServicesProfile));
//services
services.AddScoped<IAdminService, AdminService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IFacilityService, FacilityService>();
services.AddScoped<ICityService, CityService>();
services.AddScoped<ITypesService, TypesService>();
services.AddScoped<IFacilityToUserService, FacilityToUserService>();
services.AddScoped<IAuthService, AuthService>();
}
}