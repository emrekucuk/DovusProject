using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using DovusProject.Entities;
using MediatR;

namespace DovusProject.Business.Handlers.Maclar.Commands
{
    public class CreateMacCommand : IRequest<IDataResult<Mac>>
    {
        public int Dovuscu1 { get; set; }
        public int Dovuscu2 { get; set; }
        public class CreateMacCommandHandler : IRequestHandler<CreateMacCommand, IDataResult<Mac>>
        {
            private readonly IMacRepository _macRepository;

            public CreateMacCommandHandler(IMacRepository macRepository)
            {
                _macRepository = macRepository;
            }

            public async Task<IDataResult<Mac>> Handle(CreateMacCommand request, CancellationToken cancellationToken)
            {

                var addedMac = new Entities.Mac()
                {
                    Dovuscu1 = request.Dovuscu1,
                    Dovuscu2 = request.Dovuscu2,
                    VurmaSirasi = request.Dovuscu1
                };
                _macRepository.Update(addedMac);
                await _macRepository.SaveChangesAsync();
                return new SuccessDataResult<Mac>(addedMac,"Eklendi");

            }
        }
    }
}