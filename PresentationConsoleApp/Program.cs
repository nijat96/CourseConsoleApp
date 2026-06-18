
using Domain.Entities;
using PresentationConsoleApp.Controllers;
using System.Xml.Linq;

namespace PresentationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new GroupController();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Group Management Menu ===");
                Console.WriteLine("1. Get all groups");
                Console.WriteLine("2. Get group by ID");
                Console.WriteLine("3. Create group");
                Console.WriteLine("4. Update group");
                Console.WriteLine("5. Delete group");
                Console.WriteLine("6. Search groups");
                Console.WriteLine("7. Get groups by teacher");
                Console.WriteLine("8. Get groups by room");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.GetAll();
                        break;

                    case "2":
                        Console.Write("Enter group ID: ");
                        int id = int.Parse(Console.ReadLine());
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
                        int updateId = int.Parse(Console.ReadLine());
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
                        int deleteId = int.Parse(Console.ReadLine());
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
                        exit = true;
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
