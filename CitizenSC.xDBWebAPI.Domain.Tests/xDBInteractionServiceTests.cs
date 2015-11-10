using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CitizenSC.xDBWebAPI.Model.Interactions;
using MongoDB.Driver;
using Ploeh.AutoFixture;
using Moq;

namespace CitizenSC.xDBWebAPI.Domain.Tests
{
   [TestClass]
   public class xDBInteractionServiceTests
   {
      [TestMethod]
      public void GetInteractionsTestShouldPass()
      {
         var harness = new DomainTestHarness();

         var collection = harness.Fixture.CreateMany<Interaction>().ToList();
         harness.SetupGetCollectionForInteractions(collection);

         var service = harness.GetInteractionService();
         var response = service.GetInteractions();
         response.Success.Should().BeTrue();
         response.Collection.Should().NotBeNullOrEmpty();
         response.Collection.Count().Should().Be(collection.Count());
         harness.InteractionRepository.Verify();
      }

      [TestMethod]
      public void GetInteractionsTestShouldBeEmpty()
      {
         var harness = new DomainTestHarness();

         harness.SetupGetCollectionForInteractions(null);

         var service = harness.GetInteractionService();
         var response = service.GetInteractions();
         response.Success.Should().BeTrue();
         response.Collection.Should().BeNull();
         harness.InteractionRepository.Verify();
      }

      [TestMethod]
      public void GetInteractionsTestShouldThrowException()
      {
         var harness = new DomainTestHarness();

         harness.SetupGetCollectionForInteractionsToThrowException(new ArgumentNullException("collectionName", "A required parameter was null or empty"));

         var service = harness.GetInteractionService();
         var response = service.GetInteractions();
         response.Success.Should().BeFalse();
         response.Errors.Count().Should().Be(1);
         harness.InteractionRepository.Verify();
      }
   }
}
