using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenSC.xDBWebAPI.Domain.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using FluentAssertions;
using System.Web;
using CitizenSC.xDBWebAPI.Model.Interactions;

namespace CitizenSC.xDBWebAPI.Web.Tests
{
   [TestClass]
   public class InteractionsControllerTests
   {
      [TestMethod]
      public void GetTestShouldPass()
      {
         var harness = new ControllerTestHarness();

         var collection = harness.Fixture.CreateMany<Interaction>().ToList();
         var response = harness.Fixture.Build<CollectionResponse<Interaction>>()
            .With(r => r.Errors, new List<string>())
            .With(r => r.Collection, collection)
            .Create();
         harness.SetupGetInteractions(response);

         var controller = harness.GetInteractionsController();
         var result = controller.Get(String.Empty);
         result.Should().NotBeNull();
         result.Should().BeAssignableTo<IEnumerable<Interaction>>();
      }

      [TestMethod]
      public void GetTestShouldFail()
      {
         var harness = new ControllerTestHarness();

         var collection = harness.Fixture.CreateMany<Interaction>().ToList();
         var response = harness.Fixture.Build<CollectionResponse<Interaction>>()
            .With(r => r.Errors, harness.Fixture.CreateMany<String>(1).ToList())
            .Create();
         harness.SetupGetInteractions(response);

         var controller = harness.GetInteractionsController();
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
