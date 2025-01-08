using UserLibrary.Factories;
using UserLibrary.Helpers;
using UserLibrary.Models;

namespace Contact_App_Tests;

public class FactoryTest
{
    [Fact]
    public void UserFasctory_ShouldReturnUserEntityType_WhenProvidedWithUserRegistrationFormAndID()
    {
        //arrange
        var mockUser = new RegistrationForm {Name ="John", Surname = "Doe", Email = "johndoe@gmail.com", Password = "Password123!"};
        var id = GuidCreator.CreateNewId();
        
        //act
        var result = UserFactory.Create(mockUser, id);
        
        //assert
        Assert.IsType<UserEntity>(result);
    }

    [Fact]
    public void UserFactory_ShouldReturnTypeofUser_WhenProvidedWithUserEntity()
    {
        //arrange
        var mockUser = new RegistrationForm {Name ="John", Surname = "Doe", Email = "johndoe@gmail.com", Password = "Password123!"};
        var id = GuidCreator.CreateNewId();
        var mockUserEntity = UserFactory.Create(mockUser, id);
        
        //act
        var result = UserFactory.Create(mockUserEntity);
        
        //assert
        Assert.IsType<User>(result);
    }
}