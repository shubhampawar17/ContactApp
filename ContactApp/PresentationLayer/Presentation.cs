using ContactApp.Controller;
using ContactApp.Exceptions;
using ContactApp.Models.ContactApp.Models;
using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnauthorizedAccessException = ContactApp.Exceptions.UnauthorizedAccessException;
using ContactApp.Service;

namespace ContactApp.PresentationLayer
{
    public class Presentation
    {
        private readonly UserController _userController = new UserController();
        private readonly ContactController _contactController = new ContactController();

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("1. Enter UserId");
                Console.WriteLine("2. Exit");
                int option = int.Parse(Console.ReadLine());

                if (option == 2)
                {
                    Console.WriteLine("Exiting application...");
                    break; // Exit the application
                }
                else if (option == 1)
                {
                    Console.WriteLine("Enter UserId:");
                    int entereduserId = int.Parse(Console.ReadLine());

                    try
                    {
                        User user = _userController.GetUserById(entereduserId);
                        DisplayMenu(user);
                    }
                    catch (UserNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select again.");
                }
            }
        }

        private void DisplayMenu(User user)
        {
            if (user.IsAdmin)
            {
                DisplayAdminMenu();
            }
            else
            {
                DisplayStaffMenu();
            }
        }

        private void DisplayAdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Modify User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. Display All Users");
                Console.WriteLine("5. Logout");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        ModifyUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        DisplayAllUsers();
                        break;
                    case 5:
                        return;
                }
            }
        }

        private void DisplayStaffMenu()
        {
            while (true)
            {
                Console.WriteLine("\nStaff Menu:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Modify Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display All Contacts");
                Console.WriteLine("5. Logout");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        ModifyContact();
                        break;
                    case 3:
                        DeleteContact();
                        break;
                    case 4:
                        DisplayAllContacts();
                        break;
                    case 5:
                        return;
                }
            }
        }

        private void AddUser()
        {
            Console.Write("Enter User Name: ");
            string name = Console.ReadLine();
            Console.Write("Is the user an admin? (yes/no): ");
            bool isAdmin = Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase);

            _userController.AddUser(new User { Id = new Random().Next(100), Name = name, IsAdmin = isAdmin, IsActive = true });
            Console.WriteLine("User added successfully.");
        }

        private void ModifyUser()
        {
            Console.Write("Enter User ID to modify: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();

            _userController.ModifyUser(id, name);
            Console.WriteLine("User modified successfully.");
        }

        private void DeleteUser()
        {
            Console.Write("Enter User ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            _userController.DeleteUser(id);
            Console.WriteLine("User deleted successfully.");
        }

        private void DisplayAllUsers()
        {
            var users = _userController.GetAllUsers();
            Console.WriteLine("\nList of Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, IsAdmin: {user.IsAdmin}");
            }
        }

        private void AddContact()
        {
            Console.Write("Enter Contact Name: ");
            string name = Console.ReadLine();

            _contactController.AddContact(new Contact { Id = new Random().Next(100), Name = name, IsActive = true });
            Console.WriteLine("Contact added successfully.");
        }

        private void ModifyContact()
        {
            Console.Write("Enter Contact ID to modify: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();

            _contactController.ModifyContact(id, name);
            Console.WriteLine("Contact modified successfully.");
        }

        private void DeleteContact()
        {
            Console.Write("Enter Contact ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            _contactController.DeleteContact(id);
            Console.WriteLine("Contact deleted successfully.");
        }

        private void DisplayAllContacts()
        {
            var contacts = _contactController.GetAllContacts();
            Console.WriteLine("\nList of Contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.Id}, Name: {contact.Name}");
            }
        }
    }
}
