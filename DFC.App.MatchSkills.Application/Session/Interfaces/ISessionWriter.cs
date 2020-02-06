﻿using DFC.App.MatchSkills.Application.Session.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DFC.App.MatchSkills.Application.Session.Interfaces
{
    public interface ISessionWriter
    {
        Task<string> CreateUserSession(string previousPage, string currentPage, string sessionIdFromCookie = null);
        Task<HttpResponseMessage> UpdateUserSessionAsync(UserSession updatedSession);
        string GeneratePrimaryKey();
    }
}
