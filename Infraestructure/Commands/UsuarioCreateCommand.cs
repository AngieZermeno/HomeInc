using HomeInc.Aplication.Dtos;
using MediatR;

namespace HomeInc.Infraestructure.Commands
{
    public class UsuarioCreateCommand : IRequest<UsuarioDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UsuarioCreateCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
