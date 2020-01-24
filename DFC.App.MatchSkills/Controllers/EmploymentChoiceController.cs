﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace DFC.App.MatchSkills.Controllers
{

    public class EmploymentChoiceController : BaseController
    {
        private const string PathName = "EmploymentChoice";

        public EmploymentChoiceController(IDataProtectionProvider dataProtectionProvider) : base(dataProtectionProvider)
        {
        }

        [HttpGet]
        [Route("/head/EmploymentChoice")]
        public override IActionResult Head()
        {
            return View(ReturnPath("Head", PathName));
        }

        [HttpGet]
        [Route("/breadcrumb/EmploymentChoice")]
        public override IActionResult Breadcrumb()
        {
            return View(ReturnPath("Breadcrumb", PathName));
        }

        [HttpGet]
        [Route("/bodytop/EmploymentChoice")]
        public override IActionResult BodyTop()
        {
            return View(ReturnPath("bodytop"));
        }

        [HttpGet]
        [Route("/body/EmploymentChoice")]
        public override IActionResult Body()
        {
            var sessionId = TryGetSessionId(Request).Result;
            if (!string.IsNullOrWhiteSpace(sessionId))
            {
                AppendCookie(sessionId);
            }
            
            return View(ReturnPath("body", PathName));
        }

        [HttpGet]
        [Route("/sidebarright/EmploymentChoice")]
        public override IActionResult SidebarRight()
        {
            return View(ReturnPath("sidebarright"));
        }
    }
}