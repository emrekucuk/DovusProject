using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.Maclar.Commands
{
    public class UpdateMacCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int Dovuscu1 { get; set; }
        public int Dovuscu2 { get; set; }
        public int VurmaSirasi { get; set; }
        public class UpdateMacCommandHandler : IRequestHandler<UpdateMacCommand, IResult>
        {
            private readonly IMacRepository _macRepository;

            public UpdateMacCommandHandler(IMacRepository macRepository)
            {
                _macRepository = macRepository;
            }

            public async Task<IResult> Handle(UpdateMacCommand request, CancellationToken cancellationToken)
            {

                var addedMac = new Entities.Mac()
                {
                    Dovuscu1 = request.Dovuscu1,
                    Dovuscu2 = request.Dovuscu2,
                    VurmaSirasi = request.Dovuscu1
                };
                _macRepository.Update(addedMac);
                await _macRepository.SaveChangesAsync();
                return new SuccessResult("Eklendi");

            }
        }
    }
}