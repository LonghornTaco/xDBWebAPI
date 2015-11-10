using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CitizenSC.xDBWebAPI.Model.Contacts
{
   [BsonIgnoreExtraElements]
   public class Person
   {
      public string FirstName { get; set; }
      public string MiddleName { get; set; }
      public string Surname { get; set; }
      public string Title { get; set; }
      public string JobTitle { get; set; }
      public string Gender { get; set; }
      public DateTime? Birthdate { get; set; }
   }
}