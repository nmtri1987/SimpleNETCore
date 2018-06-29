using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AcaraDataRequestApplication.ModelBinders;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.UnitOfWork;
using AutoMapper;

namespace AcaraDataRequestApplication
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
            services.AddDbContext<DataRequestApplicationDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("AcaraDataRequestApplicationConnection"),
                                        ob => {
                                            ob.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.FullName);
                                            //ob.UseRowNumberForPaging();
                                        }
                                    );
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper();

            services.AddMvc(options =>
            {
                //options.ModelBinderProviders.Insert(0, new CustomDateTimeModelBinderProvider());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
