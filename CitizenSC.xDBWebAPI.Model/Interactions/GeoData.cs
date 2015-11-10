using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CitizenSC.xDBWebAPI.Model.Interactions
{
   [BsonIgnoreExtraElements]
   public class GeoData
   {
      public string AreaCode { get; set; }
      public string BusinessName { get; set; }
      public string City { get; set; }
      public string Country { get; set; }
      public string Dns { get; set; }
      public string Isp { get; set; }
      public string MetroCode { get; set; }
      public string PostalCode { get; set; }
      public string Url { get; set; }
      public int Classification { get; set; }
      public int Status { get; set; }
   }
}