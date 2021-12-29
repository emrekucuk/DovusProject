using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.SavasLoglari.Queries
{
    public class GetMacLogQuery : IRequest<IDataResult<Entities.MacLoglari>>
    {
        public int Id { get; set; }
        public class GetMacLogQueryHandler : IRequestHandler<GetMacLogQuery, IDataResult<Entities.MacLoglari>>
        {

            private readonly IMacLoglariRepository _macLoglariRepository;

            public GetMacLogQueryHandler(IMacLoglariRepository macLoglariRepository)
            {
                _macLoglariRepository = macLoglariRepository;
            }

            public async Task<IDataResult<Entities.MacLoglari>> Handle(GetMacLogQuery request, CancellationToken cancellationToken)
            {
                var macLog = await _macLoglariRepository.GetAsync(x => x.Id == request.Id);
                return new SuccessDataResult<Entities.MacLoglari>(macLog);
            }
        }
    }
}
