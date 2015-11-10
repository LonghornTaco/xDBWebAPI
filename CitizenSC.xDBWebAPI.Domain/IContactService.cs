using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenSC.xDBWebAPI.Domain.Response;
using CitizenSC.xDBWebAPI.Model.Contacts;

namespace CitizenSC.xDBWebAPI.Domain
{
   public interface IContactService
   {
      CollectionResponse<Contact> GetContacts();
   }
}
