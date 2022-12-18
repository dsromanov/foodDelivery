using foodDelivery.Services.Models;
namespace foodDelivery.Services.Abstract;

public interface IFacilityToUserService
{
FacilityToUserModel GetFacilityToUser(Guid id);

FacilityToUserModel UpdateFacilityToUser(Guid id, UpdateFacilityToUserModel FacilityToUserModel);

void DeleteFacilityToUser(Guid id);

PageModel<FacilityToUserPreviewModel> GetFacilityToUsers(int limit = 20, int offset = 0);
FacilityToUserModel CreateFacilityToUser(Guid UserId, Guid FacilityId, FacilityToUserModel facilityToUserModel);
}