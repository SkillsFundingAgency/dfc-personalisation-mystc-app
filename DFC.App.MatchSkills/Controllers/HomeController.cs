﻿using DFC.App.MatchSkills.Models;
using DFC.App.MatchSkills.ViewModels.Home;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DFC.App.MatchSkills.Controllers
{
    public class HomeController : CompositeSessionController<HomeCompositeViewModel>
    {
        public HomeController(IDataProtectionProvider dataProtectionProvider, IOptions<CompositeSettings> settings) 
            : base(dataProtectionProvider, settings)
        {
        }

        #region Default Routes

        // The home page uses MVC default routes, so we need non "/[controller]" versions of the endpoints just for here

        [Route("/head")]
        public override IActionResult Head()
        {
            return base.Head();
        }

        [Route("/bodytop")]
        public override IActionResult BodyTop()
        {
            return base.BodyTop();
        }

        [Route("/breadcrumb")]
        public override IActionResult Breadcrumb()
        {
            return base.Breadcrumb();
        }

        [Route("/body")]
        public override IActionResult Body()
        {
            return base.Body();
        }

        [Route("/sidebarright")]
        public override IActionResult SidebarRight()
        {
            return base.SidebarRight();
        }

        #endregion Default Routes
    }
}