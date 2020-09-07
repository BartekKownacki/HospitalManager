using HospitalManager.Domain.Entity;
using HospitalManager;
using Moq;
using System;
using Xunit;
using HospitalManager.App.Abstract;
using HospitalManager.App.Managers;
using FluentAssertions;
using HospitalManager.App.Concrete;
using System.Collections.Generic;

namespace HospitalManager.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Patient patient = new Patient() {Id = 1, FirstName = "Adam", LastName="Nowak", PESEL = "123123123", PhoneNumber = 123123123, EmailAdress = "adam@wp.pl"};
            var mock = new Mock<PatientService>();
            mock.Setup(s => s.GetById(1)).Returns(patient);

            var manager = new PatientManager(mock.Object);
            //Act
            var returnedPatient = manager.GetById(patient.Id);

            //Assert
            //Assert.Equal(patient, returnedPatient);
            returnedPatient.Should().BeSameAs(patient);
        }

        [Fact]
        public void Test2()
        {
            //Arrange
            User user = new User() {Id = 1, Login = "aaa", Password = "bbb" };
            IUserService userService = new UserService();
            userService.Add(user);

            var manager = new UserManager(userService);
            //Act
            var returneduser = manager.GetUser(user);

            //Assert
            userService.GetUser(user).Should().BeSameAs(user);
             
            //Clean
            userService.Remove(user);
        }

        [Fact]
        public void Test3()
        {
            
        }
    }
}
