using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.Implementation
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly AppDbContext<Group> _groups =new();
        public void Add(Group entity)
        {
            try
            {
                if (entity != null)
                    _groups.list.Add(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Group entity)
        {
            _groups.list.Remove(entity);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return _groups.list.Find(predicate);
        }

        public List<Group> GetAll(Predicate<Group> predicate)
        {
            return _groups.list.FindAll(predicate);
        }
        public List<Group>GetAll()
        {
            return _groups.list;
        }

        public List<Group> GetAll(int page, int pageSize)
        {
            return GetAll().Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        public Group Update(Group entity, int id)
        {
            var result = Get(x => x.Id == id);
            result.Name= entity.Name;
            result.Teacher= entity.Teacher;
            result.Room= entity.Room;
            return result;
        }

    }
}
