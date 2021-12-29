using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.SavasLoglari.Queries
{
    public class GetSavasLogQuery : IRequest<IDataResult<Entities.SavasLoglari>>
    {
        public int Id { get; set; }
        public class GetSavasLogQueryHandler : IRequestHandler<GetSavasLogQuery, IDataResult<Entities.SavasLoglari>>
        {

            private readonly ISavasLoglariRepository _savasLoglariRepository;

            public GetSavasLogQueryHandler(ISavasLoglariRepository savasLoglariRepository)
            {
                _savasLoglariRepository = savasLoglariRepository;
            }

            public async Task<IDataResult<Entities.SavasLoglari>> Handle(GetSavasLogQuery request, CancellationToken cancellationToken)
            {
                var savasLoglari = await _savasLoglariRepository.GetAsync(x => x.Id == request.Id);
                return new SuccessDataResult<Entities.SavasLoglari>(savasLoglari);
            }
        }
    }
}
