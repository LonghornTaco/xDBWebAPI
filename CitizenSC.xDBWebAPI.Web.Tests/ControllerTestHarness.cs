using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenSC.xDBWebAPI.Common.Settings;
using CitizenSC.xDBWebAPI.Domain;
using CitizenSC.xDBWebAPI.Domain.Response;
using CitizenSC.xDBWebAPI.Model.Contacts;
using CitizenSC.xDBWebAPI.Model.Interactions;
using CitizenSC.xDBWebAPI.WebApi.Controllers;
using Moq;
using Ploeh.AutoFixture;

namespace CitizenSC.xDBWebAPI.Web.Tests
{
   public class ControllerTestHarness
   {
      private SimpleInjector.Container _container;

      private Mock<IContactService> _contactService;
      private Mock<IInteractionService> _interactionService;
      private Mock<IApplicationSettings> _appSettings;
      private Fixture _fixture;

      public Mock<IContactService> ContactService
      {
         get
         {
            if (_contactService == null)
               _contactService = Mock.Get(_container.GetInstance<IContactService>());
            return _contactService;
         }
      }
      public Mock<IInteractionService> InteractionService
      {
         get
         {
            if (_interactionService == null)
               _interactionService = Mock.Get(_container.GetInstance<IInteractionService>());
            return _interactionService;
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

      public ControllerTestHarness()
      {
         _container = new SimpleInjector.Container();
         _container.RegisterSingleton<IApplicationSettings>(new Mock<IApplicationSettings>().Object);
         _container.RegisterSingleton<IContactService>(new Mock<IContactService>().Object);
         _container.RegisterSingleton<IInteractionService>(new Mock<IInteractionService>().Object);

         _fixture = new Fixture();
      }

      public ContactsController GetContactsController()
      {
         return new ContactsController(ContactService.Object, AppSettings.Object);
      }
      public void SetupGetContacts(CollectionResponse<Contact> response)
      {
         ContactService.Setup(s => s.GetContacts()).Returns(response).Verifiable();
      }
      public void SetupGetInteractions(CollectionResponse<Interaction> response)
      {
         InteractionService.Setup(s => s.GetInteractions()).Returns(response).Verifiable();
      }

      public InteractionsController GetInteractionsController()
      {
         return new InteractionsController(InteractionService.Object, AppSettings.Object);
      }
   }
}
