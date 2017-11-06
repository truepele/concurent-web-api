namespace App.Web.Api.Infrastructure
{
    public class ETaggedResult<T>
    {
        public ETaggedResult(T data, string eTag)
        {
            Data = data;
            ETag = eTag;
        }

        public T Data { get; }

        public string ETag { get; }
    }
}