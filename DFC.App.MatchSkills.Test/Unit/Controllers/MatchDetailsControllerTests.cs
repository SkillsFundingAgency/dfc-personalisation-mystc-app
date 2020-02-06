﻿using DFC.App.MatchSkills.Application.Session.Interfaces;
using DFC.App.MatchSkills.Controllers;
using DFC.App.MatchSkills.Models;
using FluentAssertions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;

namespace DFC.App.MatchSkills.Test.Unit.Controllers
{
    [TestFixture]
    public class MatchDetailsControllerTests
    {
        private IDataProtectionProvider _dataProtectionProvider;
        private IOptions<CompositeSettings> _compositeSettings;
        private ISessionService _sessionService;
  

        [SetUp]
        public void Init()
        {
            _sessionService = Substitute.For<ISessionService>();
            _dataProtectionProvider = new EphemeralDataProtectionProvider();
            _compositeSettings = Options.Create(new CompositeSettings());
        }

        [Test]
        public void WhenBodyCalled_ReturnHtml()
        {
            var controller = new MatchDetailsController(_dataProtectionProvider, _compositeSettings, _sessionService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            var result = controller.Body() as ViewResult;
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
            result.ViewName.Should().BeNull();
        }
    }
}
