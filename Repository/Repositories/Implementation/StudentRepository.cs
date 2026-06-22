using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Repository.Repositories.Implementation
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly AppDbContext<Student> _students = new();
        public void Add(Student entity)
        {
            if (entity == null)
            {
                throw new NullModelException();
            }
            _students.list.Add(entity);
        }

        public void Delete(Student entity)
        {
            if (entity == null)
            {
                throw new NullModelException();
            }
            _students.list.Remove(entity);
        }
        public Student Get(Predicate<Student> predicate)
        {
            return _students.list.Find(predicate) ?? throw new NullModelException();
        }
        public List<Student> GetAll(Predicate<Student> predicate) => _students.list.FindAll(predicate) ?? throw new NullModelException();
        public List<Student> GetAll() => _students.list ?? throw new NullModelException();

        public List<Student> GetAll(int page, int pageSize)
        {
            try
            {
                return GetAll().Skip((page - 1) * pageSize).Take(pageSize).ToList() ?? throw new NullModelException();
            }
            catch
            {
                var pageCount = (int)(GetAll().Count() / pageSize);
                return GetAll(pageCount, pageSize);
            }
        }
        public List<Student> Search(string query)
        {
            return GetAll(x => x != null && (
                                x.Name.ToLower().Contains(query.Trim().ToLower()) ||
                                x.Surname.ToLower().Contains(query.Trim().ToLower()) ||
                                (x.Surname + " " + x.Name).Trim().ToLower().Contains(query.Trim().ToLower()) ||
                                (x.Name + " " + x.Surname).Trim().ToLower().Contains(query.Trim().ToLower()))) ?? throw new NullModelException();
        }

        public Student Update(Student entity, int id)
        {
            var result = Get(x => x.Id == id);
            if (result == null)
            {
                throw new NullModelException();
            }
            result.Name = entity.Name;
            result.Surname = entity.Surname;
            result.Age = entity.Age;
            result.GroupId = entity.GroupId;
            return result;
        }


    }
}
