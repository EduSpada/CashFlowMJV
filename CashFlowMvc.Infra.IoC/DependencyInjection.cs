using CashFlowMvc.Application.Interfaces;
using CashFlowMvc.Application.Mappings;
using CashFlowMvc.Application.Services;
using CashFlowMvc.Domain.Account;
using CashFlowMvc.Domain.Interfaces;
using CashFlowMvc.Infra.Data.Context;
using CashFlowMvc.Infra.Data.Identity;
using CashFlowMvc.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                           IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    string connectionString = configuration.GetConnectionString("MysqlConnectionString");
                    options.UseMySql(connectionString,
                                    ServerVersion.AutoDetect(connectionString));
                }
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                    options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();

            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IOperationService, OperationService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            return services;
        }
    }
}