
namespace Console_Contact_App.Services;

public class MainMenuLogic
{
    public void GetUserInput()
    {
        var userInput = Console.ReadLine()!.Trim().ToLower();
        var isSelected = false;

        while (!isSelected)
        {
            var userRegistration = new UserRegistration();
            
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
                        isSelected = true;
                        userRegistration.Run();
                        break;
                    case "2" :
                        Console.WriteLine("You have chosen 2");
                        isSelected = true;
                        break;
                    case "3" :
                        Console.WriteLine("You have chosen 3");
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