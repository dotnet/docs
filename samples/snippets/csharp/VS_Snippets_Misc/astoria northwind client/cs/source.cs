using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Client;
using NorthwindClient.Northwind;
//<snippetUsingForAttributes>
using System.Data.Services.Common;
//</snippetUsingForAttributes>

namespace NorthwindClient
{
    
    public class Source
    {
        public static Uri svcUri = new Uri("http://glengatest4-vm1/Northwind/Northwind.svc/");
        public static Uri svcUri2 = new Uri("http://glengatest4-vm1/Northwind/Northwind2.svc/");

        public static void GetAllCustomers()
        {
            //<snippetGetAllCustomers>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            //<snippetGetAllCustomersSpecific>  
            // Define a new query for Customers.
            DataServiceQuery<Customer> query = context.Customers;
            //</snippetGetAllCustomersSpecific>

            try
            {
                // Enumerate over the query result, which is executed implicitly.
                foreach (Customer customer in query)
                {
                    Console.WriteLine("Customer Name: {0}", customer.CompanyName);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetGetAllCustomers>
        }
        public static void GetAllCustomersLinq()
        {
            //<snippetGetAllCustomersLinq>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            try
            {
                // Define a LINQ query that returns all customers.
                var allCustomers = from cust in context.Customers
                                   select cust;

                // Enumerate over the query obtained from the context.
                foreach (Customer customer in allCustomers)
                {
                    Console.WriteLine("Customer Name: {0}", customer.CompanyName);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetGetAllCustomersLinq>
        }
        public static void GetAllCustomersFromContext()
        {
            //<snippetGetAllCustomersFromContext>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            try
            {
                // Enumerate over the query obtained from the context.
                foreach (Customer customer in context.Customers)
                {
                    Console.WriteLine("Customer Name: {0}", customer.CompanyName);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetGetAllCustomersFromContext>
        }
        public static void GetAllCustomersQuery()
        {
            //<snippetGetAllCustomersQuery>
            // Create the DataServiceContext using the service URI.
            DataServiceContext context = new DataServiceContext(svcUri);

            // Define a new query for Customers.
            DataServiceQuery<Customer> query = context.CreateQuery<Customer>("Customers");
            
            try
            {
                // Enumerate over the query result.
                foreach (Customer customer in query.Execute())
                {
                    Console.WriteLine("Customer Name: {0}", customer.CompanyName);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetGetAllCustomersQuery>
        }

        public static void GetAllCustomersExplicit()
        {
            //<snippetGetAllCustomersExplicit>
            // Define a request URI that returns Customers.
            Uri customersUri = new Uri("Customers", UriKind.Relative);

            // Create the DataServiceContext using the service URI.
            DataServiceContext context = new DataServiceContext(svcUri);

            try
            {
                // Enumerate over the query result.
                foreach (Customer customer in context.Execute<Customer>(customersUri))
                {
                    Console.WriteLine("Customer Name: {0}", customer.CompanyName);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetGetAllCustomersExplicit>
        }
        //<snippetExecuteQueryAsync>
        public static void BeginExecuteCustomersQuery()
        {
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define the query to execute asynchronously that returns 
            // all customers with their respective orders.
            DataServiceQuery<Customer> query = (DataServiceQuery<Customer>)(from cust in context.Customers.Expand("Orders")
                                               where cust.CustomerID == "ALFKI"
                                               select cust);

            try
            {
                // Begin query execution, supplying a method to handle the response
                // and the original query object to maintain state in the callback.
                query.BeginExecute(OnCustomersQueryComplete, query);
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
        }

        // Handle the query callback.
        private static void OnCustomersQueryComplete(IAsyncResult result)
        {
            // Get the original query from the result.
            DataServiceQuery<Customer> query = 
                result as DataServiceQuery<Customer>;

            foreach (Customer customer in query.EndExecute(result))
            {
                Console.WriteLine("Customer Name: {0}", customer.CompanyName);
                foreach (Order order in customer.Orders)
                {
                    Console.WriteLine("Order #: {0} - Freight $: {1}",
                        order.OrderID, order.Freight);
                }
            }
        }    
        //</snippetExecuteQueryAsync>
        public static void LoadRelatedOrderCustomer()
        {
            //<snippetLoadRelatedOrderCustomer>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            try
            {
                // Enumerate over the top 10 orders obtained from the context.
                foreach (Order order in context.Orders.Take(10))
                {
                    //<snippetLoadRelatedOrderCustomerSpecific>
                    // Explicitly load the customer for each order.
                    context.LoadProperty(order, "Customer");
                    //</snippetLoadRelatedOrderCustomerSpecific>

                    // Write out customer and order information.
                    Console.WriteLine("Customer: {0} - Order ID: {1}", 
                        order.Customer.CompanyName, order.OrderID);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLoadRelatedOrderCustomer>
        }
        public static void LoadRelatedOrderDetails()
        {
            //<snippetLoadRelatedOrderDetails>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            try
            {
                // Enumerate over the top 10 orders obtained from the context.
                foreach (Order order in context.Orders.Take(10))
                {
                    Console.WriteLine("Order ID: {0}", order.OrderID);

                    //<snippetLoadRelatedOrderDetailsSpecific>
                    // Explicitly load the order details for each order.
                    context.LoadProperty(order, "Order_Details");
                    //</snippetLoadRelatedOrderDetailsSpecific>

                    foreach (Order_Detail item in order.Order_Details)
                    {
                        Console.WriteLine("\tProduct: {0} - Quantity: {1}",
                            item.ProductID, item.Quantity);
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLoadRelatedOrderDetails>
        }

        public static void ExpandOrderDetails()
        {
            //<snippetExpandOrderDetails>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            //<snippetExpandOrderDetailsSpecific>
            // Define a query for orders that also returns items and customers.
            DataServiceQuery<Order> query =
                context.Orders.Expand("Order_Details,Customer");
            //</snippetExpandOrderDetailsSpecific>

            try
            {
                // Enumerate over the first 10 results of the query.
                foreach (Order order in query.Take(10))
                {
                    Console.WriteLine("Customer: {0}", order.Customer.CompanyName);
                    Console.WriteLine("Order ID: {0}", order.OrderID);

                    foreach (Order_Detail item in order.Order_Details)
                    {
                        Console.WriteLine("\tProduct: {0} - Quantity: {1}",
                            item.ProductID, item.Quantity);
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetExpandOrderDetails>
        }
        public static void AddQueryOptions()
        {
            //<snippetAddQueryOptions>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            //<snippetAddQueryOptionsSpecific>
            // Define a query for orders with a Freight value greater than 30
            // and that is ordered by the ship date, descending.
            DataServiceQuery<Order> selectedOrders = context.Orders
                .AddQueryOption("$filter", "Freight gt 30")
                .AddQueryOption("$orderby", "OrderID desc");
            //</snippetAddQueryOptionsSpecific>

            try
            {
                // Enumerate over the results of the query.
                foreach (Order order in selectedOrders)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}", 
                        order.OrderID, order.ShippedDate, order.Freight);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetAddQueryOptions>
        }

        public static void AddQueryOptionsLinq()
        {
            //<snippetAddQueryOptionsLinq>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30
            // and that is ordered by the ship date, descending.
            //<snippetAddQueryOptionsLinqSpecific>
            var selectedOrders = from o in context.Orders
                                 where o.Freight > 30
                                 orderby o.ShippedDate descending 
                                 select o;
            //</snippetAddQueryOptionsLinqSpecific>

            try
            {
                // Enumerate over the results of the query.
                foreach (Order order in selectedOrders)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}",
                        order.OrderID, order.ShippedDate, order.Freight);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetAddQueryOptionsLinq>
        }
        public static void AddQueryOptionsLinqExpression()
        {
            //<snippetAddQueryOptionsLinqExpression>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30
            // and that is ordered by the ship date, descending.
            //<snippetAddQueryOptionsLinqExpressionSpecific>
            var selectedOrders = context.Orders
                                .Where(o => o.Freight > 30)
                                .OrderByDescending(o => o.ShippedDate);
            //</snippetAddQueryOptionsLinqExpressionSpecific>

            try
            {
                // Enumerate over the results of the query.
                foreach (Order currentOrder in selectedOrders)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}",
                        currentOrder.OrderID, currentOrder.ShippedDate, 
                        currentOrder.Freight);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetAddQueryOptionsLinqExpression>
        }
        public static void OrderWithFilter()
        {
            //<snippetOrderWithFilter>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            //<snippetOrderWithFilterSpecific>
            // Define a query for orders with a Freight value greater than 30
            // that also orders the result by the Freight value, descending.
            DataServiceQuery<Order> selectedOrders = context.Orders
                .AddQueryOption("$orderby", "Freight gt 30 desc");
            //</snippetOrderWithFilterSpecific>

            try
            {
                // Enumerate over the results of the query.
                foreach (Order order in selectedOrders)
                {
                    Console.WriteLine("Order ID: {0} - Freight: {1}",
                        order.OrderID, order.Freight);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetOrderWithFilter>
        }

        public static void BatchQuery()
        {
            //<snippetBatchQuery>
            string customerId = "ALFKI";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Create the separate query URI's, one that returns 
            // a single customer and another that returns all Products.
            Uri customerUri = new Uri(svcUri.AbsoluteUri + 
                "/Customers('" + customerId + "')/?$expand=Orders");
            Uri productsUri = new Uri(svcUri.AbsoluteUri +
               "/Products");

            // Create the query requests.
            DataServiceRequest<Customer> customerQuery = 
                new DataServiceRequest<Customer>(customerUri);
            DataServiceRequest<Product> productsQuery =
                            new DataServiceRequest<Product>(productsUri);

            // Add the query requests to a batch request array.
            DataServiceRequest[] batchRequests = 
                new DataServiceRequest[]{customerQuery, productsQuery};

            DataServiceResponse batchResponse;

            try
            {
                // Execute the query batch and get the response.
                batchResponse = context.ExecuteBatch(batchRequests);

                if (batchResponse.IsBatchResponse)
                {
                    // Parse the batchResponse.BatchHeaders.
                }  
                // Enumerate over the results of the query.
                foreach (QueryOperationResponse response in batchResponse)
                {
                    // Handle an error response.
                    if (response.StatusCode > 299 || response.StatusCode < 200)
                    {
                        Console.WriteLine("An error occurred.");
                        Console.WriteLine(response.Error.Message);
                    }
                    else
                    {
                        // Find the response for the Customers query.
                        if (response.Query.ElementType == typeof(Customer))
                        {
                            foreach (Customer customer in response)
                            {
                                Console.WriteLine("Customer: {0}", customer.CompanyName);
                                foreach (Order order in customer.Orders)
                                {
                                    Console.WriteLine("Order ID: {0} - Freight: {1}",
                                        order.OrderID, order.Freight);
                                }
                            }
                        }
                        // Find the response for the Products query.
                        else if (response.Query.ElementType == typeof(Product))
                        {
                            foreach (Product product in response)
                            {
                                Console.WriteLine("Product: {0}", product.ProductName);
                            }
                        }
                    }
                }
            }

            // This type of error is raised when the data service returns with
            // a response code < 200 or >299 in the top level element.
            catch (DataServiceRequestException e)
            {
                // Get the response from the exception.
                batchResponse = e.Response;

                if (batchResponse.IsBatchResponse)
                {
                    // Parse the batchResponse.BatchHeaders.
                }

                foreach (QueryOperationResponse response in batchResponse)
                {
                    if (response.Error != null)
                    {
                        Console.WriteLine("An error occurred.");
                        Console.WriteLine(response.Error.Message);
                    }
                }
            }
            //</snippetBatchQuery>
        }
        public static void AttachObject()
        {
            //<snippetAttachObject>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define an existing customer to attach, including the key.
            Customer customer = 
                Customer.CreateCustomer("ALFKI", "Alfreds Futterkiste");
            
            // Set current property values.
            customer.Address = "Obere Str. 57";
            customer.City = "Berlin";
            customer.PostalCode = "12209";
            customer.Country = "Germany";

            // Set property values to update.
            customer.ContactName = "Peter Franken";
            customer.ContactTitle = "Marketing Manager";
            customer.Phone = "089-0877310";
            customer.Fax = "089-0877451";

            try
            {
                //<snippetAttachObjectSpecific>
                // Attach the existing customer to the context and mark it as updated.
                context.AttachTo("Customers", customer);
                context.UpdateObject(customer);

                // Send updates to the data service.
                context.SaveChanges();
                //</snippetAttachObjectSpecific>  
            }
            catch (DataServiceClientException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
            //</snippetAttachObject>
        }
        public static void AddProduct()
        {
            //<snippetAddProduct>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);
            
            //<snippetCreateNewProduct>
            // Create the new product.
            Product newProduct =
                Product.CreateProduct(0, "White Tea - loose", false);
            //</snippetCreateNewProduct>

            // Set property values.
            newProduct.QuantityPerUnit = "120gm bags";
            newProduct.ReorderLevel = 5;
            newProduct.UnitPrice = 5.2M;

            try
            {
                //<snippetAddProductSpecific>
                // Add the new product to the Products entity set.
                context.AddToProducts(newProduct);
                //</snippetAddProductSpecific>  

                // Send the insert to the data service.
                DataServiceResponse response = context.SaveChanges();

                // Enumerate the returned responses.
                foreach (ChangeOperationResponse change in response)
                {
                    // Get the descriptor for the entity.
                    EntityDescriptor descriptor = change.Descriptor as EntityDescriptor;

                    if (descriptor != null)
                    {
                        Product addedProduct = descriptor.Entity as Product;

                        if (addedProduct != null)
                        {
                            Console.WriteLine("New product added with ID {0}.",
                                addedProduct.ProductID);
                        }
                    }
                }
            }
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
            //</snippetAddProduct>
            finally
            {
                //remove the added product.
                context.DeleteObject(newProduct);
                context.SaveChanges();
            }
        }
        public static void ModifyCustomer()
        {
            //<snippetModifyCustomer>
            string customerId = "ALFKI";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Get a customer to modify using the supplied ID.
            var customerToChange = (from customer in context.Customers
                                    where customer.CustomerID == customerId
                                    select customer).Single();
             
            // Change some property values.
            customerToChange.CompanyName = "Alfreds Futterkiste";
            customerToChange.ContactName = "Maria Anders";
            customerToChange.ContactTitle = "Sales Representative";

            try
            {
                //<snippetModifyCustomerSpecific>
                // Mark the customer as updated.
                context.UpdateObject(customerToChange);
                //</snippetModifyCustomerSpecific>  

                // Send the update to the data service.
                context.SaveChanges();
            }
            catch (DataServiceRequestException  ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
            //</snippetModifyCustomer>
        }
        public static void DeleteProduct()
        {
            // Create the DataServiceContext using the service URI.
            NorthwindEntities extraContext = new NorthwindEntities(svcUri);

            //First add a product to the context.
            Product newProduct =
                Product.CreateProduct(0, "White Tea - loose", false);
            extraContext.AddToProducts(newProduct);
            extraContext.SaveChanges();

            int productID = newProduct.ProductID;

            //<snippetDeleteProduct>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            try
            {
                // Get the product to delete, by product ID.
                var deletedProduct = (from product in context.Products
                                      where product.ProductID == productID
                                      select product).Single();

                //<snippetDeleteProductSpecific>    
                // Mark the product for deletion.    
                context.DeleteObject(deletedProduct);
                //</snippetDeleteProductSpecific>    

                // Send the delete to the data service.
                context.SaveChanges();
            }
            // Handle the error that occurs when the delete operation fails,
            // which can happen when there are entities with existing 
            // relationships to the product being deleted.
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
            //</snippetDeleteProduct>
        }
        public static void AddOrderDetailToOrder()
        {
            //<snippetAddOrderDetailToOrder>
            int productId = 25;
            string customerId = "ALFKI";

            Order_Detail newItem = null;

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            try
            {
                // Get the specific product.
                var selectedProduct = (from product in context.Products
                                       where product.ProductID == productId
                                       select product).Single();

                // Get the specific customer.
                var cust = (from customer in context.Customers.Expand("Orders")
                            where customer.CustomerID == customerId
                            select customer).Single();

                // Get the first order. 
                Order order = cust.Orders.FirstOrDefault();

                // Create a new order detail for the specific product.
                newItem = Order_Detail.CreateOrder_Detail(
                    order.OrderID, selectedProduct.ProductID, 10, 5, 0);

                // Add the new order detail to the context.
                context.AddToOrder_Details(newItem);

                // Add links for the one-to-many relationships.
                context.AddLink(order, "Order_Details", newItem);
                context.AddLink(selectedProduct, "Order_Details", newItem);

                // Add the new order detail to the collection, and
                // set the reference to the product.
                order.Order_Details.Add(newItem);
                newItem.Product = selectedProduct;

                // Send the changes to the data service.
                DataServiceResponse response = context.SaveChanges();

                // Enumerate the returned responses.
                foreach (ChangeOperationResponse change in response)
                {
                    // Get the descriptor for the entity.
                    EntityDescriptor descriptor = change.Descriptor as EntityDescriptor;

                    if (descriptor != null)
                    {
                        if (descriptor.Entity.GetType() == typeof(Order_Detail))
                        {
                            Order_Detail addedItem = descriptor.Entity as Order_Detail;

                            if (addedItem != null)
                            {
                                Console.WriteLine("New {0} item added to order {1}.",
                                    addedItem.Product.ProductName, addedItem.OrderID.ToString());
                            }
                        }
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }

            // Handle any errors that may occur during insert, such as 
            // a constraint violation.
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
            //</snippetAddOrderDetailToOrder>
            //remove the added product.
            finally
            {
                context.DeleteObject(newItem);
                context.SaveChanges();
            }
        }
 
        public static void AddOrderDetailToOrderAuto()
        {
            //<snippetAddOrderDetailToOrderAuto>
            int productId = 25;
            string customerId = "ALFKI";

            Order_Detail newItem = null;

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            try
            {
                // Get the specific product.
                var selectedProduct = (from product in context.Products
                                       where product.ProductID == productId
                                       select product).Single();

                // Get the specific customer.
                var cust = (from customer in context.Customers.Expand("Orders")
                            where customer.CustomerID == customerId
                            select customer).Single();

                // Get the first order. 
                Order order = cust.Orders.FirstOrDefault();

                // Create a new order detail for the specific product.
                newItem = Order_Detail.CreateOrder_Detail(
                    order.OrderID, selectedProduct.ProductID, 10, 5, 0);

                //<snippetAddOrderDetailToOrderSpecific>
                // Add the new item with a link to the related order.
                context.AddRelatedObject(order, "Order_Details", newItem);
                //</snippetAddOrderDetailToOrderSpecific>

                //<snippetSetNavProps>
                // Add the new order detail to the collection, and
                // set the reference to the product.
                order.Order_Details.Add(newItem);
                newItem.Order = order;
                newItem.Product = selectedProduct;
                //</snippetSetNavProps>
               
                // Send the changes to the data service.
                DataServiceResponse response = context.SaveChanges();

                // Enumerate the returned responses.
                foreach (ChangeOperationResponse change in response)
                {
                    // Get the descriptor for the entity.
                    EntityDescriptor descriptor = change.Descriptor as EntityDescriptor;

                    if (descriptor != null)
                    {
                        if (descriptor.Entity.GetType() == typeof(Order_Detail))
                        {
                            Order_Detail addedItem = descriptor.Entity as Order_Detail;

                            if (addedItem != null)
                            {
                                Console.WriteLine("New {0} item added to order {1}.", 
                                    addedItem.Product.ProductName, addedItem.OrderID.ToString());
                            }
                        }
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }

            // Handle any errors that may occur during insert, such as 
            // a constraint violation.
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
            //</snippetAddOrderDetailToOrderAuto>
            //remove the added product.
            finally
            {
                context.DeleteObject(newItem);
                context.SaveChanges();
            }
        }
        public static void CountAllCustomersValueOnly()
        {
            //<snippetCountAllCustomersValueOnly>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);
         
            // Define a new query for Customers.
            DataServiceQuery<Customer> query = context.Customers;
            
            try
            {    
                // Execute the query to just return the value of all customers in the set.
                int totalCount = query.Count();
                
                // Retrieve the total count from the response.
                Console.WriteLine("There are {0} customers in total.", totalCount);
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetCountAllCustomersValueOnly>
        }
        public static void CountAllCustomers()
        {
            //<snippetCountAllCustomers>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);
         
            //<snippetCountAllCustomersSpecific>  
            // Define a new query for Customers that includes the total count.
            DataServiceQuery<Customer> query = context.Customers.IncludeTotalCount();
            //</snippetCountAllCustomersSpecific>

            try
            {    
                //<snippetGetResponseSpecific> 
                // Execute the query for all customers and get the response object.
                QueryOperationResponse<Customer> response = 
                    query.Execute() as QueryOperationResponse<Customer>;
                //</snippetGetResponseSpecific> 

                // Retrieve the total count from the response.
                Console.WriteLine("There are a total of {0} customers.", response.TotalCount);

                // Enumerate the customers in the response.
                foreach (Customer customer in response)
                {
                    Console.WriteLine("\tCustomer Name: {0}", customer.CompanyName);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetCountAllCustomers>
        }
        public static void GetCustomersPaged()
        {
            //<snippetGetCustomersPaged>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);
            DataServiceQueryContinuation<Customer> token = null;
            int pageCount = 0; 

            try
            { 
                // Execute the query for all customers and get the response object.
                QueryOperationResponse<Customer> response =
                    context.Customers.Execute() as QueryOperationResponse<Customer>;

                //<snippetLoadNextLink>
                // With a paged response from the service, use a do...while loop 
                // to enumerate the results before getting the next link.
                do
                {
                    // Write the page number.
                    Console.WriteLine("Page {0}:", pageCount++);

                    // If nextLink is not null, then there is a new page to load.
                    if (token != null)
                    {
                        // Load the new page from the next link URI.
                        response = context.Execute<Customer>(token)
                            as QueryOperationResponse<Customer>;
                    }

                    // Enumerate the customers in the response.
                    foreach (Customer customer in response)
                    {
                        Console.WriteLine("\tCustomer Name: {0}", customer.CompanyName);
                    }
                }

                // Get the next link, and continue while there is a next link.
                while ((token = response.GetContinuation()) != null);
                //</snippetLoadNextLink>
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetGetCustomersPaged>
        }
        public static void GetCustomersPagedNested()
        {
            //<snippetGetCustomersPagedNested>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);
            DataServiceQueryContinuation<Customer> nextLink = null;
            int pageCount = 0;
            int innerPageCount = 0;

            try
            {
                // Execute the query for all customers and related orders,
                // and get the response object.
                var response =
                    context.Customers.AddQueryOption("$expand", "Orders")
                    .Execute() as QueryOperationResponse<Customer>;

                // With a paged response from the service, use a do...while loop 
                // to enumerate the results before getting the next link.
                do
                {
                    // Write the page number.
                    Console.WriteLine("Customers Page {0}:", ++pageCount);

                    // If nextLink is not null, then there is a new page to load.
                    if (nextLink != null)
                    {
                        // Load the new page from the next link URI.
                        response = context.Execute<Customer>(nextLink)
                            as QueryOperationResponse<Customer>;
                    }

                    // Enumerate the customers in the response.
                    foreach (Customer c in response)
                    {
                        Console.WriteLine("\tCustomer Name: {0}", c.CompanyName);
                        Console.WriteLine("\tOrders Page {0}:", ++innerPageCount);
                        // Get the next link for the collection of related Orders.
                        DataServiceQueryContinuation<Order> nextOrdersLink = 
                            response.GetContinuation(c.Orders);

                        //<snippetLoadNextOrdersLink>
                        while (nextOrdersLink != null)
                        {
                            foreach (Order o in c.Orders)
                            {
                                // Print out the orders.
                                Console.WriteLine("\t\tOrderID: {0} - Freight: ${1}",
                                    o.OrderID, o.Freight);
                            }

                            // Load the next page of Orders.
                            var ordersResponse = context.LoadProperty(c, "Orders", nextOrdersLink);
                            nextOrdersLink = ordersResponse.GetContinuation();
                        }
                        //</snippetLoadNextOrdersLink>
                    }
                }

                // Get the next link, and continue while there is a next link.
                while ((nextLink = response.GetContinuation()) != null);
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetGetCustomersPagedNested>
        }
        public static void SelectCustomerAddress()
        {
            //<snippetSelectCustomerAddress>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            //<snippetSelectCustomerAddressSpecific>  
            // Define an anonymous LINQ query that projects the Customers type into 
            // a CustomerAddress type that contains only address properties.
            //<snippetProjectWithInitializer> 
            var query = from c in context.Customers
                        where c.Country == "Germany"
                        select new CustomerAddress { 
                            CustomerID = c.CustomerID, 
                            Address = c.Address, 
                            City = c.City, 
                            Region = c.Region,
                            PostalCode = c.PostalCode, 
                            Country = c.Country};
            //</snippetProjectWithInitializer>
            //</snippetSelectCustomerAddressSpecific>

            try
            {
                // Enumerate over the query result, which is executed implicitly.
                foreach (var item in query)
                {
                    // Modify the address and mark the object as updated.
                    item.Address += " #101";
                    context.UpdateObject(item);

                    // Write out the current values.
                    Console.WriteLine("Customer ID: {0} \r\nStreet: {1} "
                        + "\r\nCity: {2} \r\nState: {3} \r\nZip Code: {4} \r\nCountry: {5}", 
                        item.CustomerID, item.Address, item.City, item.Region, 
                        item.PostalCode, item.Country);
                }

                // Save changes to the data service.
                context.SaveChanges();
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetSelectCustomerAddress>
        }
        public static void SelectCustomerAddressNonEntity()
        {
            //<snippetSelectCustomerAddressNonEntity>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define an anonymous LINQ query that projects the Customers type into 
            // a CustomerAddress type that contains only address properties.
            var query = from c in context.Customers
                        where c.Country == "Germany"
                        select new CustomerAddressNonEntity
                        {
                            CompanyName = c.CompanyName, 
                            Address = c.Address,
                            City = c.City, 
                            Region = c.Region,
                            PostalCode = c.PostalCode, 
                            Country = c.Country
                        };

            try
            {
                // Enumerate over the query result, which is executed implicitly.
                foreach (var item in query)
                {
                    item.Address += "Street";

                    Console.WriteLine("Company name: {0} \nStreet: {1} "
                        + "\nCity: {2} \nState: {3} \nZip Code: {4} \nCountry: {5}",
                        item.CompanyName, item.Address, item.City, item.Region,
                        item.PostalCode, item.Country);
                }     
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetSelectCustomerAddressNonEntity>
        }
        public static void ProjectWithConstructor()
        {
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define an anonymous LINQ query that projects the Customers type into 
            // a CustomerAddress type that contains only address properties.
            //<snippetProjectWithConstructor> 
            var query = from c in context.Customers
                        where c.Country == "Germany"
                        select new CustomerAddress(
                        c.CustomerID, 
                        c.Address, 
                        c.City, 
                        c.Region,
                        c.PostalCode, 
                        c.Country);
            //</snippetProjectWithConstructor>

            try
            {
                // Enumerate over the query result, which is executed implicitly.
                foreach (var item in query)
                {
                    // Write out the current values.
                    Console.WriteLine("Customer ID: {0} \r\nStreet: {1} "
                        + "\r\nCity: {2} \r\nState: {3} \r\nZip Code: {4} \r\nCountry: {5}",
                        item.CustomerID, item.Address, item.City, item.Region,
                        item.PostalCode, item.Country);
                }
            }
            catch (NotSupportedException ex)
            {
                throw new ApplicationException(
                    "This is an expected error.", ex);
            }
        }
        public static void ProjectWithTransform()
        {
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define an anonymous LINQ query that projects the Customers type into 
            // a CustomerAddress type and tries to create a new Address string by
            // concatenating other properties.
            //<snippetProjectWithTransform> 
            var query = from c in context.Customers
                        where c.Country == "Germany"
                        select new CustomerAddress
                        {
                            CustomerID = c.CustomerID, 
                            Address = "Full address:" + c.Address + ", " +
                            c.City + ", " + c.Region + " " + c.PostalCode,
                            City = c.City,
                            Region = c.Region,
                            PostalCode = c.PostalCode,
                            Country = c.Country
                        };
            //</snippetProjectWithTransform>

            try
            {
                // Enumerate over the query result, which is executed implicitly.
                foreach (var item in query)
                {
                    // Write out the current values.
                    Console.WriteLine("Customer ID: {0} \r\nStreet: {1} "
                        + "\r\nCity: {2} \r\nState: {3} \r\nZip Code: {4} \r\nCountry: {5}",
                        item.CustomerID, item.Address, item.City, item.Region,
                        item.PostalCode, item.Country);
                }
            }
            catch (NotSupportedException ex)
            {
                throw new ApplicationException(
                    "This is an expected error.", ex);
            }
        }
        public static void ProjectWithConvertion()
        {
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define an anonymous LINQ query that projects the Customers type into 
            // a CustomerAddress type that contains only address properties.
            //<snippetProjectWithConvertion> 
            var query = from c in context.Customers
                        where c.Country == "Germany"
                        select new CustomerAddress
                        {
                            CustomerID = c.CustomerID,
                            Address = c.Address,
                            City = c.City,
                            Region = c.Region,
                            PostalCode = c.PostalCode,
                            Country = c.Country
                        };
            //</snippetProjectWithConvertion>

            try
            {
                // Enumerate over the query result, which is executed implicitly.
                foreach (var item in query)
                {
                    // Write out the current values.
                    Console.WriteLine("Customer ID: {0} \r\nStreet: {1} "
                        + "\r\nCity: {2} \r\nState: {3} \r\nZip Code: {4} \r\nCountry: {5}",
                        item.CustomerID, item.Address, item.City, item.Region,
                        item.PostalCode.Split(new char[]{'-'})[0], item.Country);
                }
            }
            catch (NotSupportedException ex)
            {
                throw new ApplicationException(
                    "This is an expected error.", ex);
            }
        }
        public static void LinqQueryPrecedence()
        {
            //<snippetLinqQueryPrecedence>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders that have shipped.
            //<snippetLinqQueryPrecedenceSpecific>
            var ordersQuery = (from o in context.Orders
                                 where o.ShippedDate < DateTime.Today
                                 orderby o.OrderDate descending, o.CustomerID 
                                 select o).Skip(10).Take(10);
            //</snippetLinqQueryPrecedenceSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Order>)ordersQuery)
                    .RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Order order in ordersQuery)
                {
                    Console.WriteLine("CustomerID:{0}\n{1}, {2}",
                        order.ShipName, order.ShipCity, order.ShipCountry);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqQueryPrecedence>
        }
        public static void LinqMethodPrecedence()
        {
            //<snippetLinqMethodPrecedence>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30.
            //<snippetLinqMethodPrecedenceSpecific>
            var projectedQuery = context.Customers
                .Where(c => c.Country == "Germany")
                .OrderBy(c => c.CompanyName)
                .Select(c => new CustomerAddress
                {
                    CustomerID = c.CustomerID,
                    Address = c.Address,
                    City = c.City,
                    Region = c.Region,
                    PostalCode = c.PostalCode,
                    Country = c.Country
                }).Skip(10).Take(10);
            //</snippetLinqMethodPrecedenceSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<CustomerAddress>)projectedQuery)
                    .RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (CustomerAddress address in projectedQuery)
                {
                    Console.WriteLine("Address:\n{0}\n{1}, {2}",
                        address.Address, address.City, address.Region);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqMethodPrecedence>
        }
        #region LINQ examples
        public static void LinqWhereClause()
        {
            //<snippetLinqWhereClause>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30.
            //<snippetLinqWhereClauseSpecific>
            var filteredOrders = from o in context.Orders
                                    where o.Freight > 30
                                    select o;
            //</snippetLinqWhereClauseSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Order>)filteredOrders).RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Order order in filteredOrders)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}",
                        order.OrderID, order.ShippedDate, order.Freight);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqWhereClause>
        }
        public static void LinqWhereMethod()
        {
            //<snippetLinqWhereMethod>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30.
            //<snippetLinqWhereMethodSpecific>
            var filteredOrders = context.Orders
                .Where(o => o.Freight > 30);
            //</snippetLinqWhereMethodSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Order>)filteredOrders).RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Order order in filteredOrders)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}",
                        order.OrderID, order.ShippedDate, order.Freight);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqWhereMethod>
        }
        public static void ExplicitQueryWhereMethod()
        {
            //<snippetExplicitQueryWhereMethod>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            //<snippetExplicitQueryWhereMethodSpecific>
            // Define a query for orders with a Freight value greater than 30.
            var filteredOrders
                = context.Orders.AddQueryOption("$filter", "Freight gt 30M");
            //</snippetExplicitQueryWhereMethodSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(filteredOrders.RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Order order in filteredOrders)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}",
                        order.OrderID, order.ShippedDate, order.Freight);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetExplicitQueryWhereMethod>
        }
        public static void LinqOrderByClause()
        {
            //<snippetLinqOrderByClause>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30.
            //<snippetLinqOrderByClauseSpecific>
            var sortedCustomers = from c in context.Customers
                                 orderby c.CompanyName ascending, 
                                 c.PostalCode descending
                                 select c;
            //</snippetLinqOrderByClauseSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Customer>)sortedCustomers).RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Customer cust in sortedCustomers)
                {
                    Console.WriteLine("Customer name: {0} - Zip code: {1}",
                        cust.CompanyName, cust.PostalCode);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqOrderByClause>
        }
        public static void LinqOrderByMethod()
        {
            //<snippetLinqOrderByMethod>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30.
            //<snippetLinqOrderByMethodSpecific>
            var sortedCustomers = context.Customers.OrderBy(c => c.CompanyName)
                .ThenByDescending(c => c.PostalCode);
            //</snippetLinqOrderByMethodSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Customer>)sortedCustomers).RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Customer cust in sortedCustomers)
                {
                    Console.WriteLine("Customer name: {0} - Zip code: {1}",
                        cust.CompanyName, cust.PostalCode);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqOrderByMethod>
        }
        public static void ExplicitQueryOrderByMethod()
        {
            //<snippetExplicitQueryOrderByMethod>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30.
            //<snippetExplicitQueryOrderByMethodSpecific>
            var sortedCustomers = context.Customers
                .AddQueryOption("$orderby", "CompanyName, PostalCode desc");
            //</snippetExplicitQueryOrderByMethodSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(sortedCustomers.RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Customer cust in sortedCustomers)
                {
                    Console.WriteLine("Customer name: {0} - Zip code: {1}",
                        cust.CompanyName, cust.PostalCode);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetExplicitQueryOrderByMethod>
        }
        public static void LinqSkipTakeMethod()
        {
            //<snippetLinqSkipTakeMethod>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query that returns 25 orders after skipping the 
            // first 50 orders returned by the query.
            //<snippetLinqSkipTakeMethodSpecific>
            var pagedOrders = (from o in context.Orders
                                  orderby o.OrderDate descending
                                 select o).Skip(50).Take(25);
            //</snippetLinqSkipTakeMethodSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Order>)pagedOrders).RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Order order in pagedOrders)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}",
                        order.OrderID, order.ShippedDate, order.Freight);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqSkipTakeMethod>
        }
        public static void ExplicitQuerySkipTakeMethod()
        {
            //<snippetExplicitQuerySkipTakeMethod>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query that returns 25 orders after skipping the 
            // first 50 orders returned by the query.
            //<snippetExplicitQuerySkipTakeMethodSpecific>
            var pagedOrders = context.Orders
                .AddQueryOption("$orderby", "OrderDate desc")
                .AddQueryOption("$skip", 50)
                .AddQueryOption("$top", 25);
            //</snippetExplicitQuerySkipTakeMethodSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Order>)pagedOrders).RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Order order in pagedOrders)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}",
                        order.OrderID, order.ShippedDate, order.Freight);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetExplicitQuerySkipTakeMethod>
        }
        public static void LinqSelectClause()
        {
            //<snippetLinqSelectClause>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30.
            //<snippetLinqSelectClauseSpecific>
            var projectedQuery = from c in context.Customers
                        select new CustomerAddress
                        {
                            CustomerID = c.CustomerID,
                            Address = c.Address,
                            City = c.City,
                            Region = c.Region,
                            PostalCode = c.PostalCode,
                            Country = c.Country
                        };
            //</snippetLinqSelectClauseSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<CustomerAddress>)projectedQuery).RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (CustomerAddress address in projectedQuery)
                {
                    Console.WriteLine("Address:\n{0}\n{1}, {2}",
                        address.Address, address.City, address.Region);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqSelectClause>
        }
        public static void LinqSelectMethod()
        {
            //<snippetLinqSelectMethod>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query for orders with a Freight value greater than 30.
            //<snippetLinqSelectMethodSpecific>
            var projectedQuery = context.Customers.Where(c => c.Country == "Germany")
                .Select(c => new CustomerAddress
                {
                    CustomerID = c.CustomerID, 
                    Address = c.Address,
                    City = c.City,
                    Region = c.Region,
                    PostalCode = c.PostalCode,
                    Country = c.Country});                   
            //</snippetLinqSelectMethodSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<CustomerAddress>)projectedQuery)
                    .RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (CustomerAddress address in projectedQuery)
                {
                    Console.WriteLine("Address:\n{0}\n{1}, {2}",
                        address.Address, address.City, address.Region);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqSelectMethod>
        }
        public static void LinqQueryExpand()
        {
            //<snippetLinqQueryExpand>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query that returns orders and details
            // for the customer "ALKFI".
            //<snippetLinqQueryExpandSpecific>
            var ordersQuery = from o in context.Orders.Expand("Order_Details")
                                 where o.CustomerID == "ALFKI"
                                 select o;
            //</snippetLinqQueryExpandSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Order>)ordersQuery)
                    .RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Order order in ordersQuery)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}",
                        order.OrderID, order.ShippedDate, order.Freight);

                    foreach (Order_Detail item in order.Order_Details)
                    {
                        Console.WriteLine("\tProduct: {0} (Price: {1}) - Quantity: {2}",
                        item.ProductID, item.UnitPrice, item.Quantity);
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqQueryExpand>
        }
        public static void LinqQueryExpandMethod()
        {
            //<snippetLinqQueryExpandMethod>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Define a query that returns orders and details
            // for the customer "ALKFI".
            //<snippetLinqQueryExpandMethodSpecific>
            var ordersQuery = context.Orders.Expand("Order_Details")
                              .Where(o => o.CustomerID == "ALFKI");
            //</snippetLinqQueryExpandMethodSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Order>)ordersQuery)
                    .RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Order order in ordersQuery)
                {
                    Console.WriteLine("Order ID: {0} - Ship Date: {1} - Freight: {2}",
                        order.OrderID, order.ShippedDate, order.Freight);

                    foreach (Order_Detail item in order.Order_Details)
                    {
                        Console.WriteLine("\tProduct: {0} (Price: {1}) - Quantity: {2}",
                        item.ProductID, item.UnitPrice, item.Quantity);
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqQueryExpandMethod>
        }
        #endregion 
        public static void LinqQueryClientEval()
        {
            //<snippetLinqQueryClientEval>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            //<snippetLinqQueryClientEvalSpecific>
            int basePrice = 100;
            decimal discount = .10M;

            // Define a query that returns products based on a 
            // calculation that is determined on the client.
            var productsQuery = from p in context.Products
                              where p.UnitPrice >
                              (basePrice - (basePrice * discount)) &&
                              p.ProductName.Contains("bike")
                              select p;
            //</snippetLinqQueryClientEvalSpecific>

            try
            {
                // Write out the URI.
                Console.WriteLine(((DataServiceQuery<Product>)productsQuery)
                    .RequestUri.ToString());

                // Enumerate over the results of the query.
                foreach (Product prod in productsQuery)
                {
                    Console.WriteLine("Product ID: {0} ({1}) - Unit price: {2}",
                        prod.ProductID, prod.ProductName, prod.UnitPrice);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetLinqQueryClientEval>
        }
        public static void RegisterHeadersQuery()
        {
            //<snippetRegisterHeadersQuery>
            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri);

            // Register to handle the SendingRequest event.
            // Note: If this must be done for every request to the data service, consider
            // registering for this event by overriding the OnContextCreated partial method in 
            // the entity container, in this case NorthwindEntities. 
            context.SendingRequest += new EventHandler<SendingRequestEventArgs>(OnSendingRequest);

            // Define a query for orders with a Freight value greater than 30.
            var query = from cust in context.Customers
                where cust.Country == "Germany"
                select cust;

            try
            {
                // Enumerate to execute the query.
                foreach (Customer cust in query)
                {
                    Console.WriteLine("Name: {0}\nAddress:\n{1}\n{2}, {3}",
                        cust.CompanyName, cust.Address, cust.City, cust.Region);
                }
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
            //</snippetRegisterHeadersQuery>
        }
        //<snippetOnSendingRequest>
        private static void OnSendingRequest(object sender, SendingRequestEventArgs e)
        {
            // Add an Authorization header that contains an OAuth WRAP access token to the request.
            e.RequestHeaders.Add("Authorization", "WRAP access_token=\"123456789\"");
        }
        //</snippetOnSendingRequest>

        //public static void SelectProductWithNulls()
        //{
        //    //<snippetSelectProductWithNulls>
        //    // Create the DataServiceContext using the service URI.
        //    NorthwindEntities context = new NorthwindEntities(svcUri);

        //    // Define an anonymous LINQ query that projects the Products type, 
        //    // checking for relationships that return a null reference.
        //    //<snippetSelectProductWithNullsSpecific> 
        //    var query = from p in context.Products
        //                where (p.Discontinued == false && p.ProductID > 77)
        //                select new Product
        //                {
        //                    ProductID = p.ProductID,
        //                    ProductName = p.ProductName,
        //                    QuantityPerUnit = p.QuantityPerUnit,
        //                    UnitPrice = p.UnitPrice,
        //                    UnitsInStock = p.UnitsInStock,
        //                    UnitsOnOrder = p.UnitsOnOrder,
        //                    ReorderLevel = p.ReorderLevel,
        //                    Discontinued = p.Discontinued,
        //                    SupplierID = p.SupplierID,
        //                    CategoryID = p.CategoryID,
        //                    Category = p.Category, //(p.Category == null) ? null : p.Category,
        //                    Supplier = p.Supplier //(p.Supplier ==null) ? null : p.Supplier
        //                };
        //    //</snippetSelectProductWithNullsSpecific>

        //    try
        //    {
        //        // Enumerate over the query result, which is executed implicitly.
        //        foreach (var item in query)
        //        {
                    
        //            // Write out the current values.
        //            Console.WriteLine("Product ID: {0}/nUnits on order: {1}",
        //                item.ProductID, item.UnitsOnOrder);
        //        }

        //    }
        //    catch (DataServiceQueryException ex)
        //    {
        //        throw new ApplicationException(
        //            "An error occurred during query execution.", ex);
        //    }
        //    //</snippetSelectProductWithNulls>
        //}

        public static EventHandler<SendingRequestEventArgs> context_SendingRequest { get; set; }


        public static void CallServiceOperationIQueryable()
        {
            //<snippetCallServiceOperationIQueryable>
            // Define the service operation query parameter.
            string city = "London";

            // Define the query URI to access the service operation with specific 
            // query options relative to the service URI.
            string queryString = string.Format("GetOrdersByCity?city='{0}'", city)
                + "&$orderby=ShippedDate desc"
                + "&$expand=Order_Details";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri2);

            try
            {
                // Execute the service operation that returns all orders for the specified city.
                var results = context.Execute<Order>(new Uri(queryString, UriKind.Relative));

                // Write out order information.
                foreach (Order o in results)
                {
                    Console.WriteLine(string.Format("Order ID: {0}", o.OrderID));

                    foreach (Order_Detail item in o.Order_Details)
                    {
                        Console.WriteLine(String.Format("\tItem: {0}, quantity: {1}",
                            item.ProductID, item.Quantity));
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                QueryOperationResponse response = ex.Response;

                Console.WriteLine(response.Error.Message);
            }
            //</snippetCallServiceOperationIQueryable>
        }

        public static void CallServiceOperationCreateQuery()
        {
            //<snippetCallServiceOperationCreateQuery>
            // Define the service operation query parameter.
            string city = "London";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri2);

            // Use the CreateQuery method to create a query that accessess
            // the service operation passing a single parameter.       
            var query = context.CreateQuery<Order>("GetOrdersByCity")
                .AddQueryOption("city", string.Format("'{0}'", city))
                .Expand("Order_Details");

            try
            {
                // The query is executed during enumeration.
                foreach (Order o in query)
                {
                    Console.WriteLine(string.Format("Order ID: {0}", o.OrderID));

                    foreach (Order_Detail item in o.Order_Details)
                    {
                        Console.WriteLine(String.Format("\tItem: {0}, quantity: {1}",
                            item.ProductID, item.Quantity));
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                QueryOperationResponse response = ex.Response;

                Console.WriteLine(response.Error.Message);
            }
            //</snippetCallServiceOperationCreateQuery>
        }

        public static void CallServiceOperationSingleEntity()
        {
            //<snippetCallServiceOperationSingleEntity>
            // Define the query URI to access the service operation, 
            // relative to the service URI.
            string queryString = "GetNewestOrder";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri2);

            try
            {
                // Execute a service operation that returns only the newest single order.
                Order order
                    = (context.Execute<Order>(new Uri(queryString, UriKind.Relative)))
                    .FirstOrDefault();

                // Write out order information.
                Console.WriteLine(string.Format("Order ID: {0}", order.OrderID));
                Console.WriteLine(string.Format("Order date: {0}", order.OrderDate));
            }
            catch (DataServiceQueryException ex)
            {
                QueryOperationResponse response = ex.Response;

                Console.WriteLine(response.Error.Message);
            }
            //</snippetCallServiceOperationSingleEntity>
        }

        public static void CallServiceOperationEnumString()
        {
            //<snippetCallServiceOperationEnumString>
            // Define the query URI to access the service operation, 
            // relative to the service URI.
            string queryString = "GetCustomerNames";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri2);

            try
            {
                // Execute a service operation that returns only the newest single order.
                IEnumerable<string> customerNames
                    = context.Execute<string>(new Uri(queryString, UriKind.Relative));
                
                foreach (string name in customerNames)
                {
                    // Write out order information.
                    Console.WriteLine(name);
                }
            }
            catch (DataServiceQueryException ex)
            {
                QueryOperationResponse response = ex.Response;

                Console.WriteLine(response.Error.Message);
            }
            //</snippetCallServiceOperationEnumString>
        }

        public static void CallServiceOperationSingleInt()
        {
            //<snippetCallServiceOperationSingleInt>
            // Define the query URI to access the service operation, 
            // relative to the service URI.
            string queryString = "CountOpenOrders";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri2);

            try
            {
                // Execute a service operation that returns the integer 
                // count of open orders.
                int numOrders
                    = (context.Execute<int>(new Uri(queryString, UriKind.Relative)))
                    .FirstOrDefault();

                // Write out the number of open orders.
                Console.WriteLine(string.Format("Open orders as of {0}: {1}",
                    DateTime.Today.Date, numOrders));
            }
            catch (DataServiceQueryException ex)
            {
                QueryOperationResponse response = ex.Response;

                Console.WriteLine(response.Error.Message);
            }
            //</snippetCallServiceOperationSingleInt>
        }


        public static void CallServiceOperationVoid()
        {
            //<snippetCallServiceOperationVoid>
            // Define the query URI to access the service operation, 
            // relative to the service URI.
            string queryString = "ReturnsNoData";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri2);

            try
            {
                // Execute a service operation that returns void.
                context.Execute<string>(new Uri(queryString, UriKind.Relative));
            }
            catch (DataServiceQueryException ex)
            {
                QueryOperationResponse response = ex.Response;

                Console.WriteLine(response.Error.Message);
            }
            //</snippetCallServiceOperationVoid>
        }

        public static void CallServiceOperationQueryAsync()
        {
            //<snippetCallServiceOperationQueryAsync>
            // Define the service operation query parameter.
            string city = "London";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri2);

            // Use the CreateQuery method to create a query that accessess
            // the service operation passing a single parameter.       
            var query = context.CreateQuery<Order>("GetOrdersByCity")
                .AddQueryOption("city", string.Format("'{0}'", city))
                .Expand("Order_Details");

            // Execute the service operation that returns 
            // all orders for the specified city.
            var results = 
                query.BeginExecute(OnAsyncQueryExecutionComplete, query);
            //</snippetCallServiceOperationQueryAsync>
        }

        //<snippetOnAsyncQueryExecutionComplete>
        private static void OnAsyncQueryExecutionComplete(IAsyncResult result)
        {
            // Get the query back from the stored state.
            var query = result.AsyncState as DataServiceQuery<Order>;
            
            try
            {
                // Complete the exection and write out the results.
                foreach (Order o in query.EndExecute(result))
                {
                    Console.WriteLine(string.Format("Order ID: {0}", o.OrderID));

                    foreach (Order_Detail item in o.Order_Details)
                    {
                        Console.WriteLine(String.Format("\tItem: {0}, quantity: {1}",
                            item.ProductID, item.Quantity));
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                QueryOperationResponse response = ex.Response;

                Console.WriteLine(response.Error.Message);
            }
        }
        //</snippetOnAsyncQueryExecutionComplete>    

    public static void CallServiceOperationAsync()
        {
            //<snippetCallServiceOperationAsync>
            // Define the service operation query parameter.
            string city = "London";

            // Define the query URI to access the service operation with specific 
            // query options relative to the service URI.
            string queryString = string.Format("GetOrdersByCity?city='{0}'", city)
                + "&$orderby=ShippedDate desc"
                + "&$expand=Order_Details";

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(svcUri2);

            // Execute the service operation that returns 
            // all orders for the specified city.
            var results = context.BeginExecute<Order>(
                new Uri(queryString, UriKind.Relative),
                OnAsyncExecutionComplete, context);
            //</snippetCallServiceOperationAsync>
        }
    
        //<snippetOnAsyncExecutionComplete>
        private static void OnAsyncExecutionComplete(IAsyncResult result)
        {
            // Get the context back from the stored state.
            var context = result.AsyncState as NorthwindEntities;
            
            try
            {
                // Complete the exection and write out the results.
                foreach (Order o in context.EndExecute<Order>(result))
                {
                    Console.WriteLine(string.Format("Order ID: {0}", o.OrderID));

                    foreach (Order_Detail item in o.Order_Details)
                    {
                        Console.WriteLine(String.Format("\tItem: {0}, quantity: {1}",
                            item.ProductID, item.Quantity));
                    }
                }
            }
            catch (DataServiceQueryException ex)
            {
                QueryOperationResponse response = ex.Response;

                Console.WriteLine(response.Error.Message);
            }
        }
        //</snippetOnAsyncExecutionComplete>
    }
}
