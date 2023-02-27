using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Model
{
    public class Context
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
