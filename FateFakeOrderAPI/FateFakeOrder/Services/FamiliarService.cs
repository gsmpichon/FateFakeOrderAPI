using FateFakeOrder.API.Interfaces;
using FateFakeOrder.Data;
using FateFakeOrder.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FateFakeOrder.API.Services
{
    public class FamiliarService : IFamiliarService
    {
        private readonly IConfiguration _config;
        private readonly RestClient _restClient;

        public FamiliarService(IConfiguration config)
        {
            _config = config;
            _restClient = new RestClient($"{_config.GetValue<string>("ConnectionServices:FamiliarService")}");
        }
        public async Task Delete(int id)
        {
            var request = new RestRequest("/{taskId}", Method.DELETE);
            request.AddUrlSegment("taskId", id);
            var response = _restClient.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;

        }

        public async Task<Familiar> Get(int id)
        {

            var request = new RestRequest("/{taskId}", Method.GET);
            request.AddUrlSegment("taskId", id);
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Familiar>(content);



        }

        public async Task<IEnumerable<Familiar>> GetAll()
        {
            var request = new RestRequest("", Method.GET);
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<IEnumerable<Familiar>>(content);
        }

        public Task<IEnumerable<Servant>> GetServants(int familiarID)
        {
            throw new NotImplementedException();
        }

        public async Task Save(Familiar familiar)
        {
            var request = new RestRequest("", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(familiar);
            var response = _restClient.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;

        }
    }
}
