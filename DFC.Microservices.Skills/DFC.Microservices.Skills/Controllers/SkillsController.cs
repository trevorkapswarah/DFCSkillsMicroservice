using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.Microservices.Skills.Interfaces;
using DFC.Microservices.Skills.Models;
using Microsoft.AspNetCore.Mvc;

namespace DFC.Microservices.Skills.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        private readonly IViewRenderService viewRenderService;
        private readonly IRepository repository;

        public SkillsController(IViewRenderService viewRenderService, IRepository repository)
        {
            this.viewRenderService = viewRenderService;
            this.repository = repository;
        }
        // GET api/skills/plumber
        [HttpGet("{urlname}")]
        public async Task<IDictionary<string, string>> Get(string urlName)
        {
            var result = new ConcurrentDictionary<string, string>();

            var model = new SkillsModel
            {
                Skills = repository.GetSkills(SocCodeMapping(urlName))?.Select(x => x.skillname),
                JobProfileUrl = urlName
            };

            var viewString = await viewRenderService.RenderViewToStringAsync("SkillsList", model);

            result.TryAdd("Skills", viewString);

            return result;
        }

        [HttpGet("getallskills/{socCode}")]
        public IEnumerable<SocOnetSkills> GetSkills(string socCode)
        {
            return repository.GetSkills(socCode);
        }

        private string SocCodeMapping(string urlName)
        {
            switch (urlName.ToLower())
            {
                case "nurse":
                    return "2124";
                case "plumber":
                    return "2119";
                case "teaching-assistant":
                    return "2111";
                case "proofreader":
                    return "1223";
                case "border-force-officer":
                    return "1172";
                default:
                    return "1115";
            }
        }

    }
}
