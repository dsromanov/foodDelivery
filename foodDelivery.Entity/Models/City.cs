namespace foodDelivery.Entity.Models;

public class City : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Facility> Facilities { get; set; }
    
}