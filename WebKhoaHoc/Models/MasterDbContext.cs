using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebKhoaHoc.Models
{
    public class MasterDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DbSet<ApplicationRole> AspNetRoles { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CombinedCourse> CombinedCourses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {
        }
    }
}