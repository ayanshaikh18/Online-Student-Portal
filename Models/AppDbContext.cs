using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Notice> Notices { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<FacultySubject> FacultySubjects { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FacultySubject>().HasKey(fs => new { fs.FacultyId, fs.SubjectId });

            modelBuilder.Entity<FacultySubject>()
                .HasOne<AppUser>(user => user.Faculty)
                .WithMany(f => f.FacultySubjects)
                .HasForeignKey(fs => fs.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FacultySubject>()
                .HasOne<Subject>(s=>s.Subject)
                .WithMany(s => s.FacultySubjects)
                .HasForeignKey(fs => fs.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Result>()
                .HasOne<AppUser>(res => res.Student)
                .WithMany(students => students.Results)
                .HasForeignKey(res => res.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Result>()
                .HasOne<Subject>(res => res.Subject)
                .WithMany(subjects => subjects.Results)
                .HasForeignKey(res => res.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppUser>()
                .HasMany<Assignment>(f => f.Assignments)
                .WithOne(a => a.Faculty)
                .HasForeignKey(a => a.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Assignments)
                .WithOne(a => a.Subject)
                .HasForeignKey(a => a.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Submission>()
                .HasOne<AppUser>(sub => sub.Student)
                .WithMany(s => s.Submissions)
                .HasForeignKey(sub => sub.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Submission>()
                .HasOne<Assignment>(sub => sub.Assignment)
                .WithMany(a => a.Submissions)
                .HasForeignKey(sub => sub.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);


            
        }
    }
}
    