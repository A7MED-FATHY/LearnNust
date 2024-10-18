using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Models;

namespace Online_Learning_Platform.Data
{





    public class ApplicationDbContext :IdentityDbContext<AppliactionUser>
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
       

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source= LAPTOP-OIGMED40 ;Initial Catalog=Online Learning Platform;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
);
            base.OnConfiguring(optionsBuilder);
        }




    }
}