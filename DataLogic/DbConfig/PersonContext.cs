using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{

    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<Phone> PhoneNumbers { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }

    }

}
   