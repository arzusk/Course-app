using Domain.Models;
using Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        void Create(Student entity);
        List<Student> Search(string fullname);
        List<Student> Sorting(SortType sort );
        void Edit(int id,Student student);
    }
}
