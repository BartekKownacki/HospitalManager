using HospitalManager.App.Common;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;


namespace HospitalManager.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> filteredMenuActions = new List<MenuAction>();
            foreach(var menuAction in Items)
            {
                if(menuAction.MenuName==menuName)
                {
                    filteredMenuActions.Add(menuAction);
                }
            }
            return filteredMenuActions;
        }

        
        public void Initialize()
        {
            //Login menu
            Add(new MenuAction(1, "Login", "Login"));
            Add(new MenuAction(2, "Register", "Login"));

            //ActionMenu
            Add(new MenuAction(1, "Show patients list", "mainMenu"));
            Add(new MenuAction(2, "Add new patient", "mainMenu"));
            Add(new MenuAction(3, "Remove patient", "mainMenu"));
            Add(new MenuAction(4, "Add new illness to patient", "mainMenu"));
            Add(new MenuAction(5, "Generate prescription for patient (txt file)", "mainMenu"));
            Add(new MenuAction(6, "Sign out", "mainMenu"));
            Add(new MenuAction(7, "Press 'q' to quit", "mainMenu"));
        }

    }
}
