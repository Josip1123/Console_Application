using Console_Contact_App.Models;
using Console_Contact_App.Presentation;

namespace Console_Contact_App.Services;

public class MainMenuLogic(
    UserRegistration userRegistration,
    DataHandling dataHandling
)
{
    private bool _isSelected;

    public void GetUserInput()
    {
        var userInput = Console.ReadLine()!.Trim().ToLower();

        while (!_isSelected)
        {
            switch (userInput)
            {
                case null:
                case "":
                    HandleInvalidInput();
                    break;
                case "1":
                    HandleRegisterUser();
                    break;
                case "2":
                    HandleShowAllUsers();
                    break;
                case "3":
                    HandleExit();
                    break;
                default:
                    Console.WriteLine("Error, not a valid option, try again");
                    userInput = Console.ReadLine();
                    break;
            }
        }
    }

    private void HandleInvalidInput()
    {
        Console.WriteLine("INVALID FORMAT: Type in number or name of the menu option");
        GetUserInput();
    }


    private void HandleRegisterUser()
    {
        _isSelected = true;
        dataHandling.GetFileInitially("Users.txt");
        var userEntity = userRegistration.Register();

        if (userEntity == null) HandleRegisterUser();

        dataHandling.SaveToList(userEntity!);
        dataHandling.SaveUsers("Users.txt");

        Console.WriteLine(
            "Do you want to register more users? Type y for 'yes' or another key to get back to main menu");
        var userDoneInput = Console.ReadLine()!.Trim().ToLower();

        if (userDoneInput == "y") HandleRegisterUser();
    }

    private void HandleShowAllUsers()
    {
        Console.WriteLine("Showing All Contacts...");
        try
        {
            var users = dataHandling.GetUsers("Users.txt");
        }
        catch (NoUserFileException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An error occured while trying to access the users file: {e.Message}");
            Console.ResetColor();
            Console.WriteLine(e);
        }

        dataHandling.ShowAllUsers();
        MainMenu.ShowMainMenu();
        GetUserInput();
        _isSelected = true;
    }

    private void HandleExit()
    {
        Console.WriteLine("Exiting the program...");
        _isSelected = true;
        Console.ReadKey();
        Environment.Exit(0);
    }
}