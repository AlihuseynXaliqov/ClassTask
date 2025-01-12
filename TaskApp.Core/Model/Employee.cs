
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TaskApp.Core.Model.Base;

namespace TaskApp.Core.Model
{
    public class Employee :IdentityUser
    {
        public string Surname { get; set; }

        public ICollection<Assignment> Assignments { get; set; }    

    }
}
