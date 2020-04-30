using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Data.Services.Common;
//<snippetUsingLinqExpressions>
using System.Linq.Expressions;
//</snippetUsingLinqExpressions>
using System.Reflection;
using System.Data.Objects;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ServiceModel;
namespace NorthwindDataService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Northwind2 : DataService<NorthwindEntities>
    {
        Northwind2()
        {
            this.ProcessingPipeline.ProcessingChangeset += new EventHandler<EventArgs>(ProcessingPipeline_ProcessingChangeset);
            this.ProcessingPipeline.ProcessingRequest += new EventHandler<DataServiceProcessingPipelineEventArgs>(ProcessingPipeline_ProcessingRequest);
        }

        void ProcessingPipeline_ProcessingRequest(object sender, DataServiceProcessingPipelineEventArgs e)
        {
            HttpRequest req = HttpContext.Current.Request;

            if (req.HttpMethod == "POST" && req.PathInfo == @"/GetCustomerNames")
            {
                StreamReader reader = new StreamReader(req.InputStream);
                string body = reader.ReadToEnd();
            }
        }

        void ProcessingPipeline_ProcessingChangeset(object sender, EventArgs e)
        {
            HttpRequest req = HttpContext.Current.Request;

            if (req.HttpMethod == "POST")
            {
                StreamReader reader = new StreamReader(req.InputStream);
                string body = reader.ReadToEnd();
            }

            //if (HttpContext.Current.Request.HttpMethod == "PUT" |
            //    HttpContext.Current.Request.HttpMethod == "MERGE")
            //{
            //    string path = HttpContext.Current.Request.Path;
            //    string[] sep = new string[]{"(",",",")"};
            //    string[] keys = path.Split(sep,StringSplitOptions.RemoveEmptyEntries);

            //    List<KeyValuePair<string, object>> keyCol = new List<KeyValuePair<string, object>>();

            //    for (int i=1; i < keys.Length; i++)
            //    {
            //        string[] pairs = keys[i].Split(new char[]{'='});
            //        KeyValuePair<string, object> kv = new KeyValuePair<string,object>(pairs[0],int.Parse(pairs[1]));

            //        keyCol.Add(kv);
            //    }

            //     object entity;
            //     EntityKey ek = new EntityKey("NorthwindEntities.Order_Details", keyCol);

            //    this.CurrentDataSource.TryGetObjectByKey(ek, out entity);

            //    Order_Detail item = (Order_Detail)entity;

            //    item.Discount = 0.5f;

            //    this.CurrentDataSource.SaveChanges();

            //}
        }

        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Employees", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Customers", EntitySetRights.All);
            config.SetEntitySetAccessRule("Orders", EntitySetRights.All);
            config.SetEntitySetAccessRule("Order_Details", EntitySetRights.All);
            config.SetEntitySetAccessRule("Products", EntitySetRights.All);
            config.UseVerboseErrors = true;
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;

            //<snippetServiceOperationConfig>
            config.SetServiceOperationAccessRule(
                "GetOrdersByCity", ServiceOperationRights.AllRead);
            //</snippetServiceOperationConfig>

            config.SetServiceOperationAccessRule("RaiseError", ServiceOperationRights.AllRead);
            config.SetServiceOperationAccessRule("GetNewestOrder", ServiceOperationRights.AllRead);
            config.SetServiceOperationAccessRule("CountOpenOrders", ServiceOperationRights.AllRead);
            config.SetServiceOperationAccessRule("ReturnsNoData", ServiceOperationRights.AllRead);
            config.SetServiceOperationAccessRule("GetCustomerNames", ServiceOperationRights.AllRead);
            config.SetServiceOperationAccessRule("GetCustomerNamesPost", ServiceOperationRights.AllRead);
            config.SetServiceOperationAccessRule("CloneCustomer", ServiceOperationRights.AllRead);
            config.SetServiceOperationAccessRule("GetOrdersByState", ServiceOperationRights.AllRead);
            config.SetEntitySetPageSize("Customers", 10);
            config.SetEntitySetPageSize("Orders", 10);
        }
        //<snippetServiceOperation>
        //<snippetServiceOperationDef>
        [WebGet]
        public IQueryable<Order> GetOrdersByCity(string city)
        //</snippetServiceOperationDef>
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException("city",
                    "You must provide a value for the parameter'city'.");
            }

            // Get the ObjectContext that is the data source for the service.
            NorthwindEntities context = this.CurrentDataSource;

            try
            {

                var selectedOrders = from order in context.Orders.Include("Order_Details")
                                     where order.Customer.City == city
                                     select order;

                return selectedOrders;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format(
                    "An error occurred: {0}", ex.Message));
            }
        }
        //</snippetServiceOperation>

        [WebGet]
        [SingleResult]
        public Order GetNewestOrder()
        {
            // Get the ObjectContext that is the data source for the service.
            NorthwindEntities context = this.CurrentDataSource;

            try
            {
                var orders = from order in context.Orders
                             where order.OrderDate != null
                             orderby order.OrderDate descending
                             select order;

                return orders.First();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("An error occurred: {0}", ex.Message));
            }
        }

        [WebGet]
        public int CountOpenOrders()
        {
            // Get the ObjectContext that is the data source for the service.
            NorthwindEntities context = this.CurrentDataSource;

            try
            {
                var orders = from order in context.Orders
                             where order.ShippedDate == null
                             select order;

                return orders.Count();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("An error occurred: {0}", ex.Message));
            }
        }

        [WebGet]
        public void ReturnsNoData()
        {
            // This method returns no data (it also doesn't do anything).
        }

        //<snippetQueryInterceptor>
        //<snippetQueryInterceptorDef>
        // Define a query interceptor for the Orders entity set.
        [QueryInterceptor("Orders")]
        public Expression<Func<Order, bool>> OnQueryOrders()
        //</snippetQueryInterceptorDef>
        {
            // Filter the returned orders to only orders
            // that belong to a customer that is the current user.
            return o => o.Customer.ContactName ==
                HttpContext.Current.User.Identity.Name;
        }
        //</snippetQueryInterceptor>

        //<snippetChangeInterceptor>
        //<snippetChangeInterceptorDef>
        // Define a change interceptor for the Products entity set.
        [ChangeInterceptor("Products")]
        public void OnChangeProducts(Product product, UpdateOperations operations)
        //</snippetChangeInterceptorDef>
        {
            if (operations == UpdateOperations.Change)
            {
                System.Data.Objects.ObjectStateEntry entry;

                if (this.CurrentDataSource.ObjectStateManager
                    .TryGetObjectStateEntry(product, out entry))
                {
                    // Reject changes to a discontinued Product.
                    // Because the update is already made to the entity by the time the
                    // change interceptor in invoked, check the original value of the Discontinued
                    // property in the state entry and reject the change if 'true'.
                    if ((bool)entry.OriginalValues["Discontinued"])
                    {
                        throw new DataServiceException(400, string.Format(
                                    "A discontinued {0} cannot be modified.", product.ToString()));
                    }
                }
                else
                {
                    throw new DataServiceException(string.Format(
                        "The requested {0} could not be found in the data source.", product.ToString()));
                }
            }
            else if (operations == UpdateOperations.Delete)
            {
                // Block the delete and instead set the Discontinued flag.
                throw new DataServiceException(400,
                    "Products cannot be deleted; instead set the Discontinued flag to 'true'");
            }
        }

        //</snippetChangeInterceptor>

        //<snippetHandleExceptions>
        // Override to manage returned exceptions.
        protected override void HandleException(HandleExceptionArgs args)
        {
            // Handle exceptions raised in service operations.
            if (args.Exception.GetType() ==
                typeof(TargetInvocationException)
                && args.Exception.InnerException != null)
            {
                if (args.Exception.InnerException.GetType()
                    == typeof(DataServiceException))
                {

                    // Unpack the DataServiceException.
                    args.Exception = args.Exception.InnerException as DataServiceException;
                }
                else
                {
                    // Return a new DataServiceException as "400: bad request."
                    args.Exception =
                        new DataServiceException(400,
                            args.Exception.InnerException.Message);
                }
            }
        }
        //</snippetHandleExceptions>

        //<snippetRaiseErrorOperation>
        [WebGet]
        public void RaiseError()
        {
            throw new DataServiceException(500, "My custom error message.");
        }
        //</snippetRaiseErrorOperation>

        [WebInvoke(Method = "POST")]
        public IEnumerable<string> GetCustomerNamesPost()
        {
            // Get the ObjectContext that is the data source for the service.
            NorthwindEntities context = this.CurrentDataSource;

            var customers = from cust in context.Customers
                            orderby cust.ContactName
                            select cust;

            foreach (Customer cust in customers)
            {
                yield return cust.ContactName;
            }
        }
        [WebGet]
        public IEnumerable<string> GetCustomerNames()
        {
            // Get the ObjectContext that is the data source for the service.
            NorthwindEntities context = this.CurrentDataSource;

            var customers = from cust in context.Customers
                            orderby cust.ContactName
                            select cust;

            foreach (Customer cust in customers)
            {
                yield return cust.ContactName;
            }
        }
        // Used in the Service Operations topic to demo multiple params.
        [WebGet]
        public IQueryable<Order> GetOrdersByState(string state, bool includeItems)
        {
            if (string.IsNullOrEmpty(state))
            {
                throw new ArgumentNullException("state",
                    "You must provide a value for the parameter'state'.");
            }

            // Get the ObjectContext that is the data source for the service.
            NorthwindEntities context = this.CurrentDataSource;

            try
            {
                ObjectQuery<Order> selectedOrders = context.Orders;

                if (includeItems)
                {
                    selectedOrders = selectedOrders.Include("Order_Details");
                }
                return selectedOrders.Where(o => o.ShipRegion.Equals(state));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format(
                    "An error occurred: {0}", ex.Message));
            }
        }

