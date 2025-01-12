using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Model;

namespace TaskApp.DAL.Configuration
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a=>a.Description).IsRequired();

            builder.HasOne(e => e.Employees)
                .WithMany(a => a.Assignments)
                .HasForeignKey(a => a.UserId);

            builder.HasOne(t => t.Topics)
                .WithMany(a => a.Assignments)
                .HasForeignKey(a => a.TopicId);

            
        }
    }
}
