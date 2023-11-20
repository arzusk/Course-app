using Domain.Models;
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
        List<Group> Sorting();
        void Edit(int groupId,Group group);
    }
}
