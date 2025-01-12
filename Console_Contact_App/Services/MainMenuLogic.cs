using Console_Contact_App.Presentation;
using UserLibrary.Factories;
using UserLibrary.Helpers;
using UserLibrary.Interfaces;
using UserLibrary.Models;


namespace Console_Contact_App.Services;

public class MainMenuLogic(IUserService userService)
{
    private bool _isSelected;

    public void GetUserInput(string userInput)
    {
        

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
                case "3" :
                    HandleDeleteUser();
                    break;
                case "4":
                    HandleEdit();
                    break;
                case "5" :
                    HandleClearConsole();
                    break;
                case "6":
                    HandleExit();
                    break;
                default:
                    Console.WriteLine("Error, not a valid option, try again");
                    userInput = Console.ReadLine()!;
                    break;
            }
        }
    }

    private void HandleInvalidInput()
    {
        Console.WriteLine("INVALID FORMAT: Type in number or name of the menu option");
        var userInput = Console.ReadLine()!.Trim().ToLower();
        GetUserInput(userInput);
    }

    private void HandleClearConsole()
    {
        Console.Clear();
        RerunMainMenu();
    }


    private void HandleRegisterUser()
    {
        userService.InitializeUsers("Users.txt");
        var userEntity = userService.Register(GuidCreator.CreateNewId());

        if (userEntity == null) HandleRegisterUser();
        userService.SaveUsers("Users.txt", [userEntity!]);

        Console.WriteLine(
            "Do you want to register more users? Type y for 'yes' or another key to get back to main menu");
        var userDoneInput = Console.ReadLine()!.Trim().ToLower();

        if (userDoneInput == "y")
        {
            _isSelected = true;
            HandleRegisterUser();
        }
        else
        {
            _isSelected = false;
            RerunMainMenu();
        }
    }


    private void HandleShowAllUsers()
    {
        
        try
        {
            var userEntities = userService.GetUsers("Users.txt");
            var users = userEntities.Select(userEntity => UserFactory.Create(userEntity)).ToList();
            if (userEntities.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Showing All Contacts...");
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No Contacts to show...");
            }
            Console.ResetColor();
            
            foreach (var item in users)
            {
                Console.WriteLine(
                    $"{users.IndexOf(item) + 1}. {item.UserId}, {item.FullName}, {item.Email}, {item.Phone}, {item.Address}");
            }
        }
        catch (NoUserFileException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An error occured while trying to access the users file: {e.Message}");
            Console.ResetColor();
            Console.WriteLine(e);
        }

        RerunMainMenu();
    }

    private void HandleDeleteUser()
    {
        var users = userService.GetUsers("Users.txt");
        Console.WriteLine("Enter the ID of the user you want to delete:");
        var userId = Console.ReadLine()!.Trim();

        if (userId.Length < 36 && !Guid.TryParse(userId, out _))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not Valid GUID, try again");
            Console.ResetColor();
            HandleDeleteUser();
        }
        
        bool exists = users.Any(user => user.UserId!.Contains(userId));

        if (!exists)
        {
            Console.WriteLine("No user that matches ID, please provide valid User ID.");
            HandleDeleteUser();
        }
        

        var newList = userService.DeleteUser(userId, users);
        
        userService.RewriteUsers("Users.txt", newList);
        
        RerunMainMenu();
    }

    private void HandleEdit()
    {
        var list = userService.GetUsers("Users.txt");
        Console.WriteLine("Enter the ID of the user you want to edit:");
        var wantToChangeInput = Console.ReadLine()!.Trim();
        
        if (wantToChangeInput.Length < 36 && !Guid.TryParse(wantToChangeInput, out _))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not Valid GUID, try again");
            Console.ResetColor();
            HandleEdit();
        }

        bool exists = list.Any(user => user.UserId!.Contains(wantToChangeInput));

        if (!exists)
        {
            Console.WriteLine("No user that matches ID, please provide valid User ID.");
            HandleEdit();
        }
        
        var indexOfUserToChange = userService.GetIndex(list, wantToChangeInput);
        
        var editedUser = userService.Register(wantToChangeInput);
        list[indexOfUserToChange] = editedUser!;
        
        userService.RewriteUsers("Users.txt", list);
        
        RerunMainMenu();
    }

    private void HandleExit()
    {
        Console.WriteLine("Exiting the program...");
        _isSelected = true;
        Console.ReadKey();
        Environment.Exit(0);
    }

    private void RerunMainMenu()
    {
        MainMenu.ShowMainMenu();
        var userInput = Console.ReadLine()!.Trim().ToLower();
        GetUserInput(userInput);
    }
}