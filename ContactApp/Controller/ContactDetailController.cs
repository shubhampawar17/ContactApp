using ContactApp.Models;
using ContactApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Controller
{
    public class ContactDetailController
    {
        private readonly ContactDetailService _contactDetailService = new ContactDetailService();

        public void AddContactDetail(ContactDetail contactDetail) => _contactDetailService.AddContactDetail(contactDetail);
        public void ModifyContactDetail(int id, string detail) => _contactDetailService.ModifyContactDetail(id, detail);
        public void DeleteContactDetail(int id) => _contactDetailService.DeleteContactDetail(id);
        public List<ContactDetail> GetAllContactDetails() => _contactDetailService.GetAllContactDetails();
        public ContactDetail GetContactDetailById(int id) => _contactDetailService.GetContactDetailById(id);
    }
}
