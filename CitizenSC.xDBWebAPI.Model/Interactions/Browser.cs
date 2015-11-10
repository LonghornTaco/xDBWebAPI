using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CitizenSC.xDBWebAPI.Model.Interactions
{
   public class Browser
   {
      public string BrowserVersion { get; set; }
      public string BrowserMajorName { get; set; }
      public string BrowserMinorName { get; set; }
   }
}