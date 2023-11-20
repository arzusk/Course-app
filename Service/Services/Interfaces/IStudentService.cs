using Domain.Models;
using Repository.Enums;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(Student student);
        void Delete(Student student);
        Student GetById(int id);
        List<Student> GetAll();
        List<Student> Search(string fullname);
        List<Student> Sorting(SortType sort);
        void Edit(int id, Student student);
    }
}
