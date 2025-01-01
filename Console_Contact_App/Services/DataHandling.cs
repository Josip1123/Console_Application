using System.Text.Json;
using Console_Contact_App.Factories;
using Console_Contact_App.Models;
using Console_Contact_App.Presentation;

namespace Console_Contact_App.Services;

public class DataHandling
{
    private List<UserEntity> _savedUsers = [];

    public List<UserEntity> SaveToList(UserEntity item)
    {
        _savedUsers.Add(item);
        return _savedUsers;
    }

    public void SaveUsers(string filePath)
    {
        try
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(_savedUsers));
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("User saved successfully!");
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something went wrong while saving the user {e.Message}");
        }
    }

    public List<User> GetUsers(string filePath)
    {
        try
        {
            var usersFromListJson = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(usersFromListJson))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The users list is empty, try adding users first");
                Console.ResetColor();
                return [];
            }

            var usersFromListTxt = JsonSerializer.Deserialize<List<UserEntity>>(usersFromListJson);
            _savedUsers = usersFromListTxt!;
            return _savedUsers.Select(UserFactory.Create).ToList();
        }
        catch (Exception e)
        {
            throw new NoUserFileException();
        } 
    }

    public void GetFileInitially(string filePath)
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

    public void ShowAllUsers()
    {
        foreach (var item in _savedUsers)
        {
            Console.WriteLine(
                $"{_savedUsers.IndexOf(item) + 1}. {item.UserId}, {item.Name}, {item.Email}, {item.Phone}, {item.Address}");
        }

        MainMenu.ShowMainMenu();
        var userInput = new MainMenuLogic(
            new UserRegistration(),
            new DataHandling()
        );
        userInput.GetUserInput();
    }
}