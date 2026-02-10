
using Day2.Models;
using Day2.Repository;
using Day2.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services
            //    .AddControllers()
            //    .AddNewtonsoftJson(options =>
            //        options.SerializerSettings.ReferenceLoopHandling =
            //            Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //    );

            builder.Services.AddDbContext<ITIContext>(op =>
                op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();           
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<studentsrepository>();
            builder.Services.AddScoped<GenericRepository<student>>();
            builder.Services.AddScoped<GenericRepository<UnitWork>>();
            //builder.Services.AddScoped<GenericRepository<Department>>();
            //builder.Services.AddScoped<GenericRepository<User>>();
            builder.Services.
                AddAuthentication(op => op.DefaultAuthenticateScheme = "malekSchema").
                AddJwtBearer("malekSchema", option =>
            {
                String MyKey = "This is my secret key malek using sha256";
                var MySecurityKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(MyKey));
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = MySecurityKey,
                    //WE ARE USING THE BELOW TWO OPTIONS IN CASE WE'VE AN ISOLATED/SEPARATED SERVER TO THE AUTHENTECATION
                    ValidateIssuer= false, 
                    ValidateAudience=false
                };

            } );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
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
