using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.Microservices.Skills.Interfaces;
using DFC.Microservices.Skills.Models;
using DFC.Microservices.Skills.Repositories.DataAccessPostgreSqlProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DFC.Microservices.Skills.Repositories
{
    public class PostgreSqlRepository : IRepository
    {
        private readonly WebApiContext skillsPostgreSqlContext;

        public PostgreSqlRepository(IConfiguration configuration)
        {
            skillsPostgreSqlContext = new WebApiContext(configuration);
        }
        public IEnumerable<SocOnetSkills> GetSkills(string socCode)
        {
          return skillsPostgreSqlContext.SocOnetSkills.Where(x => x.soccode.Equals(socCode)).OrderByDescending(skill => skill.skillsrank).Take(15);
        }
    }
}
