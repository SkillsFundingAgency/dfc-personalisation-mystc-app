﻿using DFC.App.MatchSkills.Models;
using DFC.App.MatchSkills.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DFC.App.MatchSkills.Controllers
{
    public class WorkedController : CompositeSessionController<WorkedCompositeViewModel>
    {
        private readonly CompositeSettings _compositeSettings;

        public WorkedController(IDataProtectionProvider dataProtectionProvider,
            IOptions<CompositeSettings> compositeSettings)
            : base(dataProtectionProvider, compositeSettings)
        {
            _compositeSettings = compositeSettings.Value;
        }

        [HttpPost]
        [Route("MatchSkills/body/[controller]")]
        public IActionResult Body(WorkedBefore choice)
        {
            switch (choice)
            {
                case WorkedBefore.Yes:
                    return RedirectPermanent($"{_compositeSettings.Path}/{CompositeViewModel.PageId.Route}");
                case WorkedBefore.No:
                default:
                    return base.Body();
            }
        }
    }
}
