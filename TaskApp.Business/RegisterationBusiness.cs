using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.Service.Implementation;
using TaskApp.Business.Service.Interface;

namespace TaskApp.Business
{
    public static class RegisterationBusiness
    {
        public static void AddRegisterationBusiness(this IServiceCollection services)
        {
            services.AddScoped<ITagService,TagService>();
            /*services.AddScoped<IUserService ,UserService>();*/
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
