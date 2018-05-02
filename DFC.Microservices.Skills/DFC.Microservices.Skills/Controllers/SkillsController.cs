using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DFC.Microservices.Skills.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        // GET api/skills/plumber
        [HttpGet("{urlname}")]
        public IDictionary<string, string> Get(string urlName)
        {
            var result = new ConcurrentDictionary<string, string>();

            result.TryAdd("HowToBecome", "<div></div>");
            result.TryAdd("EntryQualifications", "<div></div>");
            result.TryAdd("WhatYouWillDo", "<div></div>");

            return result;
        }
    }
}
