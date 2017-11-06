using System.Collections.Generic;
using System.Web.Http;
using App.Web.Api.Contracts;
using App.Web.Api.Infrastructure;
using App.Web.Api.Infrastructure.ActionResults;
using App.Web.Api.Infrastructure.ParameterBindings;

namespace App.Web.Api.Controllers
{
    public class SomeController : ApiController
    {
        // GET: api/Some
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET: api/Some/5
        [ETaggedResponse]
        public IHttpActionResult Get(int id)
        {
            return Ok(
                    new SomeDto
                    {
                        StringValue = "value"
                    })
                .ETagged("etagValue");
        }

        // POST: api/Some
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Some/5
        public IHttpActionResult Put(int id, SomeDto entity, [FromIfMatch] string eTag)
        {
            //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Conflict, eTag));
            return Ok(new {Entity = entity, ETag = eTag});
        }

        // DELETE: api/Some/5
        public void Delete(int id)
        {
        }
    }
}