using System.ComponentModel.DataAnnotations.Schema;

namespace proveedores_backend.Models
{
    public class Provider
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdProvider { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
