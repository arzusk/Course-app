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
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public void Edit(int groupId, Group group)
        {

            Group existGroup = GetById(groupId);

            if (existGroup != null)
            {
                if (!string.IsNullOrWhiteSpace(existGroup.Name))
                {
                    existGroup.Name = group.Name;
                }
                if (existGroup.Capacity is not null)
                {
                    existGroup.Capacity = group.Capacity;
                }
            }


        }
        public List<Group> Search(string name)
        {
            return AppDbContext<Group>.Datas.Where(m => m.Name.ToLower().Trim().Contains(name.ToLower().Trim())).ToList();
        }

        public List<Group> Sorting(SortType sort)
        {
            switch (sort)
            {
                case SortType.Asc:
                    return AppDbContext<Group>.Datas.OrderBy(m => m.Capacity).ToList(); break;
                case SortType.Desc:
                    return AppDbContext<Group>.Datas.OrderByDescending(m => m.Capacity).ToList(); break;
            }
            return null;
        }

        public bool IsGroupName(string groupName)
        {
            return AppDbContext<Group>.Datas.All(m => m.Name != groupName);
        }
    }
}
