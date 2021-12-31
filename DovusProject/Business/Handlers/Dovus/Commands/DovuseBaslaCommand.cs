﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Handlers.DovuscuOzellikleri.Commands;
using DovusProject.Business.Handlers.GecmisMaclar.Commands;
using DovusProject.Business.Handlers.Maclar.Commands;
using DovusProject.Business.Handlers.MacLoglari.Commands;
using DovusProject.Business.Results;
using MediatR;

namespace DovusProject.Business.Handlers.Dovus.Commands
{
    public class DovuseBaslaCommand : IRequest<IResult>
    {
        public string Yetenek1 { get; set; }
        public string Yetenek2 { get; set; }
        public class DovuseBaslaCommandHandler : IRequestHandler<DovuseBaslaCommand, IResult>
        {
            private readonly IMediator _mediator;

            public DovuseBaslaCommandHandler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<IResult> Handle(DovuseBaslaCommand request, CancellationToken cancellationToken)
            {
  
                var addedDovuscuOzellikleri = await _mediator.Send(new CreateDovuscuOzellikleriCommand()
                {
                    Yetenek1 = request.Yetenek1,
                    Yetenek2 = request.Yetenek2
                });

                var addedDovus = await _mediator.Send(new CreateMacCommand()
                {
                   Dovuscu1 = 1,
                   Dovuscu2 = addedDovuscuOzellikleri.Data.Id
                });

                await _mediator.Send(new CreateMacLogCommand()
                {
                    Olaylar = addedDovuscuOzellikleri.Data.Ad + " oluşturuldu. Armor King ile olan maçı başladı."
                });

                List<string> list = new List<string>();
                list.Add("Dövüşçü 1 id = " + addedDovus.Data.Dovuscu1);
                list.Add("Dövüşçü 2 id = " + addedDovus.Data.Dovuscu2);
                list.Add("Vuruş Sırası = "+ addedDovus.Data.VurmaSirasi);
                list.Add("Düz vuruş = 1" );
                list.Add("Yetenek 1 = 2" );
                list.Add("Yetenek 2 = 3" );
                return new SuccessDataResult<List<string>>(list, "Dövüşe Başlandı");

            }
        }
    }
}
