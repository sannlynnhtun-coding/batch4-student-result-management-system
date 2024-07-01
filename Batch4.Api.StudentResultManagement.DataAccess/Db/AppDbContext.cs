using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.StudentResultManagement.DataAccess.Db
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<ResultModel> Results { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<StudentCourseModel> StudentCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultModel>(entity =>
            {
                entity.Property(e => e.Status)
                      .HasConversion<int>();
            });

            modelBuilder.Entity<StudentModel>(entity =>
            {
                entity.Property(e => e.GenderStatus)
                      .HasConversion<int?>();
            });

            base.OnModelCreating(modelBuilder);
        }


    }

    public class StudentCreateRequest
    {
        public StudentModel Student { get; set; }
        public List<int> CourseIds { get; set; }
    }

    public class ResultCreateRequest
    {
        public int ResultId { get; set; }

        public decimal Score { get; set; }

        public EnumStatus Status { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }
    }

}

