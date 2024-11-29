using System.Diagnostics;

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
                    case "add" :
                        Console.WriteLine("You have chosen add");
                        isSelected = true;
                        break;
                    case "show" :
                        Console.WriteLine("You have chosen show");
                        isSelected = true;
                        break;
                    case "delete" :
                        Console.WriteLine("You have chosen delete");
                        isSelected = true;
                        break;
                    case "edit" :
                        Console.WriteLine("You have chosen edit");
                        isSelected = true;
                        break;
                    case "exit" :
                        Console.WriteLine("You have chosen exit");
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