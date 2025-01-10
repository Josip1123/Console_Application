using System.Text.Json;
using Moq;
using UserLibrary.Interfaces;
using UserLibrary.Models;
using UserLibrary.Services;


namespace Contact_App_Tests;


public class UserServiceTests

{
    [Fact]
    public void SaveUsers_ShouldCreateFileWithAllUsers()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        var filePath = "MockTest.txt";

        var userEntities = new List<UserEntity>
        {
            new() { UserId = "1", Name = "John", Surname = "Doe", Email = "john@email.com", Password = "Password123!"},
            new() { UserId = "2", Name = "Jane", Surname = "Smith", Email = "jane@email.com", Password = "Password123!!!"}
        };
        
        mockService
            .Setup( userService => userService.SaveUsers(filePath, userEntities))
            .Callback<string, List<UserEntity>>((path, users) =>
            {
                File.WriteAllText(path, JsonSerializer.Serialize(users));
            });

        // Act
        mockService.Object.SaveUsers(filePath, userEntities);
        string fileData = File.ReadAllText(filePath);
        var jsonedData = JsonSerializer.Deserialize<List<UserEntity>>(fileData);

        // Assert
        Assert.True(File.Exists(filePath));
        Assert.Contains("John", fileData);
        Assert.Contains("Jane", fileData);
        Assert.Equal(2,jsonedData!.Count);

        // Clean up
        File.Delete(filePath);
    }

    [Fact]
    
    public void SaveUsers_ShouldWriteErrorMsgToConsole_WhenError()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        var filePath = "Test.txt";
        List<UserEntity> userEntities = [];

        mockService
            .Setup(s => s.SaveUsers(filePath, userEntities))
            .Callback(() => { throw new Exception("Mocked Exception"); });
        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // act
        try
        {
            mockService.Object.SaveUsers(filePath, userEntities);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong while saving the user", ex);
        }

        var output = consoleOutput.ToString();
        // Assert
        Assert.Contains("Something went wrong while saving the user", output);
    }
    [Fact]
    public void GetUsers_ShouldReturnEmptyList_WhenNoFilePresent()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        var filePath = "Test_Not_Found.txt";
        List<UserEntity> userEntities = [];

        mockService
            .Setup(s => s.GetUsers(filePath))
            .Returns([]);

        // act
        var result = mockService.Object.GetUsers(filePath);


        // Assert
        Assert.Equal(userEntities, result);

    }
    [Fact]
    public void GetUsers_ShouldReturnUserEntityList_WhenFileProvided()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        var filePath = "Mock_File.txt";

        var userEntities = new List<UserEntity>
        {
            new() { UserId = "1", Name = "John", Surname = "Doe", Email = "john@email.com", Password = "Password123!"},
            new() { UserId = "2", Name = "Jane", Surname = "Smith", Email = "jane@email.com", Password = "Password123!!!"}
        };

        mockService.Setup(userService => userService.GetUsers(filePath)).Returns(userEntities);

        // act
        var result = mockService.Object.GetUsers(filePath);


        // Assert
        Assert.IsType<List<UserEntity>>(result);
        Assert.Equal(2, result.Count);

    }
    
    [Fact]
    public void GetUsers_ShouldReturnError_WhenFileDoesntExist()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        var filePath = "Mock_File.txt";
        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        mockService
            .Setup(userService => userService.GetUsers(filePath))
            .Callback(() => { throw new Exception("Mocked No File Exception"); });

        // act
        try
        {
            mockService.Object.GetUsers(filePath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Invalid file: {filePath}", e);
        }
        
        var output = consoleOutput.ToString();
        
        // Assert
        Assert.Contains("Invalid file:", output);

    }

    [Fact]
    public void Register_shouldReturnNull_IfUserHasntCompleatedRegistration()
    {
        //Arrange
        var mockService = new Mock<IUserService>();
        bool isNotDone = true;
        UserEntity nullEntity = null!;
        UserEntity userEntity = new()
            { UserId = "1", Name = "John", Surname = "Doe", Email = "john@email.com", Password = "Password123!" };
        
        mockService.Setup(userService => userService.Register()).Returns(nullEntity);
        
        //Act
        
        var result = isNotDone ? mockService.Object.Register() : userEntity;
       
        //Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void Register_shouldReturnUserEntity_WhenUserCompleatedReg()
    {
        //Arrange
        var mockService = new Mock<IUserService>();
        bool isDone = true;
        UserEntity userEntity = new()
            { UserId = "1", Name = "John", Surname = "Doe", Email = "john@email.com", Password = "Password123!" };

        mockService.Setup(userService => userService.Register()).Returns(userEntity);
        
        //Act
        
        var result = isDone ? mockService.Object.Register() : null;
       
        //Assert
        Assert.NotNull(result);
        Assert.IsType<UserEntity>(result);
    }
    
    [Fact]
    public void InitializeUsers_ShouldReturnListFormTheFile()
    {
        //Arrange
        var mockService = new Mock<IUserService>();
        var filePath = "Mock_File.txt";
        var userEntities = new List<UserEntity>
        {
            new() { UserId = "1", Name = "John", Surname = "Doe", Email = "john@email.com", Password = "Password123!"},
            new() { UserId = "2", Name = "Jane", Surname = "Smith", Email = "jane@email.com", Password = "Password123!!!"}
        };

        mockService.Setup(userService => userService.InitializeUsers(filePath)).Returns(userEntities);
        
        //Act

        var result = mockService.Object.InitializeUsers(filePath);
       
        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<UserEntity>>(result);
        Assert.Equal(2, result.Count);
    }
    
        [Fact]
        public void DeleteUser_ShouldRemoveUserFromTheLIst_WhenCorrectIdIsProvided()
        {
            //arrange
            IUserService userService = new UserService();
            var idToDelete = "1";
            var users = new List<UserEntity>
            {
                new() { UserId = "1", Name = "John", Surname = "Doe", Email = "john@email.com", Password = "Password123!"},
                new() { UserId = "2", Name = "Jane", Surname = "Smith", Email = "jane@email.com", Password = "Password123!!!"}
            };
            // act

            var result = userService.DeleteUser(idToDelete, users);
        
            // assert
        
            Assert.Single(result);
            Assert.IsType<List<UserEntity>>(result);
            Assert.DoesNotContain(result, userEntity => userEntity.UserId == idToDelete);

        }
        
        [Fact]
        public void DeleteUser_ShouldFail_WhenIncorrectIdIsProvided()
        {
            //arrange
            IUserService userService = new UserService();
            var idToDelete = "3";
            var users = new List<UserEntity>
            {
                new() { UserId = "1", Name = "John", Surname = "Doe", Email = "john@email.com", Password = "Password123!"},
                new() { UserId = "2", Name = "Jane", Surname = "Smith", Email = "jane@email.com", Password = "Password123!!!"}
            };
            
            // act
            var result = userService.DeleteUser(idToDelete, users);
        
            // assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, user => user.UserId == "1");
            Assert.Contains(result, user => user.UserId == "2");

        }
}



