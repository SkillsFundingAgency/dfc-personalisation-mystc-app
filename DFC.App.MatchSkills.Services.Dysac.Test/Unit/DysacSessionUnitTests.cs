﻿using System;
using System.Net;
using System.Net.Http;
using DFC.App.MatchSkills.Application.Dysac;
using DFC.App.MatchSkills.Application.Dysac.Models;
using DFC.Personalisation.Common.Net.RestClient;
using Dfc.Session;
using Dfc.Session.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;


namespace DFC.App.MatchSkills.Services.Dysac.Test.Unit
{
    public class DysacSessionUnitTests
    {

        public class CreateNewSessionTests
        {
            private IOptions<DysacSettings> _dysacServiceSetings;
            private IDysacSessionReader _dysacService;
            private ISessionClient _sessionClient;
            private IRestClient _restClient;
            private ILogger<DysacService> _log;
            [SetUp]
            public void Init()
            {

                _dysacServiceSetings = Options.Create(new DysacSettings());
                _dysacServiceSetings.Value.ApiUrl = "https://dev.api.nationalcareersservice.org.uk/something";
                _dysacServiceSetings.Value.ApiKey = "mykeydoesnotmatterasitwillbemocked";
                _dysacServiceSetings.Value.DysacUrl = "http://dysacurl";
                _dysacServiceSetings.Value.ApiVersion = "v1";
                _dysacService = Substitute.For<IDysacSessionReader>();
                _log = Substitute.For<ILogger<DysacService>>();
                _sessionClient = Substitute.For<ISessionClient>();
                _restClient = Substitute.For<IRestClient>();
                _restClient.LastResponse = Substitute.For<RestClient.APIResponse>();
                _restClient.LastResponse.StatusCode = HttpStatusCode.Created;

            }

            [Test]
            public void When_DysacService_ObjectCreated()
            {

                var logger = Substitute.For<ILogger<DysacService>>();
                var restClient = Substitute.For<IRestClient>();
                var dysacService = new DysacService(logger, restClient, _dysacServiceSetings, _sessionClient);
            }

            [Test]
            public void When_InitiateDysacNewSessionWithNoErrors_ReturnOK()
            {
                var request = new HttpRequestMessage();
                request.Headers.Add("Ocp-Apim-Subscription-Key", "");
                request.Headers.Add("version", "");
                _restClient.PostAsync<AssessmentShortResponse>("", request).ReturnsForAnyArgs(new AssessmentShortResponse()
                {
                    CreatedDate = DateTime.Now,
                    PartitionKey = "partitionkey",
                    SessionId = "session",
                    Salt = "salt"
                });
                var dysacService = new DysacService(_log, _restClient, _dysacServiceSetings, _sessionClient);

                var results = dysacService.InitiateDysac().Result;
                results.ResponseCode.Should().Be(DysacReturnCode.Ok);
            }

            [Test]
            public void When_InitiateDysacWithErrors_ReturnErrorAndMessage()
            {
                _dysacService.InitiateDysac().ReturnsForAnyArgs(new DysacServiceResponse()
                {
                    ResponseCode = DysacReturnCode.Error,
                    ResponseMessage = "Error"
                });

                var results = _dysacService.InitiateDysac().Result;
                results.ResponseCode.Should().Be(DysacReturnCode.Error);
                results.ResponseMessage.Should().Be("Error");
            }


        }




    }
}
