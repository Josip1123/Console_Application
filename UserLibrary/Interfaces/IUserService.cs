using UserLibrary.Models;

namespace UserLibrary.Interfaces;

public interface IUserService
{
    public UserEntity? Register();
    public void SaveUsers(string filePath, List<UserEntity> userEntities);
    public List<User> GetUsers(string filePath);
    public List<UserEntity> InitializeUsers(string filePath);
}