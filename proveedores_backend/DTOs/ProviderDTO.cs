namespace proveedores_backend.DTOs
{
    public class ProviderDTO
    {
        public Guid IdProvider { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
