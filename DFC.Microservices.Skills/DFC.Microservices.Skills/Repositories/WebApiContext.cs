using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.Microservices.Skills.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DFC.Microservices.Skills.Repositories
{
    namespace DataAccessPostgreSqlProvider
    {
        // >dotnet ef migration add testMigration in AspNet5MultipleProject
        public class WebApiContext : DbContext
        {
            public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
            {
            }

            public WebApiContext(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            public DbSet<SocOnetSkills> SocOnetSkills { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DataAccessPostgreSqlProvider"));
                base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<SocOnetSkills>(socSkills =>
                {
                    socSkills.ToTable("soc_onetocc_skills");
                });
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
