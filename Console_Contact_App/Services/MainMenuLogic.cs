
using Console_Contact_App.Factories;


namespace Console_Contact_App.Services;

public class MainMenuLogic
{
    public static void GetUserInput()
    {
        var userInput = Console.ReadLine()!.Trim().ToLower();
        var isSelected = false;

        while (!isSelected)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("INVALID FORMAT: Type in number or name of the menu option");
                userInput = Console.ReadLine();
            }
            else
            {
                switch (userInput)
                {
                    case "1" :
                        Console.WriteLine("You have chosen 1");
                        isSelected = true;
                        var registrationForm = UserFactory.Create();
                        Console.WriteLine("Type in your name");
                        registrationForm.Name = Console.ReadLine()!;
                        Console.WriteLine("Type in your surname");
                        registrationForm.Surname = Console.ReadLine()!;
                        Console.WriteLine("Type your email");
                        registrationForm.Email = Console.ReadLine()!;
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
                        break;
                    case "2" :
                        Console.WriteLine("You have chosen 2");
                        isSelected = true;
                        break;
                    case "3" :
                        Console.WriteLine("You have chosen 3");
                        isSelected = true;
                        break;
                    case "4" :
                        Console.WriteLine("You have chosen 4");
                        isSelected = true;
                        break;
                    case "5" :
                        Console.WriteLine("You have chosen 5");
                        isSelected = true;
                        break;
                    default:
                        Console.WriteLine("Error, not a valid option, try again");
                        userInput = Console.ReadLine();
                        break;
                }

            }
        }
    }
}