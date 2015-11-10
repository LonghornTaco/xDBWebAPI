using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenSC.xDBWebAPI.Common.Extensions
{
   public static class ExceptionExtensions
   {
      public static List<String> ToCollection(this Exception exception)
      {
         List<String> errors = new List<string>();
         if (exception != null)
         {
            errors.Add(exception.Message);

            Exception innerException = exception.InnerException;
            while (innerException != null)
            {
               errors.Add(innerException.Message);
               innerException = innerException.InnerException;
            }
         }
         return errors;
      }

      public static string Stringify(this List<string> errors)
      {
         var builder = new StringBuilder();
         foreach (var error in errors)
            builder.AppendFormat("{0};", error);
         return builder.ToString();
      }
   }
}
