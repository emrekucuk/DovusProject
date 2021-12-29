using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.GecmisMaclar.Queries
{
    public class GetGecmisMacQuery : IRequest<IDataResult<Entities.GecmisMaclar>>
    {
        public int Id { get; set; }
        public class GetGecmisMacQueryHandler : IRequestHandler<GetGecmisMacQuery, IDataResult<Entities.GecmisMaclar>>
        {
            private readonly IGecmisMaclarRepository _gecmisMaclarRepository;

            public GetGecmisMacQueryHandler(IGecmisMaclarRepository gecmisMaclarRepository)
            {
                _gecmisMaclarRepository = gecmisMaclarRepository;
            }

            public async Task<IDataResult<Entities.GecmisMaclar>> Handle(GetGecmisMacQuery request, CancellationToken cancellationToken)
            {
                var gecmisMac = await _gecmisMaclarRepository.GetAsync(x => x.Id == request.Id);
                return new SuccessDataResult<Entities.GecmisMaclar>(gecmisMac);
            }
        }
    }
}
