using System.Collections.Generic;

namespace DFC.Microservices.Skills.Models
{
    public class SkillsModel
    {
        public IEnumerable<string> Skills { get; set; }

        public string JobProfileUrl { get; set; }
    }
}
