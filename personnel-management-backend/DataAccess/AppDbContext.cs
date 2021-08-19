using Microsoft.EntityFrameworkCore;
using PersonnelMgtBackend.Models;

namespace PersonnelMgtBackend.DataAccess
{
    public class AppDbContext: DbContext
    {
        public DbSet<Person> People { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Seed a person
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = -1, 
                    FirstName = "Tim",
                    LastName = "Walker",
                    Rank = "Corporal"
                });
        }


    }
}
