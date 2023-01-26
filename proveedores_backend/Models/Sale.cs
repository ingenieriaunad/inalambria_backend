using System.ComponentModel.DataAnnotations.Schema;

namespace proveedores_backend.Models
{
    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdSale { get; set; }
        public Guid IdProducto { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public DateTime Date { get; set; }
    }
}
