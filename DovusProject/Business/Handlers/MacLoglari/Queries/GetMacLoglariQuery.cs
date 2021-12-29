using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.SavasLoglari.Queries
{
    public class GetMacLoglariQuery : IRequest<IDataResult<IEnumerable<Entities.MacLoglari>>>
    {
        public class GetMacLoglariQueryHandler : IRequestHandler<GetMacLoglariQuery, IDataResult<IEnumerable<Entities.MacLoglari>>>
        {
            private readonly IMacLoglariRepository _macLoglariRepository;

            public GetMacLoglariQueryHandler(IMacLoglariRepository macLoglariRepository)
            {
                _macLoglariRepository = macLoglariRepository;
            }

            public async Task<IDataResult<IEnumerable<Entities.MacLoglari>>> Handle(GetMacLoglariQuery request, CancellationToken cancellationToken)
            {
                var macLoglari = await _macLoglariRepository.GetListAsync();
                return new SuccessDataResult<IEnumerable<Entities.MacLoglari>>(macLoglari);
            }
        }
    }
}
