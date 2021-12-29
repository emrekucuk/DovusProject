using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.SavasLoglari.Commands
{
    public class CreateSavasLogCommand : IRequest<IResult>
    {
        public string Olaylar { get; set; }
        public class CreateSavasLogCommandHandler : IRequestHandler<CreateSavasLogCommand, IResult>
        {
            private readonly ISavasLoglariRepository _savasLoglariRepository;

            public CreateSavasLogCommandHandler(ISavasLoglariRepository savasLoglariRepository)
            {
                _savasLoglariRepository = savasLoglariRepository;
            }

            public async Task<IResult> Handle(CreateSavasLogCommand request, CancellationToken cancellationToken)
            {
  
                var addedSavasLog = new Entities.SavasLoglari()
                {
                    Olaylar = request.Olaylar
                };
                _savasLoglariRepository.Update(addedSavasLog);
                await _savasLoglariRepository.SaveChangesAsync();
                return new SuccessResult("Eklendi");

            }
        }
    }
}
