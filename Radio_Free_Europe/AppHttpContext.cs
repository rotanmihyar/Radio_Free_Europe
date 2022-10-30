using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Radio_Free_Europe
{
    public static class AppHttpContext
    {
        private static IHttpContextAccessor httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            AppHttpContext.httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext Current
        {
            get
            {
                return httpContextAccessor.HttpContext;
            }
        }

        public static T GetService<T>()
        {
            return Current.RequestServices.GetService<T>();
        }
    }
}