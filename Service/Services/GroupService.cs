using Domain.Models;
using Repository.Enums;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;
        public GroupService()
        {
            _repository = new GroupRepository();
                
        }

        public void Create(Group group)
        {
           _repository.Create(group);
        }

        public void Delete(Group group)
        {
           _repository?.Delete(group);
        }

        public void Edit(int groupId, Group group)
        {
           _repository.Edit(groupId, group);
        }

        public List<Group> GetAll()
        {
           return _repository.GetAll();
        }

        public Group GetById(int id)
        {
           return _repository.GetById(id);
        }

        public List<Group> Search(string name)
        {
            return _repository.Search(name);
        }

        public List<Group> Sorting(SortType sort)
        {
          return _repository.Sorting(sort);
        }
    }
}
