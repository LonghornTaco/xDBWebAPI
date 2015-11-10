using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CitizenSC.xDBWebAPI.Model.Interactions
{
   [BsonIgnoreExtraElements]
   public class Interaction : IMongoEntity
   {
      public object Id { get; set; }
      public object ContactId { get; set; }
      public DateTime? StartDateTime { get; set; }
      public DateTime? EndDateTime { get; set; }
      public DateTime? SaveDateTime { get; set; }
      public object ChannelId { get; set; }
      public int ContactVisitIndex { get; set; }
      public object DeviceId { get; set; }
      public string Language { get; set; }
      public object LocationId { get; set; }
      public string Referrer { get; set; }
      public string ReferringSite { get; set; }
      public string SiteName { get; set; }
      public int TrafficType { get; set; }
      public string UserAgent { get; set; }
      public int Value { get; set; }
      public int VisitPageCount { get; set; }
      public Browser Browser { get; set; }
      public string BrowserName { get { return Browser != null ? String.Format("{0} {1}", Browser.BrowserMajorName, Browser.BrowserVersion) : String.Empty; } set { } }
      public GeoData GeoData { get; set; }
      public string AreaCode { get { return GeoData != null ? GeoData.AreaCode : String.Empty; } set { } }
      public string BusinessName { get { return GeoData != null ? GeoData.BusinessName : String.Empty; } set { }  }
      public string City { get { return GeoData != null ? GeoData.City : String.Empty; } set { }  }
      public string Country { get { return GeoData != null ? GeoData.Country : String.Empty; } set { }  }
      public string Dns { get { return GeoData != null ? GeoData.Dns : String.Empty; } set { }  }
      public string Isp { get { return GeoData != null ? GeoData.Isp : String.Empty; } set { }  }
      public string MetroCode { get { return GeoData != null ? GeoData.MetroCode : String.Empty; } set { }  }
      public string PostalCode { get { return GeoData != null ? GeoData.PostalCode : String.Empty; } set { }  }
      public string Url { get { return GeoData != null ? GeoData.Url : String.Empty; } set { }  }
      public string ScreenHeight { get; set; }
      public string ScreenWidth { get; set; }
   }
}