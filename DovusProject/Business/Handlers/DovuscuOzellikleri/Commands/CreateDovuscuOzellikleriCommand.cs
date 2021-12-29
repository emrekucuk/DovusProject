using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DovusProject.Business.Results;
using DovusProject.DataAccess.Abstract;
using MediatR;

namespace DovusProject.Business.Handlers.DovuscuOzellikleri.Commands
{
    public class CreateDovuscuOzellikleriCommand : IRequest<IDataResult<Entities.DovuscuOzellikleri>>
    {
        public string Yetenek1 { get; set; }
        public string Yetenek2 { get; set; }
        public class CreateDovuscuOzellikleriCommandHandler : IRequestHandler<CreateDovuscuOzellikleriCommand, IDataResult<Entities.DovuscuOzellikleri>>
        {
            private readonly IDovuscuOzellikleriRepository _dovuscuOzellikleriRepository;
            private readonly IMediator _mediator;

            public CreateDovuscuOzellikleriCommandHandler(IDovuscuOzellikleriRepository dovuscuOzellikleriRepository, IMediator mediator)
            {
                _dovuscuOzellikleriRepository = dovuscuOzellikleriRepository;
                _mediator = mediator;
            }

            public async Task<IDataResult<Entities.DovuscuOzellikleri>> Handle(CreateDovuscuOzellikleriCommand request, CancellationToken cancellationToken)
            {
                var list = _dovuscuOzellikleriRepository.GetList().Count() + 1;
                Random random = new Random();
                var addDovuscu = new Entities.DovuscuOzellikleri()
                {
                    Ad = "Oyuncu " + list,
                    CanDegeri = 100,
                    ZırhDegeri = 100,
                    DuzVurusHasari = random.Next(10,20),
                    Yetenek1 = request.Yetenek1,
                    Yetenek1Hasari = random.Next(20, 30),
                    Yetenek2 = request.Yetenek2,
                    Yetenek2Hasari = random.Next(30,40)
                };
                _dovuscuOzellikleriRepository.Add(addDovuscu);
                await _dovuscuOzellikleriRepository.SaveChangesAsync();
                return new SuccessDataResult<Entities.DovuscuOzellikleri>(addDovuscu, "Eklendi");
            }
        }
    }
}
