using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Auth;
using TaskApp.Core.Model;

namespace TaskApp.Business.Helper.Mapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Employee, RegisterDto>().ReverseMap();

        }
    }
}
