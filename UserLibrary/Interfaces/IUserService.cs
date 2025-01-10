using UserLibrary.Models;

namespace UserLibrary.Interfaces;

public interface IUserService
{
    public UserEntity? Register(string id);
    public void SaveUsers(string filePath, List<UserEntity> userEntities);
    
    public void RewriteUsers(string filePath, List<UserEntity> userEntities);
    public List<UserEntity> GetUsers(string filePath);
    public List<UserEntity> InitializeUsers(string filePath);
    public List<UserEntity> DeleteUser(string id, List<UserEntity> users);
    public int GetIndex(List<UserEntity> users, string userId);
}