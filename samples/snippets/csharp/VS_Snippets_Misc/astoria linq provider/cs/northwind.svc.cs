using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace NorthwindService
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Northwind : DataService<NorthwindDataContext>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            //<snippetEnableAccess>
            config.SetEntitySetAccessRule("Customers", EntitySetRights.ReadMultiple);
            config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead  
                                        | EntitySetRights.WriteMerge);
            config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead                             
                                        | EntitySetRights.AllWrite);
            config.SetEntitySetAccessRule("Products", EntitySetRights.ReadMultiple);
            //</snippetEnableAccess>
            config.SetEntitySetAccessRule("MyTypes", EntitySetRights.AllRead);
        }
    }

    #region ProofOfConcept
    // Proof of concept code that I added to support the forum post:
    // http://social.msdn.microsoft.com/Forums/en-US/adodotnetdataservices/thread/5c3134e5-3edf-4eb1-b36c-90e280e775f0/#b387da56-13f5-4261-ac34-d4283b0871e8
    public partial class NorthwindDataContext
    {
        public IQueryable<SomeType> MyTypes
        {
            get
            {
                List<SomeType> types = new List<SomeType>();
                for (int i=0; i <2; i++)
                {
                    types.Add(new SomeType(i, "string"+i.ToString()));
                }
                return types.AsQueryable<SomeType>();
            }
        }

    }

    [System.Data.Services.Common.DataServiceKey("Key")]
    public class SomeType
    {
        public SomeType(int key, string prop)
        {
            this.Key = key;
            this.Prop = prop;
        }
    
        public int Key {get; set;}
        

        public string Prop { get; set;}
            
    }
#endregion
}
