using AutoMapper;
using foodDelivery.Entity.Models;
using foodDelivery.Services.Models;

namespace foodDelivery.Services.MapperProfile;

public class ServicesProfile : Profile
{
public ServicesProfile()
{
#region Users


CreateMap<User, UserModel>().ReverseMap();
CreateMap<User, UserPreviewModel>()
.ForMember(x => x.Surname, y => y.MapFrom(u => u.Surname))
.ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
.ForMember(x => x.Email, y => y.MapFrom(u => u.Email))
.ForMember(x => x.BirthDate, y => y.MapFrom(u => u.BirthDate))
.ForMember(x => x.IsBlocked, y => y.MapFrom(u => u.IsBlocked));


#endregion

#region Admin


CreateMap<Admin, AdminModel>().ReverseMap();
CreateMap<Admin, AdminPreviewModel>()
.ForMember(x => x.Login, y => y.MapFrom(u => u.Login));

#endregion

#region Facility

CreateMap<Facility, FacilityModel>().ReverseMap();
CreateMap<Facility, FacilityPreviewModel>()
.ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
.ForMember(x => x.Rating, y => y.MapFrom(u => u.Rating));

#endregion
#region City

CreateMap<City, CityModel>().ReverseMap();
CreateMap<City, CityPreviewModel>()
.ForMember(x => x.Name, y => y.MapFrom(u => u.Name));

#endregion

#region Types

CreateMap<Types, TypesModel>().ReverseMap();
CreateMap<Types, TypesPreviewModel>()
.ForMember(x => x.TypeOfFacility, y => y.MapFrom(u => u.TypeOfFacility))
.ForMember(x => x.TypeOfFood, y => y.MapFrom(u => u.TypeOfFood));


#endregion

#region FacilityToUser

CreateMap<FacilityToUser, FacilityToUserModel>().ReverseMap();
CreateMap<FacilityToUser, FacilityToUserPreviewModel>()
.ForMember(x => x.IsFavourite, y => y.MapFrom(u => u.IsFavourite))
.ForMember(x => x.MarkFromUser, y => y.MapFrom(u => u.MarkFromUser));


#endregion
}
}