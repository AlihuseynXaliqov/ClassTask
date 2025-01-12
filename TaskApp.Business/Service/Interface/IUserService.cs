using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Auth;

namespace TaskApp.Business.Service.Interface
{
    public interface IUserService
    {
        public Task<string> Login(LoginDto loginDto);
        public Task Register(RegisterDto registerDto);
    }
}
