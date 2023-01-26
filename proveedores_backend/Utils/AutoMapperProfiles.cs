using AutoMapper;
using proveedores_backend.Models;
using proveedores_backend.DTOs;
namespace proveedores_backend.Utils
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Provider, ProviderDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Sale, SaleDTO>().ReverseMap();
        }
    }
}
