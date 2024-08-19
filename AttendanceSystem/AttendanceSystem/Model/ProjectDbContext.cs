using AttendanceSystem.Model.DBEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model
{
    public class ProjectDbContext : DbContext
    {
        private readonly string _connectionString;

        public ProjectDbContext()
        {
            //ProjectConnectionString
            _connectionString ="Data Source=.\\SQLEXPRESS;Initial Catalog=CSharpB16;User ID=csharpb17; Password = 123456; TrustServerCertificate = True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Adeepta Shushil", Username = "admin", Password = "12345", UserRole = "Admin" }
                );

            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

    }
}
