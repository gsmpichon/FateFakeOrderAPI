using FateFakeOrder.API.Interfaces;
using FateFakeOrder.Data;
using FateFakeOrder.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.API.Services
{
    public class ServantService : IServantService
    {
        private readonly IConfiguration _config;
        private readonly RestClient _restClient;
        public ServantService(IConfiguration config)
        {
            _config = config;
            _restClient = new RestClient($"{_config.GetValue<string>("ConnectionServices:ServantService")}");

        }
        public async Task<Servant> Get(int id)
        {
            var request = new RestRequest("/{taskId}", Method.GET);
            request.AddUrlSegment("taskId", id);
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Servant>(content);
        }

        public async Task<IEnumerable<Servant>> GetServants(int masterId)
        {
            var request = new RestRequest("", Method.GET);
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<IEnumerable<Servant>>(content);
        }

        public async Task Remove(int id)
        {
            var request = new RestRequest("/{taskId}", Method.DELETE);
            request.AddUrlSegment("taskId", id);
            var response = _restClient.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
        }

        public async Task Save(Servant servant)
        {
            var request = new RestRequest("", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(servant);
            var response = _restClient.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
        }
    }
}
