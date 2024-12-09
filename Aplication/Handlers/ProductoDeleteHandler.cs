using HomeInc.Infraestructure.Commands;
using HomeInc.Infraestructure.DataBase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeInc.Aplication.Handlers
{
    public class ProductoDeleteHandler : IRequestHandler<ProductoDeleteCommand, bool>
    {
        private readonly HomeContext _context;

        public ProductoDeleteHandler(HomeContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(ProductoDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null) return false;

                var result = await _context.Productos.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

                if (result == null) return false;

                _context.Productos.Remove(result);
                await _context.SaveChangesAsync();

                return true;

            }catch (Exception ex) { throw new Exception("Error al eliminar el producto " + ex); }            

        }
    }
}
