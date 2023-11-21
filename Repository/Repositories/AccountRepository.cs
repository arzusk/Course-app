using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public bool Login(string email, string password)
        {
           User user=AppDbContext<User>.Datas.FirstOrDefault(m=>m.Email==email && m.Password==password);
          return user != null;
        }

        public bool Register(User user, string confirmPassword)
        {
            if (user.Password != confirmPassword)
            {
                return false;
            }
            AppDbContext<User>.Datas.Add(user);
            return true;
        }
    }
}
