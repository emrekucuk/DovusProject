using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Handlers.GecmisMaclar.Commands;
using DovusProject.Business.Handlers.SavasLoglari.Commands;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.Dovus.Commands
{
    public class DovuseDevamCommand : IRequest<IResult>
    {
        public int HasarAlanId { get; set; }
        public int HasarVerenId { get; set; }
        public int HareketId { get; set; }
        public class DovuseDevamCommandHandler : IRequestHandler<DovuseDevamCommand, IResult>
        {
            private readonly IDovuscuOzellikleriRepository _dovuscuOzellikleriRepository;
            private readonly IMediator _mediator;
            private readonly IGecmisMaclarRepository _gecmisMaclarRepository;

            public DovuseDevamCommandHandler(IDovuscuOzellikleriRepository dovuscuOzellikleriRepository, IMediator mediator, IGecmisMaclarRepository gecmisMaclarRepository)
            {
                _dovuscuOzellikleriRepository = dovuscuOzellikleriRepository;
                _mediator = mediator;
                _gecmisMaclarRepository = gecmisMaclarRepository;
            }

            public async Task<IResult> Handle(DovuseDevamCommand request, CancellationToken cancellationToken)
            {

                var dovusculer = await _dovuscuOzellikleriRepository.GetListAsync();
                var hasarAlan = dovusculer.FirstOrDefault(x=>x.Id ==request.HasarAlanId);
                var hasarVeren = dovusculer.FirstOrDefault(x => x.Id == request.HasarVerenId);

                if (request.HareketId == 1)
                {
                    hasarAlan.CanDegeri -= hasarVeren.DuzVurusHasari;
                    hasarAlan.ZırhDegeri -= 5;
                }
                else if (request.HareketId == 2)
                {
                    hasarAlan.CanDegeri -= hasarVeren.Yetenek1Hasari;
                    hasarAlan.ZırhDegeri -= 10;
                }
                else
                {
                    hasarAlan.CanDegeri -= hasarVeren.Yetenek2Hasari;
                    hasarAlan.ZırhDegeri -= 15;
                }
                await _mediator.Send(new CreateMacLogCommand()
                {
                    Olaylar = hasarAlan.Ad + ", " + hasarVeren.Ad + "'den darbe aldı."
                });


                _dovuscuOzellikleriRepository.Update(hasarAlan);
                await _dovuscuOzellikleriRepository.SaveChangesAsync();
                
                if (hasarAlan.CanDegeri <= 0)
                {
                    var macId = await _gecmisMaclarRepository.GetAsync(x =>
                        (x.Oyuncu1Id == request.HasarVerenId || x.Oyuncu1Id == request.HasarAlanId) && (x.Oyuncu2Id == request.HasarVerenId || x.Oyuncu2Id == request.HasarAlanId));
                    var maclar = await _mediator.Send(new UpdateGecmisMaclarCommand()
                    {
                        Id = macId.Id,
                        KazananId = request.HasarVerenId
                    });
                    hasarAlan.CanDegeri = 100;
                    hasarAlan.ZırhDegeri = 100;
                    hasarVeren.CanDegeri = 100;
                    hasarVeren.ZırhDegeri = 100;
                    _dovuscuOzellikleriRepository.Update(hasarAlan);
                    _dovuscuOzellikleriRepository.Update(hasarVeren);
                    await _dovuscuOzellikleriRepository.SaveChangesAsync();

                    await _mediator.Send(new CreateMacLogCommand()
                    {
                        Olaylar = hasarAlan.Ad + " savaşı kaybetti."
                    });

                    return new SuccessResult("Maç Bitti. Kazanan: " + maclar.Data.KazananId);
                }

                return new SuccessDataResult<Entities.DovuscuOzellikleri>(hasarAlan, "Dövüşe devam ediliyor.");

            }
        }
    }
}
