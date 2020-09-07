using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using HospitalManager.App.Abstract;
using HospitalManager.App.Concrete;
using HospitalManager.App.Managers;
using HospitalManager.Domain.Entity;
using Moq;
using Xunit;

namespace HospitalManager.Tests
{
    public class PatientTests
    {
        [Fact]
        public void CanGetPatientById()
        {
            //Arrange
            Patient patient = new Patient(1, "aaa", "bbb", "ccc", 123, "ddd");
            var mock = new Mock<IService<Patient>>();
            mock.Setup(m => m.GetById(patient.Id)).Returns(patient);

            var manager = new PatientManager(mock.Object);

            //Act
            var result = manager.GetById(1);
            
            //Assert
            Assert.Equal(patient, result);
        }

        [Fact]
        public void CanRemovePatientByPesel()
        {
            //Arrange
            Patient patient = new Patient(1, "aaa", "bbb", "ccc", 123, "ddd");
            IService<Patient> patientService = new PatientService();
            patientService.Add(patient);

            var manager = new PatientManager(patientService);
            //Act
            manager.Remove(patient.Id);
            //Assert
            patientService.GetAll().Count.Should().Equals(0);
        }

        [Fact]
        public void CanRemovePatientById()
        {
            //Arrange
            Patient patient = new Patient(1, "aaa", "bbb", "ccc", 123, "ddd");
            var mock = new Mock<IService<Patient>>();
            mock.Setup(m => m.GetById(patient.Id)).Returns(patient);
            mock.Setup(m => m.Remove(It.IsAny<Patient>()));

            var manager = new PatientManager(mock.Object);

            //Act
            manager.Remove(patient.Id);

            //Assert
            mock.Verify(m => m.Remove(patient));
        }
    }
}
