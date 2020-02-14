﻿using DFC.App.MatchSkills.Application.Session.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DFC.App.MatchSkills.Application.Session.Interfaces
{
    public interface ISessionWriter
    {
        Task<string> CreateUserSession(CreateSessionRequest request, string sessionIdFromCookie = null);
        Task<HttpResponseMessage> UpdateUserSessionAsync(UserSession updatedSession);
        string GeneratePrimaryKey();
    }
}
