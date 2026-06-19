using Domain.Entities;
using Repository.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;
using Interface;

namespace Service.Implementation
{
    public class GroupService : IGroupService
    {
        private static int count;
        private readonly GroupRepository _repository =new();
        public void CreateGroup(Group group)
        {
            count++;
            group.SetId(count);
            _repository.Add(group);
        }

        public void DeleteGroup(int id)
        {
            var founded = GetGroupById(id);
            _repository.Delete(founded);
        }

        public List<Group> GetAllGroups()
        {
            return _repository.GetAll();
        }

        public List<Group> GetAllGroupsByRoom(string teacher)
        {
            return _repository.GetAll(x=>x.Teacher == teacher);
        }

        public List<Group> GetAllGroupsByTeacher(string room)
        {
            return _repository.GetAll(x=>x.Room == room);
        }

        public Group GetGroupById(int id)
        {
            return _repository.Get(x=>x.Id == id);
        }

        public List<Group> Search(string query)
        {
            return _repository.Search(query);
        }

        public Group UpdateGroup(int id, Group group)
        { 
            var result = _repository.Update(group, id);

            return result;
        }
    }
}
