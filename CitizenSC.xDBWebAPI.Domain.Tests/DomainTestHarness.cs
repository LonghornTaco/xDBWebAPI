using System;
using System.Collections.Generic;
using CitizenSC.xDBWebAPI.Common.Settings;
using CitizenSC.xDBWebAPI.Model.Contacts;
using CitizenSC.xDBWebAPI.Model.Interactions;
using CitizenSC.xDBWebAPI.Repository;
using MongoDB.Driver;
using Moq;
using Ploeh.AutoFixture;
using SimpleInjector;

namespace CitizenSC.xDBWebAPI.Domain.Tests
{
   public class DomainTestHarness
   {
      private Container _container;
      private Mock<IAnalyticsRepository<Contact>> _contactRepository;
      private Mock<IAnalyticsRepository<Interaction>> _interactionRepository;
      private Mock<IApplicationSettings> _appSettings;
      private Fixture _fixture;

      public Mock<IAnalyticsRepository<Contact>> ContactRepository
      {
         get
         {
            if (_contactRepository == null)
               _contactRepository = Mock.Get(_container.GetInstance<IAnalyticsRepository<Contact>>());
            return _contactRepository;
         }
      }
      public Mock<IAnalyticsRepository<Interaction>> InteractionRepository
      {
         get
         {
            if (_interactionRepository == null)
               _interactionRepository = Mock.Get(_container.GetInstance<IAnalyticsRepository<Interaction>>());
            return _interactionRepository;
         }
      }
      public Mock<IApplicationSettings> AppSettings
      {
         get
         {
            if (_appSettings == null)
               _appSettings = Mock.Get(_container.GetInstance<IApplicationSettings>());
            return _appSettings;
         }
      }
      public Fixture Fixture { get { return _fixture; } }

      public DomainTestHarness()
      {
         _container = new Container();
         _container.RegisterSingleton<IApplicationSettings>(new Mock<IApplicationSettings>().Object);
         _container.RegisterSingleton<IAnalyticsRepository<Contact>>(() => new Mock<IAnalyticsRepository<Contact>>().Object);
         _container.RegisterSingleton<IAnalyticsRepository<Interaction>>(() => new Mock<IAnalyticsRepository<Interaction>>().Object);
         _container.RegisterSingleton<IContactService, xDBContactService>();
         _container.RegisterSingleton<IInteractionService, xDBInteractionService>();

         _fixture = new Fixture();
      }

      public IContactService GetContactService()
      {
         AppSettings.SetupGet(s => s.ContactsCollectionName).Returns("Contacts");
         AppSettings.SetupGet(s => s.InteractionsCollectionName).Returns("Interactions");
         AppSettings.SetupGet(s => s.SecurityKey).Returns("SecurityKey");
         AppSettings.SetupGet(s => s.DatabaseName).Returns("Database");
         AppSettings.SetupGet(s => s.ConnectionString).Returns("ConnectionString");
         return _container.GetInstance<IContactService>();
      }
      public void SetupGetCollectionForContacts(List<Contact> returnCollection)
      {
         if (returnCollection == null)
            ContactRepository.Setup(r => r.GetCollection(It.IsAny<string>())).Returns<IEnumerable<Contact>>(null).Verifiable();
         else
            ContactRepository.Setup(r => r.GetCollection(It.IsAny<string>())).Returns(returnCollection).Verifiable();
      }
      public void SetupGetCollectionForInteractions(List<Interaction> returnCollection)
      {
         if (returnCollection == null)
            InteractionRepository.Setup(r => r.GetCollection(It.IsAny<string>())).Returns<IEnumerable<Interaction>>(null).Verifiable();
         else
            InteractionRepository.Setup(r => r.GetCollection(It.IsAny<string>())).Returns(returnCollection).Verifiable();
      }
      public void SetupGetCollectionForContactsToThrowException(Exception exception)
      {
         ContactRepository.Setup(r => r.GetCollection(It.IsAny<string>())).Throws(exception).Verifiable();
      }
      public void SetupGetCollectionForInteractionsToThrowException(Exception exception)
      {
         InteractionRepository.Setup(r => r.GetCollection(It.IsAny<string>())).Throws(exception).Verifiable();
      }

      public IInteractionService GetInteractionService()
      {
         return _container.GetInstance<IInteractionService>();
      }
   }
}
