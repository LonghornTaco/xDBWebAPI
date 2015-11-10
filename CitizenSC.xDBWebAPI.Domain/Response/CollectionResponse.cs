using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenSC.xDBWebAPI.Model;
using MongoDB.Driver;

namespace CitizenSC.xDBWebAPI.Domain.Response
{
   public class CollectionResponse<T> : SimpleResponse where T : IMongoEntity
   {
      public IEnumerable<T> Collection { get; set; }
   }
}
