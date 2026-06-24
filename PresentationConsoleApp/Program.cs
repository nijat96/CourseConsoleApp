using System;
using Domain.Entities;
using PresentationConsoleApp.Controllers;
using Service.Implementation;

namespace PresentationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentService = new StudentService();
            var groupService = new GroupService();
            var groupController = new GroupController(groupService);
            var studentController = new StudentController(studentService,groupService);
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Main Menu ===");
                Console.WriteLine("1. Manage Groups");
                Console.WriteLine("2. Manage Students");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                var mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        ManageGroups(groupController);
                        break;

                    case "2":
                        ManageStudents(studentController);
                        break;

                    case "3":
                        exit = true;
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void ManageGroups(GroupController controller)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n=== Group Menu ===");
                Console.WriteLine("1. Get all groups");
                Console.WriteLine("2. Get group by ID");
                Console.WriteLine("3. Create group");
                Console.WriteLine("4. Update group");
                Console.WriteLine("5. Delete group");
                Console.WriteLine("6. Search groups");
                Console.WriteLine("7. Get groups by teacher");
                Console.WriteLine("8. Get groups by room");
                Console.WriteLine("9. Back to main menu");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.GetAll();
                        break;
                    case "2":
                        Console.Write("Enter group ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        controller.GetById(id);
                        break;
                    case "3":
                        Console.Write("Enter group name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter teacher: ");
                        string teacher = Console.ReadLine();
                        Console.Write("Enter room: ");
                        string room = Console.ReadLine();
                        var newGroup = new Group(name, teacher, room);
                        controller.Create(newGroup);
                        break;
                    case "4":
                        Console.Write("Enter group ID to update: ");
                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        Console.Write("Enter new group name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new teacher: ");
                        string newTeacher = Console.ReadLine();
                        Console.Write("Enter new room: ");
                        string newRoom = Console.ReadLine();
                        var updatedGroup = new Group(newName,newTeacher,newRoom);
                        controller.Update(updateId, updatedGroup);
                        break;
                    case "5":
                        Console.Write("Enter group ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        controller.Delete(deleteId);
                        break;
                    case "6":
                        Console.Write("Enter search query: ");
                        string query = Console.ReadLine();
                        controller.Search(query);
                        break;
                    case "7":
                        Console.Write("Enter teacher name: ");
                        string teacherName = Console.ReadLine();
                        controller.GetByTeacher(teacherName);
                        break;
                    case "8":
                        Console.Write("Enter room name: ");
                        string roomName = Console.ReadLine();
                        controller.GetByRoom(roomName);
                        break;
                    case "9":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void ManageStudents(StudentController controller)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n=== Student Menu ===");
                Console.WriteLine("1. Get all students");
                Console.WriteLine("2. Get student by ID");
                Console.WriteLine("3. Create student");
                Console.WriteLine("4. Update student");
                Console.WriteLine("5. Delete student");
                Console.WriteLine("6. Search students");
                Console.WriteLine("7. Get students by age");
                Console.WriteLine("8. Get students by group ID");
                Console.WriteLine("9. Order students by age");
                Console.WriteLine("10. Order students by group");
                Console.WriteLine("11. Get students (paged)");
                Console.WriteLine("12. Back to main menu");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.GetAll();
                        break;
                    case "2":
                        Console.Write("Enter student ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        controller.GetById(id);
                        break;
                    case "3":
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter student surnamename: ");
                        string surname = Console.ReadLine();
                        Console.Write("Enter age: ");
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            Console.WriteLine("Invalid age.");
                            return;
                        }
                        Console.Write("Enter group ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int groupId))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        var newStudent = new Student(name,surname,age,groupId);
                        controller.Create(newStudent);
                        break;
                    case "4":
                        Console.Write("Enter student ID to update: ");
                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new surname: ");
                        string newSurname = Console.ReadLine();
                        Console.Write("Enter new age: ");
                        if (!int.TryParse(Console.ReadLine(), out int newAge))
                        {
                            Console.WriteLine("Invalid age.");
                            return;
                        }
                        Console.Write("Enter new group ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int newGroupId))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        var updatedStudent = new Student(newName,newSurname,newAge,newGroupId);
                        controller.Update(updateId, updatedStudent);
                        break;
                    case "5":
                        Console.Write("Enter student ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        controller.Delete(deleteId);
                        break;
                    case "6":
                        Console.Write("Enter search query: ");
                        string query = Console.ReadLine();
                        controller.Search(query);
                        break;
                    case "7":
                        Console.Write("Enter age: ");
                        if (!int.TryParse(Console.ReadLine(), out int searchAge))
                        {
                            Console.WriteLine("Invalid age.");
                            return;
                        }
                        controller.GetByAge(searchAge);
                        break;
                    case "8":
                        Console.Write("Enter group ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int searchGroupId))
                        {
                            Console.WriteLine("Invalid ID.");
                            return;
                        }
                        controller.GetByGroupId(searchGroupId);
                        break;
                    case "9":
                        controller.OrderByAge();
                        break;
                    case "10":
                        controller.OrderByGroups();
                        break;
                    case "11":
                        Console.Write("Enter page number: ");
                        if (!int.TryParse(Console.ReadLine(), out int page))
                        {
                            Console.WriteLine("Invalid number.");
                            return;
                        }
                        Console.Write("Enter page size: ");
                        if (!int.TryParse(Console.ReadLine(), out int pageSize))
                        {
                            Console.WriteLine("Invalid size.");
                            return;
                        }
                        controller.GetPaged(page, pageSize);
                        break;
                    case "12":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
