namespace foodDelivery.Services.Models;

public class FacilityToUserPreviewModel
{
    public int MarkFromUser { get; set; }
    public bool IsFavourite { get; set; }
    public Guid UserId { get; set; }
    public Guid FacilityId { get; set; }
}