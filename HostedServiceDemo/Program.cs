using AutoMapper;
using DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HostedServiceDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddMediatR(Assembly.Load("DataService"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddHostedService<MyService>();

            var automapperConfig = new MapperConfiguration(config =>
            {
                config.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();//Camel命名与Pascal命名的兼容,配置之后会映射property_name到PropertyName
                config.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
                config.AddProfile(new DataService.Profile.AutoMapperProfile());
            });
            builder.Services.AddSingleton(automapperConfig.CreateMapper());//只有一个单例

            builder.Services.AddDbContext<MyDbContext>(opt =>
            {
                string connStr = "Data Source=.;Initial Catalog=Demo1;Integrated Security=true;User ID=sa; Password=sa;Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
                opt.UseSqlServer(connStr);
            });

            var app = builder.Build();

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