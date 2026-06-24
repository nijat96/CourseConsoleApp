
using Service.Implementation;
using Domain.Entities;
using System;
using System.Collections.Generic;
using PresentationConsoleApp.Validation;

namespace PresentationConsoleApp.Controllers
{
    public class StudentController
    {
        private readonly StudentService _studentService;
        private readonly GroupService _groupService;

        public StudentController(StudentService studentService, GroupService groupService)
        {
            _studentService = studentService;
            _groupService = groupService;
        }

        public void GetAll()
        {
            try
            {

                Console.WriteLine($"| {"ID",-5} | {"Name",-12} | {"Age",-5} | {"Group ID",-8} |");
                var result = _studentService.GetAllStudents();
                foreach (var student in result)
                {
                    Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
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
                var student = _studentService.GetStudentById(id);
                if (student != null)
                    Console.WriteLine($"Found student: {student.Id} - {student.Name}, Age {student.Age}, Group {student.GroupId}");
                else
                    Console.WriteLine("Student not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Create(Student student)
        {
            try
            {

                if (StudentValidation.CheckName(student.Name) && StudentValidation.CheckName(student.Surname) &&
                    Service.Validations.StudentValidation.CheckStudentGroupId(student.GroupId, _groupService))
                {
                    _studentService.CreateStudent(student);
                    Console.WriteLine($"Student '{student.Name}' created successfully.");
                }
                else
                {
                    Console.WriteLine("xeta ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(int id, Student student)
        {
            try
            {
                if (StudentValidation.CheckName(student.Name) && StudentValidation.CheckName(student.Surname) &&
                    Service.Validations.StudentValidation.CheckStudentGroupId(student.GroupId,_groupService))
                {
                    var updated = _studentService.UpdateStudent(id, student);
                    if (updated != null)
                        Console.WriteLine($"Student {id} updated successfully.");
                    else
                        Console.WriteLine("Update failed. Student not found.");
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Search(string query)
        {
            try
            {
                var results = _studentService.SearchStudent(query);
                Console.WriteLine($"Search results for '{query}':");
                foreach (var student in results)
                {
                    Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetByAge(int age)
        {
            try
            {
                var results = _studentService.GetStudentsByAge(age);
                Console.WriteLine($"Students with age {age}:");
                foreach (var student in results)
                {
                    Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetByGroupId(int groupId)
        {
            try
            {
                var results = _studentService.GetStudentsByGroupId(groupId);
                Console.WriteLine($"Students in group {groupId}:");
                foreach (var student in results)
                {
                    Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void OrderByAge()
        {
            try
            {
                var results = _studentService.OrderByAge();
                Console.WriteLine("Students ordered by age:");
                foreach (var student in results)
                {
                    Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void OrderByGroups()
        {
            try
            {
                var results = _studentService.OrderByGroups();
                Console.WriteLine("Students ordered by group ID:");
                foreach (var student in results)
                {
                    Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }
        }

        public void GetPaged(int page, int pageSize)
        {
            try
            {
                var results = _studentService.GetStudents(page, pageSize);
                Console.WriteLine($"Page {page} (size {pageSize}):");
                foreach (var student in results)
                {
                    Console.WriteLine($"| {student.Id,-5} | {student.Name,-12} | {student.Age,-5} | {student.GroupId,-8} |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
