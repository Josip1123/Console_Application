using Console_Contact_App.Factories;
using Console_Contact_App.Models;

namespace Console_Contact_App.Services;

public class UserRegistration
{
    public UserEntity? Register()
    {
        var isDoneRegistering = false;
        UserEntity? userEntity = null;

        while (!isDoneRegistering)
        {
            var registrationForm = UserFactory.Create();

            Console.WriteLine("Type in your name");
            registrationForm.Name = Validators.ValidateInput("name");

            Console.WriteLine("Type in your surname");
            registrationForm.Surname = Validators.ValidateInput("last name");

            Console.WriteLine("Type your email");
            registrationForm.Email = Validators.ValidateInput("email");

            Console.WriteLine("Type in your password:");
            registrationForm.Password = Validators.ValidateInput("password");

            Console.WriteLine("Please confirm your password: ");
            registrationForm.ConfirmedPassword =
                Validators.IsSame(registrationForm.Password, "Passwords do not match!");

            Console.WriteLine("Your Phone number");
            registrationForm.Phone = Console.ReadLine();

            Console.WriteLine("Your address");
            registrationForm.Address = Console.ReadLine();

            userEntity = UserFactory.Create(registrationForm);
            isDoneRegistering = true;
        }

        return userEntity;
    }
}