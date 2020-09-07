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
    public class IllnessActionTests
    {
        [Fact]
        public void CanGetAllById()
        {
            IllnessActionService illnessActionService = new IllnessActionService();
            Patient patient = new Patient(1, "aaa", "bbb", "ccc", 123, "ddd");
            IllnessAction illnessAction = new IllnessAction(patient, "aaa", DateTime.Now, "bbb", CategoryOfIllness.Cancer, 4, "xxx", DateTime.Now.AddDays(30) );
            illnessActionService.Add(illnessAction);

            List<IllnessAction> illnessListById = new List<IllnessAction>();

            illnessListById = illnessActionService.GetAllByInfo(patient.Id);

            illnessListById.Count.Should().Equals(1);
        }

        [Fact]
        public void CanGetAllByPesel()
        {
            IllnessActionService illnessActionService = new IllnessActionService();
            Patient patient = new Patient(1, "aaa", "bbb", "ccc", 123, "ddd");
            IllnessAction illnessAction = new IllnessAction(patient, "aaa", DateTime.Now, "bbb", CategoryOfIllness.Cancer, 4, "xxx", DateTime.Now.AddDays(30));
            illnessActionService.Add(illnessAction);

            List<IllnessAction> illnessListById = new List<IllnessAction>();

            illnessListById = illnessActionService.GetAllByInfo(patient.PESEL);

            illnessListById.Count.Should().Equals(1);
        }
    }
}
