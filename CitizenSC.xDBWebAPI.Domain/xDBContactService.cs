using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenSC.xDBWebAPI.Common.Settings;
using CitizenSC.xDBWebAPI.Domain.Response;
using CitizenSC.xDBWebAPI.Model.Contacts;
using CitizenSC.xDBWebAPI.Repository;
using CitizenSC.xDBWebAPI.Common.Extensions;

namespace CitizenSC.xDBWebAPI.Domain
{
   public class xDBContactService : IContactService
   {
      public readonly IAnalyticsRepository<Contact> _repository;
      private readonly IApplicationSettings _appSettings;

      public xDBContactService(IAnalyticsRepository<Contact> repository, IApplicationSettings appSettings)
      {
         _repository = repository;
         _appSettings = appSettings;
      }

      public CollectionResponse<Contact> GetContacts()
      {
         var response = new CollectionResponse<Contact>();

         try
         {
            var contacts = _repository.GetCollection(_appSettings.ContactsCollectionName);

            if (contacts != null)
            {
               foreach (var contact in contacts)
               {
                  if (contact.Identifiers == null)
                  {
                     contact.Personal = new Person() { FirstName = "Anonymous" };
                  }
               }

               response.Collection = contacts; 
            }
         }
         catch (Exception ex)
         {
            response.Errors.AddRange(ex.ToCollection());
         }

         return response;
      }
   }
}
