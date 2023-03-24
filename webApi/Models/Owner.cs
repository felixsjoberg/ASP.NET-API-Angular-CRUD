namespace webApi.Models;
public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; }

}