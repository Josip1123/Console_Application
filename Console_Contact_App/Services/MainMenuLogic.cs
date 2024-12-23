

namespace Console_Contact_App.Services;

public class MainMenuLogic
{
    private bool _isSelected;
    
    public void GetUserInput()
    {
        var userInput = Console.ReadLine()!.Trim().ToLower();
        

        while (!_isSelected)
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
                        _isSelected = true;
                        DataHandling.GetFileInitially("Users.txt");
                        var userRegistration = new UserRegistration();
                        userRegistration.Register();
                        break;
                    case "2" :
                        Console.WriteLine("Showing All Contacts...");
                        DataHandling.GetUsersFromFile("Users.txt");
                        DataHandling.ShowAllUsers();
                        _isSelected = true;
                        break;
                    case "3" :
                        Console.WriteLine("Exiting the program...");
                        _isSelected = true;
                        Console.ReadKey();
                        Environment.Exit(0);
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