using Domain.Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class CheckStudentCreate
    {
        public static bool Check(Student student,Group group)
        {
            if(AppDbContext<Student>.Datas.Count<group.Capacity)
                return true; 
            return false;
        }
    }
}
