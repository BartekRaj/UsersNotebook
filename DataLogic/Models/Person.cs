using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool IsMarried { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public JobPosition Position { get; set; }
        public List<Email> EmailAddresses { get; set; }
        public List<Phone> PhoneNumbers { get; set; }




    }
}