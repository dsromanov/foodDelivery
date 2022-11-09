namespace foodDelivery.Entity.Models;

public class FacilityToUser : BaseEntity
{
    public int MarkFromUser { get; set; }
    public bool IsFavourite { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public Guid FacilityId { get; set; }
    public virtual Facility Facility { get; set; }
}