namespace foodDelivery.Services.Models;

public class TypesModel : BaseModel
{
    public Guid Id{get; set;}
    public string TypeOfFacility { get; set; }
    public string TypeOfFood { get; set; }

}