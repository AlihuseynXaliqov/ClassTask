
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TaskApp.Business;
using TaskApp.Business.DTOs.Tag;
using TaskApp.DAL;
using TaskApp.DAL.Context;

namespace TaskApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateTagValidator>()); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRegisterationBusiness();
            builder.Services.AddRegisterDal();
            builder.Services.AddDbContext<AppDbContext>
               (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            var app = builder.Build();

           /* app.UseGlobalException();*/

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
