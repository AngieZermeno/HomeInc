using HomeInc.Aplication.Dtos;
using MediatR;

namespace HomeInc.Infraestructure.Queries
{
    public class ProductoGetAllQuery : IRequest<IEnumerable<ProductoDTO>>
    {
        public ProductoGetAllQuery()
        {
            
        }
    }
}
