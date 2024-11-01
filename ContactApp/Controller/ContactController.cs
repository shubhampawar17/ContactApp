using ContactApp.Models;
using ContactApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Controller
{
    public class ContactController
    {
        private readonly ContactService _contactService = new ContactService();

        public void AddContact(Contact contact)
        {
            _contactService.AddContact(contact);
        }
        public void ModifyContact(int id, string name)
        {
            _contactService.ModifyContact(id, name);
        }
        public void DeleteContact(int id)
        {
            _contactService.DeleteContact(id);
        }
        public List<Contact> GetAllContacts()
        {
            return _contactService.GetAllContacts();
        }
        public Contact GetContactById(int id)
        {
            return _contactService.GetContactById(id);
        }
        //======================================================================================================
        //public void AddContact(Contact contact) => _contactService.AddContact(contact);

        //public void ModifyContact(int id, string name) => _contactService.ModifyContact(id, name);

        //public void DeleteContact(int id) => _contactService.DeleteContact(id);

        //public List<Contact> GetAllContacts() => _contactService.GetAllContacts();

        //public Contact GetContactById(int id) => _contactService.GetContactById(id);


    }
}
