using System.Diagnostics;
using App.Client.ApiInterfaces;
using App.Client.Mappings;
using App.Client.Services;
using AutoMapper;
using Refit;

namespace App.Client.Console
{
    class Program
    {
        private static void Main(string[] args)
        {
            var api = RestService.For<ISomeApiClient>("http://localhost/concurency/api");
            var mapper = new MapperConfiguration(expression => expression.AddProfile(new DtoMappings())).CreateMapper();
            var s = new SomeService(api, mapper);
            var m = s.Get(0);
            
            Debug.WriteLine(m.ETag);

            s.Update(m);
        }
    }
}
