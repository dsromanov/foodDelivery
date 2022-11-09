namespace foodDelivery.Entity.Models;

public class Facility : BaseEntity
{
    public string Name { get; set; }
    public int Rating { get; set; }

    public Guid CityId { get; set; }
    public virtual City City { get; set; }

    public Guid TypeId { get; set; }
    public virtual Types Type { get; set; }

    public virtual ICollection<FacilityToUser> FacilityToUsers { get; set; }

    
}