using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Microservices.Skills.Models;
using DFC.Microservices.Skills.Services;
using Microsoft.AspNetCore.Mvc;

namespace DFC.Microservices.Skills.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        private readonly IViewRenderService viewRenderService;

        public SkillsController(IViewRenderService viewRenderService)
        {
            this.viewRenderService = viewRenderService;
        }
        // GET api/skills/plumber
        [HttpGet("{urlname}")]
        public async Task<IDictionary<string, string>> Get(string urlName)
        {
            var result = new ConcurrentDictionary<string, string>();

            var model = new SkillsModel
            {
                Skills = new List<string> {"reading", "critical thinking", "public speaking"}
            };

            var viewString = await viewRenderService.RenderToStringAsync("SkillsList", model);

            result.TryAdd("Skills", viewString);

            return result;
        }
    }
}
