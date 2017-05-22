using System;
using System.Data.Services;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Data.Services.Common;
using System.IO;

namespace NorthwindDataService
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    //<snippetDataServiceDef>
    public class Northwind : DataService<NorthwindEntities>
    //</snippetDataServiceDef>
    {
        //<snippetDataServiceConfigComplete>
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            //<snippetDataServiceConfig>
            // Set the access rules of feeds exposed by the data service, which is
            // based on the requirements of client applications.
            config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Employees", EntitySetRights.ReadSingle);
            config.SetEntitySetAccessRule("Orders", EntitySetRights.All  
                | EntitySetRights.WriteAppend
                | EntitySetRights.WriteMerge);
            config.SetEntitySetAccessRule("Order_Details", EntitySetRights.All);
            config.SetEntitySetAccessRule("Products", EntitySetRights.All);
        //</snippetDataServiceConfig>

            //<snippetDataServiceConfigPaging>
            // Set page size defaults for the data service.
            config.SetEntitySetPageSize("Orders", 20);
            config.SetEntitySetPageSize("Order_Details", 50);
            config.SetEntitySetPageSize("Products", 50);

            // Paging requires v2 of the OData protocol.
            config.DataServiceBehavior.MaxProtocolVersion =
                System.Data.Services.Common.DataServiceProtocolVersion.V2;
            //</snippetDataServiceConfigPaging>
        }
        //</snippetDataServiceConfigComplete>
    }
}
 