namespace foodDelivery.WebAPI.Models;

public class UserResponse
{
    public Guid Id{get; set;}
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsBlocked { get; set; }
    public Guid CityId { get; set; }
}