using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DFC.Microservices.Skills.Interfaces;
using Newtonsoft.Json;

namespace DFC.Microservices.Skills.Services
{
    public class SkillsService : ISkillsService
    {
        public async Task<IEnumerable<string>> GetSkillsByJobProfileUrlName(string urlName)
        {
            var client = new HttpClient();

            var result = JsonConvert.DeserializeObject<IEnumerable<Photo>>(await client.GetStringAsync("https://jsonplaceholder.typicode.com/users"));
            return result.Select(s => s.Website);
        }
    }

    public class Photo
    {
        public string Website { get; set; }
    }
}
