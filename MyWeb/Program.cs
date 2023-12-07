using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyWeb.Services;
using System.Text;

namespace MyWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<MyWebDatabase>(optionsAction =>
            {
                optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("AppConn"), options =>
                {
                    options.MinBatchSize(2);
                });
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<CalculationService, CalculationService>();
            builder.Services.AddScoped<CalculationDelta, CalculationDelta>();
            builder.Services.AddScoped<UserService, UserService>();
            builder.Services.AddScoped<JwtService, JwtService>();

            // Get Token key

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("47D528A3D79B3F8DF7824F847E5DA")),
                    ValidateIssuer = false,
                    ClockSkew =TimeSpan.Zero,
                    ValidateLifetime = true,
                    LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken,
                                        TokenValidationParameters validationParameters) =>
                    {
                        return notBefore.HasValue? notBefore.Value<= DateTime.UtcNow: false ||
                        !expires.HasValue||expires.Value>= DateTime.UtcNow;
                    }
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}