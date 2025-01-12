using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Model.Base;

namespace TaskApp.Core.Model
{
    public class Assignment:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public string UserId { get; set; }
        public Employee Employees { get; set; }


        public int TopicId { get; set; }
        public Topic Topics { get; set; }

        public ICollection<TagAssignment> TagsAssignments { get; set; }
    }
}
