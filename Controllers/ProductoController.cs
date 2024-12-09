using HomeInc.Aplication.Dtos;
using HomeInc.Infraestructure.Commands;
using HomeInc.Infraestructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoDTO>> GetProducto()
        {
            return await _mediator.Send(new ProductoGetAllQuery());
        }

        [HttpGet("{id}")]
        public async Task<ProductoDTO> GetProductoById(Guid id)
        {
            return await _mediator.Send(new ProductoGetByIdQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> PostProducto(ProductoCreateCommand command)
        {
            var res = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetProductoById), new { id = res.Id }, res);
        }

        [HttpPut]
        public async Task<ActionResult<ProductoDTO>> PutProducto(ProductoUpdateCommand command)
        {
            var res = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetProductoById), new { id = res.Id }, res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(Guid id)
        {
            var result = await _mediator.Send(new ProductoDeleteCommand(id));

            if (result) return NoContent();
            else return BadRequest();
        }

    }
}
