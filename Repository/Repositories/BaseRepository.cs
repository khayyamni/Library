using Domain.Common;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public void Create(T entity)
        {
            AppDbContext<T>.datas.Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
             return AppDbContext<T>.datas; 
        }

        public List<T> GetAllByExpression(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
             return AppDbContext<T>.datas.FirstOrDefault(m => m.Id == id);
        }
    }
}
