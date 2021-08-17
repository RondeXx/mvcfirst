using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication12.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-95UI604; database=BirimDB; integrated security=true;");
        }
        public DbSet<Birim> Birims { get; set; }

        public DbSet<Personel> Personels { get; set; }

        public DbSet <Admin> Admins { get; set; }
    }
}
