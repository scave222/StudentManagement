using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Areas.Identity.Data;
using StudentManagement.Data;

[assembly: HostingStartup(typeof(StudentManagement.Areas.Identity.IdentityHostingStartup))]
namespace StudentManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AdminContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AdminContextConnection")));

                services.AddDefaultIdentity<StudentManagementUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AdminContext>();
            });
        }
    }
}