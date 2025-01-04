using System.ComponentModel.DataAnnotations;

namespace UserLibrary.Models;

public class RegistrationForm
{
    public string? Name { get; set; }

    public string? Surname { get; set; }
    
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    public string? ConfirmedPassword { get; set; }
    
    public string? Phone { get; set; }
    
    public string? Address { get; set; }
    
    

}