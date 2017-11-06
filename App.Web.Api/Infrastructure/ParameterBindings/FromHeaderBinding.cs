using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace App.Web.Api.Infrastructure.ParameterBindings
{
    public class FromHeaderParameterBinding : HttpParameterBinding
    {
        private readonly string _name;

        public FromHeaderParameterBinding(HttpParameterDescriptor parameterDescriptor, string headerName) : base(parameterDescriptor)
        {
            if (string.IsNullOrEmpty(headerName))
            {
                throw new ArgumentNullException(nameof(headerName));
            }
            _name = headerName;
        }

        public override Task ExecuteBindingAsync(
            ModelMetadataProvider metadataProvider, 
            HttpActionContext actionContext, 
            CancellationToken cancellationToken)
        {
            if (actionContext.Request.Headers.TryGetValues(_name, out var values))
            {
                try
                {
                    actionContext.ActionArguments[Descriptor.ParameterName] = values.FirstOrDefault();
                }
                catch (Exception exception)
                {
                    var error = new HttpError("The request is invalid.") { MessageDetail = exception.Message };
                    throw new HttpResponseException(actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, error));
                }
            }
            else if (Descriptor.IsOptional)
            {
                actionContext.ActionArguments[Descriptor.ParameterName] = Descriptor.DefaultValue ?? "";
            }
            else
            {
                var error = new HttpError("The request is invalid.") { MessageDetail = $"The `{_name}` header is required." };
                throw new HttpResponseException(actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, error));
            }

            return Task.CompletedTask;
        }
    }
}