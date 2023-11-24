using Domain.Models;
using Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository :IBaseRepository<Group>
    {
        List<Group> Search(string name);
        List<Group> Sorting(SortType sort);
        void Edit(int groupId,Group group);
        bool IsGroupName(string groupName);
    }
}
