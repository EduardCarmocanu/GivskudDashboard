using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GivskudDashboard.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GivskudDashboard
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
			CultureInfo cultureInfo = new CultureInfo("en-US");

			CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
			CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<MarkersDataContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("MarkersDataContext"));
			});
			services.AddDbContext<IdentityDataContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("IdentityDataContext"));
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<IdentityDataContext>();

			services.AddCors(options =>
			{
				options.AddPolicy("GivskudPolicy",
					policy =>
					{
						policy.WithOrigins("https://givskud.azurewebsites.net")
							.AllowAnyHeader();
					});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<IdentityUser> userManager)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseCors("GivskudPolicy");
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			IdentityDbInitializer.SeedUsers(userManager);
			app.UseAuthentication();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Markers}/{action=Index}/{id?}");
			});
		}
	}
}
