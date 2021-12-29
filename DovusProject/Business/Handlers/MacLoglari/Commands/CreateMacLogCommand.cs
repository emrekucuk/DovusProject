using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.SavasLoglari.Commands
{
    public class CreateMacLogCommand : IRequest<IResult>
    {
        public string Olaylar { get; set; }
        public class CreateMacLogCommandHandler : IRequestHandler<CreateMacLogCommand, IResult>
        {
            private readonly IMacLoglariRepository _macLoglariRepository;

            public CreateMacLogCommandHandler(IMacLoglariRepository macLoglariRepository)
            {
                _macLoglariRepository = macLoglariRepository;
            }

            public async Task<IResult> Handle(CreateMacLogCommand request, CancellationToken cancellationToken)
            {
  
                var addedMacLog = new Entities.MacLoglari()
                {
                    Olaylar = request.Olaylar
                };
                _macLoglariRepository.Update(addedMacLog);
                await _macLoglariRepository.SaveChangesAsync();
                return new SuccessResult("Eklendi");

            }
        }
    }
}
