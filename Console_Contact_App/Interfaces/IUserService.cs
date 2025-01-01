using Console_Contact_App.Models;

namespace Console_Contact_App.Interfaces;

public interface IUserService
{
    public UserEntity? Register();
    public void SaveUsers(string filePath, List<UserEntity> userEntities);
    public List<User> GetUsers(string filePath);
    public void InitializeUsers(string filePath);
}