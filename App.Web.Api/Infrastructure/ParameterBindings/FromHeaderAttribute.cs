using System.Web.Http;
using System.Web.Http.Controllers;

namespace App.Web.Api.Infrastructure.ParameterBindings
{
    public class FromHeaderAttribute : ParameterBindingAttribute
    {
        private readonly string _headerName;

        public FromHeaderAttribute(string headerName)
        {
            _headerName = headerName;
        }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameterDescriptor)
        {
            return new FromHeaderParameterBinding(parameterDescriptor, _headerName);
        }
    }
}