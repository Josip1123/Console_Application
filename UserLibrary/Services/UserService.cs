using System.Text.Json;
using UserLibrary.Factories;
using UserLibrary.Interfaces;
using UserLibrary.Models;

namespace UserLibrary.Services;

public class UserService : IUserService
{
    private List<UserEntity> _savedUsers = [];

    public void SaveUsers(string filePath, List<UserEntity> userEntities)
    {
        try
        {
            _savedUsers.AddRange(userEntities);
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

    public void RewriteUsers(string filePath, List<UserEntity> userEntities)
    {
        try
        {
            _savedUsers = [];
            _savedUsers.AddRange(userEntities);
            File.WriteAllText(filePath, JsonSerializer.Serialize(_savedUsers));
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("User list updated");
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something went wrong while saving the user {e.Message}");
        }
    }

    public List<UserEntity> GetUsers(string filePath)
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
            return _savedUsers = usersFromListTxt!;

        }
        catch (Exception e)
        {
            throw new NoUserFileException($"Invalid file: {filePath}", e);
        }
    }

    public List<UserEntity> InitializeUsers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            var usersJsoned = JsonSerializer.Serialize(_savedUsers);
            File.WriteAllText(filePath, usersJsoned);
        }

        var usersFromListJson = File.ReadAllText(filePath);
        var usersFromListTxt = JsonSerializer.Deserialize<List<UserEntity>>(usersFromListJson);

        _savedUsers = usersFromListTxt!;

        return _savedUsers;
    }

    public UserEntity? Register(string id)
    {
        var isDoneRegistering = false;
        UserEntity? userEntity = null;

        while (!isDoneRegistering)
        {
            var registrationForm = UserFactory.Create();

            Console.WriteLine("Type in your name");
            registrationForm.Name = Validators.ValidateInput("name");

            Console.WriteLine("Type in your surname");
            registrationForm.Surname = Validators.ValidateInput("last name");

            Console.WriteLine("Type your email");
            registrationForm.Email = Validators.ValidateWithRegex("email", "Type in valid Email Address",
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            );

            Console.WriteLine(
                "Type in your password that should contain an number, symbol, uppercase letter and be minimum of 8 characters long:");
            registrationForm.Password = Validators.ValidateWithRegex("password", "Wrong format",
                @"^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$");

            Console.WriteLine("Please confirm your password: ");
            registrationForm.ConfirmedPassword =
                Validators.IsSame(registrationForm.Password, "Passwords do not match!");

            Console.WriteLine("Your Phone number");
            registrationForm.Phone = Console.ReadLine();

            Console.WriteLine("Your address");
            registrationForm.Address = Console.ReadLine();

            userEntity = UserFactory.Create(
                registrationForm,
                id
            );
            isDoneRegistering = true;
        }

        return userEntity;
    }

    public List<UserEntity> DeleteUser(string id, List<UserEntity> users)
    {
        try
        {
            users.RemoveAll(item => item.UserId!.Contains(id));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User deleted successfully!");
            Console.ResetColor();
            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine("Something Went Wrong While Deleting User" + e);
            throw;
        }

    }

    public int GetIndex(List<UserEntity> users, string id)
    
    {
        try
        {
            var userToEdit = users.FirstOrDefault(user => user.UserId == id)!;

            var userIndex = users.IndexOf(userToEdit);

            return userIndex;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }

}