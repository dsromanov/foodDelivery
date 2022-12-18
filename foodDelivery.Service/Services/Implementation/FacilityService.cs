using AutoMapper;
using foodDelivery.Entity.Models;
using foodDelivery.Repository;
using foodDelivery.Services.Abstract;
using foodDelivery.Services.Models;

namespace foodDelivery.Services.Implementation;

public class FacilityService :IFacilityService
{
private readonly IRepository<Facility> FacilityRepository;
private readonly IMapper mapper;
public FacilityService(IRepository<Facility> FacilityRepository, IMapper mapper)
{
this.FacilityRepository=FacilityRepository;
this.mapper = mapper;
}

public void DeleteFacility(Guid id)
{
var FacilityToDelete =FacilityRepository.GetById(id);
if (FacilityToDelete == null)
{
throw new Exception("Facility not found");
}
FacilityRepository.Delete(FacilityToDelete);
}

public FacilityModel GetFacility(Guid id)
{
var Facility =FacilityRepository.GetById(id);
return mapper.Map<FacilityModel>(Facility);
}

public PageModel<FacilityPreviewModel> GetFacilitys(int limit = 20, int offset = 0)
{
var Facility =FacilityRepository.GetAll();
int totalCount =Facility.Count();
var chunk=Facility.OrderBy(x=>x.Name).Skip(offset).Take(limit);

return new PageModel<FacilityPreviewModel>()
{
Items = mapper.Map<IEnumerable<FacilityPreviewModel>>(Facility),
TotalCount = totalCount
};
}

public FacilityModel UpdateFacility(Guid id, UpdateFacilityModel Facility)
{
var existingFacility = FacilityRepository.GetById(id);
if (existingFacility == null)
{
throw new Exception("Facility not found");
}
existingFacility.Name=Facility.Name;
existingFacility.Rating=Facility.Rating;
existingFacility = FacilityRepository.Save(existingFacility);
return mapper.Map<FacilityModel>(existingFacility);
}
public FacilityModel CreateFacility(Guid CityId, Guid TypeId, FacilityModel facilityModel)
{
if(FacilityRepository.GetAll(x=>x.Id==facilityModel.Id).FirstOrDefault()!=null)
{
throw new Exception ("Attempt to create a non-unique object!");
}

FacilityModel createFacility = new FacilityModel();
createFacility.CityId=facilityModel.CityId;
createFacility.TypeId=facilityModel.TypeId;
createFacility.Name=facilityModel.Name;
createFacility.Rating=facilityModel.Rating;
FacilityRepository.Save(mapper.Map<Facility>(createFacility));
return createFacility;

}
}