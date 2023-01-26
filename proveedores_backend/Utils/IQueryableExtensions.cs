using proveedores_backend.DTOs;

namespace proveedores_backend.Utils
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> GetPaged<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO)
        {
            return queryable
                .Skip((paginationDTO.Page - 1) * paginationDTO.RecordsPerPage)
                .Take(paginationDTO.RecordsPerPage);
        }

    }
}
