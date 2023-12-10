using Domain.Models;
using Repository.Enums;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System.Net;
using System.Net.Cache;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Group = Domain.Models.Group;

namespace Course_app.Controllers
{
    public class StudentController
    {
        private readonly IStudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }

        public void Create()
        {

        Fullname: ConsoleColor.White.WriteConsole("Add Fullname:");
            string fullname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fullname))
            {
                ConsoleColor.Red.WriteConsole("Dont be Empty");
                goto Fullname;
            }

            if (!RegisterExcentions.CheckFullName(fullname))
            {
                ConsoleColor.Red.WriteConsole("Fullname is Required");
                goto Fullname;
            }
   

        Age: ConsoleColor.White.WriteConsole("Add your age:");
            string ageStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole("Don't be Empty,please enter your Age");
                goto Age;
            }
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
        Address: ConsoleColor.White.WriteConsole("Add address:");
            string address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                ConsoleColor.Red.WriteConsole("Dont be Empty");
                goto Address;
            }
        PhoneNumber: ConsoleColor.White.WriteConsole("Add Phone:");
            string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone))
            {
                ConsoleColor.Red.WriteConsole("Dont be Empty");
                goto PhoneNumber;
            }
            if (!RegisterExcentions.CheckPhoneNumber(phone))
            {
                ConsoleColor.Red.WriteConsole("Phone Number Format Incorrect");
                goto PhoneNumber;
            }
        Id: ConsoleColor.White.WriteConsole("Group Id:");
            string id = Console.ReadLine();
            int groupId;
            bool isValidGroupId = int.TryParse(id, out groupId);
            if (!isValidGroupId)
            {
                ConsoleColor.Red.WriteConsole("Invalid Group Id. Please enter a valid number.");
                goto Id;
            }

            GroupService groupService = new GroupService();
            Group group = groupService.GetById(groupId);


            if (group == null)
            {
                ConsoleColor.Red.WriteConsole($"Group with Id not found,please create Group");
                return;
            }
            Student student = new(groupId, fullname, address, age, phone, group.Name);

            if (_studentService == null)
            {
                Console.WriteLine(" Please initialize it before using.");
                return;
            }

            if (CheckStudentCreate.Check(student, group))
            {
                _studentService.Create(student);
                Console.WriteLine($"Fullname: {student.FullName} Age {student.Age} Phone {student.Phone} Address: {student.Address} Group Name: {group.Name}");

            }
            else
            {

                ConsoleColor.Red.WriteConsole($"Group {group.Id} is at full capacity. Student creation failed.");


            }
        }

        public void GetAll()
        {
            var result = _studentService.GetAll();
            if (result.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Not Found");

            }
            foreach (var student in result)
            {
                string res = $"Fullname: {student.FullName} Age {student.Age} Phone {student.Phone} Address: {student.Address} Group Name:{student.Group.Name} ";
                Console.WriteLine(res);
            }

        }
        public void GetById()
        {

        Id: Console.WriteLine("Add id :");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Don't Be Empty");
            }
            int id;
            bool IsCorrectId = int.TryParse(idStr, out id);
            if (IsCorrectId)
            {
                Student student = _studentService.GetById(id);

                if (student != null)
                {
                   
                    Console.WriteLine($"Student Name: {student.FullName} Student Age :{student.Age} Student Address:{student.Address} Student Phone :{student.Phone}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Student not found with the given Id.");
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Invalid Student Id. Please enter a valid number.");
                goto Id;
            }
        }

        public void Delete()
        {
            Console.WriteLine("Add Student id :");
        Id: string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Don't be Empty");
                goto Id;
            }
            int id;
            bool IsCorrectId = int.TryParse(idStr, out id);
            if (IsCorrectId)
            {
                var student = _studentService.GetById(id);
                if(student is null)
                {
                    ConsoleColor.Red.WriteConsole("Student Not Found");
                    return;
                }
                _studentService.Delete(student);
                Console.WriteLine("Student has been deleted");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("ID Format is wrong,please select again:");
                goto Id;
            }
        }
        public void Edit()
        {
            Console.WriteLine("Add Student id:");
        Id:
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Dont Be Empty");
                goto Id;
            }
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);

            if (isCorrectId)
            {
                var student = _studentService.GetById(id);
                if (student is null)
                {
                    ConsoleColor.Red.WriteConsole("Data Not Found, Please Enter Correct Id");
                    goto Id;
                }
                else
                {
                     Console.WriteLine("Edit Student Name:");
                    string name = Console.ReadLine();
                   
                    Console.WriteLine("Edit Address:");
                    string address = Console.ReadLine();

                    Console.WriteLine("Edit Student Age:");
                    string age = Console.ReadLine();
                    int intAge;
                    bool isCorrectAge = int.TryParse(age, out intAge);
                    if (!isCorrectAge && !string.IsNullOrWhiteSpace(age))
                    {
                        ConsoleColor.Red.WriteConsole("Age Format Incorrect, please add correct age ");
                        goto Id;
                    }

                    Console.WriteLine("Edit Phone:");
                    string phone = Console.ReadLine();

                    Console.WriteLine("If you want to change your group, enter the new group Id:");
                    string groupIdStr = Console.ReadLine();

                    int groupId;
                    bool isCorrectGroupId = int.TryParse(groupIdStr, out groupId);
                    if (string.IsNullOrWhiteSpace(groupIdStr))
                    {
                        groupId = student.Group.Id;
                    }
                    else if (!isCorrectGroupId)
                    {
                        ConsoleColor.Red.WriteConsole("Invalid Group Id. Please enter a valid number.");
                        goto Id;
                    }
                    name = string.IsNullOrWhiteSpace(name) ? student.FullName : name;
                    address = string.IsNullOrWhiteSpace(address) ? student.Address : address;
                    intAge = string.IsNullOrWhiteSpace(age) ? student.Age : intAge;
                    phone = string.IsNullOrWhiteSpace(phone) ? student.Phone : phone;
                    groupId = string.IsNullOrWhiteSpace(groupIdStr) ? student.Group.Id : groupId;
                    student.FullName = name;
                    student.Address = address;
                    student.Age = intAge;
                    student.Phone = phone;
                    student.Group.Id = groupId;

                    _studentService.Edit(id, student);
                    ConsoleColor.Green.WriteConsole("Edit successful");
                }
            }
        }




        public void Search()
        {
        Name: Console.WriteLine("Search student:");
            string studentName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(studentName))
            {

                ConsoleColor.Red.WriteConsole("Dont be Empty");
                goto Name;

            }
            var datas = _studentService.Search(studentName);
            foreach (var data in datas)
            {
                Console.WriteLine($"Fullname: {data.FullName} Age {data.Age} Phone {data.Phone} Address: {data.Address} Group Name:{data.Group.Name}");
                break;
            }
            if (datas.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Not Found");
            }
        }
        public void Filter()
        {
        SortType: Console.WriteLine("Select Student Sort Type: Ascending-(1), Descending-(2)");
            string sortStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(sortStr))
            {
                ConsoleColor.Red.WriteConsole("Sort Type cannot be empty, please select again:");
                goto SortType;
            }

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
                        Console.WriteLine(res);
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Sort Type is wrong, please select again:");
                    goto SortType;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Sort Type Format is wrong, please select again:");
                goto SortType;
            }
        }


    }

}

