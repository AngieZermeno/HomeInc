using HomeInc.Aplication.Dtos;
using HomeInc.Infraestructure.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<UsuarioDTO> PostUsuario (UsuarioCreateCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
