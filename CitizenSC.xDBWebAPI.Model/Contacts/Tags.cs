using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CitizenSC.xDBWebAPI.Model.Contacts
{
   [BsonIgnoreExtraElements]
   public class Tags
   {
      public IEnumerable<ContactLists> Entries { get; set; }
   }
}