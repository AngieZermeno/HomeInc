using HomeInc.Aplication.Dtos;
using MediatR;

namespace HomeInc.Infraestructure.Commands
{
    public class ProductoUpdateCommand : IRequest<ProductoDTO>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string TipoGarantia { get; set; }

        public ProductoUpdateCommand(Guid id, string nombre, string categoria, string tipoGarantia)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;
            TipoGarantia = tipoGarantia;
        }
    }
}
