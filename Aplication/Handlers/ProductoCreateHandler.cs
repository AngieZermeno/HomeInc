using HomeInc.Aplication.Dtos;
using HomeInc.Aplication.Interfaces;
using HomeInc.Domain.Entities;
using HomeInc.Infraestructure.Commands;
using HomeInc.Infraestructure.DataBase;
using MediatR;

namespace HomeInc.Aplication.Handlers
{
    public class ProductoCreateHandler : IRequestHandler<ProductoCreateCommand, ProductoDTO>
    {
        private readonly HomeContext _context;
        private readonly IUserService _user;

        public ProductoCreateHandler(HomeContext context, IUserService user)
        {
            _context = context;
            _user = user;
        }
        public async Task<ProductoDTO> Handle(ProductoCreateCommand request, CancellationToken cancellationToken)
        {
            if(request == null) { return new ProductoDTO(); }

            var newProducto = new Producto
            {
                Nombre = request.Nombre,
                Categoria = request.Categoria,
                TipoGarantia = request.TipoGarantia,
                Fecha = DateTime.Now,
                Usuario = _user.GetUsuario(),
            };

            _context.Productos.Add(newProducto);

            await _context.SaveChangesAsync();

            return new ProductoDTO
            {
                Id  = newProducto.Id,   
                Nombre = newProducto.Nombre,
                Categoria = newProducto.Categoria,
                TipoGarantia = newProducto.TipoGarantia,
                Fecha = newProducto.Fecha,
                Usuario = newProducto.Usuario,
            };

        }
    }
}
