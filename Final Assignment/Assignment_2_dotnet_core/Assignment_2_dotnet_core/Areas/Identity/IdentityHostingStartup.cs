using System;
using Assignment_2_dotnet_core.Areas.Identity.Data;
using Assignment_2_dotnet_core.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Assignment_2_dotnet_core.Areas.Identity.IdentityHostingStartup))]
namespace Assignment_2_dotnet_core.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AccountUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AccountUserContextConnection")));

                services.AddDefaultIdentity<AccountUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<AccountUserContext>();
            });
        }
    }
}