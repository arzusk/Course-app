using Domain.Models;
using Repository.Data;
using Repository.Enums;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public void Edit(int id, Student student)
        {
           Student existStudent=AppDbContext<Student>.Datas.FirstOrDefault(x => x.Id == id);
     
            if (student.FullName is not null)
            existStudent.FullName= student.FullName;

            if (student.Age is not null)
                existStudent.Age = student.Age;

            if (student.Phone is not null)
                existStudent.Phone = student.Phone;

            if (student.Address is not null)
                existStudent.Address = student.Address;

            if (student.Group != null)
            {
                if (existStudent.Group == null)
                {
                    existStudent.Group = new Group();
                }

                if (student.Group.Name != null)
                {
                    existStudent.Group.Name = student.Group.Name;
                }
            }

        }

        public List<Student> Search(string fullname)
        {
           return AppDbContext<Student>.Datas.Where(m=>m.FullName == fullname).ToList();
        }

        public List<Student> Sorting(SortType sort)
        {
            switch (sort)
            {
                case SortType.Asc:
                   return  AppDbContext<Student>.Datas.OrderBy(m=>m.Age).ToList(); break;
                 case SortType.Desc:
                   return AppDbContext<Student>.Datas.OrderByDescending(m=>m.Age).ToList();break;
            }
            return null;
        }
    }
}
