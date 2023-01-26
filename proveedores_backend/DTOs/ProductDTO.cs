namespace proveedores_backend.DTOs
{
    public class ProductDTO
    {
        public Guid IdProduct { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid IdProvider { get; set; }
    }
}
