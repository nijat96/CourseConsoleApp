using Domain.Entities;
using System;


namespace Interface
{
    public interface IGroupService
    {
        // 1 - Create Group, 2 - Update group, 3 - Delete Group, 4 - Get group  by id, 5 - Get all groups by teacher ,
        // 6 - Get all groups by room, 7 - Get all groups, 14- Search method for groups 
        void CreateGroup(Group group);
        Group UpdateGroup(int id, Group group);
        void DeleteGroup(int id);
        Group GetGroupById(int id);
        List<Group> GetAllGroups();
        List<Group> GetAllGroupsByTeacher(string teacher);
        List<Group> GetAllGroupsByRoom(string room);
        List<Group> Search(string query);



       
    }
}