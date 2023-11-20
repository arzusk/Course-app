using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService()
        {
            _repository=new AccountRepository();
        }
        public bool Login(string email, string password)
        {
           return _repository.Login(email, password);
        }

        public bool Register(User user, string confirmPassword)
        {
            return _repository.Register(user, confirmPassword);
        }
    }
}
