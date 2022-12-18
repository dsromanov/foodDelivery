using foodDelivery.Entity.Models;
namespace foodDelivery.Services.Models;
public class RegisterUserModel
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Name { get; set; }
    // public Role Role { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsBlocked { get; set; }
   
}