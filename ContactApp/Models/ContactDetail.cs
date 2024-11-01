using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public int ContactId { get; set; } // Foreign key reference to Contact
        public string Detail { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
