using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenSC.xDBWebAPI.Common.Settings;
using CitizenSC.xDBWebAPI.Domain.Response;
using CitizenSC.xDBWebAPI.Model.Interactions;
using CitizenSC.xDBWebAPI.Repository;
using CitizenSC.xDBWebAPI.Common.Extensions;

namespace CitizenSC.xDBWebAPI.Domain
{
   public class xDBInteractionService : IInteractionService
   {
      public readonly IAnalyticsRepository<Interaction> _repository;
      private readonly IApplicationSettings _appSettings;

      public xDBInteractionService(IAnalyticsRepository<Interaction> repository, IApplicationSettings appSettings)
      {
         _repository = repository;
         _appSettings = appSettings;
      }

      public CollectionResponse<Interaction> GetInteractions()
      {
         var response = new CollectionResponse<Interaction>();

         try
         {
            response.Collection = _repository.GetCollection(_appSettings.InteractionsCollectionName);
         }
         catch (Exception ex)
         {
            response.Errors.AddRange(ex.ToCollection());
         }

         return response;
      }
   }
}
