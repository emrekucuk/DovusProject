using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.DovuscuOzellikleri.Queries
{
    public class GetDovuscuOzellikQuery : IRequest<IDataResult<Entities.DovuscuOzellikleri>>
    {
        public int Id { get; set; }
        public class GetDovuscuOzellikQueryHandler : IRequestHandler<GetDovuscuOzellikQuery, IDataResult<Entities.DovuscuOzellikleri>>
        {
            private readonly IDovuscuOzellikleriRepository _dovuscuOzellikleriRepository;

            public GetDovuscuOzellikQueryHandler(IDovuscuOzellikleriRepository dovuscuOzellikleriRepository)
            {
                _dovuscuOzellikleriRepository = dovuscuOzellikleriRepository;
            }

            public async Task<IDataResult<Entities.DovuscuOzellikleri>> Handle(GetDovuscuOzellikQuery request, CancellationToken cancellationToken)
            {
                var dovuscuOzellik = await _dovuscuOzellikleriRepository.GetAsync(x => x.Id == request.Id);
                return new SuccessDataResult<Entities.DovuscuOzellikleri>(dovuscuOzellik);
            }
        }
    }
}
