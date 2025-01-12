using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Auth;
using TaskApp.Business.Helper.Exception;
using TaskApp.Business.Service.Interface;
using TaskApp.Core.Model;

namespace TaskApp.Business.Service.Implementation
{
    internal class UserService : IUserService
    {
        UserManager<Employee> userManager;
        private readonly IMapper mapper;

        public UserService(UserManager<Employee> employee, IMapper mapper)
        {
            this.userManager = employee;
            this.mapper = mapper;
        }



        public async Task Register(RegisterDto registerDto)
        {
            var user = await userManager.FindByNameAsync(registerDto.Username);
            if (user == null)
            {
                throw new NotFoundException<Employee>();
            }
            var register = mapper.Map<Employee>(user);
            var result = await userManager.CreateAsync(register);

            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                throw new Exception(sb.ToString());
            }
        }
        public Task<string> Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

    }
}
