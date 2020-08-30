using HospitalManager.App.Abstract;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.App.Managers
{
    public class LoginActionManager
    {
        private ILoginService<LoginAction> _LoginActionService;
        public LoginActionManager(ILoginService<LoginAction> LoginActionService)
        {
            _LoginActionService = LoginActionService;
        }

        public LoginAction GetRegisterData(LoginAction user)
        {
            user = new LoginAction();

            Console.Write("Please write your login: ");
            user.Login = Console.ReadLine();
            Console.Write("Please write your password: ");
            user.Password = Console.ReadLine();
            Console.Write("Please write your ID number: ");
            user.Id = Int32.Parse(Console.ReadLine());
            _LoginActionService.Add(user);
            user.IsLoggedIn = true;
            return user;
        }

        public LoginAction GetLoginData(LoginAction user)
        {
            Console.Write("Please write your login: ");
            user.Login = Console.ReadLine();
            Console.Write("Please write your password: ");
            user.Password = Console.ReadLine();

            user = _LoginActionService.GetUser(user);
            if (user.Id != 0)
            {
                Console.WriteLine("You have successfully loggged in!");
                user.IsLoggedIn = true;
            }
            else
            {
                Console.WriteLine("There is an error during your logging in...");
                user.IsLoggedIn = false;
            }
            return user;
        }

        
    }
}
