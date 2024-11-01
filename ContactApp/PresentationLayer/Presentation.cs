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
        private readonly ContactDetailController _contactDetailController = new ContactDetailController();

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
                Console.WriteLine("\nStaff Menu:\n1. Work on Contacts\n2. Work on Contact Details\n3. Logout");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: DisplayContactMenu(); break;
                    case 2: DisplayContactDetailMenu(); break;
                    case 3: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        private void DisplayContactMenu()
        {
            Console.WriteLine("\n1. Add Contact\n2. Modify Contact\n3. Delete Contact\n4. Display All Contacts\n5. Logout");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: AddContact(); break;
                case 2: ModifyContact(); break;
                case 3: DeleteContact(); break;
                case 4: DisplayAllContacts(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        private void DisplayContactDetailMenu()
        {
            Console.WriteLine("\n1. Add Contact Detail\n2. Modify Contact Detail\n3. Delete Contact Detail\n4. Display All Contact Details\n5. Logout");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: AddContactDetail(); break;
                case 2: ModifyContactDetail(); break;
                case 3: DeleteContactDetail(); break;
                case 4: DisplayAllContactDetails(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        //private void DisplayStaffMenu()
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("\nStaff Menu:");
        //        Console.WriteLine("1. Add Contact");
        //        Console.WriteLine("2. Modify Contact");
        //        Console.WriteLine("3. Delete Contact");
        //        Console.WriteLine("4. Display All Contacts");
        //        Console.WriteLine("5. Logout");

        //        int choice = int.Parse(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1:
        //                AddContact();
        //                break;
        //            case 2:
        //                ModifyContact();
        //                break;
        //            case 3:
        //                DeleteContact();
        //                break;
        //            case 4:
        //                DisplayAllContacts();
        //                break;
        //            case 5:
        //                return;
        //        }
        //    }
        //}

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

        private List<ContactDetail> contactDetails = new List<ContactDetail>();

        private void AddContactDetail()
        {
            Console.WriteLine("Enter Contact Detail ID:");
            int detailID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Contact ID associated with this detail:");
            int contactID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Detail (e.g., Phone Number, Email):");
            string detail = Console.ReadLine();

            ContactDetail newDetail = new ContactDetail
            {
                DetailID = detailID,
                ContactID = contactID,
                Detail = detail,
                IsActive = true
            };

            contactDetails.Add(newDetail);
            Console.WriteLine("Contact Detail added successfully!");
        }

        // Method to modify an existing contact detail
        private void ModifyContactDetail()
        {
            Console.WriteLine("Enter Contact Detail ID to modify:");
            int detailID = int.Parse(Console.ReadLine());

            ContactDetail existingDetail = contactDetails.Find(detail => detail.DetailID == detailID && detail.IsActive);
            if (existingDetail != null)
            {
                Console.WriteLine("Enter new Contact ID:");
                existingDetail.ContactID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new Detail:");
                existingDetail.Detail = Console.ReadLine();

                Console.WriteLine("Contact Detail modified successfully!");
            }
            else
            {
                Console.WriteLine("Contact Detail not found or is inactive.");
            }
        }

        // Method to delete a contact detail
        private void DeleteContactDetail()
        {
            Console.WriteLine("Enter Contact Detail ID to delete:");
            int detailID = int.Parse(Console.ReadLine());

            ContactDetail existingDetail = contactDetails.Find(detail => detail.DetailID == detailID && detail.IsActive);
            if (existingDetail != null)
            {
                existingDetail.IsActive = false;
                Console.WriteLine("Contact Detail deleted successfully!");
            }
            else
            {
                Console.WriteLine("Contact Detail not found or is already inactive.");
            }
        }

        // Method to display all active contact details
        private void DisplayAllContactDetails()
        {
            Console.WriteLine("List of Active Contact Details:");
            foreach (var detail in contactDetails)
            {
                if (detail.IsActive)
                {
                    Console.WriteLine($"Detail ID: {detail.DetailID}, Contact ID: {detail.ContactID}, Detail: {detail.Detail}, Status: Active");
                }
            }
        }


    }
}
