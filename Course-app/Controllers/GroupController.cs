using Domain.Models;
using Repository.Enums;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_app.Controllers
{
    internal class GroupController
    {
        private readonly GroupService _groupService;
        public GroupController()
        {
            _groupService = new GroupService();
        }
             
        public void CreateGroup()
        {
            GroupName: ConsoleColor.White.WriteConsole("Add group name:");
            string groupName=Console.ReadLine();
            Capacity: ConsoleColor.White.WriteConsole("Enter group capacity:");
            string groupCapacity=Console.ReadLine();
            int capacity;
            bool isCorrectCapacity=int.TryParse(groupCapacity, out capacity);
            Group group = new()
            {
                Name = groupName,
                Capacity = capacity,

            };

            if (isCorrectCapacity)
            {
                if (_groupService.IsGroupName(group.Name))
                {
                    _groupService.Create(group);
                    Console.WriteLine($"Group-{group.Name}-{group.Capacity} created with ID:-{group.Id}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole($"A group with the name '{group.Name}' already exists. Please choose a different name.");
                    goto GroupName;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Capacity format is wrong,please select again:");
                goto Capacity;
            }
          

        }
        public void GetAll()
        {
            var result = _groupService.GetAll();

            foreach (var item in result)
            {
                string res = $"Group Name:{item.Name} Group Capacity:{item.Capacity} - {item.Id} ";
                ConsoleColor.White.WriteConsole(res);
            }
        }

        public void GetById()
        {

        Id: Console.WriteLine("Add id :");
            string idStr = Console.ReadLine();
            int id;
            bool IsCorrectId = int.TryParse(idStr, out id);
            if (IsCorrectId)
            {
                Group group = _groupService.GetById(id);

                if (group != null)
                {
                    Console.WriteLine($"Group Name: {group.Name} Group Capacity: {group.Capacity}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Group not found with the given Id.");
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong,please select again:");
                goto Id;
            }

        }

        public void EditGroup()
        {
            Console.WriteLine("Add group id :");
           Id: string idStr=Console.ReadLine();
            int id;
            bool IsCorrectId=int.TryParse(idStr, out id);
            if (IsCorrectId)
            {
                var group=_groupService.GetById(id) ;
                if(group is null)
                {
                    Console.WriteLine("Data not found");
                }
                Console.WriteLine("Enter Group Name :");
                string name = Console.ReadLine();
            Capacity: ConsoleColor.White.WriteConsole("Edit group capacity:");
                string groupCapacity = Console.ReadLine();
                int capacity;
                bool isCorrectCapacity = int.TryParse(groupCapacity, out capacity);
                if (isCorrectCapacity)
                {
                    _groupService.Edit(id, new Group { Name = name,Capacity=capacity });
                    ConsoleColor.Green.WriteConsole("Successful edit");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Capacity format is wrong,please select again:");
                    goto Capacity;
                }
               
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong,please select again: ");
                goto Id;
            }


        }

        public void Delete()
        {
            {
                Console.WriteLine("Add Group id :");
            Id: string idStr = Console.ReadLine();
                int id;
                bool IsCorrectId = int.TryParse(idStr, out id);
                if (IsCorrectId)
                {
                    var student = _groupService.GetById(id);
                    _groupService.Delete(student);
                    Console.WriteLine("Group has been deleted");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("ID Format is wrong,please select again:");
                }

            }
        }
        public void Search() 
        {
            Console.WriteLine("Search Group:");
            string groupName=Console.ReadLine();
            var datas=_groupService.Search(groupName);
            foreach ( var data in datas )
            {
                string res = $"Group Name:{data.Name} Group Capacity:{data.Capacity} - {data.Id} ";
                ConsoleColor.White.WriteConsole(res);
            }
        }
        public void Filter() 
        {
            Console.WriteLine("Select Group Sort Type: Ascending-(1), Descending-(2)");
            SortType: string sortStr=Console.ReadLine();
            int sortType;
            bool isCorrectSortType=int.TryParse(sortStr, out sortType);
            if (isCorrectSortType)
            {
                if(sortType==(int)SortType.Asc || sortType == (int)SortType.Desc)
                {
                    List<Group> groups = new();
                    if(sortType == (int)SortType.Asc)
                    {
                        groups = _groupService.Sorting(SortType.Asc);

                    }
                    else
                    {
                        groups = _groupService.Sorting(SortType.Desc);
                    }

                    foreach ( var group in groups )
                    {
                        var res = $"{group.Name}-{group.Capacity}";
                        Console.WriteLine(res);
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
