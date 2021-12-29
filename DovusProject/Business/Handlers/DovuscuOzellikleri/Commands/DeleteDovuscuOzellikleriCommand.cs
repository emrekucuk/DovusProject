using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.DovuscuOzellikleri.Commands
{
    public class DeleteDovuscuOzellikleriCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public class DeleteDovuscuOzellikleriCommandHandler : IRequestHandler<DeleteDovuscuOzellikleriCommand, IResult>
        {
            private readonly IDovuscuOzellikleriRepository _dovuscuOzellikleriRepository;

            public DeleteDovuscuOzellikleriCommandHandler(IDovuscuOzellikleriRepository dovuscuOzellikleriRepository)
            {
                _dovuscuOzellikleriRepository = dovuscuOzellikleriRepository;
            }

            public async Task<IResult> Handle(DeleteDovuscuOzellikleriCommand request, CancellationToken cancellationToken)
            {
                var deleteDovuscu = _dovuscuOzellikleriRepository.Get(x => x.Id == request.Id);
                _dovuscuOzellikleriRepository.Delete(deleteDovuscu);
                await _dovuscuOzellikleriRepository.SaveChangesAsync();
                return new SuccessResult("Silindi");
            }
        }
    }
}
