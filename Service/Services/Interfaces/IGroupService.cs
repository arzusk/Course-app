using Domain.Models;
using Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group group);
        void Delete(Group group);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> Search(string name);
        List<Group> Sorting(SortType sort);
        void Edit(int groupId, Group group);
    }
}
