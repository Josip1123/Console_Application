using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Console_Contact_App.Models;

public class RegistrationForm
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Surname { get; set; }

    [Required]
    [EmailAddress]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }
    
    [Required]
    [PasswordPropertyText]
    public string? Password { get; set; }
    
    public string? ConfirmedPassword { get; set; }
    
    
    public string? FullName => $"{Name} {Surname}";

}