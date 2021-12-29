using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.DovuscuOzellikleri.Commands
{
    public class UpdateDovuscuOzellikleriCommand : IRequest<IDataResult<Entities.DovuscuOzellikleri>>
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Yetenek1 { get; set; }
        public string Yetenek2 { get; set; }
        public class UpdateDovuscuOzellikleriCommandHandler : IRequestHandler<UpdateDovuscuOzellikleriCommand, IDataResult<Entities.DovuscuOzellikleri>>
        {
            private readonly IDovuscuOzellikleriRepository _dovuscuOzellikleriRepository;

            public UpdateDovuscuOzellikleriCommandHandler(IDovuscuOzellikleriRepository dovuscuOzellikleriRepository)
            {
                _dovuscuOzellikleriRepository = dovuscuOzellikleriRepository;
            }

            public async Task<IDataResult<Entities.DovuscuOzellikleri>> Handle(UpdateDovuscuOzellikleriCommand request, CancellationToken cancellationToken)
            {
                var isThereDovuscu = await _dovuscuOzellikleriRepository.GetAsync(u => u.Id == request.Id);
                
                isThereDovuscu.Ad = request.Ad;
                isThereDovuscu.Yetenek1 = request.Yetenek1;
                isThereDovuscu.Yetenek2 = request.Yetenek2;

                _dovuscuOzellikleriRepository.Update(isThereDovuscu);
                await _dovuscuOzellikleriRepository.SaveChangesAsync();
                return new SuccessDataResult<Entities.DovuscuOzellikleri>(isThereDovuscu, "Güncellendi");

            }
        }
    }
}
