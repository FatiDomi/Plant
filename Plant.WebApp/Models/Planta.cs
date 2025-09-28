using System.ComponentModel.DataAnnotations;

namespace Plant.WebApp.Models
{
    public class Planta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre científico es obligatorio")]
        [Display(Name = "Nombre científico")]
        public required string NombreCientifico { get; set; }

        [Required(ErrorMessage = "El origen es obligatorio")]
        [Display(Name = "Origen")]
        public required string Origen { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción")]
        public required string Descripcion { get; set; }

        [Required(ErrorMessage = "Los cuidados básicos son obligatorios")]
        [Display(Name = "Cuidados básicos")]
        public required string CuidadosBasicos { get; set; }

        [Required(ErrorMessage = "El clima ideal es obligatorio")]
        [Display(Name = "Clima ideal")]
        public required string ClimaIdeal { get; set; }

        [Required(ErrorMessage = "La floración es obligatoria")]
        [Display(Name = "Floración")]
        public required string Floracion { get; set; }

        [Required(ErrorMessage = "La altura máxima es obligatoria")]
        [Display(Name = "Altura máxima")]
        public required string AlturaMaxima { get; set; }

        [Required(ErrorMessage = "La imagen es obligatoria")]
        [Display(Name = "Imagen")]
        public required string ImagenUrl { get; set; }
    }
}
