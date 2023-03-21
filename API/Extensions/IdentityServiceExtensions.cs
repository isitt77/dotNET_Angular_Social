using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(
            this IServiceCollection services, IConfiguration config)
        {
            // Jwt Middleware
            services.AddAuthentication(JwtBearerDefaults
                .AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}

