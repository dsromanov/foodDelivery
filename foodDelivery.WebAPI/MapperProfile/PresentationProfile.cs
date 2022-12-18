using AutoMapper;
using foodDelivery.WebAPI.Models;
using foodDelivery.Services.Models;

namespace foodDelivery.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
public PresentationProfile()
{
#region Pages

CreateMap(typeof(PageModel<>),typeof(PageResponse<>));

#endregion

#region Users

CreateMap<UserModel, UserResponse>().ReverseMap();
CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();
CreateMap<UserPreviewModel, UserPreviewResponse>().ReverseMap();
CreateMap<UserResponse, UserPreviewModel>().ReverseMap();

#endregion

#region City

CreateMap<CityModel, CityResponse>().ReverseMap();
CreateMap<UpdateCityRequest, UpdateCityModel>().ReverseMap();
CreateMap<CityPreviewModel, CityPreviewResponse>().ReverseMap();
CreateMap<CityResponse, CityPreviewModel>().ReverseMap();

#endregion

#region Facility

CreateMap<FacilityModel, FacilityResponse>().ReverseMap();
CreateMap<UpdateFacilityRequest, UpdateFacilityModel>().ReverseMap();
CreateMap<FacilityPreviewModel, FacilityPreviewResponse>().ReverseMap();
CreateMap<FacilityResponse, FacilityPreviewModel>().ReverseMap();

#endregion

#region Types

CreateMap<TypesModel, TypesResponse>().ReverseMap();
CreateMap<UpdateTypesRequest, UpdateTypesModel>().ReverseMap();
CreateMap<TypesPreviewModel, TypesPreviewResponse>().ReverseMap();
CreateMap<TypesResponse, TypesPreviewModel>().ReverseMap();

#endregion

#region FacilityToUser

CreateMap<FacilityToUserModel, FacilityToUserResponse>().ReverseMap();
CreateMap<UpdateFacilityToUserRequest, UpdateFacilityToUserModel>().ReverseMap();
CreateMap<FacilityToUserPreviewModel, FacilityToUserPreviewResponse>().ReverseMap();
CreateMap<FacilityToUserResponse, FacilityToUserPreviewModel>().ReverseMap();

#endregion



#region Admin

CreateMap<AdminModel, AdminResponse>().ReverseMap();
CreateMap<UpdateAdminRequest, UpdateAdminModel>().ReverseMap();
CreateMap<AdminPreviewModel, AdminPreviewResponse>().ReverseMap();
CreateMap<AdminResponse, AdminPreviewModel>().ReverseMap();

#endregion

}
}