
using Console_Contact_App.Factories;
using Console_Contact_App.Models;
namespace Console_Contact_App.Services;



public static class DataHandling
{
    public static List<UserEntity> SavedUsers = [];

    public static List<UserEntity> SaveToList(UserEntity item)
    {
        SavedUsers.Add(item);
        return SavedUsers;
    }
    
    public static void ShowAllUsers() 
    {
        foreach (var item in SavedUsers)
        {
            var user = UserFactory.Create(item);
            Console.WriteLine($"{user.UserId}, {user.FullName}, {item.Email}, {item.Phone}, {item.Address}");
        }
    }
}