using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CitizenSC.xDBWebAPI.Common.Settings;

namespace CitizenSC.xDBWebAPI.WebApi.Controllers
{
    public abstract class BaseWebApiController : ApiController
    {
      public IApplicationSettings AppSettings { get; private set; }

      public BaseWebApiController(IApplicationSettings appSettings)
      {
         AppSettings = appSettings;
      }
   }
}
