using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Repository.Repositories.Implementation
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly AppDbContext<Student> _students;
        public void Add(Student entity)
        {
            try
            {
                if (entity != null)
                    _students.list.Add(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student entity)
        {
            _students.list.Remove(entity);
        }

        public Student Get(Predicate<Student> predicate)
        {
            return _students.list.Find(predicate);
        }

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            return _students.list.FindAll(predicate);
        }
        public List<Student> GetAll()
        {
            return _students.list;
        }

        public List<Student> GetAll(int page, int pageSize)
        {
            return GetAll().Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Student> Search(string query)
        {
            return GetAll(x =>
                                x.Name.ToLower().Contains(query.Trim().ToLower()) ||
                                x.Surname.ToLower().Contains(query.Trim().ToLower()) ||
                                x.Group.Name.ToLower().Contains(query.Trim().ToLower()) ||
                                x.Group.Teacher.ToLower().Contains(query.Trim().ToLower()));
        }

        public Student Update(Student entity, int id)
        {
            var result = Get(x => x.Id == id);
            result.Name = entity.Name;
            result.Surname = entity.Surname;
            result.Age = entity.Age;
            result.GroupId = entity.GroupId;
            return result;
        }


    }
}
