namespace foodDelivery.WebAPI.Models;

public class CreateFacilityRequest: UpdateFacilityRequest
{    public Guid CityId { get; set; }
    public Guid TypeId { get; set; }
    
}