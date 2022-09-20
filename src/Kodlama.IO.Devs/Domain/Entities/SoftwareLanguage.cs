using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SoftwareLanguage:Entity
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }

        //bir yaazılım dilinin birden çok teknolojisi olabilir.
        public virtual ICollection<Technology> Technologies { get; set; }
        public SoftwareLanguage()
        {

        }

        public SoftwareLanguage(int id,string name, bool active, DateTime createDate, int createUser)
        {
            Id = id;
            Name = name;
            Active = active;
            CreateDate = createDate;
            CreateUser = createUser;
        }
    }
}
