using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.BusinessLogic.Implementations;
using Northwind.BusinessLogic.Interfaces;
using Northwind.DataAccess;
using Northwind.UnitOfWork;
using Northwind.WebApi.Authentication;
using Northwind.WebApi.GlobalErrorHandling;

namespace Northwind.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISupplierLogic, SupplierLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<ITokenLogic, TokenLogic>();

            services.AddSingleton<IUnitOfWork>(option => new NorthwindUnitOfWork(
                Configuration.GetConnectionString("Northwind")
                ));
            CustomJwtProvider token = new CustomJwtProvider("issuer", "audience", "northwind_2000");
            services.AddSingleton<ITokenProvider>(token);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = token.GetValidationParameters();
                    });
            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(option =>
            {
                option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });
            app.UseAuthentication();
            app.ConfigureExceptionHandler();
            app.UseMvc();
        }
    }
}
