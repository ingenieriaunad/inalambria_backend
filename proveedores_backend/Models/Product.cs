using System.ComponentModel.DataAnnotations.Schema;

namespace proveedores_backend.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdProduct { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public Guid IdProvider { get; set; }
        public Provider Provider { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
