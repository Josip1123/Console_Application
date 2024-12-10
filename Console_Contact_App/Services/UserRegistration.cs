using Console_Contact_App.Factories;

namespace Console_Contact_App.Services;

public class UserRegistration
{
    public void Run()
    {
        var registrationForm = UserFactory.Create();
        var userRegistration = new UserRegistration();
        Console.WriteLine("Type in your name");
        registrationForm.Name = userRegistration.ValidateInput("name");
        Console.WriteLine("Type in your surname");
        registrationForm.Surname = userRegistration.ValidateInput("surname");
        Console.WriteLine("Type your email");
        registrationForm.Email = userRegistration.ValidateInput("e-mail");
        Console.WriteLine("Type in your password:");
        registrationForm.Password = Console.ReadLine()!;
        Console.WriteLine("Please confirm your password: ");
        registrationForm.ConfirmedPassword = Console.ReadLine()!;
        Console.WriteLine("Your Phone number");
        registrationForm.Phone = Console.ReadLine();
        Console.WriteLine("Your adress");
        registrationForm.Address = Console.ReadLine();

        var entityTest = UserFactory.Create(registrationForm);
        Console.Write($"{entityTest.UserId}, {entityTest.Name}, {entityTest.Surname}, {entityTest.Email}, {entityTest.Password}, {entityTest.Phone}, {entityTest.Address}");
    }

    private string ValidateInput(string field)
    {
        string input;
        do
        {
            input = Console.ReadLine()!.Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"INVALID FORMAT: Please type in your {field}");
            }
        } while (string.IsNullOrEmpty(input));

        return input;
    }
}