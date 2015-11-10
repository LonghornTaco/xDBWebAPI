using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CitizenSC.xDBWebAPI.Domain;
using CitizenSC.xDBWebAPI.Model.Interactions;
using CitizenSC.xDBWebAPI.Common.Extensions;
using CitizenSC.xDBWebAPI.Common.Settings;
using System.Web;

namespace CitizenSC.xDBWebAPI.WebApi.Controllers
{
    public class InteractionsController : BaseWebApiController
    {
      private readonly IInteractionService _interactionService;

      public InteractionsController(IInteractionService interactionService, IApplicationSettings appSettings) : base(appSettings)
      {
         _interactionService = interactionService;
      }

      [WebApiAuthorization]
      public IEnumerable<Interaction> Get(string key = null)
      {
         var response = _interactionService.GetInteractions();

         if (response.Success)
            return response.Collection;
         else
            throw new HttpException(500, response.Errors.Stringify());
      }
   }
}
