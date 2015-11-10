using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CitizenSC.xDBWebAPI.Domain;
using CitizenSC.xDBWebAPI.Model.Contacts;
using CitizenSC.xDBWebAPI.Common.Extensions;
using CitizenSC.xDBWebAPI.Common.Settings;
using System.Web;

namespace CitizenSC.xDBWebAPI.WebApi.Controllers
{
   public class ContactsController : BaseWebApiController
   {
      private readonly IContactService _contactService;

      public ContactsController(IContactService contactService, IApplicationSettings appSettings) : base(appSettings) 
      {
         _contactService = contactService;
      }

      [WebApiAuthorization]
      public IEnumerable<Contact> Get(string key = null)
      {
         var response = _contactService.GetContacts();

         if (response.Success)
            return response.Collection;
         else
            throw new HttpException(500, response.Errors.Stringify());
      }
   }
}
