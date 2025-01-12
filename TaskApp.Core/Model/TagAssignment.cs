using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Model.Base;

namespace TaskApp.Core.Model
{
    public class TagAssignment : BaseEntity
    {

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}
