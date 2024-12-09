using HomeInc.Aplication.Dtos;
using HomeInc.Domain.Entities;
using HomeInc.Infraestructure.Commands;
using HomeInc.Infraestructure.DataBase;
using MediatR;

namespace HomeInc.Aplication.Handlers
{
    public class UsuarioCreateHandler : IRequestHandler<UsuarioCreateCommand, UsuarioDTO>
    {
        private readonly HomeContext _context;

        public UsuarioCreateHandler(HomeContext context)
        {
            _context = context;
        }
        public async Task<UsuarioDTO> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Usuario
                {
                    Email = request.Email,
                    Password = request.Password,
                };

                _context.Usuarios.Add(result);

                await _context.SaveChangesAsync();

                return new UsuarioDTO
                {
                    Id = result.Id,
                    Email = result.Email,
                    Password = result.Password,
                };
            }
            catch (Exception ex) { throw new Exception("Error al crear al usuario " + ex); }
            
        }
    }
}
