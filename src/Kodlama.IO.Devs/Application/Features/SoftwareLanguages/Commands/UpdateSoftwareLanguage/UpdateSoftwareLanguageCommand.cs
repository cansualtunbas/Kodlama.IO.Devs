using Application.Features.SoftwareLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Commands.UpdateSoftwareLanguage
{
    public class UpdateSoftwareLanguageCommand:IRequest<UpdatedSoftwareLanguageEntityDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public class UpdateSoftwareLanguageCommandHandler : IRequestHandler<UpdateSoftwareLanguageCommand, UpdatedSoftwareLanguageEntityDto>
        {
            private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
            private readonly IMapper _mapper;

            public UpdateSoftwareLanguageCommandHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper)
            {
                _softwareLanguageRepository = softwareLanguageRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSoftwareLanguageEntityDto> Handle(UpdateSoftwareLanguageCommand request, CancellationToken cancellationToken)
            {
                SoftwareLanguage mappedSoftwareLanguage = _mapper.Map<SoftwareLanguage>(request);
                mappedSoftwareLanguage.CreateDate = DateTime.Now;
                SoftwareLanguage updatedSoftwareLanguage = await _softwareLanguageRepository.UpdateAsync(mappedSoftwareLanguage);
                UpdatedSoftwareLanguageEntityDto updatedSoftwareLanguageEntityDto = _mapper.Map<UpdatedSoftwareLanguageEntityDto>(updatedSoftwareLanguage);

                return updatedSoftwareLanguageEntityDto;
            }
        }
    }
}
