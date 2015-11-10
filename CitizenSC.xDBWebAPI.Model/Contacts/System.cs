using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CitizenSC.xDBWebAPI.Model.Contacts
{
   [BsonIgnoreExtraElements]
   public class System
   {
      public int VisitCount { get; set; }
      public int Value { get; set; }
      public int Classification { get; set; }
      public int OverrideClassification { get; set; }

   }
}