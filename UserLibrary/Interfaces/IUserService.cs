using UserLibrary.Models;

namespace UserLibrary.Interfaces;

public interface IUserService
{
    public UserEntity? Register();
    public void SaveUsers(string filePath, List<UserEntity> userEntities);
    
    public void RewriteUsers(string filePath, List<UserEntity> userEntities);
    public List<UserEntity> GetUsers(string filePath);
    public List<UserEntity> InitializeUsers(string filePath);
    public List<UserEntity> DeleteUser(string id, List<UserEntity> users);
    //public void EditUser(UserEntity userEntity);
}