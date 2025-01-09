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
    public void PasswordHasher_ShouldNotBeTheSameAsOriginalPassword()
    {
        //act
        var mockPassword = "Password123!";
        var result = PasswordHasher.HashPassword(mockPassword);
        
        //assert
        Assert.NotEqual(mockPassword, result);
    }
    
    [Fact]
    public void PasswordHasher_ShouldReturnTrue_WhenVerifyCorrectPw()
    {
        //act
        var mockPassword = "Password123!";
        var hashedMockPw = PasswordHasher.HashPassword(mockPassword);
        var result = PasswordHasher.VerifyPassword(mockPassword, hashedMockPw);
        
        //assert
        Assert.True(result);
    }
    [Fact]
    public void PasswordHasher_ShouldReturnFalse_WhenVerifyIncorrectPw()
    {
        //act
        var mockPassword = "Password123!";
        var incorrectMockPassword = "TestPassword123!";
        var hashedMockPw = PasswordHasher.HashPassword(mockPassword);
        var result = PasswordHasher.VerifyPassword(incorrectMockPassword, hashedMockPw);
        
        //assert
        Assert.False(result);
    }
}