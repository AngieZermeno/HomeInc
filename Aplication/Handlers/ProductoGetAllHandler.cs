using HomeInc.Aplication.Dtos;
using HomeInc.Infraestructure.DataBase;
using HomeInc.Infraestructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeInc.Aplication.Handlers
{
    public class ProductoGetAllHandler : IRequestHandler<ProductoGetAllQuery, IEnumerable<ProductoDTO>>
    {
        private readonly HomeContext _context;

        public ProductoGetAllHandler(HomeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductoDTO>> Handle(ProductoGetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Productos.ToListAsync(cancellationToken);

                if (result.Any())
                {
                    return result.Select(x => new ProductoDTO
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Categoria = x.Categoria,
                        TipoGarantia = x.TipoGarantia,
                        Usuario = x.Usuario,
                        Fecha = x.Fecha,
                    });
                }

                return Enumerable.Empty<ProductoDTO>();

            }catch(Exception ex) { throw new Exception ("Error al recuperar el listado de productos" +ex); }
            
        }
    }
}
