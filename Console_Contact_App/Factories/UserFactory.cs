using Console_Contact_App.Models;

namespace Console_Contact_App.Factories;

public static class UserFactory
{
    public static RegistrationForm Create()
    {
        return new RegistrationForm();
    }

    public static UserEntity Create(
        RegistrationForm form,
        string id
    )
    {
        return new UserEntity
        {
            UserId = id,
            Name = form.Name,
            Surname = form.Surname,
            Email = form.Email,
            Password = form.Password,
            Phone = string.IsNullOrEmpty(form.Phone) ? "Phone number not provided" : form.Phone,
            Address = string.IsNullOrEmpty(form.Address) ? "Address not provided" : form.Address
        };
    }

    public static User Create(UserEntity userEntity)
    {
        return new User
        {
            UserId = userEntity.UserId,
            FullName = $"{userEntity.Name} {userEntity.Surname}",
            Email = userEntity.Email,
            Phone = userEntity.Phone,
            Address = userEntity.Address
        };
    }
}