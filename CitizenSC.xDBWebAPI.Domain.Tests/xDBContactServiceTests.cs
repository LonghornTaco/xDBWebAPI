using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CitizenSC.xDBWebAPI.Model.Contacts;
using MongoDB.Driver;
using Ploeh.AutoFixture;
using Moq;

namespace CitizenSC.xDBWebAPI.Domain.Tests
{
   [TestClass]
   public class xDBContactServiceTests
   {
      [TestMethod]
      public void GetContactsTestShouldPass()
      {
         var harness = new DomainTestHarness();

         var collection = harness.Fixture.CreateMany<Contact>().ToList();
         harness.SetupGetCollectionForContacts(collection);

         var service = harness.GetContactService();
         var response = service.GetContacts();
         response.Success.Should().BeTrue();
         response.Collection.Should().NotBeNullOrEmpty();
         response.Collection.Count().Should().Be(collection.Count());
         harness.ContactRepository.Verify();
      }

      [TestMethod]
      public void GetContactsTestShouldBeEmpty()
      {
         var harness = new DomainTestHarness();

         harness.SetupGetCollectionForContacts(null);

         var service = harness.GetContactService();
         var response = service.GetContacts();
         response.Success.Should().BeTrue();
         response.Collection.Should().BeNull();
         harness.ContactRepository.Verify();
      }

      [TestMethod]
      public void GetContactsTestShouldThrowException()
      {
         var harness = new DomainTestHarness();

         harness.SetupGetCollectionForContactsToThrowException(new ArgumentNullException("collectionName", "A required parameter was null or empty"));

         var service = harness.GetContactService();
         var response = service.GetContacts();
         response.Success.Should().BeFalse();
         response.Errors.Count().Should().Be(1);
         harness.ContactRepository.Verify();
      }

      [TestMethod]
      public void GetContactsTestShouldHaveAnonymousContacts()
      {
         var harness = new DomainTestHarness();

         var collection = harness.Fixture.CreateMany<Contact>(6).ToList();
         collection[1].Identifiers = null;
         collection[2].Identifiers = null;
         collection[4].Identifiers = null;
         harness.SetupGetCollectionForContacts(collection);

         var service = harness.GetContactService();
         var response = service.GetContacts();
         response.Success.Should().BeTrue();
         response.Collection.Where(c => c.FirstName == "Anonymous").Count().Should().Be(3);
         harness.ContactRepository.Verify();
      }
   }
}
