using MediatR;

namespace HomeInc.Infraestructure.Commands
{
    public class ProductoDeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public ProductoDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
