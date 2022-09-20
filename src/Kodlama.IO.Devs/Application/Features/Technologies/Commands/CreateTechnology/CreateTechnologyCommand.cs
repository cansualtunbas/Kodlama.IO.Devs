using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand:IRequest<CreatedTechnologyEntityDto>
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public int SoftwareLanguageId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyEntityDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<CreatedTechnologyEntityDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                //ilk adım kural varsa onu kontrol ediyoruz.

                await _technologyBusinessRules.TechnologyCanNotBeDuplicatedWhenInserted(request.Name);
                // ikinci adım gelen request'i entity'ye dönüştürüyoruz.Map ile!
                Technology mappedTechnology = _mapper.Map<Technology>(request);
                mappedTechnology.CreateDate = DateTime.Now;
                //üçüncü adım repository kullanarak bu ekleme işlemini gerçekleştirmek gerekiyor.
                Technology createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);

                //dördüncü adım veri tabanından geleni dto'ya çevirmemiz lazım.
                CreatedTechnologyEntityDto createdTechnologyEntityDto = _mapper.Map<CreatedTechnologyEntityDto>(createdTechnology);

                return createdTechnologyEntityDto;

            }
        }

    }
}
