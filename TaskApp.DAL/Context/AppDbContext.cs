
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Model;

namespace TaskApp.DAL.Context
{
    public class AppDbContext:IdentityDbContext<Employee>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<TagAssignment> TagAssignments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Topic> Topics { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    }
}
