using Service.Implementation;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace PresentationConsoleApp.Controllers
{
    public class GroupController
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        public void GetAll()
        {
            try
            {
                Console.WriteLine($"| {"ID",-5} | {"Group name",-12} | {"Teacher",-12} | {"Room",-6} |");
                var result = _groupService.GetAllGroups();
                foreach (var group in result)
                {
                    Console.WriteLine($"| {group.Id,-5} | {group.Name,-12} | {group.Teacher,-12} | {group.Room,-6} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetById(int id)
        {
            try
            {
                var group = _groupService.GetGroupById(id);
                if (group != null)
                {
                    Console.WriteLine($"Found group: {group.Id} - {group.Name} ({group.Teacher}, Room {group.Room})");
                }
                else
                {
                    Console.WriteLine("Group not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Create(Group group)
        {
            try
            {
                _groupService.CreateGroup(group);
                Console.WriteLine($"Group '{group.Name}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(int id, Group group)
        {
            try
            {
                var updated = _groupService.UpdateGroup(id, group);
                if (updated != null)
                {
                    Console.WriteLine($"Group {id} updated successfully.");
                }
                else
                {
                    Console.WriteLine("Update failed. Group not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var existing = _groupService.GetGroupById(id);
                if (existing != null)
                {
                    _groupService.DeleteGroup(id);
                    Console.WriteLine($"Group {id} deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Delete failed. Group not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Search(string query)
        {
            try
            {
                var results = _groupService.Search(query);
                Console.WriteLine($"Search results for '{query}':");
                foreach (var group in results)
                {
                    Console.WriteLine($"| {group.Id,-5} | {group.Name,-12} | {group.Teacher,-12} | {group.Room,-6} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetByTeacher(string teacher)
        {
            try
            {
                var results = _groupService.GetAllGroupsByTeacher(teacher);
                Console.WriteLine($"Groups taught by {teacher}:");
                foreach (var group in results)
                {
                    Console.WriteLine($"| {group.Id,-5} | {group.Name,-12} | {group.Teacher,-12} | {group.Room,-6} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetByRoom(string room)
        {
            try
            {
                var results = _groupService.GetAllGroupsByRoom(room);
                Console.WriteLine($"Groups in room {room}:");
                foreach (var group in results)
                {
                    Console.WriteLine($"| {group.Id,-5} | {group.Name,-12} | {group.Teacher,-12} | {group.Room,-6} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
