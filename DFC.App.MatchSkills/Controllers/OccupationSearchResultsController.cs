﻿using DFC.App.MatchSkills.Application.ServiceTaxonomy;
using DFC.App.MatchSkills.Application.Session.Interfaces;
using DFC.App.MatchSkills.Interfaces;
using DFC.App.MatchSkills.Models;
using DFC.App.MatchSkills.Services.ServiceTaxonomy.Models;
using DFC.App.MatchSkills.ViewModels;
using Microsoft.Extensions.Options;

namespace DFC.App.MatchSkills.Controllers
{

    public class OccupationSearchResultsController : CompositeSessionController<OccupationSearchResultsCompositeViewModel>
    {
        
        public OccupationSearchResultsController(IOptions<CompositeSettings> compositeSettings,
            ISessionService sessionService, ICookieService cookieService) 
            : base(compositeSettings,
                sessionService, cookieService)
        {
            
        }

       
    }
}