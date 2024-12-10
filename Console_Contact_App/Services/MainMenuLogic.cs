
namespace Console_Contact_App.Services;

public static class MainMenuLogic
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
                        isSelected = true;
                        UserRegistration.Run();
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