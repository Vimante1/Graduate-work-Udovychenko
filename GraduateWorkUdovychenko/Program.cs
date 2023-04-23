using GraduateWorkUdovychenko.Domain.Models;
using GraduateWorkUdovychenko.Services.MyUser;
using GraduateWorkUdovychenko.Services.QuizService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Text;

namespace GraduateWorkUdovychenko
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region JWT
            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
            builder.Services.AddAuthorization();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration.GetSection("JWTSettings:Issuer").Value,
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration.GetSection("JWTSettings:Audience").Value,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWTSettings:SecretKey").Value)),
                        ValidateIssuerSigningKey = true
                    };
                });
            #endregion


            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IQuizRepository, QuizRepository>();
            builder.Services.AddScoped<ICompletedQuizRepository, CompletedQuizRepository>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                string token = context.Request.Cookies["token"]; // отримати токен з кукі
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token).ToString();
                }

                await next.Invoke();
            });


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}