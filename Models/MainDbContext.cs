using SQLite.CodeFirst;
using System.Data.Entity;

namespace Skelton.WpfMahAppsPrismReactiveProperty.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base("name=main") { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Emploees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new DatabaseInitializer(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }

    class DatabaseInitializer : SqliteCreateDatabaseIfNotExists<MainDbContext>
    {
        public DatabaseInitializer(DbModelBuilder builder) : base(builder) { }

        protected override void Seed(MainDbContext context)
        {
            base.Seed(context);

            var companies = new[]
            {
                new Company { Name = "ABC" },
                new Company { Name = "DEF" },
            };
            context.Companies.AddRange(companies);
            var emploees = new[] {
                new Employee { Name = "John", Company = companies[0] },
                new Employee { Name = "Diana", Company = companies[1] },
            };
            context.Emploees.AddRange(emploees);
        }
    }
}
