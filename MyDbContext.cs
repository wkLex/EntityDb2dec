using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDb2dec
{
    internal class MyDbContext : DbContext
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=EntityDb2;Trusted_Connection=True;MultipleActiveResultSets=true";
       
        // We specifing the dataset going to be the class, object Car and the table has the name of Cars
        public DbSet<Car> Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
        }
    }
}
