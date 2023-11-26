﻿using Domain.Models;
using Microsoft.VisualBasic.FileIO;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Course_app.Controllers
{
    internal class AccountController
    {
        private readonly IAccountService _accountService;
        public AccountController()
        {
            _accountService=new AccountService();
        }
        public void Register()
        {
        Name: Console.WriteLine("Add your Name:");
            string name=Console.ReadLine();
            if (!RegisterExcentions.CheckNameorSurnameFormat(name))
            {
                ConsoleColor.Red.WriteConsole("Name is Required");
                goto Name;
            }
          Surname:  Console.WriteLine("Add your Surname :");
            string surname=Console.ReadLine();
            if (!RegisterExcentions.CheckNameorSurnameFormat(surname))
            {
                ConsoleColor.Red.WriteConsole("Surname is Required");
                goto Surname;
            }
        Age: Console.WriteLine("Add your age:");
            string ageStr = Console.ReadLine();
            int age;
            bool isCorrectAge = int.TryParse(ageStr, out age);
          
            if (!isCorrectAge)
            {
                ConsoleColor.Red.WriteConsole("Age Format incorrect,please write correct age");
                goto Age;
            }
            if (age < 15 || age > 60)
            {
                Console.WriteLine("Age incorrect");
                goto Age;
            }
        Email: Console.WriteLine("Add your Email:");
            string email = Console.ReadLine();
            if (!RegisterExcentions.IsValidEmailFormat(email))
            {
                ConsoleColor.Red.WriteConsole("Email incorrect,please write correct email");
                goto Email;
            }
            Password: Console.WriteLine("Add your password :");
            string password = Console.ReadLine();
            Console.WriteLine("Please add Confirmpassword: ");
            string confirmpassword = Console.ReadLine();        
            User user = new()
            {
               Name=name,
               Surname=surname,
               Age=age,
               Email=email,
               Password=password,
            };
            if (_accountService.Register(user, confirmpassword))
            {
                Console.WriteLine("Register success,Please select one option: ");

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Confirmpassword and Password are incorrect");
                goto Password;
            }
        }

        public void Login()
        {
            Email: Console.WriteLine("Add your email:  ");
            string email=Console.ReadLine();
            Console.WriteLine("Add your password:  ");
            string password=Console.ReadLine();
            if(_accountService.Login(email, password))
            {
                ConsoleColor.Blue.WriteConsole("Welcome our application");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Email or password incorrect,please try again");
                goto Email;
            }

            if (!RegisterExcentions.IsValidEmailFormat(email))
            {
                ConsoleColor.Red.WriteConsole("Email incorrect,please write correct email");
                goto Email;
            }
        }
    }
}
