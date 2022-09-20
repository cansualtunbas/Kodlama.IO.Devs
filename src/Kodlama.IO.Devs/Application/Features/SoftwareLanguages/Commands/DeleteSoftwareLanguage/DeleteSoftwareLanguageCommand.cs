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

namespace Application.Features.SoftwareLanguages.Commands.DeleteSoftwareLanguage
{
    public class DeleteSoftwareLanguageCommand:IRequest<DeletedSoftwareLanguageEntityDto>
    {
        public int Id { get; set; }

        public class DeleteSoftwareLanguageCommandHandler : IRequestHandler<DeleteSoftwareLanguageCommand, DeletedSoftwareLanguageEntityDto>
        {
            private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
            private readonly IMapper _mapper;

            public DeleteSoftwareLanguageCommandHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper)
            {
                _softwareLanguageRepository = softwareLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSoftwareLanguageEntityDto> Handle(DeleteSoftwareLanguageCommand request, CancellationToken cancellationToken)
            {
                SoftwareLanguage? softwareLanguage = await _softwareLanguageRepository.GetAsync(x => x.Id == request.Id);

                SoftwareLanguage deletedSoftwareLanguage = await _softwareLanguageRepository.DeleteAsync(softwareLanguage);

                //veri tabanından geleni dto'ya çevirmemiz lazım.
                DeletedSoftwareLanguageEntityDto deletedSoftwareLanguageEntityDto = _mapper.Map<DeletedSoftwareLanguageEntityDto>(deletedSoftwareLanguage);

                //ve dto döndürüyoruz.
                return deletedSoftwareLanguageEntityDto;
            }
        }
    }
}
