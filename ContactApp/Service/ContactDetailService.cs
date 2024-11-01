using ContactApp.Exceptions;
using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Service
{
    public class ContactDetailService
    {
        private List<ContactDetail> _contactDetails = new List<ContactDetail>();

        public ContactDetail GetContactDetailById(int id)
        {
            var detail = _contactDetails.FirstOrDefault(d => d.Id == id && d.IsActive);
            if (detail == null) throw new ContactDetailNotFoundException("Contact detail not found or inactive.");
            return detail;
        }
        public void AddContactDetail(ContactDetail detail) => _contactDetails.Add(detail);
        public void ModifyContactDetail(int id, string newDetail) => GetContactDetailById(id).Detail = newDetail;
        public void DeleteContactDetail(int id) => GetContactDetailById(id).IsActive = false;
        public List<ContactDetail> GetAllContactDetails() => _contactDetails.Where(d => d.IsActive).ToList();
    }
}
