using Microsoft.EntityFrameworkCore;

namespace proveedores_backend.Utils
{
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationParametersInResponse<T>(this HttpContext httpContext, IQueryable<T> queryable)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            double count = await queryable.CountAsync();
            httpContext.Response.Headers.Add("x-total-records", count.ToString());
        }
        //obtener el total de registros usando task
        public static async Task<int> GetTotalRecords<T>(this IQueryable<T> queryable)
        {
            return await queryable.CountAsync();
        }
    }
}
