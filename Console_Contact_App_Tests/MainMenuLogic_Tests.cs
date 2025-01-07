using Console_Contact_App.Services;
using Moq;
using UserLibrary.Interfaces;

namespace Console_Contact_App_Tests;


[TestFixture]
public class MainMenuLogicTests
{
    private Mock<IUserService> _mockUserService;
    private MainMenuLogic _mainMenuLogic;

    [SetUp]
    public void SetUp()
    {
        _mockUserService = new Mock<IUserService>();
        _mainMenuLogic = new MainMenuLogic(_mockUserService.Object);
    }
    
    [Test]
    public void Constructor_ShouldInitializeUserService()
    {
        Assert.That(_mainMenuLogic, Is.Not.Null);
    }
    
}