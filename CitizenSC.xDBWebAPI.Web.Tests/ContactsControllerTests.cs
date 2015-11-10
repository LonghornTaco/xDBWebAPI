using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenSC.xDBWebAPI.Domain.Response;
using CitizenSC.xDBWebAPI.Model.Contacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using FluentAssertions;
using System.Web;

namespace CitizenSC.xDBWebAPI.Web.Tests
{
   [TestClass]
   public class ContactsControllerTests
   {
      [TestMethod]
      public void GetTestShouldPass()
      {
         var harness = new ControllerTestHarness();

         var collection = harness.Fixture.CreateMany<Contact>().ToList();
         var response = harness.Fixture.Build<CollectionResponse<Contact>>()
            .With(r => r.Errors, new List<string>())
            .With(r => r.Collection, collection)
            .Create();
         harness.SetupGetContacts(response);

         var controller = harness.GetContactsController();
         var result = controller.Get(String.Empty);
         result.Should().NotBeNull();
         result.Should().BeAssignableTo<IEnumerable<Contact>>();
      }

      [TestMethod]
      public void GetTestShouldFail()
      {
         var harness = new ControllerTestHarness();

         var collection = harness.Fixture.CreateMany<Contact>().ToList();
         var response = harness.Fixture.Build<CollectionResponse<Contact>>()
            .With(r => r.Errors, harness.Fixture.CreateMany<String>(1).ToList())
            .Create();
         harness.SetupGetContacts(response);

         var controller = harness.GetContactsController();
         try
         {
            var result = controller.Get(String.Empty);
         }
         catch (HttpException ex)
         {
            ex.GetHttpCode().Should().Be(500);
         }
      }
   }
}
