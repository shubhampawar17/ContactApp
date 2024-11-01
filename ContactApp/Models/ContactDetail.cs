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
        public int ContactID { get; set; } // Foreign key reference to Contact
        public int DetailID { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Detail { get; internal set; }
    }
}
