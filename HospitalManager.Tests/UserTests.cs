using System;
using System.Collections.Generic;
using System.Text;
using HospitalManager.App.Abstract;
using HospitalManager.App.Concrete;
using HospitalManager.App.Managers;
using HospitalManager.Domain.Entity;
using Moq;
using Xunit;

namespace HospitalManager.Tests
{
    public class UserTests
    {
        [Fact]
        public void CanGetUserFromList()
        {
            //Arrange
            User user = new User() {Login = "aaa", Password = "bbb" };
            var mock = new Mock<IUserService>();
            mock.Setup(m => m.Add(new User() { Id = 1, Login = "aaa", Password = "bbb" }));
            mock.Setup(m => m.GetUser(user)).Returns(user);

            var manager = new UserManager(mock.Object);
            //Act
            var result = manager.GetUser(user);

            //Assert
            Assert.Equal(result, user);
        }

        [Fact]
        public void CanGetAllUsersFromList()
        {
            //Arrange
            IUserService userService = new UserService();
            userService.Add(new User(1, "aaa", "bbb"));
            userService.Add(new User(2, "aaa", "bbb"));
            userService.Add(new User(3, "aaa", "bbb"));

            //Act
            var users = userService.GetAll();

            //Assert
            Assert.Equal(3, users.Count);
        }

    }
}
