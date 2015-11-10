using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenSC.xDBWebAPI.Common.Settings
{
   public class xDBAppSettings : IApplicationSettings
   {
      public string ConnectionString { get { return GetConnectionString("mongoDb"); } }
      public string DatabaseName { get { return GetValue<string>("DatabaseName"); } }
      public string ContactsCollectionName { get { return GetValue<string>("ContactsCollectionName"); } }
      public string InteractionsCollectionName { get { return GetValue<string>("InteractionsCollectionName"); } }
      public string SecurityKey { get { return GetValue<string>("SecurityKey"); } }

      private static T GetValue<T>(string key)
      {
         var returnValue = default(T);
         var converter = TypeDescriptor.GetConverter(typeof(T));
         if (converter != null)
         {
            object value = ConfigurationManager.AppSettings[key];
            if (value != null)
            {
               try
               {
                  returnValue = (T)converter.ConvertFrom(value);
               }
               catch (Exception)
               {
                  Trace.TraceError(String.Format("Failed trying to convert '{0}' to type '{1}'", value, key));
               }
            }
            else
               Trace.TraceError(String.Format("Could not find the config value '{0}'", key));
         }
         return returnValue;
      }

      private static string GetConnectionString(string key)
      {
         var returnValue = String.Empty;
         object value = ConfigurationManager.ConnectionStrings[key];
         if (value != null)
         {
            try
            {
               returnValue = value.ToString();
            }
            catch (Exception)
            {
               Trace.TraceError(String.Format("Failed trying to convert '{0}' to type '{1}'", value, key));
            }
         }
         return returnValue;
      }
   }
}
