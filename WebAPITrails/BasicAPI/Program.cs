using BasicAPI.Filters;
using BasicAPI.Models;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Configuration;

namespace BasicAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers(
                opt =>
                {
                    opt.Filters.Add<JsonExceptionFilter>();
                    opt.Filters.Add<RequireHttpsOrCloseAttr>();
                }
                );
            builder.Services.Configure<HotelInfo>(
                builder.Configuration.GetSection("Info")
                );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRouting(Opt => Opt.LowercaseUrls = true);
            builder.Services.AddCors(Opt =>
            {
                Opt.AddPolicy("AllowSomeUrls", policy => policy.AllowAnyOrigin());
            });

            builder.Services.AddApiVersioning(
                opt =>
                {
                    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                    opt.ApiVersionReader = new MediaTypeApiVersionReader();
                    opt.AssumeDefaultVersionWhenUnspecified = true;
                    opt.ReportApiVersions = true;
                    opt.ApiVersionSelector = new CurrentImplementationApiVersionSelector(opt);

                }
                );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else

            {
                app.UseHsts();
            }


            app.UseAuthorization();
            app.UseCors("AllowSomeUrls");

            app.MapControllers();

            app.Run();
        }
    }
}