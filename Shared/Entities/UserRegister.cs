namespace PMUKTest.Shared.Entities;

public class UserRegister
{
    [Required, EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;
    [Required, StringLength(100), MinLength(6)]
    public string Password { get; set; } = string.Empty;
    [Compare("Password", ErrorMessage = "The passwords do not match!")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
