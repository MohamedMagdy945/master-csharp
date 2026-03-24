using Company.Model;
using Company.Serivce;

namespace UnitTest.Service
{
    public class UserServiceTests
    {
        [Fact]
        public void Register_ValidUser_ReturnTrue()
        {
            // Arrange
            var service = new UserService();
            var user = new User { Email = "test@gamil.com", Password = "123456" };

            // Act 
            var result = service.Register(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Register_InvalidEmail_ReturnFalse()
        {
            // Arrange
            var service = new UserService();
            var user = new User { Email = "testgmail.com", Password = "123456" };

            // Act
            var result = service.Register(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Register_ShortPassword_ReturnFalse()
        {
            var service = new UserService();
            var user = new User { Email = "test@gmail.com", Password = "123" };

            var result = service.Register(user);

            Assert.False(result);
        }

        [Fact]
        public void Register_EmptyEmail_ThrowsException()
        {
            var service = new UserService();
            var user = new User { Email = "", Password = "123456" };

            Assert.Throws<Exception>(() => service.Register(user));
        }

        [Fact]
        public void void_EmptyEmail_Login_ThrowsException()
        {
            var service = new UserService();
            var user = new User { Email = "", Password = "123456" };

            Assert.Throws<Exception>(() => service.Login("", "123456"));
        }
    }
}
