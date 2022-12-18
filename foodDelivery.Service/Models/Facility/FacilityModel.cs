namespace foodDelivery.Services.Models;

public class FacilityModel : BaseModel
{
    public Guid Id{get; set;}
    public string Name { get; set; }
    public int Rating { get; set; }

    public Guid CityId { get; set; }

    public Guid TypeId { get; set; }
    
}