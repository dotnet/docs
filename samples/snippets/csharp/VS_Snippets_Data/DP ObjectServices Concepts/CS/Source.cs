//<snippetUsingSerialization>
//<snippetUsing>
using System;
using System.Collections.Generic;
//<snippetUsingEvents>
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
//</snippetUsingEvents>
using System.Data.SqlClient;
//</snippetUsing>
using System.IO;
using System.Linq;
//</snippetUsingSerialization>
using System.Xml.Serialization;

namespace ObjectServicesConceptsCS
{
    class Source
    {
        //<snippetExecuteStoreCommandAndQueryForNewEntity>
        public class DepartmentInfo
        {
            private DateTime _startDate;
            private String _name;
            private Int32 _departmentID;

            public Int32 DepartmentID
            {
                get
                {
                    return _departmentID;
                }
                set
                {
                    _departmentID = value;
                }
            }
            public String Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
            public DateTime StartDate
            {
                get
                {
                    return _startDate;
                }
                set
                {
                    _startDate = value;
                }
            }
        }

        public static void ExecuteStoreCommands()
        {
            using (SchoolEntities context =
                new SchoolEntities())
            {

                int DepartmentID = 21;
                // Insert the row in the Department table. Use the parameter substitution pattern.
                int rowsAffected = context.ExecuteStoreCommand("insert Department values ({0}, {1}, {2}, {3}, {4})",
                                DepartmentID, "Engineering", 350000.00, "2009-09-01", 2);
                Console.WriteLine($"Number of affected rows: {rowsAffected}");

                // Get the DepartmentTest object.
                DepartmentInfo department = context.ExecuteStoreQuery<DepartmentInfo>
                    ("select * from Department where DepartmentID= {0}", DepartmentID).FirstOrDefault();

                Console.WriteLine("ID: {0}, Name: {1} ", department.DepartmentID, department.Name);

                rowsAffected = context.ExecuteStoreCommand("delete from Department where DepartmentID = {0}", DepartmentID);
                Console.WriteLine($"Number of affected rows: {rowsAffected}");
            }
        }
        //</snippetExecuteStoreCommandAndQueryForNewEntity>

        public static void CallCustomMethod()
        {
            Console.WriteLine("Starting method 'CallCustomMethod'");
            //<snippetCallCustomMethod>
            int orderId = 43662;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Return an order and its items.
                SalesOrderHeader order =
                    context.SalesOrderHeaders
                    .Include("SalesOrderDetails")
                    .Where("it.SalesOrderID = @orderId",
                       new ObjectParameter("orderId", orderId)).First();

                Console.WriteLine("The original order total was: "
                    + order.TotalDue);

                // Update the order status.
                order.Status = 1;

                // Increase the quantity of the first item, if one exists.
                if (order.SalesOrderDetails.Count > 0)
                {
                    order.SalesOrderDetails.First().OrderQty += 1;
                }

                // Increase the shipping amount by 10%.
                order.Freight =
                    Decimal.Round(order.Freight * (decimal)1.1, 4);

                // Call the custom method to update the total.
                order.UpdateOrderTotal();

                Console.WriteLine("The calculated order total is: "
                    + order.TotalDue);

                // Save changes in the object context to the database.
                int changes = context.SaveChanges();

                // Refresh the order to get the computed total from the store.
                context.Refresh(RefreshMode.StoreWins, order);

                Console.WriteLine("The store generated order total is: "
                    + order.TotalDue);
            }
            //</snippetCallCustomMethod>
        }

