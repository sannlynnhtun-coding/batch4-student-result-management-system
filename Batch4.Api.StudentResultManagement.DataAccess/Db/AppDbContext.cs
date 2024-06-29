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
            modelBuilder.Entity<StudentCourseModel>()
                .HasKey(sc => sc.StudentCourseId);

            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<ResultModel>(entity =>
            {
                entity.Property(e => e.Status)
                      .HasConversion<int>();

                entity.HasOne(r => r.Course)
                      .WithMany(c => c.Results)
                      .HasForeignKey(r => r.CourseId);

                entity.HasOne(r => r.Student)
                      .WithMany(s => s.Results)
                      .HasForeignKey(r => r.StudentId);
            });

            modelBuilder.Entity<StudentModel>(entity =>
            {
                entity.Property(e => e.GenderStatus)
                      .HasConversion<int?>();
            });

            base.OnModelCreating(modelBuilder);
        }
    }


}

