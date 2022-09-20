using Application.Features.SoftwareLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.SoftwareLanguages.Queries.GetListSoftwareLanguage
{
    public class GetListSoftwareLanguageQuery:IRequest<SoftwareLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSoftwareLanguageQueryHandler : IRequestHandler<GetListSoftwareLanguageQuery, SoftwareLanguageListModel>
        {
            private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
            private readonly IMapper _mapper;

            public GetListSoftwareLanguageQueryHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper)
            {
                _softwareLanguageRepository = softwareLanguageRepository;
                _mapper = mapper;
            }

            public async Task<SoftwareLanguageListModel> Handle(GetListSoftwareLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SoftwareLanguage> softwareLanguage = await _softwareLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                SoftwareLanguageListModel mappedSoftwareLanguageListModel = _mapper.Map<SoftwareLanguageListModel>(softwareLanguage);
                return mappedSoftwareLanguageListModel;
            }
        }
    }
}
