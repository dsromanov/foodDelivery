using foodDelivery.Services.Models;
namespace foodDelivery.Services.Abstract;

public interface ITypesService
{
TypesModel GetTypes(Guid id);

TypesModel UpdateTypes(Guid id, UpdateTypesModel TypesModel);

void DeleteTypes(Guid id);

PageModel<TypesPreviewModel> GetTypess(int limit = 20, int offset = 0);
TypesModel CreateTypes(TypesModel TypesModel);
}