using ContactApp.Exceptions;
using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Service
{
    public class ContactService
    {
        private List<Contact> _contacts = new List<Contact>
        {
            new Contact { Id = 1, Name = "John Doe", IsActive = true },
            new Contact { Id = 2, Name = "Jane Smith", IsActive = true }
        };

        public Contact GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id && c.IsActive);
            if (contact == null)
                throw new ContactNotFoundException("Contact not found or is inactive.");
            return contact;
        }

        public void AddContact(Contact contact) => _contacts.Add(contact);

        public void ModifyContact(int id, string name)
        {
            var contact = GetContactById(id);
            contact.Name = name;
        }

        public void DeleteContact(int id)
        {
            var contact = GetContactById(id);
            contact.IsActive = false;
        }

        public List<Contact> GetAllContacts() => _contacts.Where(c => c.IsActive).ToList();

        //private List<Contact> _contacts = new List<Contact>();
        //private List<ContactDetail> _contactDetails = new List<ContactDetail>();

        //// Method to add a contact
        //public void AddContact(Contact contact)
        //{
        //    _contacts.Add(contact);
        //}

        //// Method to modify a contact
        //public void ModifyContact(int id, string newName)
        //{
        //    var contact = _contacts.Find(c => c.Id == id);
        //    if (contact != null)
        //    {
        //        contact.Name = newName;
        //    }
        //}

        //// Method to delete a contact (soft delete)
        //public void DeleteContact(int id)
        //{
        //    var contact = _contacts.Find(c => c.Id == id);
        //    if (contact != null)
        //    {
        //        _contacts.Remove(contact);
        //    }
        //}

        //// Method to get all contacts
        //public List<Contact> GetAllContacts()
        //{
        //    return _contacts;
        //}

        //// CRUD operations for Contact Details
        //public void AddContactDetail(ContactDetail detail)
        //{
        //    _contactDetails.Add(detail);
        //}

        //public void ModifyContactDetail(int id, string newDetail)
        //{
        //    var detail = _contactDetails.Find(d => d.Id == id);
        //    if (detail != null)
        //    {
        //        detail.Detail = newDetail;
        //    }
        //}

        //public void DeleteContactDetail(int id)
        //{
        //    var detail = _contactDetails.Find(d => d.Id == id);
        //    if (detail != null)
        //    {
        //        _contactDetails.Remove(detail);
        //    }
        //}

        //public List<ContactDetail> GetAllContactDetails()
        //{
        //    return _contactDetails;
        //}

    }
}