using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementation
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly AppDbContext<Group> _groups = new();
        public void Add(Group entity)
        {
            if (entity == null)
            {
                throw new NullModelException();
            }
            _groups.list.Add(entity);
        }

        public void Delete(Group entity)
        {
            if (entity == null)
            {
                throw new NullModelException();
            }
            _groups.list.Remove(entity);
        }
        public Group Get(Predicate<Group> predicate)
        {
            return _groups.list.Find(predicate) ?? throw new NullModelException();
        }
        public List<Group> GetAll(Predicate<Group> predicate) => _groups.list.FindAll(predicate) ?? throw new NullModelException();
        public List<Group> GetAll() => _groups.list ?? throw new NullModelException();

        public List<Group> GetAll(int page, int pageSize)
        {
            try
            {
                return GetAll().Skip((page - 1) * pageSize).Take(pageSize).ToList() ?? throw new NullModelException();
            }
            catch
            {
                var pageCount = (int)GetAll().Count / pageSize;
                return GetAll(pageCount, pageSize);
            }
        }
        public List<Group> Search(string query)
        {
            return GetAll(x => x != null && (
                              x.Teacher.ToLower().Contains(query.ToLower().Trim()) ||
                              x.Room.ToLower().Contains(query.ToLower().Trim()) ||
                              x.Name.ToLower().Contains(query.ToLower().Trim()))) ?? throw new NullModelException();
        }
        public Group Update(Group entity, int id)
        {
            var result = Get(x => x.Id == id);
            if (result == null)
            {
                throw new NullModelException();
            }
            result.Name = entity.Name;
            result.Teacher = entity.Teacher;
            result.Room = entity.Room;
            return result;
        }
    }
}
