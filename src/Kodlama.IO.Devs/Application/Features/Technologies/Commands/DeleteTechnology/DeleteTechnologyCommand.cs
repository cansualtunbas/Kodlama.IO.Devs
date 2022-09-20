using Application.Features.SoftwareLanguages.Dtos;
using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand:IRequest<DeletedTechnologyEntityDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyEntityDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedTechnologyEntityDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                //ilk adım kural varsa onu kontrol ediyoruz.
                //ikinci adım silinecek veriyi buluyoruz.
                Technology? technology = await _technologyRepository.GetAsync(r => r.Id == request.Id);
                //üçüncü adım repository kullanarak bu silme işlemini gerçekleştirmek gerekiyor.
                Technology deletedTechnology = await _technologyRepository.DeleteAsync(technology);

                //dördüncü adım veri tabanından geleni dto'ya çevirmemiz lazım.
                DeletedTechnologyEntityDto deletedTechnologyEntityDto = _mapper.Map<DeletedTechnologyEntityDto>(deletedTechnology);

                return deletedTechnologyEntityDto;
            }
        }
    }
}
