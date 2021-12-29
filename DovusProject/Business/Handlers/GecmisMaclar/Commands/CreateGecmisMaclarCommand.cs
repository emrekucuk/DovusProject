using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.GecmisMaclar.Commands
{
    public class CreateGecmisMaclarCommand : IRequest<IDataResult<Entities.GecmisMaclar>>
    {
        public int Oyuncu1Id { get; set; }
        public int Oyuncu2Id { get; set; }
        public class CreateGecmisMaclarCommandHandler : IRequestHandler<CreateGecmisMaclarCommand, IDataResult<Entities.GecmisMaclar>>
        {
            private readonly IGecmisMaclarRepository _gecmisMaclar;
            private readonly IMediator _mediator;

            public CreateGecmisMaclarCommandHandler(IMediator mediator, IGecmisMaclarRepository gecmisMaclar)
            {
                _mediator = mediator;
                _gecmisMaclar = gecmisMaclar;
            }

            public async Task<IDataResult<Entities.GecmisMaclar>> Handle(CreateGecmisMaclarCommand request, CancellationToken cancellationToken)
            {
                var addedDovus = new Entities.GecmisMaclar()
                {
                    Oyuncu1Id = request.Oyuncu1Id,
                    Oyuncu2Id = request.Oyuncu2Id
                };
                
                _gecmisMaclar.Update(addedDovus);
                await _gecmisMaclar.SaveChangesAsync();
                return new SuccessDataResult<Entities.GecmisMaclar>(addedDovus, "Güncellendi");

            }
        }
    }
}
