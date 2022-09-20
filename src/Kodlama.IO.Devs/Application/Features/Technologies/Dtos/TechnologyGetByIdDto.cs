using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Dtos
{
    public class TechnologyGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SoftwareLanguageName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}
