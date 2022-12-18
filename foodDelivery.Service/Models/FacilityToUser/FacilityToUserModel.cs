namespace foodDelivery.Services.Models;

public class FacilityToUserModel:BaseModel
{
    public int MarkFromUser { get; set; }
    public bool IsFavourite { get; set; }
    public Guid UserId { get; set; }
    public Guid FacilityId { get; set; }
}