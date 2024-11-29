using Console_Contact_App.Services;
namespace Console_Contact_App.Presentation;

public class MainMenu
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("1. Add Contact");
        Console.WriteLine("2. Show All Contacts");
        Console.WriteLine("3. Delete Contact");
        Console.WriteLine("4. Edit Contact");
        Console.WriteLine("5. Exit");
        Console.Write("Type in a number or name of menu item you'd like to access: ");

        MainMenuLogic.GetUserInput();
    }
}