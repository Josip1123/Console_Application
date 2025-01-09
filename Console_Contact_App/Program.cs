using Console_Contact_App.Presentation;
using Console_Contact_App.Services;
using UserLibrary.Services;

namespace Console_Contact_App;

class Program
{
    private static void Main()
    {
        MainMenu.ShowMainMenu();
        var mainMenuLogic = new MainMenuLogic(new UserService());
        
        var userInput = Console.ReadLine()!.Trim().ToLower();
        mainMenuLogic.GetUserInput(userInput);
    }
}