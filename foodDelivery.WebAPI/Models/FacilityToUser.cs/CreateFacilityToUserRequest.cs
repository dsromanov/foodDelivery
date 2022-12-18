namespace foodDelivery.WebAPI.Models;

public class CreateFacilityToUserRequest: UpdateFacilityToUserRequest
{
    public Guid UserId { get; set; }
    public Guid FacilityId { get; set; }
}