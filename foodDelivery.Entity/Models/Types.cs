namespace foodDelivery.Entity.Models;

public class Types : BaseEntity
{
    public string TypeOfFacility { get; set; }
    public string TypeOfFood { get; set; }
   
    public virtual ICollection<Facility> Facilities { get; set; }

}