using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.GecmisMaclar.Commands
{
    public class UpdateGecmisMaclarCommand : IRequest<IDataResult<Entities.GecmisMaclar>>
    {
        public int Id { get; set; }
        public int KazananId{ get; set; }
        public class UpdateGecmisMaclarCommandHandler : IRequestHandler<UpdateGecmisMaclarCommand, IDataResult<Entities.GecmisMaclar>>
        {
            private readonly IGecmisMaclarRepository _gecmisMaclarRepository;
            private readonly IMediator _mediator;

            public UpdateGecmisMaclarCommandHandler( IMediator mediator, IGecmisMaclarRepository gecmisMaclarRepository)
            {
                _mediator = mediator;
                _gecmisMaclarRepository = gecmisMaclarRepository;
            }

            public async Task<IDataResult<Entities.GecmisMaclar>> Handle(UpdateGecmisMaclarCommand request, CancellationToken cancellationToken)
            {
                var gecmisMaclar = await _gecmisMaclarRepository.GetAsync(x => x.Id == request.Id);

                gecmisMaclar.KazananId = request.KazananId;
                _gecmisMaclarRepository.Update(gecmisMaclar);
                await _gecmisMaclarRepository.SaveChangesAsync();
                return new SuccessDataResult<Entities.GecmisMaclar>(gecmisMaclar, "Güncellendi");

            }
        }
    }
}
