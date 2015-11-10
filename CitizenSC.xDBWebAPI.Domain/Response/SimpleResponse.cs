using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenSC.xDBWebAPI.Domain.Response
{
   public class SimpleResponse
   {
      public List<string> Errors { get; set; }
      public bool Success { get { return !Errors.Any(); } }

      public SimpleResponse()
      {
         Errors = new List<string>();
      }
   }
}
