using System;
using Document_Repo_Final_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Document_Repo_Final_Project.Areas.Identity.IdentityHostingStartup))]
namespace Document_Repo_Final_Project.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Document_Repo_IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Document_Repo_IdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                     .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Document_Repo_IdentityContext>();
            });
        }
    }
}