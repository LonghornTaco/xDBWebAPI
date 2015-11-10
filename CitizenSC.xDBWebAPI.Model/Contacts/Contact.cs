using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CitizenSC.xDBWebAPI.Model.Contacts
{
   [BsonIgnoreExtraElements]
   public class Contact : IMongoEntity
   {
      public object Id { get; set; }
      public Identifiers Identifiers { get; set; }
      public System System { get; set; }
      public Person Personal { get; set; }
      public object Successor { get; set; }
      public Tags Tags { get; set; }
      public Emails Emails { get; set; }

      public string FirstName { get { return Personal != null ? Personal.FirstName : String.Empty; } set { } }
      public string MiddleName { get { return Personal != null ? Personal.MiddleName : String.Empty; } set { } }
      public string Surname { get { return Personal != null ? Personal.Surname : String.Empty; } set { } }
      public string Title { get { return Personal != null ? Personal.Title : String.Empty; } set { } }
      public string JobTitle { get { return Personal != null ? Personal.JobTitle : String.Empty; } set { } }
      public string Gender { get { return Personal != null ? Personal.Gender : String.Empty; } set { } }
      public DateTime? Birthdate { get { return Personal != null ? Personal.Birthdate : null; } set { } }
      public string Identifier { get { return Identifiers != null ? Identifiers.Identifier : String.Empty; } set { } }
   }
}