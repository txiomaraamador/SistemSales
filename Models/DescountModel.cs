using System.ComponentModel.DataAnnotations;

namespace SistemSales.Models
{
    public class DescountModel
    {
        public int IdDescount { get; set; }
        [Required(ErrorMessage = "El codigo es obligatorio")]
       
        public string? Code { get; set; }
        [Required]
       
        public string? Cant { get; set; }
       
    }
}
