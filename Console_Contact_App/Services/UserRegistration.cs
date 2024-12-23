
using Console_Contact_App.Factories;
using Console_Contact_App.Presentation;

namespace Console_Contact_App.Services;

public class UserRegistration
{
    public void Register()
    {
        var isDoneRegistering = false;

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
            registrationForm.ConfirmedPassword = Validators.IsSame(registrationForm.Password, "Passwords do not match!");
        
            Console.WriteLine("Your Phone number");
            registrationForm.Phone = Console.ReadLine();
        
            Console.WriteLine("Your address");
            registrationForm.Address = Console.ReadLine();
        
            var userEntity = UserFactory.Create(registrationForm);
            DataHandling.SaveToList(userEntity);
            DataHandling.SaveUsersToFile("Users.txt");
            
            Console.WriteLine("Do you want to register more users? Type y for 'yes' or another key to get back to main menu");
            var userDoneInput = Console.ReadLine()!.Trim().ToLower();

            if (userDoneInput != "y")
            {
                isDoneRegistering = true;
            }   
        }
        
        MainMenu.ShowMainMenu();
        var userInput = new MainMenuLogic();
        userInput.GetUserInput();
    }
    
}