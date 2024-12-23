
using System.Text.Json;
using Console_Contact_App.Factories;
using Console_Contact_App.Models;
using Console_Contact_App.Presentation;
namespace Console_Contact_App.Services;




public static class DataHandling
{
    private static List<UserEntity> _savedUsers = [];

    public static List<UserEntity> SaveToList(UserEntity item)
    {
        _savedUsers.Add(item);
        return _savedUsers;
    }

    public static void SaveUsersToFile(string filePath)
    {
        try
        {
            var usersJsoned = JsonSerializer.Serialize(_savedUsers);
            File.WriteAllText(filePath, usersJsoned);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("User saved successfully!");
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something went wrong while saving the user {e.Message}");
        }
       
    }

    public static void GetUsersFromFile(string filePath)
    {
        try
        {
            var usersFromListJson = File.ReadAllText(filePath);
            
            if (string.IsNullOrEmpty(usersFromListJson))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The users list is empty, try adding users first");
                Console.ResetColor();
                return;
            }
            
            var usersFromListTxt = JsonSerializer.Deserialize<List<UserEntity>>(usersFromListJson);
            _savedUsers = usersFromListTxt!;
            
            
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An error occured while trying to access the users file: {e.Message}");
            Console.ResetColor();
            
            MainMenu.ShowMainMenu();
            var userInput = new MainMenuLogic();
            userInput.GetUserInput();
        }
        

    }

    public static void GetFileInitially(string filePath)
    {
            
            if (File.Exists(filePath) == false)
            {
                var usersJsoned = JsonSerializer.Serialize(_savedUsers);
                File.WriteAllText(filePath, usersJsoned);
            }
            
            var usersFromListJson = File.ReadAllText(filePath);
            var usersFromListTxt = JsonSerializer.Deserialize<List<UserEntity>>(usersFromListJson);
            
            _savedUsers = usersFromListTxt!;
            
    }
    
    public static void ShowAllUsers() 
    {
        foreach (var item in _savedUsers)
        {
            var user = UserFactory.Create(item);
            Console.WriteLine($"{_savedUsers.IndexOf(item) + 1}. {user.UserId}, {user.FullName}, {item.Email}, {item.Phone}, {item.Address}");
        }
        
        MainMenu.ShowMainMenu();
        var userInput = new MainMenuLogic();
        userInput.GetUserInput();
    }
}