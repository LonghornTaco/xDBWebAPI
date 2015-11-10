using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CitizenSC.xDBWebAPI.Common.Settings;

namespace CitizenSC.xDBWebAPI.WebApi.Controllers
{
   public class WebApiAuthorizationAttribute : ActionFilterAttribute
   {
      public override void OnActionExecuting(HttpActionContext actionContext)
      {
         var baseController = (BaseWebApiController)actionContext.ControllerContext.Controller;
         var arguments = baseController.ActionContext.ActionArguments;

         if (arguments.ContainsKey("key") && arguments["key"] != null)
         {
            var key = arguments["key"].ToString();
            if (key == baseController.AppSettings.SecurityKey)
               base.OnActionExecuting(actionContext);
            else
               throw new HttpException(401, "Unauthorized");
         }
         else
            throw new HttpException(401, "Unauthorized");
      }
   }
}