using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.UIService;
using PetShop.Core.RepositoryService;
using Microsoft.EntityFrameworkCore;
using PetShop.Ctx.Repository.Repositories;
using PetShop.Ctx.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using PetShop.Core.Entity;
using PetShop.Core.IService;
using PetShop.Core.Services;

namespace PetShop.Api
{
    public class Startup
    {
        /*public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/

        private IConfiguration _conf { get; }

        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
            JwtSecurityKey.SetSecret("Sixteen characters");
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            services.AddCors();

            if (_env.IsDevelopment())
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt.UseSqlite("Data Source=PetShop.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt
                        .UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }

            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();

            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IColorRepository, ColorRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository<User>, UserRepository>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    DBInit.StartUp(ctx);
                }
            }
            else
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
