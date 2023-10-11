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

    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<Phone> PhoneNumbers { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

    }

}
   