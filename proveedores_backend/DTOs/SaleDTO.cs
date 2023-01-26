using proveedores_backend.Models;

namespace proveedores_backend.DTOs
{
    public class SaleDTO
    {
        public Guid IdSale { get; set; }
        public Guid IdProduct { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}
