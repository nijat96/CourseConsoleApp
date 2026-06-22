using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Student
    {
        //name, surname, age, group,
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int GroupId { get; set; }

        public Student(string name, string surname, int age, int groupId)
        {
            Name = name;
            Surname = surname;
            Age = age;
            GroupId = groupId;
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
