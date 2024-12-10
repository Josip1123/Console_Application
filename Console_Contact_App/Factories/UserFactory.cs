using Console_Contact_App.Models;

namespace Console_Contact_App.Factories;

public static class UserFactory
{
    public static RegistrationForm Create()
    {
        return new RegistrationForm();
    }

    public static UserEntity Create(RegistrationForm form)
    {
        return new UserEntity
        {
            UserId = Guid.NewGuid().ToString(),
            Name = form.Name,
            Surname = form.Surname,
            Email = form.Email,
            Password = form.Password
        };
    }

    public static User Create(UserEntity userEntity)
    {
        return new User
        {
            UserId = userEntity.UserId,
            FullName = $"{userEntity.Name} {userEntity.Surname}",
            Email = userEntity.Email
        };
    }
}