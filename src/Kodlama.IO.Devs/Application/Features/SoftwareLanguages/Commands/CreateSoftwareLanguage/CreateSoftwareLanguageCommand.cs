using Application.Features.SoftwareLanguages.Dtos;
using Application.Features.SoftwareLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SoftwareLanguages.Commands.CreateSoftwareLanguage
{
    public class CreateSoftwareLanguageCommand:IRequest<CreatedSoftwareLanguageEntityDto>
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        //irequesthandler içindeki ilk terim çağırılacak command, ikinci terim döndürülecek veri
        public class CreateSoftwareLanguageCommandHandler : IRequestHandler<CreateSoftwareLanguageCommand, CreatedSoftwareLanguageEntityDto>
        {
            private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
            private readonly IMapper _mapper;
            private readonly SoftwareLanguageBusinessRules _softwareLanguageBusinessRules;

            public CreateSoftwareLanguageCommandHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper, SoftwareLanguageBusinessRules softwareLanguageBusinessRules)
            {
                _softwareLanguageRepository = softwareLanguageRepository;
                _mapper = mapper;
                _softwareLanguageBusinessRules = softwareLanguageBusinessRules;
            }

            public async Task<CreatedSoftwareLanguageEntityDto> Handle(CreateSoftwareLanguageCommand request, CancellationToken cancellationToken)
            {
               await _softwareLanguageBusinessRules.SoftwareLanguageCanNotBeDuplicatedWhenInserted(request.Name);
                //gelen request'i softwareLanguage nesnesine çevirmek için mapper kullanıyoruz.
                SoftwareLanguage mappedSoftwareLanguage = _mapper.Map<SoftwareLanguage>(request);
                mappedSoftwareLanguage.CreateDate = DateTime.Now;
                //repository kullanarak bu ekleme işlemini gerçekleştirmek gerekiyor.
                SoftwareLanguage createdSoftwareLanguage = await _softwareLanguageRepository.AddAsync(mappedSoftwareLanguage);

                //veri tabanından geleni dto'ya çevirmemiz lazım.
                CreatedSoftwareLanguageEntityDto createdSoftwareLanguageEntityDto = _mapper.Map<CreatedSoftwareLanguageEntityDto>(createdSoftwareLanguage);

                //ve dto döndürüyoruz.
                return createdSoftwareLanguageEntityDto;
            }
        }
    }
}
