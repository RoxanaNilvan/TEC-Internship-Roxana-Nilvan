using ApiApp.Model;
using Microsoft.EntityFrameworkCore;

namespace Internship.Model
{
    public class APIDbContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PersonDetails> PersonDetails { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public string DbPath { get; }

        public APIDbContext()
        {
            var path = "C:\\Users\\roxan\\OneDrive\\Desktop\\GitHub\\TEC-Internship-Roxana-Nilvan\\Database\\";
            DbPath = System.IO.Path.Join(path, "Internship.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
