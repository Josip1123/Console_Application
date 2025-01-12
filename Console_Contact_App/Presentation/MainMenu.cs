namespace Console_Contact_App.Presentation;

public static class MainMenu
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("_____MENU_____");
        Console.WriteLine("1. Add Contact");
        Console.WriteLine("2. Show All Contacts");
        Console.WriteLine("3. Delete User");
        Console.WriteLine("4. Edit User");
        Console.WriteLine("5. Clear Console");
        Console.WriteLine("6. Exit");
        Console.Write("Type in a number of the menu item you'd like to access: ");
    }
}