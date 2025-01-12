﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Model.Base;

namespace TaskApp.Core.Model
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
