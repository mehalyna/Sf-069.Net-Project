using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Moq;
using SportsHub.AppService.Authentication;
using SportsHub.AppService.Authentication.Models.DTOs;
using SportsHub.AppService.Services;
using SportsHub.Domain.Models;
using SportsHub.Domain.PasswordHasher;
using UnitTests.MockData;
using Xunit;

namespace UnitTests.Services;

public class AuthenticationServiceTests
{
    private readonly Mock<IUserService> _userService;
    private readonly Mock<IPasswordHasher> _passwordHasher;
    private readonly IAuthenticationService _authentication;
    private IFixture _fixture;

    public AuthenticationServiceTests()
    {
        SetupFixture();
        _userService = _fixture.Freeze<Mock<IUserService>>();
        _passwordHasher = _fixture.Freeze<Mock<IPasswordHasher>>();
        _authentication = new AuthenticationService(_userService.Object, _passwordHasher.Object);
    }

    [Theory]
    [AutoData]
    public async Task Authenticate_WithUsername_ReturnUser(string userName)
    {
        //Arrange
        var givenUser = _fixture.Build<UserLoginDTO>().With(x=>x.UsernameOrEmail,userName).Create(); //UserLoginDTO
        var user = _fixture.Build<User>().With(x=>x.Username,userName).Create(); //User
        _userService.Setup(service => service.GetByUsernameAsync(userName)).ReturnsAsync(user);
    
        //Act
        var result = await _authentication.Authenticate(givenUser);
    
        //Assert
        Assert.Equal(result.Username, user.Username);
        Assert.Equal(result.Password, user.Password);
    
    }

    [Fact]
    public async Task Authenticate_WithUsername_ReturnNull()
    {
        //Arrange
        var givenUser = _fixture.Build<UserLoginDTO>().Create();
        _userService.Setup(service => service.GetByUsernameAsync(givenUser.UsernameOrEmail)).ReturnsAsync((User?)null);

        //Act
        var result = await _authentication.Authenticate(givenUser);

        //Assert
        Assert.Null(result);
    }

    [Theory]
    [AutoData]
    public async Task Authenticate_WithEmail_ReturnUser(string email)
    {
        //Arrange
        var givenUser = _fixture.Build<UserLoginDTO>().With(x=>x.UsernameOrEmail, email).Create();
        var user = _fixture.Build<User>().With(x=>x.Email, email).Create();
        _userService.Setup(service => service.GetByEmailAsync(email)).ReturnsAsync(user);
    
        //Act
        var result = await _authentication.Authenticate(givenUser);
    
        //Assert
        Assert.Equal(result.Email, user.Email);
        Assert.Equal(result.Password, user.Password);
    }

    [Fact]
    public async Task Authenticate_WithEmail_ReturnNull()
    {
        //Arrange
        var givenUser = _fixture.Build<UserLoginDTO>().Create();
        _userService.Setup(service => service.GetByUsernameAsync(givenUser.UsernameOrEmail)).ReturnsAsync((User?)null);

        //Act
        var result = await _authentication.Authenticate(givenUser);

        //Assert
        Assert.Null(result);
    }
    
    private void SetupFixture()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }
}