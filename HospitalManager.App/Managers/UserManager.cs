using HospitalManager.App.Abstract;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.App.Managers
{
    public class UserManager
    {
        private IUserService _UserService;
        public UserManager(IUserService UserService)
        {
            _UserService = UserService;
        }

        public User GetRegisterData(User user)
        {
            user = new User();

            Console.Write("Please write your login: ");
            user.Login = Console.ReadLine();
            Console.Write("Please write your password: ");
            user.Password = Console.ReadLine();
            Console.Write("Please write your ID number: ");
            user.Id = Int32.Parse(Console.ReadLine());
            _UserService.Add(user);
            user.IsLoggedIn = true;
            return user;
        }

        public User GetLoginData(User user)
        {
            Console.Write("Please write your login: ");
            user.Login = Console.ReadLine();
            Console.Write("Please write your password: ");
            user.Password = Console.ReadLine();

            user = _UserService.GetUser(user);
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

        public User GetUser(User user)
        {
            return _UserService.GetUser(user);
        }
    }
}
