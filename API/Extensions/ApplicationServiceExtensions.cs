using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(
            this IServiceCollection services, IConfiguration config
            )
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString(
                    "DefaultConnection"));
            });
            services.AddControllers();
            services.AddScoped<ITokenService, TokenService>();
            services.AddCors();
        }
    }
}

