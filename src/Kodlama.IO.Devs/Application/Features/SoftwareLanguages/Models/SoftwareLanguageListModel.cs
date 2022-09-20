using Application.Features.SoftwareLanguages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Models
{
    public class SoftwareLanguageListModel: BasePageableModel
    {
        public IList<SoftwareLanguageListDto> Items { get; set; }
    }
}
