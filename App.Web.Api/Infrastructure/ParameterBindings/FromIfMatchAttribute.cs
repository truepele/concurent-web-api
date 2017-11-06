namespace App.Web.Api.Infrastructure.ParameterBindings
{
    public class FromIfMatchAttribute : FromHeaderAttribute
    {
        public FromIfMatchAttribute() : base("If-Match")
        {
        }
    }
}