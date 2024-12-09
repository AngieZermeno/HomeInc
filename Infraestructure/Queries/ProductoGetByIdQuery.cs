using HomeInc.Aplication.Dtos;
using MediatR;

namespace HomeInc.Infraestructure.Queries
{
    public class ProductoGetByIdQuery : IRequest<ProductoDTO>
    {
        public Guid Id { get; set; }

        public ProductoGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
