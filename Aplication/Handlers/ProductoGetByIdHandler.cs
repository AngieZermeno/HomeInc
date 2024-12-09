using HomeInc.Aplication.Dtos;
using HomeInc.Infraestructure.DataBase;
using HomeInc.Infraestructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeInc.Aplication.Handlers
{
    public class ProductoGetByIdHandler : IRequestHandler<ProductoGetByIdQuery, ProductoDTO>
    {
        private readonly HomeContext _context;

        public ProductoGetByIdHandler(HomeContext context)
        {
            _context = context;
        }
        public async Task<ProductoDTO> Handle(ProductoGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Productos.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

                if (result == null) { return new ProductoDTO(); }

                return new ProductoDTO
                {
                    Id = result.Id,
                    Nombre = result.Nombre,
                    TipoGarantia = result.TipoGarantia,
                    Categoria = result.Categoria,
                    Fecha = result.Fecha,
                    Usuario = result.Usuario,
                };
            }
            catch (Exception ex) { throw new Exception("Error al recuperar el producto " + ex); }           

        }
    }
}
