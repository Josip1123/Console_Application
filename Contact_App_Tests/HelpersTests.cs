using UserLibrary.Helpers;

namespace Contact_App_Tests;

public class HelpersTests
{
    [Fact]
    public void GuidCreator_ShouldReturnStringOfTypeGuid_WehenUsed()
    {
        //Act
        var result = GuidCreator.CreateNewId();

        //Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(Guid.TryParse(result, out _));
    }

    [Fact]
    public void GuidCreator_ShouldGenerateUniqueIds_WhenUsed()
    {
        //act
        var result = GuidCreator.CreateNewId();
        var result2 = GuidCreator.CreateNewId();
        
        //assert
        Assert.NotEqual(result, result2);
    }

    [Fact]
    public void PasswordHasher_ShouldNotMatchOriginalPassword_WhenUsed()
    {
        //act
        var mockPassword = "Password123!";
        var result = PasswordHasher.HashPassword(mockPassword);
        
        //assert
        Assert.NotEqual(mockPassword, result);
    }
}