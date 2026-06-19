
using Service.Implementation;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace PresentationConsoleApp.Controllers
{
    public class StudentController
    {
        private readonly StudentService _studentService = new StudentService();

        public void GetAll()
        {
            Console.WriteLine($"| {"ID",-5} | {"Name",-12} | {"Age",-5} | {"Group ID",-8} |");
            var result = _studentService.GetAllStudents();
            foreach (var student in result)
            {
                Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
            }
        }

        public void GetById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student != null)
                Console.WriteLine($"Found student: {student.Id} - {student.Name}, Age {student.Age}, Group {student.GroupId}");
            else
                Console.WriteLine("Student not found.");
        }

        public void Create(Student student)
        {
            _studentService.CreateStudent(student);
            Console.WriteLine($"Student '{student.Name}' created successfully.");
        }

        public void Update(int id, Student student)
        {
            var updated = _studentService.UpdateSudent(id, student);
            if (updated != null)
                Console.WriteLine($"Student {id} updated successfully.");
            else
                Console.WriteLine("Update failed. Student not found.");
        }

        public void Delete(int id)
        {
            var existing = _studentService.GetStudentById(id);
            if (existing != null)
            {
                _studentService.DeleteStudent(id);
                Console.WriteLine($"Student {id} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Delete failed. Student not found.");
            }
        }

        public void Search(string query)
        {
            var results = _studentService.SearchStudent(query);
            Console.WriteLine($"Search results for '{query}':");
            foreach (var student in results)
            {
                Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
            }
        }

        public void GetByAge(int age)
        {
            var results = _studentService.GetStudentsByAge(age);
            Console.WriteLine($"Students with age {age}:");
            foreach (var student in results)
            {
                Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
            }
        }

        public void GetByGroupId(int groupId)
        {
            var results = _studentService.GetStudentsByGroupId(groupId);
            Console.WriteLine($"Students in group {groupId}:");
            foreach (var student in results)
            {
                Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
            }
        }

        public void OrderByAge()
        {
            var results = _studentService.OrderByAge();
            Console.WriteLine("Students ordered by age:");
            foreach (var student in results)
            {
                Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
            }
        }

        public void OrderByGroups()
        {
            var results = _studentService.OrderByGroups();
            Console.WriteLine("Students ordered by group ID:");
            foreach (var student in results)
            {
                Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
            }
        }

        public void GetPaged(int page, int pageSize)
        {
            var results = _studentService.GetStudents(page, pageSize);
            Console.WriteLine($"Page {page} (size {pageSize}):");
            foreach (var student in results)
            {
                Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
            }
        }
    }
}
