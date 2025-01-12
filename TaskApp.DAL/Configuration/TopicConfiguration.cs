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
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
           builder.HasMany(t=>t.Assignments).WithOne(a=>a.Topics).HasForeignKey(a=>a.TopicId);
        }
    }
}
