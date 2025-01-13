using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Assignment;
using TaskApp.Core.Model;

namespace TaskApp.Business.Helper.Mapper
{
    public class AssignmentProfile:Profile
    {
        public AssignmentProfile()
        {
            CreateMap<GetAssignmentDto, Assignment>();
            CreateMap<UpdateAssignmentDto, Assignment>();
            CreateMap<CreateAssignmentDto, Assignment>();
        }
    }
}
