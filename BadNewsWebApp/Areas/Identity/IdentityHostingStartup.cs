using System;
using BadNews.Models;
using BadNewsWebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BadNewsWebApp.Areas.Identity.IdentityHostingStartup))]
namespace BadNewsWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BadNewsWebAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BadNewsWebAppContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BadNewsWebAppContext>();
            });
        }
    }
}