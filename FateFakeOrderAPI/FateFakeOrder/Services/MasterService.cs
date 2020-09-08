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
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
namespace FateFakeOrder.API.Services
{
    public class MasterService : IMasterService
    {
        private readonly IConfiguration _config;
        private readonly RestClient _restClient;

        public MasterService(IConfiguration config)
        {
            _config = config;
            _restClient = new RestClient($"{_config.GetValue<string>("ConnectionServices:MasterService")}");

        }
        public async Task Delete(int id)
        {
            var request = new RestRequest("/{taskId}", Method.DELETE);
            request.AddUrlSegment("taskId", id);
            var response = _restClient.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
        }

        public async Task<Master> Get(int id)
        {
            var request = new RestRequest("/{taskId}", Method.GET);
            request.AddUrlSegment("taskId", id);
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Master>(content);
        }

        public async Task<IEnumerable<Master>> GetAll()
        {
            var request = new RestRequest("", Method.GET);
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<IEnumerable<Master>>(content);
        }

        public async Task Save(Master master)
        {
            var request = new RestRequest("", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(master);
            var response = _restClient.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
