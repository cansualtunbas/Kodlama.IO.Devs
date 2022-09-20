using Application.Features.SoftwareLanguages.Commands.CreateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Commands.DeleteSoftwareLanguage;
using Application.Features.SoftwareLanguages.Commands.UpdateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Dtos;
using Application.Features.SoftwareLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<SoftwareLanguage>, SoftwareLanguageListModel>().ReverseMap();
            CreateMap<SoftwareLanguage, SoftwareLanguageListDto>().ReverseMap();
            CreateMap<SoftwareLanguage, SoftwareLanguageGetByIdDto>().ReverseMap();
            CreateMap<SoftwareLanguage, CreatedSoftwareLanguageEntityDto>().ReverseMap();
            CreateMap<SoftwareLanguage, CreateSoftwareLanguageCommand>().ReverseMap();
            CreateMap<SoftwareLanguage, DeletedSoftwareLanguageEntityDto>().ReverseMap();
            CreateMap<SoftwareLanguage, DeleteSoftwareLanguageCommand>().ReverseMap();
            CreateMap<SoftwareLanguage, UpdatedSoftwareLanguageEntityDto>().ReverseMap();
            CreateMap<SoftwareLanguage, UpdateSoftwareLanguageCommand>().ReverseMap();
        }
    }
}