[WebGet]
public Customer CloneCustomer(string serializedCustomer)
{
    NorthwindEntities context = this.CurrentDataSource;

    XmlSerializer xmlSerializer =
        new System.Xml.Serialization.XmlSerializer(typeof(Customer));

    TextReader reader = new StringReader(serializedCustomer);

    // Get a customer created with a property-wise clone
    // of the supplied entity, with a new ID.
    Customer clone = CloneCustomer(xmlSerializer.Deserialize(reader) as Customer);

    try
    {
        // Note that this bypasses the service ops restrictions.
        context.AddToCustomers(clone);
        context.SaveChanges();
    }
    catch (Exception ex)
    {
        throw new DataServiceException(
            "The Customer could not be cloned.", ex.GetBaseException());
    }
    return clone;
}

        private static Customer CloneCustomer(Customer customer)
        {
            Customer clone = Customer.CreateCustomer("AAAAA", customer.CompanyName);
            clone.Address = customer.Address;
            clone.City = customer.City;
            clone.CompanyName = customer.CompanyName;
            clone.ContactName = customer.ContactName;
            clone.ContactTitle = customer.ContactTitle;
            clone.Country = customer.Country;
            clone.Fax = customer.Fax;
            clone.Phone = customer.Phone;
            clone.PostalCode = customer.PostalCode;
            clone.Region = customer.Region;

            return clone;
        }
    }
}
