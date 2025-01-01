using Console_Contact_App.Presentation;
using Console_Contact_App.Services;


namespace Console_Contact_App;

class Program
{
    private static void Main()
    {
        MainMenu.ShowMainMenu();
        var mainMenuLogic = new MainMenuLogic(
            new UserRegistration(),
            new DataHandling()
        );

        mainMenuLogic.GetUserInput();
    }
}