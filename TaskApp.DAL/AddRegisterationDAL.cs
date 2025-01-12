using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.DAL.Repo.Abstraction;
using TaskApp.DAL.Repo.Interface;

namespace TaskApp.DAL
{
    public static class AddRegisterationDAL
    {
        public static void AddRegisterDal(this IServiceCollection services)
        {
            services.AddScoped<ITagRepository, TagRepository>();
        }
    }
}
