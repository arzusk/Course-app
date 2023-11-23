using Domain.Models;
using Repository.Enums;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Domain.Models.Group;

namespace Course_app.Controllers
{
    internal class StudentController
    {
        private readonly IStudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }

        public void StudentCreate()
        {
            ConsoleColor.White.WriteConsole("Add Fullname:");
            string fullname = Console.ReadLine();
        Age: ConsoleColor.White.WriteConsole("Add your age:");
            string ageStr = Console.ReadLine();
            int age;
            bool isCorrectAge = int.TryParse(ageStr, out age);
            if (!isCorrectAge)
            {
                ConsoleColor.Red.WriteConsole("Age Format incorrect,please write correct age");
                goto Age;
            }
            ConsoleColor.White.WriteConsole("Add address:");
            string address = Console.ReadLine();
            ConsoleColor.White.WriteConsole("Add Phone:");
            string phone = Console.ReadLine();
            ConsoleColor.White.WriteConsole("Group Id:");
            int groupId;
            bool isValidGroupId = int.TryParse(Console.ReadLine(), out groupId);

            if (!isValidGroupId)
            {
                ConsoleColor.Red.WriteConsole("Invalid Group Id. Please enter a valid number.");
                return;
            }
            Student student = new()
            {
                FullName = fullname,
                Age = age,
                Phone = phone,
                Address = address,
            };
            Group group = new()
            {
                Id = groupId,
            };

            GroupService groupService = new GroupService();
            if (groupService.GetById(groupId) == null)
            {
                ConsoleColor.Red.WriteConsole($"Group with Id not found. Please enter a valid Group Id.");
                return;
            }
            _studentService.Create(student);
            Console.WriteLine($"Fullname: {student.FullName} Age {student.Age} Phone {student.Phone} Address: {student.Address} ");
        }

        public void GetAll()
        {
            var result=_studentService.GetAll();
            foreach (var student in result)
            {
                Console.WriteLine($"Fullname: {student.FullName} Age {student.Age} Phone {student.Phone} Address: {student.Address} Group Name:{student.Group.Name}");
            }
        }
        public void GetById()
        {

        Id: Console.WriteLine("Add id :");
            string idStr = Console.ReadLine();
            int id;
            bool IsCorrectId= int.TryParse(idStr, out id);
           if (IsCorrectId)
            {
                Student student = _studentService.GetById(id);
                Console.WriteLine($"Fullname: {student.FullName} Age {student.Age} Phone {student.Phone} Address: {student.Address}");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Invalid Group Id. Please enter a valid number.");
                goto Id;
            }
        }

        public void Delete()
        {
            Console.WriteLine("Add Student id :");
        Id: string idStr = Console.ReadLine();
            int id;
            bool IsCorrectId = int.TryParse(idStr, out id);
            if (IsCorrectId)
            {
                var student = _studentService.GetById(id);
                _studentService.Delete(student);
                Console.WriteLine("Student has been deleted");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("ID Format is wrong,please select again:");
            }

        }
        public void EditStudent()
        {
            Console.WriteLine("Add Student id :");
        Id: string idStr = Console.ReadLine();
            int id;
            bool IsCorrectId = int.TryParse(idStr, out id);
            if (IsCorrectId)
            {
                var student = _studentService.GetById(id);
                if (student is null)
                {
                    Console.WriteLine("Student not found");
                }
                else
                {
                    Console.WriteLine("Enter Student Fullname :");
                    string fullname = Console.ReadLine();
                Age: ConsoleColor.White.WriteConsole("Add your age:");
                    string ageStr = Console.ReadLine();
                    int age;
                    bool isCorrectAge = int.TryParse(ageStr, out age);
                    if (!isCorrectAge)
                    {
                        ConsoleColor.Red.WriteConsole("Age Format incorrect,please write correct age");
                        goto Age;
                    }
                    ConsoleColor.White.WriteConsole("Add address:");
                    string address = Console.ReadLine();
                    ConsoleColor.White.WriteConsole("Add Phone:");
                    string phone = Console.ReadLine();
                    ConsoleColor.White.WriteConsole("If you want to change your group, enter the group name you want to change:");
                    string groupName = Console.ReadLine();

                    Student student1 = new Student
                    {
                        Id = id,
                        FullName = fullname,
                        Age = age,
                        Phone = phone,
                        Address = address,
                        Group = new Group { Name = groupName }
                    };

                    _studentService.Edit(id, student1);
                    ConsoleColor.Green.WriteConsole("Edit successful");
                }
     
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong,please select again: ");
                goto Id;
            }

       

        }

        public void Search()
        {
            Console.WriteLine("Search student:");
            string studentName= Console.ReadLine();
            var datas=_studentService.Search(studentName);
            foreach (var data in datas)
            {
                Console.WriteLine($"Fullname: {data.FullName} Age {data.Age} Phone {data.Phone} Address: {data.Address} Group Name:{data.Group.Name}");
            }
        }
        public void Filter()
        {
            Console.WriteLine("Select Student Sort Type: Ascending-(1), Descending-(2)");
        SortType: string sortStr = Console.ReadLine();
            int sortType;
            bool isCorrectSortType = int.TryParse(sortStr, out sortType);
            if (isCorrectSortType)
            {
                if (sortType == (int)SortType.Asc || sortType == (int)SortType.Desc)
                {
                    List<Student> students = new();
                    if (sortType == (int)SortType.Asc)
                    {
                        students = _studentService.Sorting(SortType.Asc);

                    }
                    else
                    {
                        students = _studentService.Sorting(SortType.Desc);
                    }

                    foreach (var student in students)
                    {
                        var res = $"Fullname: {student.FullName} Age {student.Age} Phone {student.Phone} Address: {student.Address} Group Name:{student.Group.Name}";
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Sort Type is wrong,please select again:");
                    goto SortType;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Sort Type Format is wrong,please select again:");
                goto SortType;
            }
        }

    }

}

