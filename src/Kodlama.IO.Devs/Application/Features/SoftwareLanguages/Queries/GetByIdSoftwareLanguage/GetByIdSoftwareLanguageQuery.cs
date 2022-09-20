using Application.Features.SoftwareLanguages.Dtos;
using Application.Features.SoftwareLanguages.Models;
using Application.Features.SoftwareLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Queries.GetByIdSoftwareLanguage
{
    public class GetByIdSoftwareLanguageQuery:IRequest<SoftwareLanguageGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdSoftwareLanguageQueryHandler : IRequestHandler<GetByIdSoftwareLanguageQuery, SoftwareLanguageGetByIdDto>
        {
            private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
            private readonly IMapper _mapper;
            private readonly SoftwareLanguageBusinessRules _softwareLanguageBusinessRules;

            public GetByIdSoftwareLanguageQueryHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper, SoftwareLanguageBusinessRules softwareLanguageBusinessRules)
            {
                _softwareLanguageRepository = softwareLanguageRepository;
                _mapper = mapper;
                _softwareLanguageBusinessRules = softwareLanguageBusinessRules;
            }

            public async Task<SoftwareLanguageGetByIdDto> Handle(GetByIdSoftwareLanguageQuery request, CancellationToken cancellationToken)
            {
                SoftwareLanguage? softwareLanguage = await _softwareLanguageRepository.GetAsync(x => x.Id == request.Id);
                _softwareLanguageBusinessRules.SoftwareLanguageShouldExistWhenRequested(softwareLanguage);
                SoftwareLanguageGetByIdDto softwareLanguageGetByIdDto = _mapper.Map<SoftwareLanguageGetByIdDto>(softwareLanguage);
                return softwareLanguageGetByIdDto;
            }
        }

    }
}
