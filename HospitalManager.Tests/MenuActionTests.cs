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
    public class MenuActionTests
    {
        [Fact]
        public void CanGetMenuActionsByMenuName()
        {
            List<MenuAction> listOfMenuActions1 = new List<MenuAction>();
            List<MenuAction> listOfMenuActions2 = new List<MenuAction>();

            MenuActionService menuActionService = new MenuActionService();

            listOfMenuActions1 = menuActionService.GetMenuActionsByMenuName("Login");
            listOfMenuActions2 = menuActionService.GetMenuActionsByMenuName("mainMenu");

            listOfMenuActions1.Count.Should().Equals(2);
            listOfMenuActions2.Count.Should().Equals(7);
        }
    }
}
