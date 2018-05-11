using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace DFC.Microservices.Skills.Models
{
    public class SocOnetSkills
    {
        public string onetocccode { get; set; }

        [Key]
        public string skillid { get; set; }
        public string skillname { get; set; }

        public string soccode { get; set; }
        public double skillsrank { get; set; }
    }
}
