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
            return _savedUsers.Select(userEntity => UserFactory.Create(userEntity)).ToList();
        }
        catch (Exception e)
        {
            throw new NoUserFileException($"Invalid file: {filePath}", e);
        }
    }

    public void InitializeUsers(string filePath)
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

    public UserEntity? Register()
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
            registrationForm.Email = Validators.ValidateInput("email");

            Console.WriteLine("Type in your password:");
            registrationForm.Password = Validators.ValidateInput("password");

            Console.WriteLine("Please confirm your password: ");
            registrationForm.ConfirmedPassword =
                Validators.IsSame(registrationForm.Password, "Passwords do not match!");

            Console.WriteLine("Your Phone number");
            registrationForm.Phone = Console.ReadLine();

            Console.WriteLine("Your address");
            registrationForm.Address = Console.ReadLine();

            userEntity = UserFactory.Create(
                registrationForm,
                Guid.NewGuid().ToString()
            );
            isDoneRegistering = true;
        }

        return userEntity;
    }
}