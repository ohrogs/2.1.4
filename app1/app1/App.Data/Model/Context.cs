using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Model
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = "Server=localhost\\sql2019;Database=APP.DATABASE; User Id=APP.USER; Password=APP.PASSWORD; encrypt=false";

            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//ing posso inserirmi nela creazione del model ed posso inserirmi dopo
        {
            modelBuilder.Entity<Person>(Entity => 
            Entity.HasOne(p => p.User).
            WithMany().
            HasForeignKey(p => p.Iduser));
            //modelBuilder.Entity<User>().ToTable("users");
            base.OnModelCreating(modelBuilder);
        }
    }
}
