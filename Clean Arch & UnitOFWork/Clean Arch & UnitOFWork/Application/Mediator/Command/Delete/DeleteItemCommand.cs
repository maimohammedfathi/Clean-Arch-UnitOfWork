using MediatR;

namespace Clean_Arch___UnitOFWork.Application.Mediator.Command.Delete
{
    public class DeleteItemCommand :IRequest
    {
        public Guid Id { get; set; }
    }
}
