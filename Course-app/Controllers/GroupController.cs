using Domain.Models;
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
            Group group = new()
            {
                Name=groupName,
            };
            if (_groupService.IsGroupNameUnique(group.Name))
            {
                _groupService.Create(group);
                Console.WriteLine($"Group-{group.Name} created with ID:-{group.Id}");
            }
            else
            {
                ConsoleColor.Red.WriteConsole($"A group with the name '{group.Name}' already exists. Please choose a different name.");
                goto GroupName;
            }

        }
        public void GetAll()
        {
            var result = _groupService.GetAll();

            foreach (var item in result)
            {
                string res = $"{item.Name} - {item.Id} ";
                ConsoleColor.White.WriteConsole(res);
            }
        }

        public void GetById()
        {
            Console.WriteLine("Add id :");
            int id=int.Parse(Console.ReadLine());
            Group group=_groupService.GetById(id);
            Console.WriteLine(group.Name);
        }
    }
}
