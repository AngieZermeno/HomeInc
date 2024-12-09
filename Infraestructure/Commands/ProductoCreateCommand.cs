using HomeInc.Aplication.Dtos;
using MediatR;

namespace HomeInc.Infraestructure.Commands
{
    public class ProductoCreateCommand : IRequest<ProductoDTO>
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string TipoGarantia { get; set; }

        public ProductoCreateCommand(string nombre, string categoria, string tipoGarantia)
        {
            Nombre = nombre;
            Categoria = categoria;
            TipoGarantia = tipoGarantia;
        }
    }
}
