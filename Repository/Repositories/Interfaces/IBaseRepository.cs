using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create (T entity);
        void Delete (T entity);
        void Edit(T entity);
        T GetById (int id); 
        List<T> GetAll();
        List<T> Search(string str);
        List<T> Sorting(int entity);

    }
}
