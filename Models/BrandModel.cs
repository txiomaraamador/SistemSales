using System.ComponentModel.DataAnnotations;

namespace SistemSales.Models
{
    public class BrandModel
    {
        public int IdBrand { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        // [StringLength(45, ErrorMessage = "El nombre debe tener como máximo 45 caracteres")]
        public string? Name { get; set; }
    }
}
