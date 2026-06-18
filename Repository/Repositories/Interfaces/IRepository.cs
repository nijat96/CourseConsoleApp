using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        void Add(T entity);
        void Delete(T entity);
        T Update(T entity, int id);
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate = null);
        List<T> GetAll(int page, int pageSize);
    }
}
