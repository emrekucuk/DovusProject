using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.GecmisMaclar.Queries
{
    public class GetGecmisMaclarQuery : IRequest<IDataResult<IEnumerable<Entities.GecmisMaclar>>>
    {
        public class GetGecmisMaclarQueryHandler : IRequestHandler<GetGecmisMaclarQuery, IDataResult<IEnumerable<Entities.GecmisMaclar>>>
        {
            private readonly IGecmisMaclarRepository _gecmisMaclarRepository;

            public GetGecmisMaclarQueryHandler(IGecmisMaclarRepository gecmisMaclarRepository)
            {
                _gecmisMaclarRepository = gecmisMaclarRepository;
            }

            public async Task<IDataResult<IEnumerable<Entities.GecmisMaclar>>> Handle(GetGecmisMaclarQuery request, CancellationToken cancellationToken)
            {
                var gecmisMaclar = await _gecmisMaclarRepository.GetListAsync();
                return new SuccessDataResult<IEnumerable<Entities.GecmisMaclar>>(gecmisMaclar);
            }
        }
    }
}
