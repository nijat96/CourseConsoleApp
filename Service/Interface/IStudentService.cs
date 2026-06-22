using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IStudentService
    {
        //    , 8 - Create Student  9 - Update Student   ,
        // 10- Get student  by id, 11 - Delete student,12 - Get students   by age, 13 - Get all students by group id,
        // , 15 - Search method for students by name or surname.
        void CreateStudent(Student student);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        Student UpdateStudent(int id, Student student);
        List<Student> GetAllStudents();
        List<Student> GetStudentsByAge(int age);
        List<Student> GetStudentsByGroupId(int groupId);
        List<Student> GetStudents(int page, int pageSize);
        List<Student> SearchStudent(string query);
        List<Student> OrderByGroups();
        List<Student> OrderByAge();

    }
}
