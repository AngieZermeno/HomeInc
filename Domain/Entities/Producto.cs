using System.ComponentModel.DataAnnotations;

namespace HomeInc.Domain.Entities
{
    public class Producto
    {
        public Guid Id { get; set; }    
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string TipoGarantia { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
