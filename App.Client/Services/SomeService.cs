using System;
using System.Diagnostics;
using App.Client.ApiInterfaces;
using App.Client.Models;
using App.Web.Api.Contracts;
using AutoMapper;
using Refit;

namespace App.Client.Services
{
    public class SomeService : ISomeService
    {
        private readonly ISomeApiClient _apiClient;
        private readonly IMapper _mapper;

        public SomeService(ISomeApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public SomeModel Get(int id)
        {
            var message = _apiClient.Get(id).Result;
            var result = _mapper.Map<SomeModel>(message.Content.ReadAsync<SomeDto>().Result);
            result.ETag = message.Headers.ETag.Tag;
            return result;
        }

        public void Update(SomeModel model)
        {
            try
            {
                var response = _apiClient.Put(model.Id, _mapper.Map<SomeDto>(model), model.ETag).Result;
                Debug.WriteLine(response);
            }
            catch (ApiException e)
            {
                Debug.WriteLine(e.Content);
                throw;
            }
            catch (Exception e) when (e.InnerException is ApiException)
            {
                Debug.WriteLine(((ApiException)e.InnerException).Content);
                throw;
            }
        }
    }
}
