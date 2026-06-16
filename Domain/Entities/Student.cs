using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Student
    {
        //name, surname, age, group,
        private static int ID;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Student(string name, string surname, int age)
        {
            ID++;
            Id = ID;
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
