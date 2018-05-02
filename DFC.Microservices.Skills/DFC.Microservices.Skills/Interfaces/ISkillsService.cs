using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFC.Microservices.Skills.Interfaces
{
    public interface ISkillsService
    {
        Task<IEnumerable<string>> GetSkillsByJobProfileUrlName(string urlName);
    }
}
