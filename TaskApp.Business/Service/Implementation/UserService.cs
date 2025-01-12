using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        private readonly IConfiguration config;

        public UserService(UserManager<Employee> employee, IMapper mapper,IConfiguration config)
        {
            this.userManager = employee;
            this.mapper = mapper;
            this.config = config;
        }



        public async Task Register(RegisterDto registerDto)
        {
            var user = await userManager.FindByNameAsync(registerDto.Username);
            if (user != null)
            {
                throw new NotFoundException<Employee>();
            }
            var register = mapper.Map<Employee>(registerDto);
            var result = await userManager.CreateAsync(register,registerDto.Password);

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
        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByNameAsync(loginDto.Username);
            if (user == null) throw new Exception("Melumatlar sehvdir");
            var result = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result) throw new Exception("Melumatlar sehvdir");

            var _claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: _claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(5)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;


        }
    

}
}
