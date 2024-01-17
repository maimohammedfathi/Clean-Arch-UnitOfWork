using Clean_Arch___UnitOFWork.Application.Interface;
using MediatR;

namespace Clean_Arch___UnitOFWork.Application.Mediator.Command.Delete
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IRepository<object> _repository;

        public DeleteItemCommandHandler(IRepository<object> repository)
        {
            _repository=repository;
        }

        public async Task Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            await _repository.SaveChangeAsync(cancellationToken);
            return;
        }
    }
}
