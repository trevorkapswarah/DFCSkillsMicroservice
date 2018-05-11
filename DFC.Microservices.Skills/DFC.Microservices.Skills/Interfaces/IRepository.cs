using System.Collections.Generic;
using DFC.Microservices.Skills.Models;

namespace DFC.Microservices.Skills.Interfaces
{
    public interface IRepository
    {
        IEnumerable<SocOnetSkills> GetSkills(string socCode);
    }
}
