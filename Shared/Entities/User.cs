namespace PMUKTest.Shared.Entities;

public class User
{
    public int Id { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string Role { get; set; } = "User";
}
