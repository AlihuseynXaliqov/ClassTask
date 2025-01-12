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
    public class AssignmentsTagsConfiguration : IEntityTypeConfiguration<TagAssignment>
    {
        public void Configure(EntityTypeBuilder<TagAssignment> builder)
        {
            builder.HasOne(t => t.Tag)
                .WithMany(ta => ta.TagsAssignments)
                .HasForeignKey(ta => ta.TagId);
            
            builder.HasOne(a=>a.Assignment)
                .WithMany(ta=>ta.TagsAssignments)
                .HasForeignKey(ta=>ta.AssignmentId);

            builder.Ignore(ta=>ta.IsDeleted);
        }
    }
}
