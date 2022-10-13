//<snippetNorthwindServiceFull>
using System.Data.Services;
using System.Linq;
using System.ServiceModel.Web;

namespace NorthwindService
{
    //<snippetDataServiceClass>
    //<snippetServiceDefinition>
    public class Northwind : DataService<NorthwindEntities>
    //</snippetServiceDefinition>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            //<snippetAllReadConfig>
            // Grant only the rights needed to support the client application.
           config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead
                | EntitySetRights.WriteMerge
                | EntitySetRights.WriteReplace );
            config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead
                | EntitySetRights.AllWrite);
            config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead);
            //</snippetAllReadConfig>
        }
    }
    //</snippetDataServiceClass>
}
//</snippetNorthwindServiceFull>