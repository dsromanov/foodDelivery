using Microsoft.AspNetCore.Identity;
namespace foodDelivery.Entity.Models;

public class User : IdentityUser<Guid>, IBaseEntity
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

    #region BaseEntity

    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }

    #endregion
}


public class UserRole : IdentityRole<Guid>
{ }