using UserLibrary.Services;

namespace Contact_App_Tests;

public class ValidatorsTests
{
    [Fact]
    public void ShouldReturnTrueWhenEqual()
    {
        // Arrange
        var input = "Test String";
        var testInput = "Test String";
        using (var stringReader = new StringReader(input))
        {
            Console.SetIn(stringReader);

            // Act

            var result = Validators.IsSame(testInput, "Doesn't match");
            
            
            // Assert
            Assert.Equal(input, result);
        }
    }
    
    [Fact]
    public void ShouldReturnTrueWhenMatchesRegexPattern()
    {
        // Arrange
        var input = "john.doe@gmail.com";
        using (var stringReader = new StringReader(input))
        {
            Console.SetIn(stringReader);

            // Act
            var result = Validators.ValidateWithRegex("email","Wrong format", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            
            // Assert
            Assert.Equal(input, result);
        }
    }
}