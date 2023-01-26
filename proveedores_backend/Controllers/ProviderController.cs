using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proveedores_backend.DTOs;
using proveedores_backend.Utils;
using proveedores_backend.Models;
using System.Collections;

namespace proveedores_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : Controller
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;
        //constructor
        public ProviderController(ApplicationDBContext context,IMapper mapper )
        {
            this.context = context;
            this.mapper = mapper;

        }
        // GET: ProviderController
        [HttpGet("GetAll")]
        public async Task<ActionResult> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable    = context.Providers.AsQueryable();
            int totalRecords = 0;
            List<Provider> providers = new List<Provider>();
            if (string.IsNullOrEmpty(paginationDTO.Search))
            {
                totalRecords = await queryable.GetTotalRecords();
                providers    = await queryable.OrderBy(p=>p.Name)
                                              .GetPaged(paginationDTO)
                                              .ToListAsync();
            }
            //si existe Search en la petición buscamos por nombre o identificación o telefono o email
            if (!string.IsNullOrEmpty(paginationDTO.Search))
            {
                providers = await queryable.Where(p => p.Name.Contains(paginationDTO.Search) ||
                                                       p.Identification.Contains(paginationDTO.Search) ||
                                                       p.Phone.Contains(paginationDTO.Search) ||
                                                       p.Email.Contains(paginationDTO.Search))
                                           .OrderBy(p => p.Name)
                                           .GetPaged(paginationDTO)
                                           .ToListAsync();
                totalRecords = providers.Count();
            }                          
            return Ok(new 
            {   
                totalRecords,
                providers= mapper.Map<List<ProviderDTO>>(providers)
            });
        }
        [HttpPost("new")]
        public async Task<ActionResult> Post([FromBody] ProviderDTO providerDTO)
        {
            string message = "El proveedor se ha creado correctamente";
            var provider = mapper.Map<Provider>(providerDTO);
            var providerExists = await context.Providers
                                              .AnyAsync(p => p.Identification == provider.Identification);
            if (providerExists)
            {
                message = "El proveedor ya existe";
                return BadRequest(new { message });
            }
            context.Add(provider);
            await context.SaveChangesAsync();
            return Ok(new { message });

        }
        /* Obtener productos vendidos por proveedor */
        [HttpGet("GetProductsSoldByProvider")]
        public async Task<ActionResult> GetProductsSoldByProvider([FromQuery] PaginationDTO paginationDTO)
        {
            /* buscar las ventas por Idproveedor*/
            var queryable = context.Sales.AsQueryable();
            int totalRecords = 0;
            double totalSold = 0;
            IEnumerable sales = new ArrayList();
            //hacemos join con la tabla de productos y cargamos el producto de la venta
            var idProvider= Guid.Parse(paginationDTO.IdProvider);
            var query = from s in queryable
                        join p in context.Products on s.IdProducto equals p.IdProduct
                        orderby s.Date
                        where p.IdProvider == idProvider
                        select new{
                            s.IdSale,
                            s.IdProducto,
                            s.Quantity,
                            s.Date,
                            Product=p
                        };
            
            totalRecords = await query.GetTotalRecords();
            totalSold    = await query.SumAsync(s => s.Quantity * s.Product.Price);
            sales = await query.GetPaged(paginationDTO)
                               .ToListAsync();
            return Ok(new{
                totalRecords,
                totalSold,
                sales 
            });
        }
    }
}
