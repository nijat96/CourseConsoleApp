using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Group
    {
        //name, teacher, room
        private static int ID;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }

        public Group(string name, string teacher, string room)
        {
            ID++;
            Id = ID;
            Name = name;
            Teacher = teacher;
            Room = room;
        }
    }
}
