using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitizenSC.xDBWebAPI.Model.Contacts
{
   public class Emails
   {
      public string Preferred { get; set; }
      public EmailEntries Entries { get; set; }
   }
}