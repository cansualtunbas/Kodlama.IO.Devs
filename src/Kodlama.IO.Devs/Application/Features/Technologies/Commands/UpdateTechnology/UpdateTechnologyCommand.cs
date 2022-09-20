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

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand:IRequest<UpdatedTechnologyEntityDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int SoftwareLanguageId { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyEntityDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedTechnologyEntityDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                //birinci adım eğer kural varsa onu kontrol ediyoruz.

                // ikinci adım gelen request'i entity'ye dönüştürüyoruz.Map ile!
                Technology mappedTechnology = _mapper.Map<Technology>(request);

                //üçüncü adım repository kullanarak bu update işlemini gerçekleştirmek gerekiyor.
                mappedTechnology.CreateDate = DateTime.Now;
                Technology updatedTechnology =await _technologyRepository.UpdateAsync(mappedTechnology);

                //dördüncü adım veri tabanından geleni dto'ya çevirmemiz lazım.
                UpdatedTechnologyEntityDto updatedTechnologyEntityDto = _mapper.Map<UpdatedTechnologyEntityDto>(updatedTechnology);


                return updatedTechnologyEntityDto;
            }
        }
    }
}
