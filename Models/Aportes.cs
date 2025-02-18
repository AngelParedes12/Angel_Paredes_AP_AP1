using System.ComponentModel.DataAnnotations;

namespace Angel_Paredes_AP_AP1.Models
{
    public class Aportes
    {
        [Key]
        public int AporteId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten números")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Persona")]
        public string? Observacion { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(1, 200000.00, ErrorMessage = "Debe ser entre 1 y 200,000")]
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }
    }
}
