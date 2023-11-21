using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Course_app.Controllers
{
    internal class StudentController
    {
        private readonly IStudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }

        public void Create()
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

            GroupService groupService = new GroupService();
            if (groupService.GetById(groupId) == null)
            {
                ConsoleColor.Red.WriteConsole($"Group with Id not found. Please enter a valid Group Id.");
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

            _studentService.Create(student);
            Console.WriteLine($"Fullname: {student.FullName} Age {student.Age} Phone {student.Phone} Address: {student.Address}  Group Name: {group.Name}");
        }

        public void GetAll()
        {
            var result=_studentService.GetAll();
            foreach (var student in result)
            {
                Console.WriteLine($"Fullname: {student.FullName} Age {student.Age} Phone {student.Phone} Address: {student.Address}");
            }
        }
        public void GetById()
        {
            Console.WriteLine("Add id :");
            int id = int.Parse(Console.ReadLine());
            Student student = _studentService.GetById(id);
            Console.WriteLine($"Fullname: {student.FullName} Age {student.Age} Phone {student.Phone} Address: {student.Address}");
        }

    }

}

