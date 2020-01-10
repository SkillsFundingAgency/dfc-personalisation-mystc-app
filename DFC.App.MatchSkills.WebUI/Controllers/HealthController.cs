﻿using Microsoft.AspNetCore.Mvc;

namespace DFC.App.MatchSkills.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        public HealthController()
        {
        }

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
