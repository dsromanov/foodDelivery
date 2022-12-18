using AutoMapper;
using foodDelivery.Entity.Models;
using foodDelivery.Repository;
using foodDelivery.Services.Abstract;
using foodDelivery.Services.Models;

namespace foodDelivery.Services.Implementation;

public class TypesService :ITypesService
{
private readonly IRepository<Types> TypesRepository;
private readonly IMapper mapper;
public TypesService(IRepository<Types> TypesRepository, IMapper mapper)
{
this.TypesRepository=TypesRepository;
this.mapper = mapper;
}

public void DeleteTypes(Guid id)
{
var TypesToDelete =TypesRepository.GetById(id);
if (TypesToDelete == null)
{
throw new Exception("Types not found");
}
TypesRepository.Delete(TypesToDelete);
}

public TypesModel GetTypes(Guid id)
{
var Types =TypesRepository.GetById(id);
return mapper.Map<TypesModel>(Types);
}

public PageModel<TypesPreviewModel> GetTypess(int limit = 20, int offset = 0)
{
var Types =TypesRepository.GetAll();
int totalCount =Types.Count();
var chunk=Types.OrderBy(x=>x.TypeOfFacility).Skip(offset).Take(limit);

return new PageModel<TypesPreviewModel>()
{
Items = mapper.Map<IEnumerable<TypesPreviewModel>>(Types),
TotalCount = totalCount
};
}

public TypesModel UpdateTypes(Guid id, UpdateTypesModel Types)
{
var existingTypes = TypesRepository.GetById(id);
if (existingTypes == null)
{
throw new Exception("Types not found");
}
existingTypes.TypeOfFacility=Types.TypeOfFacility;
existingTypes.TypeOfFood=Types.TypeOfFood;
existingTypes = TypesRepository.Save(existingTypes);
return mapper.Map<TypesModel>(existingTypes);
}
TypesModel ITypesService.CreateTypes(TypesModel TypesModel)
{
TypesRepository.Save(mapper.Map<Entity.Models.Types>(TypesModel));
return TypesModel;
}
}