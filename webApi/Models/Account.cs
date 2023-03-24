namespace webApi.Models;

public class Account
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public string AccountType { get; set; } = null!;
    public int? OwnerId { get; set; }

}
