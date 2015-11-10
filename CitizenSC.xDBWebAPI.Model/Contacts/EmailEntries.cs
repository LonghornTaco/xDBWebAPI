using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CitizenSC.xDBWebAPI.Model.Contacts
{
   [BsonIgnoreExtraElements]
   public class EmailEntries
   {
      [BsonElement("Personal Email")]
      public EmailEntry PersonalEmail { get; set; }

      [BsonElement("Work Email")]
      public EmailEntry WorkEmail { get; set; }
   }
}