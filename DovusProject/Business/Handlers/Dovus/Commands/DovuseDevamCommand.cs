using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Handlers.GecmisMaclar.Commands;
using DovusProject.Business.Handlers.MacLoglari.Commands;
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
            private readonly IMacRepository _macRepository;
            private readonly IMediator _mediator;

            public DovuseDevamCommandHandler(IDovuscuOzellikleriRepository dovuscuOzellikleriRepository, IMediator mediator, IMacRepository macRepository)
            {
                _dovuscuOzellikleriRepository = dovuscuOzellikleriRepository;
                _mediator = mediator;
                _macRepository = macRepository;
            }

            public async Task<IResult> Handle(DovuseDevamCommand request, CancellationToken cancellationToken)
            {
                var mac = await _macRepository.GetAsync(x => 
                    (x.Dovuscu1 == request.HasarAlanId || x.Dovuscu1 == request.HasarVerenId) && 
                    (x.Dovuscu2 == request.HasarAlanId || x.Dovuscu2 == request.HasarVerenId));

                if (mac.VurmaSirasi != request.HasarVerenId)
                {
                    return new SuccessResult("Vurma Sırası Rakibinizde.");
                }

                mac.VurmaSirasi = request.HasarAlanId;
                _macRepository.Update(mac);
                await _macRepository.SaveChangesAsync();

                var dovusculer = await _dovuscuOzellikleriRepository.GetListAsync();
                var hasarAlan = dovusculer.FirstOrDefault(x => x.Id == request.HasarAlanId);
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
                    var maclar = await _mediator.Send(new CreateGecmisMaclarCommand()
                    {
                        Dovuscu1Id = hasarAlan.Id,
                        Dovuscu2Id = hasarVeren.Id,
                        KazananId = hasarVeren.Id
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
                        Olaylar = hasarAlan.Ad + " maçı kaybetti."
                    });

                    return new SuccessResult("Maç Bitti. Kazanan: " + maclar.Data.KazananId);
                }

                return new SuccessDataResult<Entities.DovuscuOzellikleri>(hasarAlan, "Dövüşe devam ediliyor.");

            }
        }
    }
}
