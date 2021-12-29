using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.SavasLoglari.Queries
{
    public class GetSavaslariLoglari : IRequest<IDataResult<IEnumerable<Entities.SavasLoglari>>>
    {
        public class GetSavaslariLoglariHandler : IRequestHandler<GetSavaslariLoglari, IDataResult<IEnumerable<Entities.SavasLoglari>>>
        {
            private readonly ISavasLoglariRepository _savasLoglariRepository;

            public GetSavaslariLoglariHandler(ISavasLoglariRepository savasLoglariRepository)
            {
                _savasLoglariRepository = savasLoglariRepository;
            }

            public async Task<IDataResult<IEnumerable<Entities.SavasLoglari>>> Handle(GetSavaslariLoglari request, CancellationToken cancellationToken)
            {
                var savasLoglari = await _savasLoglariRepository.GetListAsync();
                return new SuccessDataResult<IEnumerable<Entities.SavasLoglari>>(savasLoglari);
            }
        }
    }
}
