using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenSC.xDBWebAPI.Common.Settings
{
   public interface IApplicationSettings
   {
      string ConnectionString { get; }
      string DatabaseName { get; }
      string ContactsCollectionName { get; }
      string InteractionsCollectionName { get; }
      string SecurityKey { get; }
   }
}
