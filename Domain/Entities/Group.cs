using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Group
    {
        //name, teacher, room
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }

        public Group(string name, string teacher, string room)
        {
            Name = name;
            Teacher = teacher;
            Room = room;
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
