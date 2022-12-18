using foodDelivery.Services.Models;
namespace foodDelivery.Services.Abstract;

public interface IFacilityService
{
FacilityModel GetFacility(Guid id);

FacilityModel UpdateFacility(Guid id, UpdateFacilityModel FacilityModel);

void DeleteFacility(Guid id);

PageModel<FacilityPreviewModel> GetFacilitys(int limit = 20, int offset = 0);
FacilityModel CreateFacility(Guid CityId, Guid TypeId, FacilityModel facilityModel);
}