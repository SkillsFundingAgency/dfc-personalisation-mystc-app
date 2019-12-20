﻿using System;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using AutoMapper;
using DFC.App.MatchSkills.Application.ServiceTaxonomy;
using DFC.App.MatchSkills.Services.ServiceTaxonomy.Models;
using DFC.Personalisation.Common.Net.RestClient;
using DFC.Personalisation.Domain.Models;


namespace DFC.App.MatchSkills.Services.ServiceTaxonomy
{
    public class ServiceTaxonomyRepository : IServiceTaxonomyReader, IServiceTaxonomySearcher
    {
        static async Task<TList> GetJsonList<TList>(string apiPath, string ocpApimSubscriptionKey) where TList : class
        {
            if (string.IsNullOrWhiteSpace((apiPath)))
                throw new ArgumentNullException(nameof(apiPath), "ApiPath must be specified.");

            if (string.IsNullOrWhiteSpace((ocpApimSubscriptionKey)))
                throw new ArgumentNullException(nameof(ocpApimSubscriptionKey), "Ocp-Apim-Subscription-Key must be specified.");

            var restClient = new RestClient(new HttpClient());
            return await restClient.Get<TList>(apiPath,ocpApimSubscriptionKey);
     
        }
        public async Task<Skill[]> GetAllSkills<TSkills>(string apiPath, string ocpApimSubscriptionKey)
        {
            var result = await GetJsonList<STSkills>(apiPath, ocpApimSubscriptionKey); 
            return Mapping.Mapper.Map<Skill[]>(result.Skills);
        }

        
        public async Task<Occupation[]> GetAllOccupations<TOccupations>(string apiPath, string ocpApimSubscriptionKey) 
        {
            var result = await GetJsonList<STOccupations>(apiPath, ocpApimSubscriptionKey);
            return Mapping.Mapper.Map<Occupation[]>(result.Occupations);
        }


        public async Task<Skill[]> SearchSkills<TSkills>(string apiPath, string ocpApimSubscriptionKey, string skill)
        {
            if (string.IsNullOrWhiteSpace((skill)))
                throw new ArgumentNullException(nameof(skill), "Please provide Skill to search");
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(skill);
            var result = await GetAllSkills<Skill[]>(apiPath, ocpApimSubscriptionKey);
            return result.Where(s => regEx.IsMatch(s.Name)).ToArray();
        }

        public async Task<Occupation[]> SearchOccupations<TOccupations>(string apiPath, string ocpApimSubscriptionKey, string occupation)
        {
            if (string.IsNullOrWhiteSpace((occupation)))
                throw new ArgumentNullException(nameof(occupation), "Please provide Occupation to search");
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(occupation);
            var result = await GetAllOccupations<Occupation[]>(apiPath, ocpApimSubscriptionKey);
            return result.Where(o => regEx.IsMatch(o.Name)).ToArray();
        }
    }
   
   
}
