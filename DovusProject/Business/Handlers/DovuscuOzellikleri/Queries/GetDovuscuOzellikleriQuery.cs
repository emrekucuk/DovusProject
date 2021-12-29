using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.DovuscuOzellikleri.Queries
{
    public class GetDovuscuOzellikleriQuery : IRequest<IDataResult<IEnumerable<Entities.DovuscuOzellikleri>>>
    {
        public class GetDovuscuOzellikleriQueryHandler : IRequestHandler<GetDovuscuOzellikleriQuery, IDataResult<IEnumerable<Entities.DovuscuOzellikleri>>>
        {
            private readonly IDovuscuOzellikleriRepository _dovuscuOzellikleriRepository;

            public GetDovuscuOzellikleriQueryHandler(IDovuscuOzellikleriRepository dovuscuOzellikleriRepository)
            {
                _dovuscuOzellikleriRepository = dovuscuOzellikleriRepository;
            }

            public async Task<IDataResult<IEnumerable<Entities.DovuscuOzellikleri>>> Handle(GetDovuscuOzellikleriQuery request, CancellationToken cancellationToken)
            {
                var dovuscuOzellikleriList = await _dovuscuOzellikleriRepository.GetListAsync();
                return new SuccessDataResult<IEnumerable<Entities.DovuscuOzellikleri>>(dovuscuOzellikleriList);
            }
        }
    }
}
