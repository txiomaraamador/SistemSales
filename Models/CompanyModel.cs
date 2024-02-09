using System.ComponentModel.DataAnnotations;

namespace SistemSales.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
       // [Required(ErrorMessage = "El nombre es obligatorio")]
       // [StringLength(45, ErrorMessage = "El nombre debe tener como máximo 45 caracteres")]
        public string? Name { get; set; }

       // [StringLength(45, ErrorMessage = "La dirección debe tener como máximo 45 caracteres")]
        public string? Address { get; set; }

      //  [StringLength(45, ErrorMessage = "El número de teléfono debe tener como máximo 45 caracteres")]
        public string? Phone { get; set; }
    }
}
