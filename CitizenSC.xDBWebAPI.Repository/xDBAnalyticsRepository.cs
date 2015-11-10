using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using CitizenSC.xDBWebAPI.Common.Settings;
using CitizenSC.xDBWebAPI.Model;

namespace CitizenSC.xDBWebAPI.Repository
{
   public class xDBAnalyticsRepository<T> : IAnalyticsRepository<T> where T : IMongoEntity
   {
      private readonly IApplicationSettings _appSettings;

      public xDBAnalyticsRepository(IApplicationSettings appSettings)
      {
         _appSettings = appSettings;
      }

      public IEnumerable<T> GetCollection(string collectionName)
      {
         if (String.IsNullOrEmpty(collectionName))
            throw new ArgumentNullException("collectionName", "A required parameter was null or empty");

         var database = GetDatabase();
         var collection = database.GetCollection<T>(collectionName);
         return collection != null ? collection.FindAll().ToList() : null;
      }

      private MongoDatabase GetDatabase()
      {
         var server = MongoServer.Create(_appSettings.ConnectionString);
         return server.GetDatabase(_appSettings.DatabaseName);
      }
   }
}
