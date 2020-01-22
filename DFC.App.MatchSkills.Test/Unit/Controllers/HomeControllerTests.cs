﻿using System;
using System.Collections.Generic;
using System.Text;
using DFC.App.MatchSkills.Controllers;
using DFC.App.MatchSkills.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace DFC.App.MatchSkills.Test.Unit.Controllers
{
    public class HomeControllerTests
    {
        [Test]
        public void WhenHeadCalled_ReturnHtml()
        {
            var controller = new HomeController();
            var result = controller.Head();
            var vm = new HeadViewModel
            {
                PageTitle = "Page Title",
                DefaultCssLink = "Link"
                
            };
            var pageTitle = vm.PageTitle;
            var css = vm.DefaultCssLink;
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();

        }
        [Test]
        public void WhenBodyCalled_ReturnHtml()
        {
            var controller = new HomeController();
            var result = controller.Body();
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();

        }
        [Test]
        public void WhenBreadCrumbCalled_ReturnHtml()
        {
            var controller = new HomeController();
            var result = controller.Breadcrumb();
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        [Test]
        public void WhenBodyTopCalled_ReturnHtml()
        {
            var controller = new HomeController();
            var result = controller.BodyTop();
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        [Test]
        public void WhenSidebarRightCalled_ReturnHtml()
        {
            var controller = new HomeController();
            var result = controller.SidebarRight();
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
    }
}