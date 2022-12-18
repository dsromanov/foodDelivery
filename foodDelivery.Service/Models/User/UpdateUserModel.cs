namespace foodDelivery.Services.Models;

public class UpdateUserModel
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsBlocked { get; set; }
}