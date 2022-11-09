namespace foodDelivery.Entity.Models;

public class User : BaseEntity
{
    public string PasswordHash { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsBlocked { get; set; }

    public Guid CityId { get; set; }
    public virtual City City { get; set; }

    public virtual ICollection<FacilityToUser> FacilityToUsers { get; set; }

    
}