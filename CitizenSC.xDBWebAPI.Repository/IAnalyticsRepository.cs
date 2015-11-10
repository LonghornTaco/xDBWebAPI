using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using CitizenSC.xDBWebAPI.Model;

namespace CitizenSC.xDBWebAPI.Repository
{
   public interface IAnalyticsRepository<T> where T : IMongoEntity
   {
      IEnumerable<T> GetCollection(string collectionName);
   }
}
