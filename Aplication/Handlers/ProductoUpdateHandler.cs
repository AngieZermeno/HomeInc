using HomeInc.Aplication.Dtos;
using HomeInc.Aplication.Interfaces;
using HomeInc.Infraestructure.Commands;
using HomeInc.Infraestructure.DataBase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeInc.Aplication.Handlers
{
    public class ProductoUpdateHandler : IRequestHandler<ProductoUpdateCommand, ProductoDTO>
    {
        private readonly HomeContext _context;
        private readonly IUserService _user;

        public ProductoUpdateHandler(HomeContext context, IUserService user)
        {
            _context = context;
            _user = user;
        }
        public async Task<ProductoDTO> Handle(ProductoUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Productos.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

                if (result == null) { return new ProductoDTO(); }

                result.Nombre = request.Nombre;
                result.TipoGarantia = request.TipoGarantia;
                result.Categoria = request.Categoria;
                result.Usuario = _user.GetUsuario();
                result.Fecha = DateTime.Now;

                _context.Productos.Update(result);

                await _context.SaveChangesAsync();

                return new ProductoDTO
                {
                    Id = result.Id,
                    Nombre = result.Nombre,
                    TipoGarantia = result.TipoGarantia,
                    Categoria = result.Categoria,
                    Fecha = result.Fecha,
                    Usuario = result.Usuario
                };

            }
                catch (Exception ex) { throw new Exception(message: ex.Message); }


            


        }
    }
}
