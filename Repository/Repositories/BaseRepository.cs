using Domain.Common;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
     
        public void Create(T entity)
        {
        
            AppDbContext<T>.Datas.Add(entity);
        }


        public void Delete(T entity)
        {
            AppDbContext<T>.Datas.Remove(entity);
        }

        public List<T> GetAll()
        {
           return AppDbContext<T>.Datas.ToList();
        }

        public T GetById(int id)
        {
            return AppDbContext<T>.Datas.FirstOrDefault(m => m.Id == id);
        }

       
    }
}
