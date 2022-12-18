using AutoMapper;
using foodDelivery.Entity.Models;
using foodDelivery.Repository;
using foodDelivery.Services.Abstract;
using foodDelivery.Services.Models;

namespace foodDelivery.Services.Implementation;

public class FacilityToUserService :IFacilityToUserService
{
private readonly IRepository<FacilityToUser> FacilityToUserRepository;
private readonly IMapper mapper;
public FacilityToUserService(IRepository<FacilityToUser> FacilityToUserRepository, IMapper mapper)
{
this.FacilityToUserRepository=FacilityToUserRepository;
this.mapper = mapper;
}

public void DeleteFacilityToUser(Guid id)
{
var FacilityToUserToDelete =FacilityToUserRepository.GetById(id);
if (FacilityToUserToDelete == null)
{
throw new Exception("FacilityToUser not found");
}
FacilityToUserRepository.Delete(FacilityToUserToDelete);
}

public FacilityToUserModel GetFacilityToUser(Guid id)
{
var FacilityToUser =FacilityToUserRepository.GetById(id);
return mapper.Map<FacilityToUserModel>(FacilityToUser);
}

public PageModel<FacilityToUserPreviewModel> GetFacilityToUsers(int limit = 20, int offset = 0)
{
var FacilityToUser =FacilityToUserRepository.GetAll();
int totalCount =FacilityToUser.Count();
var chunk=FacilityToUser.OrderBy(x=>x.IsFavourite).Skip(offset).Take(limit);

return new PageModel<FacilityToUserPreviewModel>()
{
Items = mapper.Map<IEnumerable<FacilityToUserPreviewModel>>(FacilityToUser),
TotalCount = totalCount
};
}

public FacilityToUserModel UpdateFacilityToUser(Guid id, UpdateFacilityToUserModel FacilityToUser)
{
var existingFacilityToUser = FacilityToUserRepository.GetById(id);
if (existingFacilityToUser == null)
{
throw new Exception("FacilityToUser not found");
}
existingFacilityToUser.IsFavourite=FacilityToUser.IsFavourite;
existingFacilityToUser.MarkFromUser=FacilityToUser.MarkFromUser;
existingFacilityToUser = FacilityToUserRepository.Save(existingFacilityToUser);
return mapper.Map<FacilityToUserModel>(existingFacilityToUser);
}
public FacilityToUserModel CreateFacilityToUser(Guid UserId, Guid FacilityId, FacilityToUserModel facilityToUserModel)
{
if(FacilityToUserRepository.GetAll(x=>x.Id==facilityToUserModel.Id).FirstOrDefault()!=null)
{
throw new Exception ("Attempt to create a non-unique object!");
}

FacilityToUserModel createFacilityToUser = new FacilityToUserModel();
createFacilityToUser.UserId=facilityToUserModel.UserId;
createFacilityToUser.FacilityId=facilityToUserModel.FacilityId;
createFacilityToUser.IsFavourite=facilityToUserModel.IsFavourite;
createFacilityToUser.MarkFromUser=facilityToUserModel.MarkFromUser;
FacilityToUserRepository.Save(mapper.Map<FacilityToUser>(createFacilityToUser));
return createFacilityToUser;

}
}