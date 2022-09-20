using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology: Entity
    {
        public int SoftwareLanguageId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        //birçok orm tarafından kullanılması için virtual olarak tanımlanıyor.
        //teknoloji bir yazılım diline ait.
        public virtual SoftwareLanguage? SoftwareLanguage { get; set; }
        public Technology()
        {
        }

        public Technology(int id,int softwareLanguageId,string name, bool active, DateTime createDate, int createUser)
        {
            Id = id;
            SoftwareLanguageId = softwareLanguageId;
            Name = name;
            Active = active;
            CreateDate = createDate;
            CreateUser = createUser;
        }
    }
}
