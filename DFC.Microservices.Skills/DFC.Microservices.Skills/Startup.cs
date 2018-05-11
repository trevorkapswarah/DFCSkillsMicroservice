using DFC.Microservices.Skills.Interfaces;
using DFC.Microservices.Skills.Repositories;
using DFC.Microservices.Skills.Repositories.DataAccessPostgreSqlProvider;
using DFC.Microservices.Skills.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DFC.Microservices.Skills
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
            services.AddMvc();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<IRepository, PostgreSqlRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