        #region MrefMethods
        static public void ObjectStateChanges()
        {
            //<snippetObjectStateChanges>
            int productID = 3;
            string productName = "Flat Washer 10";
            string productNumber = "FW-5600";
            Int16 safetyStockLevel = 1000;
            Int16 reorderPoint = 750;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // The ObjectStateManagerChanged event is raised whenever
                // an entity leaves or enters the context.
                context.ObjectStateManager.ObjectStateManagerChanged += (sender, e) =>
                {
                    Console.WriteLine(string.Format(
                    "ObjectStateManager.ObjectStateManagerChanged | Action:{0} Object:{1}"
                    , e.Action
                    , e.Element));
                };

                // When an entity is queried for we get an added event.
                var product =
                        (from p in context.Products
                         where p.ProductID == productID
                         select p).First();

                // Create a new Product.
                Product newProduct = Product.CreateProduct(0,
                    productName, productNumber, false, false, safetyStockLevel, reorderPoint,
                    0, 0, 0, DateTime.Today, Guid.NewGuid(), DateTime.Today);

                // Add the new object to the context.
                // When an entity is added we also get an added event.
                context.Products.AddObject(newProduct);

                // Delete the object from the context.
                //Deleting an entity raises a removed event.
                context.Products.DeleteObject(newProduct);
            }
            //</snippetObjectStateChanges>
        }

        static public void ContextClass()
        {
            Console.WriteLine("Starting method 'ContextClass'");
            //<snippetObjectContext>
            // Create the ObjectContext.
            ObjectContext context =
                new ObjectContext("name=AdventureWorksEntities");

            // Set the DefaultContainerName for the ObjectContext.
            // When DefaultContainerName is set, the Entity Framework only
            // searches for the type in the specified container.
            // Note that if a type is defined only once in the metadata workspace
            // you do not have to set the DefaultContainerName.
            context.DefaultContainerName = "AdventureWorksEntities";

            ObjectSet<Product> query = context.CreateObjectSet<Product>();

            // Iterate through the collection of Products.
            foreach (Product result in query)
                Console.WriteLine($"Product Name: {result.Name}");
            //</snippetObjectContext>
        }

        static public void ContextClass2()
        {
            Console.WriteLine("Starting method 'ContextClass'");
            //<snippetObjectContext2>
            // Create the ObjectContext.
            ObjectContext context =
                new ObjectContext("name=AdventureWorksEntities");

            ObjectSet<Product> query = context.CreateObjectSet<Product>();

            // Iterate through the collection of Products.
            foreach (Product result in query)
                Console.WriteLine($"Product Name: {result.Name}");
            //</snippetObjectContext2>
        }

        static public void ObjectQueryResult_GetEnumerator_Dispose()
        {
            Console.WriteLine("Starting method 'QueryResult'");
            //<snippetQueryResult>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                ObjectSet<Product> query = context.Products;
                ObjectResult<Product> queryResults = null;

                System.Collections.IEnumerator enumerator = null;
                try
                {
                    queryResults = query.Execute(MergeOption.AppendOnly);

                    // Get the enumerator.
                    enumerator = ((System.Collections.IEnumerable)queryResults).GetEnumerator();

                    // Iterate through the query results.
                    while (enumerator.MoveNext())
                    {
                        Product product = (Product)enumerator.Current;
                        Console.WriteLine($"{product.Name}");
                    }
                    // Dispose the enumerator
                    ((IDisposable)enumerator).Dispose();
                }
                finally
                {
                    // Dispose the query results and the enumerator.
                    if (queryResults != null)
                    {
                        queryResults.Dispose();
                    }
                    if (enumerator != null)
                    {
                        ((IDisposable)enumerator).Dispose();
                    }
                }
            }
            //</snippetQueryResult>
        }
        static public void ObjectStateEntry_CurrentValueGetModifiedPropertiesEntity()
        {
            Console.WriteLine("Starting method 'ObjectStateEntry_CurrentValueGetModifiedPropertiesEntity'");
            //<snippetObjectStateEntry_GetModifiedProperties>
            int orderId = 43680;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                var order = (from o in context.SalesOrderHeaders
                             where o.SalesOrderID == orderId
                             select o).First();

                // Get ObjectStateEntry from EntityKey.
                ObjectStateEntry stateEntry =
                    context.ObjectStateManager
                    .GetObjectStateEntry(((IEntityWithKey)order).EntityKey);

                //Get the current value of SalesOrderHeader.PurchaseOrderNumber.
                CurrentValueRecord rec1 = stateEntry.CurrentValues;
                string oldPurchaseOrderNumber =
                    (string)rec1.GetValue(rec1.GetOrdinal("PurchaseOrderNumber"));

                //Change the value.
                order.PurchaseOrderNumber = "12345";
                string newPurchaseOrderNumber =
                    (string)rec1.GetValue(rec1.GetOrdinal("PurchaseOrderNumber"));

                // Get the modified properties.
                IEnumerable<string> modifiedFields = stateEntry.GetModifiedProperties();
                foreach (string s in modifiedFields)
                    Console.WriteLine($"Modified field name: {s}\n Old Value: {oldPurchaseOrderNumber}\n New Value: {newPurchaseOrderNumber}");

                // Get the Entity that is associated with this ObjectStateEntry.
                SalesOrderHeader associatedEntity = (SalesOrderHeader)stateEntry.Entity;
                Console.WriteLine($"Associated Entity's ID: {associatedEntity.SalesOrderID}");
            }
            //</snippetObjectStateEntry_GetModifiedProperties>
        }
        static public void ObjectStateManager_TryGetObjectStateEntry()
        {
            Console.WriteLine("Starting method 'ObjectStateManager_TryGetObjectStateEntry'");
            //<snippetObjectStateManager>
            int orderId = 43680;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                ObjectStateManager objectStateManager = context.ObjectStateManager;
                ObjectStateEntry stateEntry = null;

                var order = (from o in context.SalesOrderHeaders
                             where o.SalesOrderID == orderId
                             select o).First();

                // Attempts to retrieve ObjectStateEntry for the given EntityKey.
                bool isPresent = objectStateManager.TryGetObjectStateEntry(((IEntityWithKey)order).EntityKey, out stateEntry);
                if (isPresent)
                {
                    Console.WriteLine("The entity was found");
                }
            }
            //</snippetObjectStateManager>
        }
        static public void ObjectQuery_GetResultType()
        {
            Console.WriteLine("Starting method 'ObjectQuery_GetResultType'");
            //<snippetGetResultType>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString = @"SELECT VALUE product "
                + "FROM AdventureWorksEntities.Products AS product";
                ObjectQuery<DbDataRecord> query =
                    new ObjectQuery<DbDataRecord>
                        (queryString, context);

                TypeUsage type = query.GetResultType();
                if (type.EdmType is RowType)
                {
                    RowType row = type.EdmType as RowType;
                    foreach (EdmProperty column in row.Properties)
                        Console.WriteLine($"{column.Name}");
                }
            }
            //</snippetGetResultType>
        }
        static public void ObjectQuery_Execute()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Execute'");
            //<snippetObjectQuery_Execute>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                ObjectSet<Product> query = context.Products;

                // Execute the query and get the ObjectResult.
                ObjectResult<Product> queryResult = query.Execute(MergeOption.AppendOnly);
                // Iterate through the collection of Product items.
                foreach (Product result in queryResult)
                    Console.WriteLine($"{result.Name}");
            }
            //</snippetObjectQuery_Execute>
        }
        static public void ObjectQuery_ToTraceStringEsql()
        {
            Console.WriteLine("Starting method 'ObjectQuery_ToTraceStringEsql'");
            //<snippetObjectQuery_ToTraceStringEsql>
            int productID = 900;
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Define the Entity SQL query string.
                string queryString =
                    @"SELECT VALUE product FROM AdventureWorksEntities.Products AS product
                  WHERE product.ProductID = @productID";

                // Define the object query with the query string.
                ObjectQuery<Product> productQuery =
                    new ObjectQuery<Product>(queryString, context, MergeOption.AppendOnly);

                productQuery.Parameters.Add(new ObjectParameter("productID", productID));

                // Write the store commands for the query.
                Console.WriteLine(productQuery.ToTraceString());
            }
            //</snippetObjectQuery_ToTraceStringEsql>
        }
        static public void ObjectQuery_ToTraceStringLinq()
        {
            Console.WriteLine("Starting method 'ObjectQuery_ToTraceStringLinq'");
            //<snippetObjectQuery_ToTraceStringLinq>
            int productID = 900;
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Define an ObjectSet to use with the LINQ query.
                ObjectSet<Product> products = context.Products;

                // Define a LINQ query that returns a selected product.
                var result = from product in products
                             where product.ProductID == productID
                             select product;

                // Cast the inferred type var to an ObjectQuery
                // and then write the store commands for the query.
                Console.WriteLine(((ObjectQuery<Product>)result).ToTraceString());
            }
            //</snippetObjectQuery_ToTraceStringLinq>
        }
        static public void ObjectQuery_ToTraceString()
        {
            Console.WriteLine("Starting method 'ObjectQuery_ToTraceString'");
            //<snippetObjectQuery_ToTraceString>
            int productID = 900;
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Define the object query for the specific product.
                ObjectQuery<Product> productQuery =
                    context.Products.Where("it.ProductID = @productID");
                productQuery.Parameters.Add(new ObjectParameter("productID", productID));

                // Write the store commands for the query.
                Console.WriteLine(productQuery.ToTraceString());
            }
            //</snippetObjectQuery_ToTraceString>
        }

        static public void ObjectQuery_First()
        {
            Console.WriteLine("Starting method 'ObjectQuery_First'");
            //<snippetObjectQuery_First>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE product FROM AdventureWorksEntities.Products AS product";

                ObjectQuery<Product> productQuery1 =
                    new ObjectQuery<Product>(queryString, context, MergeOption.NoTracking);

                // Get the first Product.
                Product productQuery2 = productQuery1.First();

                Console.WriteLine($"Product Name: {productQuery2.Name}");
            }
            //</snippetObjectQuery_First>
        }
        static public void ObjectQuery_Where()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Where'");
            //<snippetObjectQuery_Where>
            int productID = 900;
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE product FROM
                        AdventureWorksEntities.Products AS product";

                ObjectQuery<Product> productQuery1 =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                ObjectQuery<Product> productQuery2 =
                    productQuery1.Where("it.ProductID = @productID");

                productQuery2.Parameters.Add(new ObjectParameter("productID", productID));

                // Iterate through the collection of Product items.
                foreach (Product result in productQuery2)
                {
                    Console.WriteLine($"Product Name: {result.Name}; Product ID: {result.ProductID}");
                }
            }
            //</snippetObjectQuery_Where>
        }
        static public void ObjectQuery_Top()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Top'");
            //<snippetObjectQuery_Top>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE product FROM AdventureWorksEntities.Products AS product";

                ObjectQuery<Product> productQuery1 =
                    new ObjectQuery<Product>(queryString, context, MergeOption.NoTracking);

                ObjectQuery<Product> productQuery2 = productQuery1.Top("2");

                // Iterate through the collection of Product items.
                foreach (Product result in productQuery2)
                    Console.WriteLine($"{result.Name}");
            }
            //</snippetObjectQuery_Top>
        }
        static public void ObjectQuery_SelectValue()
        {
            Console.WriteLine("Starting method 'ObjectQuery_SelectValue'");
            //<snippetObjectQuery_SelectValue>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE product FROM
                        AdventureWorksEntities.Products AS product";

                ObjectQuery<Product> productQuery1 =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                ObjectQuery<Int32> productQuery2 =
                    productQuery1.SelectValue<Int32>("it.ProductID");

                foreach (Int32 result in productQuery2)
                {
                    Console.WriteLine($"{result}");
                }
            }
            //</snippetObjectQuery_SelectValue>
        }

        static public void ObjectQuery_Select()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Select'");
            //<snippetObjectQuery_Select>
            int productID = 900;
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString = @"SELECT VALUE product FROM
                    AdventureWorksEntities.Products AS product
                    WHERE product.ProductID > @productID";

                ObjectQuery<Product> productQuery1 =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                productQuery1.Parameters.Add(new ObjectParameter("productID", productID));

                ObjectQuery<DbDataRecord> productQuery2 =
                    productQuery1.Select("it.ProductID");

                foreach (DbDataRecord result in productQuery2)
                {
                    Console.WriteLine($"{result["ProductID"]}");
                }
            }
            //</snippetObjectQuery_Select>
        }
        static public void ObjectQuery_OrderBy()
        {
            Console.WriteLine("Starting method 'ObjectQuery_OrderBy'");
            //<snippetObjectQuery_OrderBy>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString = @"SELECT VALUE product
                    FROM AdventureWorksEntities.Products AS product";

                ObjectQuery<Product> productQuery1 =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                ObjectQuery<Product> productQuery2 =
                    productQuery1.OrderBy("it.ProductID");

                // Iterate through the collection of Product items.
                foreach (Product result in productQuery2)
                {
                    Console.WriteLine($"{result.ProductID}");
                }
            }
            //</snippetObjectQuery_OrderBy>
        }
        static public void ObjectQuery_Intersect()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Intersect'");
            //<snippetObjectQuery_Intersect>
            int productID1 = 900;
            int productID2 = 950;
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString = @"SELECT VALUE product
                    FROM AdventureWorksEntities.Products
                    AS product WHERE product.ProductID > @productID1";

                ObjectQuery<Product> productQuery =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                string queryString2 = @"SELECT VALUE product
                    FROM AdventureWorksEntities.Products
                    AS product WHERE product.ProductID > @productID2";

                ObjectQuery<Product> productQuery2 =
                    new ObjectQuery<Product>(queryString2,
                        context, MergeOption.NoTracking);

                ObjectQuery<Product> productQuery3 =
                    productQuery.Intersect(productQuery2);

                productQuery3.Parameters.Add(new ObjectParameter("productID1", productID1));
                productQuery3.Parameters.Add(new ObjectParameter("productID2", productID2));

                Console.WriteLine("Result of Intersect");
                Console.WriteLine("------------------");

                // Iterate through the collection of Product items
                // after the Intersect method was called.
                foreach (Product result in productQuery3)
                {
                    Console.WriteLine($"Product Name: {result.ProductID}");
                }
            }
            //</snippetObjectQuery_Intersect>
        }
        static public void Projection_SkipLimit()
        {
            Console.WriteLine("Starting method 'Projection_SkipLimit'");
            //<snippetProjection_SkipLimit>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Define the parameters used to define the "page" of returned data.
                int skipValue = 3;
                int limitValue = 5;

                // Define a query that returns a "page" or the full
                // Product data using the Skip and Top methods.
                // When Top() follows Skip(), it acts like the LIMIT statement.
                ObjectQuery<Product> query = context.Products
                    .Skip("it.ListPrice", "@skip",
                            new ObjectParameter("skip", skipValue))
                    .Top("@limit", new ObjectParameter("limit", limitValue));

                // Iterate through the page of Product items.
                foreach (Product result in query)
                    Console.WriteLine($"ID: {result.ProductID}; Name: {result.Name}");
            }
            //</snippetProjection_SkipLimit>
        }
        static public void Projection_GroupBy()
        {
            Console.WriteLine("Starting method 'Projection_GroupBy'");
            //<snippetProjection_GroupBy>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                //<snippetComplexQueryBuilderMethod>
                // Define the query with a GROUP BY clause that returns
                // a set of nested LastName records grouped by first letter.
                ObjectQuery<DbDataRecord> query =
                    context.Contacts
                    .GroupBy("SUBSTRING(it.LastName, 1, 1) AS ln", "ln")
                    .Select("it.ln AS ln, (SELECT c1.LastName " +
                    "FROM AdventureWorksEntities.Contacts AS c1 " +
                    "WHERE SubString(c1.LastName, 1, 1) = it.ln) AS CONTACT")
                    .OrderBy("it.ln");
                //</snippetComplexQueryBuilderMethod>

                // Execute the query and walk through the nested records.
                foreach (DbDataRecord rec in
                    query.Execute(MergeOption.AppendOnly))
                {
                    Console.WriteLine($"Last names that start with the letter '{rec[0]}':");
                    List<DbDataRecord> list = rec[1] as List<DbDataRecord>;
                    foreach (DbDataRecord r in list)
                    {
                        for (int i = 0; i < r.FieldCount; i++)
                        {
                            Console.WriteLine($"   {r[i]} ");
                        }
                    }
                }
            }
            //</snippetProjection_GroupBy>
        }
        static public void Projection_Union()
        {
            Console.WriteLine("Starting method 'Projection_Union'");
            //<snippetProjection_Union>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                ObjectQuery<DbDataRecord> query =
                    context.Products.Select("it.Name, it.ProductID As Pid, it.ListPrice")
                    .Where("it.Name LIKE 'A%'").Union(context.Products
                    .Select("it.Name, it.ProductID As Pid, it.ListPrice")
                    .Where("it.Name LIKE 'B%'")).Select("it.Name, it.ListPrice").OrderBy("it.Name");

                foreach (DbDataRecord rec in query)
                {
                    Console.WriteLine($"Name: {rec[0]}; ListPrice: {rec[1]}");
                }
            }
            //</snippetProjection_Union>
        }
	static public void Projection_Union_LINQ()
        {
            //<snippetProjectionUnionLINQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = (from a in context.Products
                         where a.Name.StartsWith("A")
                         select new { a.Name, pid = a.ProductID, a.ListPrice })
                        .Union
                        (from b in context.Products
                         where b.Name.StartsWith("B")
                         select new { b.Name, pid = b.ProductID, b.ListPrice })
                        .Select(c => new { c.Name, c.ListPrice }).OrderBy(d => d.Name);

                foreach (var result in query)
                {
                    Console.WriteLine(result.Name);
                }
            }
            //</snippetProjectionUnionLINQ>
        }
        static public void ObjectQuery_Where2()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Where2'");
            //<snippetObjectQuery_Where2>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Define the product ID for filtering.
                int productId = 900;

                //<snippetObjectQuery_WhereOnly>
                // Return Product objects with the specified ID.
                ObjectQuery<Product> query =
                    context.Products
                    .Where("it.ProductID = @product",
                    new ObjectParameter("product", productId));
                //</snippetObjectQuery_WhereOnly>

                // Iterate through the collection of Product items.
                foreach (Product result in query)
                {
                    Console.WriteLine($"Product Name: {result.Name}; Product ID: {result.ProductID}");
                }
            }
            //</snippetObjectQuery_Where2>
        }
        static public void ObjectQuery_GroupBy()
        {
            Console.WriteLine("Starting method 'ObjectQuery_GroupBy'");
            //<snippetObjectQuery_GroupBy>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString = @"SELECT VALUE product
                    FROM AdventureWorksEntities.Products AS product";

                ObjectQuery<Product> productQuery =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                ObjectQuery<DbDataRecord> productQuery2 =
                    productQuery.GroupBy("it.name AS pn",
                    "Sqlserver.COUNT(it.Name) as count, pn");

                // Iterate through the collection of Products
                // after the GroupBy method was called.
                foreach (DbDataRecord result in productQuery2)
                {
                    Console.WriteLine($"Name: {result["pn"]}; Count: {result["count"]}");
                }
            }
        }
        //</snippetObjectQuery_GroupBy>
        static public void ObjectQuery_Except()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Except'");
            //<snippetObjectQuery_Except>
            int productID = 900;
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString = @"SELECT VALUE product
                    FROM AdventureWorksEntities.Products AS product";

                ObjectQuery<Product> productQuery =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                string queryString2 = @"SELECT VALUE product
                    FROM AdventureWorksEntities.Products
                    AS product WHERE product.ProductID < @productID";

                ObjectQuery<Product> productQuery2 =
                    new ObjectQuery<Product>(queryString2,
                        context, MergeOption.NoTracking);

                productQuery2.Parameters.Add(new ObjectParameter("productID", productID));

                ObjectQuery<Product> productQuery3 =
                    productQuery.Except(productQuery2);

                Console.WriteLine("Result of Except");
                Console.WriteLine("------------------");

                // Iterate through the collection of Product items
                // after the Except method was called.
                foreach (Product result in productQuery3)
                    Console.WriteLine($"Product Name: {result.ProductID}");
            }
            //</snippetObjectQuery_Except>
        }
        static public void ObjectQuery_Distinct_UnionAll()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Distinct_UnionAll'");
            //<snippetObjectQuery_Distinct_UnionAll>
            int productID = 100;
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE product FROM AdventureWorksEntities.Products
                        AS product WHERE product.ProductID < @productID";

                ObjectQuery<Product> productQuery =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                ObjectQuery<Product> productQuery2 =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                ObjectQuery<Product> productQuery3 =
                    productQuery.UnionAll(productQuery2);

                productQuery3.Parameters.Add(new ObjectParameter("productID", productID));

                Console.WriteLine("Result of UnionAll");
                Console.WriteLine("------------------");

                // Iterate through the collection of Product items,
                // after the UnionAll method was called on two queries.
                foreach (Product result in productQuery3)
                {
                    Console.WriteLine($"Product Name: {result.ProductID}");
                }
                ObjectQuery<Product> productQuery4 = productQuery3.Distinct();

                Console.WriteLine("\nResult of Distinct");
                Console.WriteLine("------------------");

                // Iterate through the collection of Product items.
                // after the Distinct method was called on a query.
                foreach (Product result in productQuery4)
                    Console.WriteLine($"Product Name: {result.ProductID}");
            }
            //</snippetObjectQuery_Distinct_UnionAll>
        }
        static public void ObjectQuery_Distinct_Union()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Distinct_Union'");
            //<snippetObjectQuery_Distinct_Union>
            int productID = 100;
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString = @"SELECT VALUE product
                    FROM AdventureWorksEntities.Products AS product
                    WHERE product.ProductID < @productID";

                ObjectQuery<Product> productQuery =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                ObjectQuery<Product> productQuery2 =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                ObjectQuery<Product> productQuery3 =
                    productQuery.Union(productQuery2);

                productQuery3.Parameters.Add(new ObjectParameter("productID", productID));

                Console.WriteLine("Result of Union");
                Console.WriteLine("------------------");

                // Iterate through the collection of Product items,
                // after the Union method was called on two queries.
                foreach (Product result in productQuery3)
                {
                    Console.WriteLine($"Product Name: {result.ProductID}");
                }
            }
            //</snippetObjectQuery_Distinct_Union>
        }

        static public void LINQQuery_Parameters()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Parameters'");
            //<snippetLINQQuery_Parameters>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string FirstName = "Frances";
                string LastName = "Adams";

                var contactQuery = from contact in context.Contacts
                                   where contact.LastName == LastName && contact.FirstName == FirstName
                                   select contact;

                // Iterate through the results of the parameterized query.
                foreach (var result in contactQuery)
                {
                    Console.WriteLine($"{result.FirstName} {result.LastName} ");
                }
            }
            //</snippetLINQQuery_Parameters>
        }
        static public void ObjectQuery_Parameters()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Parameters'");
            //<snippetObjectQuery_Parameters>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact FROM AdventureWorksEntities.Contacts
                    AS contact WHERE contact.LastName = @ln
                    AND contact.FirstName = @fn";

                ObjectQuery<Contact> contactQuery =
                    new ObjectQuery<Contact>(queryString, context);

                // Add parameters to the collection.
                contactQuery.Parameters.Add(new ObjectParameter("ln", "Adams"));
                contactQuery.Parameters.Add(new ObjectParameter("fn", "Frances"));

                ObjectParameterCollection objectParameterCollection =
                    contactQuery.Parameters;

                // Iterate through the ObjectParameterCollection.
                foreach (ObjectParameter result in objectParameterCollection)
                {
                    Console.WriteLine($"{result.Name} {result.Value} {result.ParameterType}");
                }
            }
            //</snippetObjectQuery_Parameters>
        }
        static public void ObjectQuery_Name()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Name'");
            //<snippetObjectQuery_Name>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact
                    FROM AdventureWorksEntities.Contacts AS contact";

                ObjectQuery<Contact> contactQuery =
                    new ObjectQuery<Contact>(queryString,
                        context, MergeOption.NoTracking);

                // Write ObjectQuery's name.
                Console.WriteLine($"The ObjectQuery's name is: {contactQuery.Name}");
            }
            //</snippetObjectQuery_Name>
        }

        static public void ObjectQuery_ScalarTypeException()
        {
            Console.WriteLine("Starting method 'ObjectQuery_ScalarTypeException'");
            Console.WriteLine("This method should generate an ArgumentException.");
            //<snippetObjectQuery_ScalarTypeException>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                try
                {
                    //<snippetObjectQuery_ScalarTypeExceptionShort>
                    // Define a query projection that returns
                    // a collection with a single scalar result.
                    ObjectQuery<Int32> scalarQuery =
                        new ObjectQuery<Int32>("100", context);

                    // Calling an extension method that requires a collection
                    // will result in an exception.
                    bool hasValues = scalarQuery.Any();
                    //</snippetObjectQuery_ScalarTypeExceptionShort>
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetObjectQuery_ScalarTypeException>
        }
        static public void ObjectQuery_Context()
        {
            Console.WriteLine("Starting method 'ObjectQuery_Context'");
            //<snippetObjectQuery_Context>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact FROM
                    AdventureWorksEntities.Contacts AS contact";

                ObjectQuery<Contact> contactQuery =
                    new ObjectQuery<Contact>(queryString,
                        context, MergeOption.NoTracking);

                // Get ObjectContext from ObjectQuery.
                ObjectContext objectContext = contactQuery.Context;
                Console.WriteLine($"Connection string {objectContext.Connection.ConnectionString}");
            }
            //</snippetObjectQuery_Context>
        }
        static public void ObjectQueryConstructors()
        {
            Console.WriteLine("Starting method 'ObjectQueryConstructors'");
            //<snippetObjectQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Call the constructor with a query for products and the ObjectContext.
                ObjectQuery<Product> productQuery1 =
                    new ObjectQuery<Product>("Products", context);

                foreach (Product result in productQuery1)
                    Console.WriteLine($"Product Name: {result.Name}");

                string queryString =
                    @"SELECT VALUE product FROM AdventureWorksEntities.Products AS product";

                // Call the constructor with the specified query and the ObjectContext.
                ObjectQuery<Product> productQuery2 =
                    new ObjectQuery<Product>(queryString, context);

                foreach (Product result in productQuery2)
                    Console.WriteLine($"Product Name: {result.Name}");

                // Call the constructor with the specified query, the ObjectContext,
                // and the NoTracking merge option.
                ObjectQuery<Product> productQuery3 =
                    new ObjectQuery<Product>(queryString,
                        context, MergeOption.NoTracking);

                foreach (Product result in productQuery3)
                    Console.WriteLine($"Product Name: {result.Name}");
            }
            //</snippetObjectQuery>
        }
        static public void ObjectParameterCollectionClass_Remove()
        {
            Console.WriteLine("Starting method 'ObjectParameterCollectionClass_Remove'");
            //<snippetObjectParameterCollection_Remove>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact FROM AdventureWorksEntities.Contacts
                    AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn";

                ObjectQuery<Contact> contactQuery =
                    new ObjectQuery<Contact>(queryString, context);

                // Add parameters to the ObjectQuery's Parameters collection.
                contactQuery.Parameters.Add(new ObjectParameter("ln", "Adams"));
                contactQuery.Parameters.Add(new ObjectParameter("fn", "Frances"));

                ObjectParameterCollection objectParameterCollection =
                    contactQuery.Parameters;
                Console.WriteLine($"Count before Remove is called: {objectParameterCollection.Count}");

                ObjectParameter objectParameter = objectParameterCollection["ln"];

                // Remove the specified parameter from the collection.
                objectParameterCollection.Remove(objectParameter);
                Console.WriteLine($"Count after Remove is called: {objectParameterCollection.Count}");
            }
            //</snippetObjectParameterCollection_Remove>
        }
        static public void ObjectParameterCollectionClass_CopyTo()
        {
            Console.WriteLine("Starting method 'ObjectParameterCollectionClass_CopyTo'");
            //<snippetObjectParameterCollection_CopyTo>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact FROM AdventureWorksEntities.Contacts
                    AS contact WHERE contact.LastName = @ln
                    AND contact.FirstName = @fn";

                ObjectQuery<Contact> contactQuery =
                    new ObjectQuery<Contact>(queryString, context);

                // Add parameters to the collection.
                contactQuery.Parameters.Add(new ObjectParameter("ln", "Adams"));
                contactQuery.Parameters.Add(new ObjectParameter("fn", "Frances"));

                ObjectParameterCollection objectParameterCollection =
                    contactQuery.Parameters;
                ObjectParameter[] objectParameterArray =
                    new ObjectParameter[objectParameterCollection.Count];

                objectParameterCollection.CopyTo(objectParameterArray, 0);

                // Iterate through the ObjectParameter array.
                for (int i = 0; i < objectParameterArray.Length; i++)
                {
                    Console.WriteLine($"Name: {objectParameterArray[i].Name} Type: {objectParameterArray[i].ParameterType} Value: {objectParameterArray[i].Value}");
                }
            }
            //</snippetObjectParameterCollection_CopyTo>
        }
        static public void ObjectParameterCollectionClass_Count_Add_Indexer()
        {
            Console.WriteLine("Starting method 'ObjectParameterCollectionClass_Count_Add_Indexer'");
            //<snippetObjectParameterCollection_Count_Add_Indexer>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact FROM AdventureWorksEntities.Contacts
                    AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn";

                ObjectQuery<Contact> contactQuery =
                    new ObjectQuery<Contact>(queryString, context);

                // Add parameters to the collection.
                contactQuery.Parameters.Add(new ObjectParameter("ln", "Adams"));
                contactQuery.Parameters.Add(new ObjectParameter("fn", "Frances"));

                ObjectParameterCollection objectParameterCollection =
                    contactQuery.Parameters;

                Console.WriteLine($"Count is {objectParameterCollection.Count}.");

                // Iterate through the ObjectParameterCollection collection.
                foreach (ObjectParameter result in objectParameterCollection)
                {
                    Console.WriteLine($"{result.Name} {result.Value} {result.ParameterType}");
                }
            }
            //</snippetObjectParameterCollection_Count_Add_Indexer>
        }
        static public void ObjectParameterCollectionClass_ContainsWithParamArg()
        {
            Console.WriteLine("Starting method 'ObjectParameterCollectionClass_ContainsWithParamArg'");
            //<snippetObjectParameterCollection_ParamArg>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact FROM AdventureWorksEntities.Contacts
                    AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn";

                ObjectQuery<Contact> contactQuery =
                    new ObjectQuery<Contact>(queryString, context);

                // Create a collection of parameters.
                ObjectParameter param = new ObjectParameter("ln", "Adams");
                contactQuery.Parameters.Add(param);
                contactQuery.Parameters.Add(new ObjectParameter("fn", "Frances"));

                ObjectParameterCollection objectParameterCollection =
                    contactQuery.Parameters;

                // Check whether the specifed parameter is in the collection.
                if (objectParameterCollection.Contains(param))
                    Console.WriteLine("parameter is here");
                else
                    Console.WriteLine("parameter is not here");
            }
            //</snippetObjectParameterCollection_ParamArg>
        }
        static public void ObjectParameterCollectionClass_ContainsWithStringArg()
        {
            Console.WriteLine("Starting method 'ObjectParameterCollectionClass_ContainsWithStringArg'");
            //<snippetObjectParameterCollection_StringArg>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact FROM AdventureWorksEntities.Contacts
                    AS contact WHERE contact.LastName = @ln AND contact.FirstName = @fn";

                ObjectQuery<Contact> contactQuery =
                    new ObjectQuery<Contact>(queryString, context);

                // Add parameters to the collection.
                contactQuery.Parameters.Add(new ObjectParameter("ln", "Adams"));
                contactQuery.Parameters.Add(new ObjectParameter("fn", "Frances"));

                ObjectParameterCollection objectParameterCollection =
                    contactQuery.Parameters;

                if (objectParameterCollection.Contains("ln"))
                    Console.WriteLine("ln is here");
                else
                    Console.WriteLine("ln is not here");
            }
            //</snippetObjectParameterCollection_StringArg>
        }
        static public void ObjectParameterClass_Value_Name_Type()
        {
            Console.WriteLine("Starting method 'ObjectParameterClass_Value_Name_Type'");
            //<snippetObjectParameter_Value_Name_Type>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                ObjectParameter param = new ObjectParameter("fn", typeof(System.String));
                param.Value = "Frances";

                Console.WriteLine("Param Name: {0}, Param Value: {1} Param Type: {2}",
                                    param.Name, param.Value, param.ParameterType);
            }
            //</snippetObjectParameter_Value_Name_Type>
        }
        static public void ObjectParameterClass()
        {
            Console.WriteLine("Starting method 'ObjectParameterClass'");
            //<snippetObjectParameter>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact FROM AdventureWorksEntities.Contacts
                        AS contact WHERE contact.FirstName = @fn";

                ObjectParameter param = new ObjectParameter("fn", "Frances");

                ObjectQuery<Contact> contactQuery =
                    context.CreateQuery<Contact>(queryString, param);

                // Iterate through the collection of Contact items.
                foreach (Contact result in contactQuery)
                    Console.WriteLine("First Name: {0}, Last Name: {1}",
                    result.FirstName, result.LastName);
            }
            //</snippetObjectParameter>
        }
        static public void EntityKeyClass_TryGetObjectByKey()
        {
            Console.WriteLine("Starting method 'EntityKeyClass_TryGetObjectByKey'");
            //<snippetEntityKeyClass_TryGetObjectByKey>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                Object entity = null;
                IEnumerable<KeyValuePair<string, object>> entityKeyValues =
                    new KeyValuePair<string, object>[] {
                        new KeyValuePair<string, object>("SalesOrderID", 43680) };

                // Create the  key for a specific SalesOrderHeader object.
                EntityKey key = new EntityKey("AdventureWorksEntities.SalesOrderHeaders", entityKeyValues);

                // Get the object from the context or the persisted store by its key.
                if (context.TryGetObjectByKey(key, out entity))
                {
                    Console.WriteLine("The requested " + entity.GetType().FullName +
                        " object was found");
                }
                else
                {
                    Console.WriteLine("An object with this key " +
                        "could not be found.");
                }
            }
            //</snippetEntityKeyClass_TryGetObjectByKey>
        }
        static public void EntityKeyClass_GetObjectByKey_CreateKey()
        {
            Console.WriteLine("Starting method 'EntityKeyClass_GetObjectByKey_CreateKey'");
            //<snippetEntityKeyClass_GetObjectByKey>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                try
                {
                    // Define the entity key values.
                    IEnumerable<KeyValuePair<string, object>> entityKeyValues =
                        new KeyValuePair<string, object>[] {
                        new KeyValuePair<string, object>("SalesOrderID", 43680) };

                    // Create the  key for a specific SalesOrderHeader object.
                    EntityKey key = new EntityKey("AdventureWorksEntities.SalesOrderHeaders", entityKeyValues);

                    // Get the object from the context or the persisted store by its key.
                    SalesOrderHeader order =
                        (SalesOrderHeader)context.GetObjectByKey(key);

                    Console.WriteLine($"SalesOrderID: {order.SalesOrderID} Order Number: {order.SalesOrderNumber}");
                }
                catch (ObjectNotFoundException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetEntityKeyClass_GetObjectByKey>
        }
        static public void CreateQuery()
        {
            Console.WriteLine("Starting method 'CreateQuery'");
            //<snippetCreateQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString =
                    @"SELECT VALUE contact FROM AdventureWorksEntities.Contacts
                        AS contact WHERE contact.FirstName = @fn";

                ObjectQuery<Contact> contactQuery =
                    context.CreateQuery<Contact>(queryString,
                        new ObjectParameter("fn", "Frances"));

                // Iterate through the collection of Contact items.
                foreach (Contact result in contactQuery)
                    Console.WriteLine("First Name: {0}, Last Name: {1}",
                    result.FirstName, result.LastName);
            }
            //</snippetCreateQuery>
        }
        static public void ObjectContextAddDeleteSave_ObjectStateEntryState()
        {
            Console.WriteLine("Starting method 'ObjectContextAddDeleteSave_ObjectStateEntryState'");
            //<snippetObjectStateEntry>
            // Specify the order to update.
            int orderId = 43680;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                try
                {
                    var order = (from o in context.SalesOrderHeaders
                                 where o.SalesOrderID == orderId
                                 select o).First();

                    // Change the status of an existing order.
                    order.Status = 1;

                    // Delete the first item in the order.
                    context.DeleteObject(order.SalesOrderDetails.First());

                    // Create a new SalesOrderDetail object.
                    // You can use the static CreateObjectName method (the Entity Framework
                    // adds this method to the generated entity types) instead of the new operator:
                    // SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0,
                    //                                         Guid.NewGuid(), DateTime.Today));
                    SalesOrderDetail detail = new SalesOrderDetail
                    {
                        SalesOrderID = 0,
                        SalesOrderDetailID = 0,
                        OrderQty = 2,
                        ProductID = 750,
                        SpecialOfferID = 1,
                        UnitPrice = (decimal)2171.2942,
                        UnitPriceDiscount = 0,
                        LineTotal = 0,
                        rowguid = Guid.NewGuid(),
                        ModifiedDate = DateTime.Now
                    };
                    order.SalesOrderDetails.Add(detail);

                    // Get the ObjectStateEntry for the order.
                    ObjectStateEntry stateEntry =
                        context.ObjectStateManager
                        .GetObjectStateEntry(order);
                    Console.WriteLine($"State before SaveChanges() is called: {stateEntry.State.ToString()}");

                    // Save changes in the object context to the database.
                    int changes = context.SaveChanges();

                    Console.WriteLine($"State after SaveChanges() is called: {stateEntry.State.ToString()}");

                    Console.WriteLine(changes.ToString() + " changes saved!");
                    Console.WriteLine("Updated item for order ID: "
                        + order.SalesOrderID.ToString());

                    // Iterate through the collection of SalesOrderDetail items.
                    foreach (SalesOrderDetail item in order.SalesOrderDetails)
                    {
                        Console.WriteLine("Item ID: "
                            + item.SalesOrderDetailID.ToString() + "  Product: "
                            + item.ProductID.ToString() + "  Quantity: "
                            + item.OrderQty.ToString());
                    }
                }
                catch (UpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetObjectStateEntry>
        }
        static public void EntityObjectRelManager_IRelatedEnd()
        {
            Console.WriteLine("Starting method 'EntityObjectRelManager_IRelatedEnd'");
            //<snippetIRelatedEnd>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                Contact contact = new Contact();

                // Create a new SalesOrderHeader.
                SalesOrderHeader newSalesOrder1 = new SalesOrderHeader();
                // Add SalesOrderHeader to the Contact.
                contact.SalesOrderHeaders.Add(newSalesOrder1);

                // Create another SalesOrderHeader.
                SalesOrderHeader newSalesOrder2 = new SalesOrderHeader();
                // Add SalesOrderHeader to the Contact.
                contact.SalesOrderHeaders.Add(newSalesOrder2);

                // Get all related ends
                IEnumerable<IRelatedEnd> relEnds =
                    ((IEntityWithRelationships)contact).RelationshipManager
                    .GetAllRelatedEnds();

                foreach (IRelatedEnd relEnd in relEnds)
                {
                    Console.WriteLine($"Relationship Name: {relEnd.RelationshipName}");
                    Console.WriteLine($"Source Role Name: {relEnd.SourceRoleName}");
                    Console.WriteLine($"Target Role Name: {relEnd.TargetRoleName}");
                }
            }
            //</snippetIRelatedEnd>
        }
        static public void EntityCollectionCountContainsAddRemove_IRelatedEnd_Add()
        {
            Console.WriteLine("Starting method 'EntityCollectionCountContainsAddRemove_IRelatedEnd_Add'");
            //<snippetIRelatedEnd_Add>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                Contact contact = new Contact();

                // Create a new SalesOrderHeader.
                SalesOrderHeader newSalesOrder1 = new SalesOrderHeader();
                // Add SalesOrderHeader to the Contact.
                contact.SalesOrderHeaders.Add(newSalesOrder1);

                // Create another SalesOrderHeader.
                SalesOrderHeader newSalesOrder2 = new SalesOrderHeader();
                // Add SalesOrderHeader to the Contact.
                contact.SalesOrderHeaders.Add(newSalesOrder2);

                // Get all related ends
                IEnumerable<IRelatedEnd> relEnds =
                    ((IEntityWithRelationships)contact)
                    .RelationshipManager.GetAllRelatedEnds();

                foreach (IRelatedEnd relEnd in relEnds)
                {
                    // Get Entity Collection from related end
                    EntityCollection<SalesOrderHeader> entityCollection =
                        (EntityCollection<SalesOrderHeader>)relEnd;

                    Console.WriteLine($"EntityCollection count: {entityCollection.Count}");
                    // Remove the first entity object.
                    entityCollection.Remove(newSalesOrder1);

                    bool contains = entityCollection.Contains(newSalesOrder1);

                    // Write the number of items after one entity has been removed
                    Console.WriteLine($"EntityCollection count after one entity has been removed: {entityCollection.Count}");

                    if (contains == false)
                        Console.WriteLine("The removed entity is not in the collection any more.");

                    //Use IRelatedEnd to add the entity back.
                    relEnd.Add(newSalesOrder1);
                    Console.WriteLine($"EntityCollection count after an entity has been added again: {entityCollection.Count}");
                }
            }
            //</snippetIRelatedEnd_Add>
        }
        public static void Projection_Navigation()
        {
            Console.WriteLine("Starting method 'Projection_Navigation'");
            //<snippetProjection_Navigation>
            string lastName = "Zhou";
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                //<snippetProjection_NavigationQuery>
                // Define a query that returns a nested
                // DbDataRecord for the projection.
                ObjectQuery<DbDataRecord> query =
                    context.Contacts.Select("it.FirstName, "
                        + "it.LastName, it.SalesOrderHeaders")
                    .Where("it.LastName = @ln", new ObjectParameter("ln", lastName));
                //</snippetProjection_NavigationQuery>

                foreach (DbDataRecord rec in
                    query.Execute(MergeOption.AppendOnly))
                {

                    // Display contact's first name.
                    Console.WriteLine($"First Name {rec[0]}: ");
                    List<SalesOrderHeader> list = rec[2]
                        as List<SalesOrderHeader>;
                    // Display SalesOrderHeader information
                    // associated with the contact.
                    foreach (SalesOrderHeader soh in list)
                    {
                        Console.WriteLine("   Order ID: {0}, " +
                            "Order date: {1}, Total Due: {2}",
                            soh.SalesOrderID, soh.OrderDate, soh.TotalDue);
                    }
                }
            }
            //</snippetProjection_Navigation>
        }
        #endregion

        #region ConceptualMethods

        public static void CallEnlistTransaction()
        {
            Console.WriteLine("Starting method 'EnlistTransaction'");
            TransactionSample.EnlistTransaction();
        }

        public static void SerializeToXml()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectQuery<Contact> query = context.Contacts.Include("SalesOrderHeaders.SalesOrderDetails");
                StringWriter writer = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(typeof(SalesOrderHeader));

                // Return the first 5 orders.
                EntityCollection<SalesOrderHeader> orders =
                    context.Contacts.First().SalesOrderHeaders;

                foreach (SalesOrderHeader order in orders)
                {
                    serializer.Serialize(writer, order);
                    writer.WriteLine();
                }
                Console.WriteLine(writer.ToString());
            }
        }

        public static Boolean CleanupOrders()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectQuery<Contact> query = context.Contacts.Include("SalesOrderHeaders.SalesOrderDetails");

                SalesOrderHeader order = query.First().SalesOrderHeaders.First();

                DetachOrders(context, order);

                if (order.EntityState != EntityState.Detached)
                {
                    Console.WriteLine("Detach failed");
                    return false;
                }
                return true;
            }
        }

        //<snippetDetachObjects>
        // This method is called to detach SalesOrderHeader objects and
        // related SalesOrderDetail objects from the supplied object
        // context when no longer needed by the application.
        // Once detached, the resources can be garbage collected.
        private static void DetachOrders(ObjectContext context,
            SalesOrderHeader order)
        {
            try
            {
                // Detach each item from the collection.
                while (order.SalesOrderDetails.Count > 0)
                {
                    //<snippetDetachOnly>
                    // Detach the first SalesOrderDetail in the collection.
                    context.Detach(order.SalesOrderDetails.First());
                    //</snippetDetachOnly>
                }

                // Detach the order.
                context.Detach(order);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        //</snippetDetachObjects>

        public static void ObjectContextProxy()
        {

            Console.WriteLine("Starting method 'ObjectContextProxy'");
            //<snippetObjectContextProxy>

            // Create an instance of the proxy class that returns an object context.
            AdventureWorksProxy context = new AdventureWorksProxy();
            // Get the first order from the context.
            SalesOrderHeader order =
                context.Context.SalesOrderHeaders.First();

            // Add some text that we want to catch before saving changes.
            order.Comment = "some text";

            try
            {
                // Save changes using the proxy class.
                int changes = context.Context.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                // Handle the exception returned by the proxy class
                // validation if a problem string is found.
                Console.WriteLine(ex.ToString());
            }

            //</snippetObjectContextProxy>
        }
        public static void FilterQueryLinq()
        {
            Console.WriteLine("Starting method 'FilterQueryLinq'");
            //<snippetFilterQueryLinq>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // Specify the order amount.
                int orderCost = 2500;

                // Define a LINQ query that returns only online orders
                // more than the specified amount.
                var onlineOrders =
                    from order in context.SalesOrderHeaders
                    where order.OnlineOrderFlag == true &&
                    order.TotalDue > orderCost
                    select order;

                // Print order information.
                foreach (var onlineOrder in onlineOrders)
                {
                    Console.WriteLine($"Order ID: {onlineOrder.SalesOrderID} Order date: "
                        + "{onlineOrder.OrderDate:d} Order number: {onlineOrder.SalesOrderNumber}");
                }
            }
            //</snippetFilterQueryLinq>
        }
        public static void FilterQueryEsql()
        {
            Console.WriteLine("Starting method 'FilterQueryEsql'");
            //<snippetFilterQueryEsql>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // Specify the order amount.
                decimal orderCost = 2500;

                // Specify the Entity SQL query that returns only online orders
                // more than the specified amount.
                string queryString = @"SELECT VALUE o FROM AdventureWorksEntities.SalesOrderHeaders AS o
                    WHERE o.OnlineOrderFlag = TRUE AND o.TotalDue > @ordercost";

                // Define an ObjectQuery and pass the maxOrderCost parameter.
                ObjectQuery<SalesOrderHeader> onlineOrders =
                    new ObjectQuery<SalesOrderHeader>(queryString, context);
                onlineOrders.Parameters.Add(
                    new ObjectParameter("ordercost", orderCost));

                // Print order information.
                foreach (var onlineOrder in onlineOrders)
                {
                    Console.WriteLine($"Order ID: {onlineOrder.SalesOrderID} Order date: "
                        + "{onlineOrder.OrderDate:d} Order number: {onlineOrder.SalesOrderNumber}");
                }
            }
            //</snippetFilterQueryEsql>
        }
        public static void FilterQuery()
        {
            Console.WriteLine("Starting method 'FilterQuery'");
            //<snippetFilterQuery>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // Specify the order amount.
                int orderCost = 2500;

                // Define an ObjectQuery that returns only online orders
                // more than the specified amount.
                ObjectQuery<SalesOrderHeader> onlineOrders =
                    context.SalesOrderHeaders
                    .Where("it.OnlineOrderFlag = TRUE AND it.TotalDue > @ordercost",
                    new ObjectParameter("ordercost", orderCost));

                // Print order information.
                foreach (var onlineOrder in onlineOrders)
                {
                    Console.WriteLine($"Order ID: {onlineOrder.SalesOrderID} Order date: "
                       + "{onlineOrder.OrderDate:d} Order number: {onlineOrder.SalesOrderNumber}");
                }
            }
            //</snippetFilterQuery>
        }
        public static void SortQueryLinq()
        {
            Console.WriteLine("Starting method 'SortQueryLinq'");
            //<snippetSortQueryLinq>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Define a query that returns a list
                // of Contact objects sorted by last name.
                var sortedNames =
                    from n in context.Contacts
                    orderby n.LastName
                    select n;

                Console.WriteLine("The sorted list of last names:");
                foreach (Contact name in sortedNames)
                {
                    Console.WriteLine(name.LastName);
                }
            }
            //</snippetSortQueryLinq>
        }
        public static void SortQueryEsql()
        {
            Console.WriteLine("Starting method 'SortQueryEsql'");
            //<snippetSortQueryEsql>
            // Define the Entity SQL query string that returns
            // Contact objects sorted by last name.
            string queryString = @"SELECT VALUE contact FROM Contacts AS contact
                    Order By contact.LastName";

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Define an ObjectQuery that returns a collection
                // of Contact objects sorted by last name.
                ObjectQuery<Contact> query =
                    new ObjectQuery<Contact>(queryString, context);

                Console.WriteLine("The sorted list of last names:");
                foreach (Contact name in query.Execute(MergeOption.AppendOnly))
                {
                    Console.WriteLine(name.LastName);
                }
            }
            //</snippetSortQueryEsql>
        }
        public static void SortQuery()
        {
            Console.WriteLine("Starting method 'SortQuery'");
            //<snippetSortQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Define an ObjectQuery that returns a collection
                // of Contact objects sorted by last name.
                ObjectQuery<Contact> query =
                    context.Contacts.OrderBy("it.LastName");

                Console.WriteLine("The sorted list of last names:");
                foreach (Contact name in query.Execute(MergeOption.AppendOnly))
                {
                    Console.WriteLine(name.LastName);
                }
            }
            //</snippetSortQuery>
        }
        public static void QueryEntityCollection()
        {
            Console.WriteLine("Starting method 'QueryEntityCollection'");
            //<snippetQueryEntityCollection>

            // Specify the customer ID.
            int customerId = 4332;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Get a specified customer by contact ID.
                var customer = (from customers in context.Contacts
                                where customers.ContactID == customerId
                                select customers).First();

                // You do not have to call the Load method to load the orders for the customer,
                // because  lazy loading is set to true
                // by the constructor of the AdventureWorksEntities object.
                // With  lazy loading set to true the related objects are loaded when
                // you access the navigation property. In this case SalesOrderHeaders.

                // Write the number of orders for the customer.
                Console.WriteLine($"Customer '{customer.LastName}' has placed {customer.SalesOrderHeaders.Count} total orders.");

                // Get the online orders that have shipped.
                var shippedOrders =
                    from order in customer.SalesOrderHeaders
                    where order.OnlineOrderFlag == true
                    && order.Status == 5
                    select order;

                // Write the number of orders placed online.
                Console.WriteLine($"{shippedOrders.Count()} orders placed online have been shipped.");
            }
            //</snippetQueryEntityCollection>
        }
        public static void QueryCreateSourceQuery()
        {
            Console.WriteLine("Starting method 'QueryCreateSourceQuery'");
            //<snippetQueryCreateSourceQuery>

            // Specify the customer ID.
            int customerId = 4332;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Get a specified customer by contact ID.
                var customer = (from customers in context.Contacts
                                where customers.ContactID == customerId
                                select customers).First();

                // Use CreateSourceQuery to generate a query that returns
                // only the online orders that have shipped.
                var shippedOrders =
                    from orders in customer.SalesOrderHeaders.CreateSourceQuery()
                    where orders.OnlineOrderFlag == true
                    && orders.Status == 5
                    select orders;

                // Write the number of orders placed online.
                Console.WriteLine($"{shippedOrders.Count()} orders placed online have been shipped.");

                // You do not have to call the Load method to load the orders for the customer,
                // because  lazy loading is set to true
                // by the constructor of the AdventureWorksEntities object.
                // With  lazy loading set to true the related objects are loaded when
                // you access the navigation property. In this case SalesOrderHeaders.

                // Write the number of total orders for the customer.
                Console.WriteLine($"Customer '{customer.LastName}' has placed {customer.SalesOrderHeaders.Count} total orders.");
            }
            //</snippetQueryCreateSourceQuery>
        }
        public static void LoadSelectedObjects()
        {
            Console.WriteLine("Starting method 'LoadSelectedObjects'");
            //<snippetLoadSelectedObjects>
            // Specify the customer ID.
            int customerId = 4332;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Get a specified customer by contact ID.
                Contact customer = context.Contacts
                    .Where("it.ContactID = @customerId",
                    new ObjectParameter("customerId", customerId)).First();

                // Return the customer's first five orders with line items and
                // attach them to the SalesOrderHeader collection.
                customer.SalesOrderHeaders.Attach(
                    customer.SalesOrderHeaders.CreateSourceQuery()
                    .Include("SalesOrderDetails").Take(5));

                foreach (SalesOrderHeader order in customer.SalesOrderHeaders)
                {
                    Console.WriteLine(String.Format("PO Number: {0}",
                        order.PurchaseOrderNumber));
                    Console.WriteLine(String.Format("Order Date: {0}",
                        order.OrderDate.ToString()));
                    Console.WriteLine("Order items:");

                    foreach (SalesOrderDetail item in order.SalesOrderDetails)
                    {
                        Console.WriteLine(String.Format("Product: {0} "
                            + "Quantity: {1}", item.ProductID.ToString(),
                            item.OrderQty.ToString()));
                    }
                }
            }
            //</snippetLoadSelectedObjects>>
        }

        #endregion
        public static void QueryWithMultipleSpan()
        {
            Console.WriteLine("Starting method 'QueryWithMultiplePaths'");
            //<snippetQueryWithMultiplePaths>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                //<snippetSpanOnlyWithMultiplePaths>
                // Create a SalesOrderHeader query with two query paths,
                // one that returns order items and a second that returns the
                // billing and shipping addresses for each order.
                ObjectQuery<SalesOrderHeader> query =
                    context.SalesOrderHeaders.Include("SalesOrderDetails").Include("Address");
                //</snippetSpanOnlyWithMultiplePaths>

                // Execute the query and display information for each item
                // in the orders that belong to the first contact.
                foreach (SalesOrderHeader order in query.Top("10"))
                {
                    Console.WriteLine(String.Format("PO Number: {0}",
                        order.PurchaseOrderNumber));
                    Console.WriteLine(String.Format("Order Date: {0}",
                        order.OrderDate.ToString()));
                    Console.WriteLine(String.Format("Bill to city and postal code: {0}, {1}",
                        order.Address.City.ToString(),
                        order.Address.PostalCode.ToString()));
                    Console.WriteLine(String.Format("Ship to city and postal code: {0}, {1}",
                        order.Address1.City.ToString(),
                        order.Address1.PostalCode.ToString()));
                    Console.WriteLine("Order items:");
                    foreach (SalesOrderDetail item in order.SalesOrderDetails)
                    {
                        Console.WriteLine(String.Format("Product: {0} "
                            + "Quantity: {1}", item.ProductID.ToString(),
                            item.OrderQty.ToString()));
                    }
                }
            }
            //</snippetQueryWithMultiplePaths>
        }
        public static void OpenConnection()
        {
            Console.WriteLine("Starting method 'OpenConnection'");
            //<snippetOpenConnection>
            // Define the order ID for the order we want.
            int orderId = 43680;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                //<snippetOpenConnection_line>
                // Explicitly open the connection.
                context.Connection.Open();
                //</snippetOpenConnection_line>

                // Execute a query to return an order.
                SalesOrderHeader order =
                    context.SalesOrderHeaders.Where(
                    "it.SalesOrderID = @orderId", new ObjectParameter("orderId", orderId))
                    .Execute(MergeOption.AppendOnly).First();

                // Change the status of the order.
                order.Status = 1;

                // Save changes.
                if (0 < context.SaveChanges())
                {
                    Console.WriteLine("Changes saved.");
                }
                // The connection is closed when the object context
                // is disposed because it is no longer in scope.
            }
            //</snippetOpenConnection>
        }
        static public void OpenConnection_Long()
        {
            Console.WriteLine("Starting method 'OpenConnection_Long'");
            //<snippetOpenConnectionLong>
            // Define the order ID for the order we want.
            int orderId = 43680;

            // Create a long-running context.
            AdventureWorksEntities context =
                new AdventureWorksEntities();

            try
            {
                if (context.Connection.State != ConnectionState.Open)
                {
                    // Explicitly open the connection.
                    context.Connection.Open();
                }

                // Execute a query to return an order.
                SalesOrderHeader order =
                    context.SalesOrderHeaders.Where(
                    "it.SalesOrderID = @orderId", new ObjectParameter("orderId", orderId))
                    .Execute(MergeOption.AppendOnly).First();

                // Change the status of an existing order.
                order.Status = 1;

                // You do not have to call the Load method to load the details for the order,
                // because  lazy loading is set to true
                // by the constructor of the AdventureWorksEntities object.
                // With  lazy loading set to true the related objects are loaded when
                // you access the navigation property. In this case SalesOrderDetails.

                // Delete the first item in the order.
                context.DeleteObject(order.SalesOrderDetails.First());

                // Save changes.
                if (0 < context.SaveChanges())
                {
                    Console.WriteLine("Changes saved.");
                }

                // Create a new SalesOrderDetail object.
                // You can use the static CreateObjectName method (the Entity Framework
                // adds this method to the generated entity types) instead of the new operator:
                // SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0,
                //                                         Guid.NewGuid(), DateTime.Today));
                SalesOrderDetail detail = new SalesOrderDetail
                {
                    SalesOrderID = 0,
                    SalesOrderDetailID = 0,
                    OrderQty = 2,
                    ProductID = 750,
                    SpecialOfferID = 1,
                    UnitPrice = (decimal)2171.2942,
                    UnitPriceDiscount = 0,
                    LineTotal = 0,
                    rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };

                order.SalesOrderDetails.Add(detail);

                // Save changes again.
                if (0 < context.SaveChanges())
                {
                    Console.WriteLine("Changes saved.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Explicitly dispose of the context,
                // which closes the connection.
                context.Dispose();
            }
            //</snippetOpenConnectionLong>
        }

        public static void OpenEntityConnection()
        {
            Console.WriteLine("Starting method 'OpenEntityConnection'");
            //<snippetOpenEntityConnection>
            // Define the order ID for the order we want.
            int orderId = 43680;

            //<snippetOpenEntityConnectionLine>
            // Create an EntityConnection.
            EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities");

            // Create a long-running context with the connection.
            AdventureWorksEntities context =
                new AdventureWorksEntities(conn);
            //</snippetOpenEntityConnectionLine>

            try
            {
                // Explicitly open the connection.
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Execute a query to return an order.
                SalesOrderHeader order =
                    context.SalesOrderHeaders.Where(
                    "it.SalesOrderID = @orderId", new ObjectParameter("orderId", orderId))
                    .Execute(MergeOption.AppendOnly).First();

                // Change the status of the order.
                order.Status = 1;

                // You do not have to call the Load method to load the details for the order,
                // because  lazy loading is set to true
                // by the constructor of the AdventureWorksEntities object.
                // With  lazy loading set to true the related objects are loaded when
                // you access the navigation property. In this case SalesOrderDetails.

                // Delete the first item in the order.
                context.DeleteObject(order.SalesOrderDetails.First());

                // Save changes.
                if (0 < context.SaveChanges())
                {
                    Console.WriteLine("Changes saved.");
                }

                // Create a new SalesOrderDetail object.
                // You can use the static CreateObjectName method (the Entity Framework
                // adds this method to the generated entity types) instead of the new operator:
                // SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0,
                //                                         Guid.NewGuid(), DateTime.Today));
                SalesOrderDetail detail = new SalesOrderDetail
                {
                    SalesOrderID = 1,
                    SalesOrderDetailID = 0,
                    OrderQty = 2,
                    ProductID = 750,
                    SpecialOfferID = 1,
                    UnitPrice = (decimal)2171.2942,
                    UnitPriceDiscount = 0,
                    LineTotal = 0,
                    rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };

                order.SalesOrderDetails.Add(detail);

                // Save changes again.
                if (0 < context.SaveChanges())
                {
                    Console.WriteLine("Changes saved.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Explicitly dispose of the context and the connection.
                context.Dispose();
                conn.Dispose();
            }
            //</snippetOpenEntityConnection>
        }
        public static void BuildObjectGraphAndAttach()
        {
            Console.WriteLine("Starting method 'AttachRelatedObjects'");

            SalesOrderHeader order = new SalesOrderHeader();
            List<SalesOrderDetail> items = new List<SalesOrderDetail>();

            // First load up some objects and then drop the context.
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {

                Contact customer = context.Contacts.Include("SalesOrderHeaders.SalesOrderDetails").First();
                order = customer.SalesOrderHeaders.First();

                while (order.SalesOrderDetails.Count > 0)
                {
                    SalesOrderDetail item = order.SalesOrderDetails.First();
                    // Add the item to the List and detach.
                    items.Add(item);
                    context.Detach(item);
                }

                // Remove the existing relationships.
                order.SalesOrderDetails.Clear();

                // Detach the order.
                context.Detach(order);

                // Call AttachRelatedObjects.
                AttachRelatedObjects(context, order, items);

                // Detach items.
                foreach (SalesOrderDetail item in items)
                {
                    context.Detach(item);
                }

                // Remove the existing relationships.
                order.SalesOrderDetails.Clear();

                // Detach the order.
                context.Detach(order);

                // Call AttachObjectGraph.
                AttachObjectGraph(context, order, items);
            }
        }
        //<snippetAttachObjectGraph>
        private static void AttachObjectGraph(
            ObjectContext currentContext,
            SalesOrderHeader detachedOrder,
            List<SalesOrderDetail> detachedItems)
        {
            // Define the relationships by adding each SalesOrderDetail
            // object in the detachedItems List<SalesOrderDetail> collection to the
            // EntityCollection on the SalesOrderDetail navigation property of detachedOrder.
            foreach (SalesOrderDetail item in detachedItems)
            {
                detachedOrder.SalesOrderDetails.Add(item);
            }

            // Attach the object graph to the supplied context.
            currentContext.Attach(detachedOrder);
        }
        //</snippetAttachObjectGraph>
        //<snippetAttachRelatedObjects>
        private static void AttachRelatedObjects(
            ObjectContext currentContext,
            SalesOrderHeader detachedOrder,
            List<SalesOrderDetail> detachedItems)
        {
            // Attach the root detachedOrder object to the supplied context.
            currentContext.Attach(detachedOrder);

            // Attach each detachedItem to the context, and define each relationship
            // by attaching the attached SalesOrderDetail object to the EntityCollection on
            // the SalesOrderDetail navigation property of the now attached detachedOrder.
            foreach (SalesOrderDetail item in detachedItems)
            {
                currentContext.Attach(item);
                detachedOrder.SalesOrderDetails.Attach(item);
            }
        }
        //</snippetAttachRelatedObjects>
        public static void DetachAndUpdateItem()
        {
            Console.WriteLine("Starting method 'DetachAndUpdateItem'");

            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // Get an item to detach.
                SalesOrderDetail originalItem =
                    context.SalesOrderDetails.First();

                // Get the order for the item and set the status to 1,
                // or an exception will occur when the item Qty is changed.
                if (!originalItem.SalesOrderHeaderReference.IsLoaded)
                {
                    originalItem.SalesOrderHeaderReference.Load();
                }

                originalItem.SalesOrderHeader.Status = 1;

                Console.WriteLine("Original qty:" + originalItem.OrderQty.ToString());

                // Detach the item.
                context.Detach(originalItem);
                // Create a new updated item and change the status.
                object obj = null;

                context.TryGetObjectByKey(originalItem.EntityKey, out obj);

                if (object.ReferenceEquals(obj, originalItem))
                {
                    throw new InvalidOperationException("Refs are identical.");
                }
                SalesOrderDetail updatedItem = (SalesOrderDetail)obj;
                updatedItem.OrderQty += 1;
                updatedItem.ModifiedDate = DateTime.Today;

                context.Detach(updatedItem);
                SalesOrderDetail newItem = SalesOrderDetail.CreateSalesOrderDetail(
                    43680, 0, 5, 711, 1, (decimal)13.0368,
                    0, 0, Guid.NewGuid(), DateTime.Now);

                ApplyItemUpdates(originalItem, newItem);

                Console.WriteLine("Updated qty:" + originalItem.OrderQty.ToString());

                updatedItem.OrderQty += 1;

                //ApplyItemUpdates(updatedItem);

                Console.WriteLine("Updated qty:" + originalItem.OrderQty.ToString());
            }
        }

        //<snippetApplyItemUpdates>
        private static void ApplyItemUpdates(SalesOrderDetail originalItem,
            SalesOrderDetail updatedItem)
        {
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                context.SalesOrderDetails.Attach(updatedItem);
                // Check if the ID is 0, if it is the item is new.
                // In this case we need to change the state to Added.
                if (updatedItem.SalesOrderDetailID == 0)
                {
                    // Because the ID is generated by the database we do not need to
                    // set updatedItem.SalesOrderDetailID.
                    context.ObjectStateManager.ChangeObjectState(updatedItem, System.Data.EntityState.Added);
                }
                else
                {
                    // If the SalesOrderDetailID is not 0, then the item is not new
                    // and needs to be updated. Because we already added the
                    // updated object to the context we need to apply the original values.
                    // If we attached originalItem to the context
                    // we would need to apply the current values:
                    // context.ApplyCurrentValues("SalesOrderDetails", updatedItem);
                    // Applying current or original values, changes the state
                    // of the attached object to Modified.
                    context.ApplyOriginalValues("SalesOrderDetails", originalItem);
                }
                context.SaveChanges();
            }
        }
        //</snippetApplyItemUpdates>

        //<snippetApplyItemUpdatesGetObject>
        private static void ApplyItemUpdates(SalesOrderDetail updatedItem)
        {
            // Define an ObjectStateEntry and EntityKey for the current object.
            EntityKey key = default(EntityKey);
            object originalItem = null;

            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // Create the detached object's entity key.
                key = context.CreateEntityKey("SalesOrderDetails", updatedItem);

                // Get the original item based on the entity key from the context
                // or from the database.
                if (context.TryGetObjectByKey(key, out originalItem))
                {
                    // Call the ApplyCurrentValues method to apply changes
                    // from the updated item to the original version.
                    context.ApplyCurrentValues(key.EntitySetName, updatedItem);
                }

                context.SaveChanges();
            }
        }
        //</snippetApplyItemUpdatesGetObject>

        public static void ChangeItemQuantity()
        {
            Console.WriteLine("Starting method 'ChangeItemQuantity'");
            //<snippetCreateSalesOrderDetail>
            int orderId = 43680;
            using (AdventureWorksEntities context
                = new AdventureWorksEntities())
            {
                var order = (from o in context.SalesOrderHeaders
                             where o.SalesOrderID == orderId
                             select o).First();

                // Add a new item.
                //<snippetCreateSalesOrderDetailShort>
                SalesOrderDetail newItem = SalesOrderDetail.CreateSalesOrderDetail(
                    0, 0, 5, 711, 1, (decimal)13.0368,
                    0, 0, Guid.NewGuid(), DateTime.Now);
                //</snippetCreateSalesOrderDetailShort>
                order.SalesOrderDetails.Add(newItem);

                context.SaveChanges();
            }
            //</snippetCreateSalesOrderDetail>
        }
        public static void ChangeObjectRelationship()
        {
            Console.WriteLine("Starting method 'ChangeObjectRelationship'");
            //<snippetChangeObjectRelationship>

            // Define the order and new address IDs.
            int orderId = 43669;
            int addressId = 26;

            using (AdventureWorksEntities context
                = new AdventureWorksEntities())
            {
                // Get the billing address to change to.
                Address address =
                    context.Addresses.Single(c => c.AddressID == addressId);

                // Get the order being changed.
                SalesOrderHeader order =
                    context.SalesOrderHeaders.Single(o => o.SalesOrderID == orderId);

                // You do not have to call the Load method to load the addresses for the order,
                // because  lazy loading is set to true
                // by the constructor of the AdventureWorksEntities object.
                // With  lazy loading set to true the related objects are loaded when
                // you access the navigation property. In this case Address.

                // Write the current billing street address.
                Console.WriteLine("Current street: "
                    + order.Address.AddressLine1);

                // Change the billing address.
                if (!order.Address.Equals(address))
                {
                    // Use Address navigation property to change the association.
                    order.Address = address;

                    // Write the changed billing street address.
                    Console.WriteLine("Changed street: "
                        + order.Address.AddressLine1);
                }

                // If the address change succeeds, save the changes.
                context.SaveChanges();

                // Write the current billing street address.
                Console.WriteLine("Current street: "
                    + order.Address.AddressLine1);
            }
            //</snippetChangeObjectRelationship>
        }

        public static void ChangeObjectRelationshipUsingFKProperty()
        {
            Console.WriteLine("Starting method 'ChangeObjectRelationshipUsingFKProperty'");
            // The following code uses foreign key property to change the relationship.

            //<snippetChangeObjectRelationshipUsingFKProperty>
            int orderId = 43669;
            int addressId = 24;

            using (AdventureWorksEntities context
                = new AdventureWorksEntities())
            {
                // Get the order being changed.
                SalesOrderHeader order = context.SalesOrderHeaders.First(o => o.SalesOrderID == orderId);

                // Change the billing address.
                order.BillToAddressID = addressId;

                // Write the current billing street address.
                Console.WriteLine("Updated street: "
                    + order.Address.AddressLine1);

                // Save the changes.
                context.SaveChanges();
            }
            //</snippetChangeObjectRelationshipUsingFKProperty>
        }

        public static void AddObjectUsingKey()
        {
            Console.WriteLine("Starting method 'AddObjectUsingKey'");
            // Specify the order to which to add the item.
            int orderId = 43680;
            //<snippetAddObjectUsingStandInSalesOrderHeaders>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Create the stand-in SalesOrderHeader object
                // based on the specified SalesOrderID.
                SalesOrderHeader order =
                    new SalesOrderHeader { SalesOrderID = orderId };

                // Attach the stand-in SalesOrderHeader object.
                context.SalesOrderHeaders.Attach(order);

                // Create a new SalesOrderDetail object.
                // You can use the static CreateObjectName method (the Entity Framework
                // adds this method to the generated entity types) instead of the new operator:
                // SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0,
                //                                         Guid.NewGuid(), DateTime.Today));
                SalesOrderDetail detail = new SalesOrderDetail
                {
                    SalesOrderID = orderId,
                    SalesOrderDetailID = 0,
                    OrderQty = 2,
                    ProductID = 750,
                    SpecialOfferID = 1,
                    UnitPrice = (decimal)2171.2942,
                    UnitPriceDiscount = 0,
                    LineTotal = 0,
                    rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };

                order.SalesOrderDetails.Add(detail);

                context.SaveChanges();
            }
            //</snippetAddObjectUsingStandInSalesOrderHeaders>
            //<snippetAddObjectUsingKey>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                try
                {
                    // Create the key that represents the order.
                    EntityKey orderKey =
                        new EntityKey("AdventureWorksEntities.SalesOrderHeaders",
                            "SalesOrderID", orderId);

                    // Create the stand-in SalesOrderHeader object
                    // based on the specified SalesOrderID.
                    SalesOrderHeader order = new SalesOrderHeader();
                    order.EntityKey = orderKey;

                    // Assign the ID to the SalesOrderID property to match the key.
                    order.SalesOrderID = (int)orderKey.EntityKeyValues[0].Value;

                    // Attach the stand-in SalesOrderHeader object.
                    context.SalesOrderHeaders.Attach(order);

                    // Create a new SalesOrderDetail object.
                    // You can use the static CreateObjectName method (the Entity Framework
                    // adds this method to the generated entity types) instead of the new operator:
                    // SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0,
                    //                                         Guid.NewGuid(), DateTime.Today));
                    SalesOrderDetail detail = new SalesOrderDetail
                    {
                        SalesOrderID = orderId,
                        SalesOrderDetailID = 0,
                        OrderQty = 2,
                        ProductID = 750,
                        SpecialOfferID = 1,
                        UnitPrice = (decimal)2171.2942,
                        UnitPriceDiscount = 0,
                        LineTotal = 0,
                        rowguid = Guid.NewGuid(),
                        ModifiedDate = DateTime.Now
                    };

                    order.SalesOrderDetails.Add(detail);

                    context.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Ensure that the key value matches the value of the object's ID property.");
                }
                catch (UpdateException)
                {
                    Console.WriteLine($"An error has occurred. Ensure that an object with the '{orderId}' key value exists.");
                }
            }
            //</snippetAddObjectUsingKey>
        }
        static public void QueryWithAlias()
        {
            Console.WriteLine("Starting method 'QueryWithAlias'");
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                //<snippetQueryWithAliasNamed>
                //<snippetQueryWithAlias>
                int cost = 10;
                // Return Product objects with a standard cost
                // above 10 dollars.
                ObjectQuery<Product> productQuery =
                    context.Products
                    .Where("it.StandardCost > @cost", new ObjectParameter("cost", cost));
                //</snippetQueryWithAlias>

                // Set the Name property for the query and then
                // use that name as the alias in the subsequent
                // OrderBy method.
                productQuery.Name = "product";
                ObjectQuery<Product> filteredProduct = productQuery
                    .OrderBy("product.ProductID");
                //</snippetQueryWithAliasNamed>

                // Iterate through the collection of Product items.
                foreach (Product result in filteredProduct)
                {
                    Console.WriteLine($"Product Name: {result.Name}; Product ID: {result.ProductID}");
                }
            }
        }
        static public void QueryWithParams()
        {
            Console.WriteLine("Starting method 'QueryWithParams'");
            //<snippetQueryWithParams>
            string firstName = @"Frances";
            string lastName = @"Adams";

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                //<snippetQueryWithParamsOnly>
                // Get the contacts with the specified name.
                ObjectQuery<Contact> contactQuery = context.Contacts
                    .Where("it.LastName = @ln AND it.FirstName = @fn",
                    new ObjectParameter("ln", lastName),
                    new ObjectParameter("fn", firstName));
                //</snippetQueryWithParamsOnly>

                // Iterate through the collection of Contact items.
                foreach (Contact result in contactQuery)
                    Console.WriteLine($"Last Name: {result.LastName}; First Name: {result.FirstName}");
            }
            //</snippetQueryWithParams>
        }
        public static void QueryWithSpan()
        {
            Console.WriteLine("Starting method 'QueryWithSpan'");
            //<snippetQueryWithSpan>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                //<snippetSpanOnly>
                // Define an object query with a path that returns
                // orders and items for a specific contact.
                Contact contact =
                    context.Contacts.Include("SalesOrderHeaders.SalesOrderDetails")
                    .FirstOrDefault();
                //</snippetSpanOnly>

                // Execute the query and display information for each item
                // in the orders that belong to the first contact.
                foreach (SalesOrderHeader order in contact
                    .SalesOrderHeaders)
                {
                    Console.WriteLine(String.Format("PO Number: {0}",
                        order.PurchaseOrderNumber));
                    Console.WriteLine(String.Format("Order Date: {0}",
                        order.OrderDate.ToString()));
                    Console.WriteLine("Order items:");
                    foreach (SalesOrderDetail item in order.SalesOrderDetails)
                    {
                        Console.WriteLine(String.Format("Product: {0} "
                            + "Quantity: {1}", item.ProductID.ToString(),
                            item.OrderQty.ToString()));
                    }
                }
            }
            //</snippetQueryWithSpan>
        }
        public static void QueryWithSpanLinq()
        {
            Console.WriteLine("Starting method 'QueryWithSpanLinq'");
            //<snippetQueryWithSpanLinq>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                //<snippetSpanLinqOnly>
                // Define a LINQ query with a path that returns
                // orders and items for a contact.
                var contacts = (from contact in context.Contacts
                              .Include("SalesOrderHeaders.SalesOrderDetails")
                                select contact).FirstOrDefault();
                //</snippetSpanLinqOnly>

                // Execute the query and display information for each item
                // in the orders that belong to the contact.
                foreach (SalesOrderHeader order in contacts
                    .SalesOrderHeaders)
                {
                    Console.WriteLine(String.Format("PO Number: {0}",
                        order.PurchaseOrderNumber));
                    Console.WriteLine(String.Format("Order Date: {0}",
                        order.OrderDate.ToString()));
                    Console.WriteLine("Order items:");
                    foreach (SalesOrderDetail item in order.SalesOrderDetails)
                    {
                        Console.WriteLine(String.Format("Product: {0} "
                            + "Quantity: {1}", item.ProductID.ToString(),
                            item.OrderQty.ToString()));
                    }
                }
            }
            //</snippetQueryWithSpanLinq>
        }
        public static void QueryWithSpanEsql()
        {
            Console.WriteLine("Starting method 'QueryWithSpanEsql'");
            //<snippetQueryWithSpanEsql>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                //<snippetSpanEsqlOnly>
                // Define an object query with a path that returns
                // orders and items for a specific contact.
                string queryString =
                    @"SELECT VALUE TOP(1) contact FROM " +
                    "AdventureWorksEntities.Contacts AS contact";

                // Define the object query with the query string.
                ObjectQuery<Contact> contactQuery = new ObjectQuery<Contact>(queryString,
                    context, MergeOption.NoTracking);

                Contact contact =
                    contactQuery.Include("SalesOrderHeaders.SalesOrderDetails")
                    .FirstOrDefault();
                //</snippetSpanEsqlOnly>

                // Execute the query and display information for each item
                // in the orders that belong to the first contact.
                foreach (SalesOrderHeader order in contact
                    .SalesOrderHeaders)
                {
                    Console.WriteLine(String.Format("PO Number: {0}",
                        order.PurchaseOrderNumber));
                    Console.WriteLine(String.Format("Order Date: {0}",
                        order.OrderDate.ToString()));
                    Console.WriteLine("Order items:");
                    foreach (SalesOrderDetail item in order.SalesOrderDetails)
                    {
                        Console.WriteLine(String.Format("Product: {0} "
                            + "Quantity: {1}", item.ProductID.ToString(),
                            item.OrderQty.ToString()));
                    }
                }
            }
            //</snippetQueryWithSpanEsql>
        }
        public static void QueryEntityType()
        {
            Console.WriteLine("Starting method 'QueryEntityType'");
            //<snippetQueryEntityType>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                ObjectSet<Product> productQuery = context.Products;

                // Iterate through the collection of Product items.
                foreach (Product result in productQuery)
                    Console.WriteLine($"Product Name: {result.Name}; Product ID: {result.ProductID}");
            }
            //</snippetQueryEntityType>
        }

        public static void QueryEntityTypeCollection()
        {
            //<snippetQueryEntityTypeCollection>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                ObjectQuery<Contact> query= context.Contacts.Where("it.LastName==@ln",
                    new ObjectParameter("ln", "Zhou"));

                // Iterate through the collection of Contact items.
                foreach (Contact result in query)
                    Console.WriteLine($"Contact First Name: {result.FirstName}; Last Name: {result.LastName}");
            }
            //</snippetQueryEntityTypeCollection>
        }
        public static void QueryAnonymousType()
        {
            Console.WriteLine("Starting method 'QueryAnonymousType'");
            //<snippetQueryAnonymousType>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Use the Select method to define the projection.
                ObjectQuery<DbDataRecord> query =
                    context.Products.Select("it.ProductID, it.Name");

                // Iterate through the collection of data rows.
                foreach (DbDataRecord rec in query)
                {
                    Console.WriteLine($"ID {rec[0]}; Name {rec[1]}");
                }
            }
            //</snippetQueryAnonymousType>
        }
        public static void QueryPrimitiveTypeLinq()
        {
            Console.WriteLine("Starting method 'QueryPrimitiveTypeLinq'");
            //<snippetQueryPrimitiveTypeLinq>
            int contactId = 377;

            using (AdventureWorksEntities context
                = new AdventureWorksEntities())
            {
                // Select a value.
                ObjectSet<SalesOrderHeader> orders
                    = context.SalesOrderHeaders;

                IQueryable<Int32> orderQuery =
                    from order in orders
                    where order.Contact.ContactID == contactId
                    select order.PurchaseOrderNumber.Length;

                // Iterate through the collection of values.
                foreach (Int32 result in orderQuery)
                {
                    Console.WriteLine($"{result}");
                }

                // Use a nullable DateTime value because ShipDate can be null.
                //<snippetQueryPrimitiveTypeLinqShort>
                IQueryable<DateTime?> shipDateQuery =
                    from order in orders
                    where order.Contact.ContactID == contactId
                    select order.ShipDate;
                //</snippetQueryPrimitiveTypeLinqShort>

                // Iterate through the collection of values.
                foreach (DateTime? shipDate in shipDateQuery)
                {
                    string shipDateMessage = "date not set";

                    if (shipDate != null)
                    {
                        shipDateMessage = shipDate.ToString();
                    }
                    Console.WriteLine($"Ship Date: {shipDateMessage}.");
                }
            }
            //</snippetQueryPrimitiveTypeLinq>
        }
        public static void QueryPrimitiveTypeEsql()
        {
            Console.WriteLine("Starting method 'QueryPrimitiveTypeEsql'");
            //<snippetQueryPrimitiveTypeEsql>
            int contactId = 377;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string orderQueryString = @"SELECT VALUE Length(order.PurchaseOrderNumber)
                    FROM AdventureWorksEntities.SalesOrderHeaders AS order
                    WHERE order.CustomerID = @contactId";
                string shipDateQueryString = @"SELECT VALUE order.ShipDate
                    FROM AdventureWorksEntities.SalesOrderHeaders AS order
                    WHERE order.CustomerID = @contactId";

                // Use the SelectValue method to select a value.
                ObjectQuery<Int32> orderQuery =
                    new ObjectQuery<Int32>(orderQueryString,
                        context, MergeOption.NoTracking);
                orderQuery.Parameters.Add(
                    new ObjectParameter("contactId", contactId));

                // Iterate through the collection of values.
                foreach (Int32 result in orderQuery)
                {
                    Console.WriteLine($"{result}");
                }

                // Use a nullable DateTime value because ShipDate can be null.
                ObjectQuery<Nullable<DateTime>> shipDateQuery =
                    new ObjectQuery<Nullable<DateTime>>(shipDateQueryString,
                context, MergeOption.NoTracking);
                shipDateQuery.Parameters.Add(
                    new ObjectParameter("contactId", contactId));

                // Iterate through the collection of values.
                foreach (Nullable<DateTime> shipDate in shipDateQuery)
                {
                    string shipDateMessage = "date not set";

                    if (shipDate != null)
                    {
                        shipDateMessage = shipDate.ToString();
                    }
                    Console.WriteLine($"Ship Date: {shipDateMessage}.");
                }
            }
            //</snippetQueryPrimitiveTypeEsql>
        }
        public static void QueryPrimitiveType()
        {
            Console.WriteLine("Starting method 'QueryPrimitiveType'");
            //<snippetQueryPrimitiveType>
            int contactId = 377;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Use the SelectValue method to select a value.
                ObjectQuery<Int32> orderQuery =
                    context.SalesOrderHeaders
                    .Where("it.CustomerID = @contactId",
                    new ObjectParameter("contactId", contactId))
                    .SelectValue<Int32>("Length(it.PurchaseOrderNumber)");

                // Iterate through the collection of values.
                foreach (Int32 result in orderQuery)
                {
                    Console.WriteLine($"{result}");
                }

                // Use a nullable DateTime value because ShipDate can be null.
                //<snippetQueryPrimitiveTypeShort>
                ObjectQuery<Nullable<DateTime>> shipDateQuery =
                    context.SalesOrderHeaders
                    .Where("it.CustomerID = @contactId",
                        new ObjectParameter("contactId", contactId))
                    .SelectValue<Nullable<DateTime>>("it.ShipDate");
                //</snippetQueryPrimitiveTypeShort>

                // Iterate through the collection of values.
                foreach (Nullable<DateTime> shipDate in shipDateQuery)
                {
                    string shipDateMessage = "date not set";

                    if (shipDate != null)
                    {
                        shipDateMessage = shipDate.ToString();
                    }
                    Console.WriteLine($"Ship Date: {shipDateMessage}.");
                }
            }
            //</snippetQueryPrimitiveType>
        }

        public static void ModifyObjects()
        {
            Console.WriteLine("Starting method 'ModifyObjects'");
            //<snippetSaveChanges>
            // Specify the order to update.
            int orderId = 43680;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                try
                {
                    //<snippetObjectChanges>
                    var order = (from o in context.SalesOrderHeaders
                                 where o.SalesOrderID == orderId
                                 select o).First();

                    // Change the status and ship date of an existing order.
                    order.Status = 1;
                    order.ShipDate = DateTime.Today;

                    // You do not have to call the Load method to load the details for the order,
                    // because  lazy loading is set to true
                    // by the constructor of the AdventureWorksEntities object.
                    // With  lazy loading set to true the related objects are loaded when
                    // you access the navigation property. In this case SalesOrderDetails.

                    // Delete the first item in the order.
                    context.DeleteObject(order.SalesOrderDetails.First());

                    // Create a new SalesOrderDetail object.
                    // You can use the static CreateObjectName method (the Entity Framework
                    // adds this method to the generated entity types) instead of the new operator:
                    // SalesOrderDetail.CreateSalesOrderDetail(1, 0, 2, 750, 1, (decimal)2171.2942, 0, 0,
                    //                                         Guid.NewGuid(), DateTime.Today));
                    SalesOrderDetail detail = new SalesOrderDetail
                    {
                        SalesOrderID = 1,
                        SalesOrderDetailID = 0,
                        OrderQty = 2,
                        ProductID = 750,
                        SpecialOfferID = 1,
                        UnitPrice = (decimal)2171.2942,
                        UnitPriceDiscount = 0,
                        LineTotal = 0,
                        rowguid = Guid.NewGuid(),
                        ModifiedDate = DateTime.Now
                    };

                    order.SalesOrderDetails.Add(detail);

                    //<snippetSave>
                    // Save changes in the object context to the database.
                    int changes = context.SaveChanges();
                    //</snippetSave>
                    //</snippetObjectChanges>

                    Console.WriteLine(changes.ToString() + " changes saved!");
                    Console.WriteLine("Updated item for order: "
                        + order.SalesOrderID.ToString());

                    foreach (SalesOrderDetail item in order.SalesOrderDetails)
                    {
                        Console.WriteLine("Item ID: "
                            + item.SalesOrderDetailID.ToString() + "  Product: "
                            + item.ProductID.ToString() + "  Quantity: "
                            + item.OrderQty.ToString());
                    }
                }
                catch (UpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetSaveChanges>
        }
        public static void AddDeleteObject()
        {
            int productId;
            // Add the product object.
            productId = AddObject();

            DeleteObject(productId);
        }

        private static int AddObject()
        {
            Console.WriteLine("Starting method 'AddObject'");
            //<snippetAddObject>
            Product newProduct;

            // Define values for the new product.
            string dateTimeString = "1998-06-01 00:00:00.000";
            string productName = "Flat Washer 10";
            string productNumber = "FW-5600";
            Int16 safetyStockLevel = 1000;
            Int16 reorderPoint = 750;

            // Convert the date time string into a DateTime instance.
            DateTime sellStartDate;
            if (!DateTime.TryParse(dateTimeString, out sellStartDate))
            {
                throw new ArgumentException(string.Format("The string '{0}'cannot "
                    + "be converted to DateTime.", dateTimeString));
            }

            // Create a new Product.
            newProduct = Product.CreateProduct(0,
                productName, productNumber, false, false, safetyStockLevel, reorderPoint,
                0, 0, 0, DateTime.Today, Guid.NewGuid(), DateTime.Today);

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                try
                {
                    // Add the new object to the context.
                    context.Products.AddObject(newProduct);

                    // Persist the new product to the data source.
                    context.SaveChanges();

                    // Return the identity of the new product.
                    return newProduct.ProductID;
                }
                catch (UpdateException ex)
                {
                    throw new InvalidOperationException(string.Format(
                        "The object could not be added. Make sure that a "
                        + "product with a product number '{0}' does not already exist.\n",
                        newProduct.ProductNumber), ex);
                }
            }
            //</snippetAddObject>
        }

        private static void DeleteObject(int productId)
        {
            Console.WriteLine("Starting method 'DeleteObject'");
            //<snippetDeleteObject>
            object deletedProduct;

            // Define the key of the product to delete.
            EntityKey productKey =
                new EntityKey("AdventureWorksEntities.Products",
                    "ProductID", productId);

            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // Get the object to delete with the specified key.
                if (context.TryGetObjectByKey(productKey, out deletedProduct))
                {
                    try
                    {
                        // Delete the object with the specified key
                        // and save changes to delete the row from the data source.
                        context.DeleteObject(deletedProduct);
                        context.SaveChanges();
                    }
                    catch (OptimisticConcurrencyException ex)
                    {
                        throw new InvalidOperationException(string.Format(
                            "The product with an ID of '{0}' could not be deleted.\n"
                            + "Make sure that any related objects are already deleted.\n",
                            productKey.EntityKeyValues[0].Value), ex);
                    }
                }
                else
                {
                    throw new InvalidOperationException(string.Format(
                        "The product with an ID of '{0}' could not be found.\n"
                        + "Make sure that Product exists.\n",
                        productKey.EntityKeyValues[0].Value));
                }
            }
            //</snippetDeleteObject>
        }
        public static void HandleConflicts()
        {
            Console.WriteLine("Starting method 'HandleConflicts'");
            //<snippetConcurrency>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                try
                {
                    // Perform an operation with a high-level of concurrency.
                    // Change the status of all orders without an approval code.
                    ObjectQuery<SalesOrderHeader> orders =
                        context.SalesOrderHeaders.Where(
                        "it.CreditCardApprovalCode IS NULL").Top("100");

                    foreach (SalesOrderHeader order in orders)
                    {
                        // Reset the order status to 4 = Rejected.
                        order.Status = 4;
                    }
                    //<snippetHandleConcurrencyException>
                    try
                    {
                        // Try to save changes, which may cause a conflict.
                        int num = context.SaveChanges();
                        Console.WriteLine("No conflicts. " +
                            num.ToString() + " updates saved.");
                    }
                    catch (OptimisticConcurrencyException)
                    {
                        // Resolve the concurrency conflict by refreshing the
                        // object context before re-saving changes.
                        context.Refresh(RefreshMode.ClientWins, orders);

                        // Save changes.
                        context.SaveChanges();
                        Console.WriteLine("OptimisticConcurrencyException "
                        + "handled and changes saved");
                    }
                    //</snippetHandleConcurrencyException>

                    foreach (SalesOrderHeader order in orders)
                    {
                        Console.WriteLine("Order ID: " + order.SalesOrderID.ToString()
                            + " Order status: " + order.Status.ToString());
                    }
                }
                catch (UpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetConcurrency>
        }

        public static void QueryWithLoad()
        {
            Console.WriteLine("Starting method 'QueryWithLoad'");
            //<snippetQueryWithLoad>
            // Specify the customer ID.
            int contactID = 4332;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                context.ContextOptions.LazyLoadingEnabled = false;

                // Get a specified customer by contact ID.
                var contact =
                    (from c in context.Contacts
                     where c.ContactID == contactID
                     select c).First();

                // Load the orders for the customer explicitly.
                if (!contact.SalesOrderHeaders.IsLoaded)
                {
                    contact.SalesOrderHeaders.Load();
                }

                foreach (SalesOrderHeader order in contact.SalesOrderHeaders)
                {
                    //<snippetLoad>
                    // Load the items for the order if not already loaded.
                    if (!order.SalesOrderDetails.IsLoaded)
                    {
                        order.SalesOrderDetails.Load();
                    }
                    //</snippetLoad>

                    Console.WriteLine(String.Format("PO Number: {0}",
                        order.PurchaseOrderNumber));
                    Console.WriteLine(String.Format("Order Date: {0}",
                        order.OrderDate.ToString()));
                    Console.WriteLine("Order items:");
                    foreach (SalesOrderDetail item in order.SalesOrderDetails)
                    {
                        Console.WriteLine(String.Format("Product: {0} "
                            + "Quantity: {1}", item.ProductID.ToString(),
                            item.OrderQty.ToString()));
                    }
                }
            }
            //</snippetQueryWithLoad>
        }

        public static void DirectlyExecuteCommandsAgainstStore()
        {
            //<snippetExecuteStoreQueryWithParamReturnString>
            using (SchoolEntities context =
                new SchoolEntities())
            {
                // The following three queries demonstrate
                // three different ways of passing a parameter.
                // The queries return a string result type.

                // Use the parameter substitution pattern.
                foreach (string name in context.ExecuteStoreQuery<string>
                    ("Select Name from Department where DepartmentID < {0}", 5))
                {
                    Console.WriteLine(name);
                }

                // Use parameter syntax with object values.
                foreach (string name in context.ExecuteStoreQuery<string>
                    ("Select Name from Department where DepartmentID < @p0", 5))
                {
                    Console.WriteLine(name);
                }
                // Use an explicit SqlParameter.
                foreach (string name in context.ExecuteStoreQuery<string>
                    ("Select Name from Department where DepartmentID < @p0",
                        new SqlParameter { ParameterName = "p0", Value = 5 }))
                {
                    Console.WriteLine(name);
                }
            }
            //</snippetExecuteStoreQueryWithParamReturnString>
        }

        public static void TranslateReader()
        {
            throw new NotImplementedException();
        }
        
        public static void ExecuteStoredProc()
        {
            Console.WriteLine("Starting method 'ExecuteStoredProc'");
            //<snippetExecuteStoredProc>
            // Specify the Student ID.
            int studentId = 2;

            using (SchoolEntities context =
                new SchoolEntities())
            {
                foreach (StudentGrade grade in
                          context.GetStudentGrades(studentId))
                {
                    Console.WriteLine("StudentID: " + studentId);
                    Console.WriteLine("Student grade: " + grade.Grade);
                }
            }
            //</snippetExecuteStoredProc>
        }

        public static void ExecuteStoredProcWithOutputParams()
        {
            Console.WriteLine("Starting method 'ExecuteStoredProcWithOutputParams'");
            //<snippetExecuteStoredProcWithOutParams>
            using (SchoolEntities context =
                new SchoolEntities())
            {
                // name is an output parameter.
                ObjectParameter name = new ObjectParameter("Name", typeof(String));
                context.GetDepartmentName(1, name);
                Console.WriteLine(name.Value);
            }
            //</snippetExecuteStoredProcWithOutParams>
        }

        public static void ExecuteFunctionWithOutParam()
        {
            Console.WriteLine("Starting method 'ExecuteFunctionWithOutParam'");
            //<snippetExecuteFunctionWithOutParam>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                ObjectParameter id = new ObjectParameter("ID", 1);
                ObjectParameter name = new ObjectParameter("Name", typeof(String));

                context.ExecuteFunction("GetProductName", id, name);
                Console.WriteLine(name.Value);
            }
            //</snippetExecuteFunctionWithOutParam>
        }

        public static void ObjectQueryWithComplexType()
        {
            Console.WriteLine("Starting method 'ObjectQueryWithComplexType'");
            //<snippetObjectQueryWithComplexType>

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                var contacts =
                    from contact in context.Contacts
                    where contact.ContactID == 3
                    select contact;

                foreach (Contact contact in contacts)
                {
                    Console.WriteLine("Contact Id: " + contact.ContactID);
                    Console.WriteLine("Contact's email: " + contact.EmailPhoneComplexProperty.EmailAddress);
                    Console.WriteLine("Contact's phone#: " + contact.EmailPhoneComplexProperty.Phone);
                }
            }
            //</snippetObjectQueryWithComplexType>
        }
        static public void ChangeExistingRelationshipWithFK()
        {
            //<snippetChangeExistingRelationshipWithFK>
            int studentId = 6;
            int enrollmentID = 2;

            using (var context = new SchoolEntities())
            {
                // Get StudentGrade.
                var grade = (from g in context.StudentGrades
                             where g.EnrollmentID == enrollmentID
                             select g).First();

                // Change the relationship.
                grade.StudentID = studentId;
                // You can access Person reference object on the grade object
                // without loading the reference explicitly when
                // the lazy loading option is set to true.
                Console.WriteLine(grade.Person.PersonID);
                // Save the changes.
                context.SaveChanges();
            }
            //</snippetChangeExistingRelationshipWithFK>
        }

        static public void AddNewObjectsWithFK()
        {
            //<snippetAddNewObjectsWithFK>
            using (var context = new SchoolEntities())
            {
                Person newStudent = new Person
                {
                    // The database will generate PersonID.
                    // The object context will get the ID
                    // After the SaveChanges is called.
                    PersonID = 0,
                    LastName = "Li",
                    FirstName = "Yan"
                };
                StudentGrade newStudentGrade = new StudentGrade
                {
                    // The database will generate EnrollmentID.
                    // The object context will get the ID
                    // After the SaveChanges is called.
                    EnrollmentID = 0,
                    Grade = 4.0M,
                    StudentID = 50
                };

                // Add newStudent to object context.
                // The newStudent's state will change from Detached to Added.
                context.People.AddObject(newStudent);

                // To associate the new objects you can do one of the following:
                // Add the new dependent object to the principal object: newStudent.StudentGrades.Add(newStudentGrade).
                // Assign the reference (principal) object to the navigation property of the
                // dependent object: newStudentGrade.Person = newStudent.
                // Both of these methods will synchronize the navigation properties on both ends of the relationship.

                // Adding the newStudentGrade to newStudent will change newStudentGrade's status
                // from Detached to Added.
                newStudent.StudentGrades.Add(newStudentGrade);
                // Navigation properties in both directions will work immediately.
                Console.WriteLine($"Access StudentGrades navigation property to get the count: ");
                Console.WriteLine($"Access Person navigation property: {newStudentGrade.Person.FirstName} ");

                context.SaveChanges();
            }
            //</snippetAddNewObjectsWithFK>
        }
        static public void CreateNewObjectSetFKAndRef()
        {
            //<snippetFKvsRef>
            //<snippetExistingPrincipalToNewDependentFK>

            // The following example creates a new StudentGrade object and associates
            // the StudentGrade with the Course and Person by
            // setting the foreign key properties.

            using (SchoolEntities context = new SchoolEntities())
            {
                StudentGrade newStudentGrade = new StudentGrade
                {
                    // The database will generate the EnrollmentID.
                    EnrollmentID = 0,
                    Grade = 4.0M,
                    // To create the association between the Course and StudentGrade,
                    // and the Student and the StudentGrade, set the foreign key property
                    // to the ID of the principal.
                    CourseID = 4022,
                    StudentID = 17,
                };

                // Adding the new object to the context will synchronize
                // the references with the foreign keys on the newStudentGrade object.
                context.StudentGrades.AddObject(newStudentGrade);

                // You can access Course and Student objects on the newStudentGrade object
                // without loading the references explicitly because
                // the lazy loading option is set to true in the constructor of SchoolEntities.
                Console.WriteLine($"Student ID {newStudentGrade.Person.PersonID}:");
                Console.WriteLine($"Course ID {newStudentGrade.Course.CourseID}:");

                context.SaveChanges();
            }
            //</snippetExistingPrincipalToNewDependentFK>

            //<snippetExistingPrincipalToNewDependentRef>
            // The following example creates a new StudentGrade and associates
            // the StudentGrade with the Course and Person by
            // setting the navigation properties to the Course and Person objects that were returned
            // by the query.
            // You do not need to call AddObject() in order to add the grade object
            // to the context, because when you assign the reference
            // to the navigation property the objects on both ends get synchronized by the Entity Framework.
            // Note, that the Entity Framework will not synchronize the ends until the SaveChanges method
            // is called if your objects do not meet the change tracking requirements.
            using (var context = new SchoolEntities())
            {
                int courseID = 4022;
                var course = (from c in context.Courses
                             where c.CourseID == courseID
                             select c).First();

                int personID = 17;
                var student = (from p in context.People
                              where p.PersonID == personID
                              select p).First();

                StudentGrade grade = new StudentGrade
                {
                    // The database will generate the EnrollmentID.
                    Grade = 4.0M,
                    // Use the navigation properties to create the association between the objects.
                    Course = course,
                    Person = student
                };
                context.SaveChanges();
            }
            //</snippetExistingPrincipalToNewDependentRef>
            //</snippetFKvsRef>
        }

        public static void ObjectQueryTablePerType()
        {
            Console.WriteLine("Starting method 'ObjectQueryTablePerType'");
            //<snippetObjectQueryTablePerType>

            try
            {
                using (SchoolEntities context =
                                      new SchoolEntities())
                {
                    int departmentID = 7;
                    // Get courses for the department with id 7.
                    IQueryable<Course> courses = context.Departments
                            .Where(d => d.DepartmentID == departmentID)
                            .SelectMany(d => d.Courses);

                    Console.WriteLine("All the courses for the selected department.");
                    foreach (Course course in courses)
                    {
                        Console.WriteLine($"CourseID: {course.CourseID} ");
                    }
                    var onlineCourses = courses.OfType<OnlineCourse>();
                    Console.WriteLine("Online courses only for the selected department.");
                    foreach (OnlineCourse onlineCourse in onlineCourses)
                    {
                        Console.WriteLine($"CourseID: {onlineCourse.CourseID} ");
                    }
                    var onsiteCourses = courses.OfType<OnsiteCourse>();
                    Console.WriteLine("Onsite courses only for the selected department.");
                    foreach (OnsiteCourse onsite in onsiteCourses)
                    {
                        Console.WriteLine($"CourseID: {onsite.CourseID} ");
                    }
                }
            }
            catch (System.Data.MappingException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (System.Data.EntityException e)
            {
                Console.WriteLine(e.ToString());
            }

            //</snippetObjectQueryTablePerType>
        }

        public static void DDLTest()
        {
            //<snippetDDL>
			// Initialize the connection string.
			String connectionString = "...";

			using (SchoolEntities context = new SchoolEntities(connectionString))
			{
				try
				{
					if (context.DatabaseExists())
					{
						// Make sure the database instance is closed.
						context.DeleteDatabase();
					}
					// View the database creation script.
					Console.WriteLine(context.CreateDatabaseScript());
                    // Create the new database instance based on the storage (SSDL) section
                    // of the .edmx file.
					context.CreateDatabase();

					// The following code adds a new objects to the context
					// and saves the changes to the database.
					Department dpt = new Department
					{
						Name = "Engineering",
						Budget = 350000.00M,
						StartDate = DateTime.Now
					};

					context.Departments.AddObject(dpt);
					// An entity has a temporary key
					// until it is saved to the database.
					Console.WriteLine(dpt.EntityKey.IsTemporary);
					context.SaveChanges();
					// The object was saved and the key
					// is not temporary any more.
					Console.WriteLine(dpt.EntityKey.IsTemporary);
				}
				catch (InvalidOperationException ex)
				{
					Console.WriteLine(ex.InnerException.Message);
				}
				catch (NotSupportedException ex)
				{
					Console.WriteLine(ex.InnerException.Message);
				}
		     }
            //</snippetDDL>
         }
    }

    #region partial methods
    //<snippetPartialClassMethod>
    public partial class SalesOrderHeader
    {
        // Update the order total.
        //<snippetUpdateOrderTotal>
        public void UpdateOrderTotal()
        {
            decimal newSubTotal = 0;

            // Ideally, this information is available in the EDM.
            decimal taxRatePercent = GetCurrentTaxRate();
            decimal freightPercent = GetCurrentFreight();

            // If the items for this order are loaded or if the order is
            // newly added, then recalculate the subtotal as it may have changed.
            if (this.SalesOrderDetails.IsLoaded ||
                EntityState == EntityState.Added)
            {
                foreach (SalesOrderDetail item in this.SalesOrderDetails)
                {
                    // Calculate line totals for loaded items.
                    newSubTotal += (item.OrderQty *
                        (item.UnitPrice - item.UnitPriceDiscount));
                }

                this.SubTotal = newSubTotal;
            }

            // Calculate the new tax amount.
            this.TaxAmt = this.SubTotal
                 + Decimal.Round((this.SubTotal * taxRatePercent / 100), 4);

            // Calculate the new freight amount.
            this.Freight = this.SubTotal
                + Decimal.Round((this.SubTotal * freightPercent / 100), 4);

            // Calculate the new total.
            this.TotalDue = this.SubTotal + this.TaxAmt + this.Freight;
        }
        //</snippetUpdateOrderTotal>
    }
    //</snippetPartialClassMethod>
    public partial class SalesOrderHeader
    {
        private static decimal GetCurrentTaxRate()
        {
            return 8.8m;
        }
        private static decimal GetCurrentFreight()
        {
            return 2.5m;
        }
    }
    //<snippetOnPropertyChange>
    public partial class SalesOrderDetail : EntityObject
    {
        partial void OnOrderQtyChanging(short value)
        {
            // Only handle this change for existing SalesOrderHeader
            // objects that are attached to an object context. If the item
            // is detached then we cannot access or load the related order.
            if (EntityState != EntityState.Detached)
            {
                try
                {
                    // Ensure that the referenced SalesOrderHeader is loaded.
                    if (!this.SalesOrderHeaderReference.IsLoaded)
                    {
                        this.SalesOrderHeaderReference.Load();
                    }

                    // Cancel the change if the order cannot be modified.
                    if (this.SalesOrderHeader.Status > 3)
                    {
                        throw new InvalidOperationException("The quantity cannot be changed "
                        + "or the item cannot be added because the order has either "
                        + "already been shipped or has been cancelled.");
                    }

                    // Log the pending order change.
                    File.AppendAllText(LogFile, "Quantity of item '"
                        + this.SalesOrderDetailID.ToString() + "' in order '"
                        + this.SalesOrderHeader.SalesOrderID.ToString()
                        + "' changing from '" + this.OrderQty.ToString()
                        + "' to '" + value.ToString() + "'." + Environment.NewLine
                        + "Change made by user: " + Environment.UserName
                        + Environment.NewLine);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("The quantity could not be changed "
                    + " because the order information could not be retrieved. "
                    + "The following error occurred:" + ex.Message);
                }
            }
        }
        partial void OnOrderQtyChanged()
        {
            // Only handle this change for existing SalesOrderHeader
            // objects that are attached to an object context.
            if (EntityState != EntityState.Detached)
            {
                try
                {
                    // Ensure that the SalesOrderDetail is loaded.
                    if (!SalesOrderHeaderReference.IsLoaded)
                    {
                        SalesOrderHeaderReference.Load();
                    }

                    // Reset the status for the order related to this item.
                    this.SalesOrderHeader.Status = 1;

                    // Log the completed order change.
                    File.AppendAllText(LogFile, "Quantity of item '"
                        + SalesOrderDetailID.ToString() + "' in order '"
                        + SalesOrderHeader.SalesOrderID.ToString()
                        + "' successfully changed to '" + OrderQty.ToString()
                        + "'." + Environment.NewLine
                        + "Change made by user: " + Environment.UserName
                        + Environment.NewLine);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("An error occurred; "
                    + "the data could be in an inconsistent state. "
                    + Environment.NewLine + ex.Message);
                }
            }
        }
    }
    //</snippetOnPropertyChange>

    //<snippetRelationshipChangeHandler>
    public partial class SalesOrderHeader
    {
        // SalesOrderHeader default constructor.
        public SalesOrderHeader()
        {
            // Register the handler for changes to the
            // shipping address (Address1) reference.
            this.AddressReference.AssociationChanged
                += new CollectionChangeEventHandler(ShippingAddress_Changed);
        }

        // AssociationChanged handler for the relationship
        // between the order and the shipping address.
        private void ShippingAddress_Changed(object sender,
            CollectionChangeEventArgs e)
        {
            // Check for a related reference being removed.
            if (e.Action == CollectionChangeAction.Remove)
            {
                // Check the order status and raise an exception if
                // the order can no longer be changed.
                if (this.Status > 3)
                {
                    throw new InvalidOperationException(
                        "The shipping address cannot "
                    + "be changed because the order has either "
                    + "already been shipped or has been cancelled.");
                }
                // Call the OnPropertyChanging method to raise the PropertyChanging event.
                // This event notifies client controls that the association is changing.
                this.OnPropertyChanging("Address1");
            }
            else if (e.Action == CollectionChangeAction.Add)
            {
                // Call the OnPropertyChanged method to raise the PropertyChanged event.
                // This event notifies client controls that the association has changed.
                this.OnPropertyChanged("Address1");
            }
        }
    }
    //</snippetRelationshipChangeHandler>
    public partial class SalesOrderDetail
    {
        // Define the log file in the program directory.
        public static string LogFile = "salesorderdetail.log";
    }

    //<snippetSavingChanges>
    public class AdventureWorksProxy
    {
        // Define the object context to be provided.
        private AdventureWorksEntities contextProxy =
            new AdventureWorksEntities();

        public AdventureWorksProxy()
        {
            // When the object is initialized, register the
            // handler for the SavingChanges event.
            contextProxy.SavingChanges
                += new EventHandler(context_SavingChanges);
        }

        // Method that provides an object context.
        public AdventureWorksEntities Context
        {
            get
            {
                return contextProxy;
            }
        }

        // SavingChanges event handler.
        private void context_SavingChanges(object sender, EventArgs e)
        {
            // Ensure that we are passed an ObjectContext
            ObjectContext context = sender as ObjectContext;
            if (context != null)
            {

                // Validate the state of each entity in the context
                // before SaveChanges can succeed.
                foreach (ObjectStateEntry entry in
                    context.ObjectStateManager.GetObjectStateEntries(
                    EntityState.Added | EntityState.Modified))
                {
                    // Find an object state entry for a SalesOrderHeader object.
                    if (!entry.IsRelationship && (entry.Entity.GetType() == typeof(SalesOrderHeader)))
                    {
                        SalesOrderHeader orderToCheck = entry.Entity as SalesOrderHeader;

                        // Call a helper method that performs string checking
                        // on the Comment property.
                        string textNotAllowed = Validator.CheckStringForLanguage(
                            orderToCheck.Comment);

                        // If the validation method returns a problem string, raise an error.
                        if (!string.IsNullOrEmpty(textNotAllowed))
                        {
                            throw new ArgumentException(String.Format("Changes cannot be "
                                + "saved because the {0} '{1}' object contains a "
                                + "string that is not allowed in the property '{2}'.",
                                entry.State, "SalesOrderHeader", "Comment"));
                        }
                    }
                }
            }
        }
    }
    //</snippetSavingChanges>
    public class Validator
    {
        public static string CheckStringForLanguage(string inputString)
        {
            //string invalid = "Some inappropriate comment.";
            string invalid = string.Empty;
            // Do the string checking here.
            return invalid;
        }
    }

    //<snippetOnContextCreated>
    public partial class AdventureWorksEntities
    {
        partial void OnContextCreated()
        {
            // Register the handler for the SavingChanges event.
            this.SavingChanges
                += new EventHandler(context_SavingChanges);
        }
        // SavingChanges event handler.
        private static void context_SavingChanges(object sender, EventArgs e)
        {
            // Validate the state of each entity in the context
            // before SaveChanges can succeed.
            foreach (ObjectStateEntry entry in
                ((ObjectContext)sender).ObjectStateManager.GetObjectStateEntries(
                EntityState.Added | EntityState.Modified))
            {
                // Find an object state entry for a SalesOrderHeader object.
                if (!entry.IsRelationship && (entry.Entity.GetType() == typeof(SalesOrderHeader)))
                {
                    SalesOrderHeader orderToCheck = entry.Entity as SalesOrderHeader;

                    // Call a helper method that performs string checking
                    // on the Comment property.
                    string textNotAllowed = Validator.CheckStringForLanguage(
                        orderToCheck.Comment);

                    // If the validation method returns a problem string, raise an error.
                    if (!string.IsNullOrEmpty(textNotAllowed))
                    {
                        throw new ArgumentException(String.Format("Changes cannot be "
                            + "saved because the {0} '{1}' object contains a "
                            + "string that is not allowed in the property '{2}'.",
                            entry.State, "SalesOrderHeader", "Comment"));
                    }
                }
            }
        }
    }
    //</snippetOnContextCreated>
    #endregion
    public class UpdateScenario
    {
        //<snippetFKUpdateService>
        static private StudentGrade GetOriginalValue(int ID)
        {
            StudentGrade originalItem;
            using (SchoolEntities context
                = new SchoolEntities())
            {
                originalItem =
                    context.StudentGrades.Where(g => g.EnrollmentID == ID).FirstOrDefault();

                context.Detach(originalItem);
            }
            return originalItem;
        }

        static private void SaveUpdates(StudentGrade updatedItem)
        {
            using (SchoolEntities context
                = new SchoolEntities())
            {
                // Query for the StudentGrade object with the specified ID.
                var original = (from o in context.StudentGrades
                                 where o.EnrollmentID == updatedItem.EnrollmentID
                                 select o).First();

                // Apply changes.
                context.StudentGrades.ApplyCurrentValues(updatedItem);

                // Save changes.
                context.SaveChanges();
            }
        }
        //</snippetFKUpdateService>

        static public void ManipulateObjects()
        {
            //<snippetFKUpdateClient>
            // A client calls a service to get the original object.
            StudentGrade studentGrade = GetOriginalValue(3);
            // Change the relationships.
            studentGrade.CourseID = 5;
            studentGrade.StudentID = 10;
            // The client calls a method on a service to save the updates.
            SaveUpdates(studentGrade);
            //</snippetFKUpdateClient>
        }
    }

    //<snippetEnableLazyLoad>
    class LazyLoading
    {
        public void EnableLazyLoading()
        {
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // You do not have to set context.ContextOptions.LazyLoadingEnabled to true
                // if you used the Entity Framework to generate the object layer.
                // The generated object context type sets lazy loading to true
                // in the constructor.
                context.ContextOptions.LazyLoadingEnabled = true;

                // Display ten contacts and select a contact
                var contacts = context.Contacts.Take(10);
                foreach (var c in contacts)
                    Console.WriteLine(c.ContactID);

                Console.WriteLine("Select a customer:");
                Int32 contactID = Convert.ToInt32(Console.ReadLine());

                // Get a specified customer by contact ID.
                var contact = context.Contacts.Where(c => c.ContactID == contactID).FirstOrDefault();

                // If lazy loading was not enabled no SalesOrderHeaders would be loaded for the contact.
                foreach (SalesOrderHeader order in contact.SalesOrderHeaders)
                {
                    Console.WriteLine($"SalesOrderID: {order.SalesOrderID} Order Date: {order.OrderDate} ");
                }
            }
        }
    }
    //</snippetEnableLazyLoad>
}
