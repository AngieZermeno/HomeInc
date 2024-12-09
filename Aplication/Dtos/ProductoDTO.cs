using System.ComponentModel.DataAnnotations;

namespace HomeInc.Aplication.Dtos
{
    public class ProductoDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string TipoGarantia { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
    }
}
