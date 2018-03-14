//<snippetNamespaces>
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Data.EntityClient;
using AdventureWorksModel;
using System.Data.Metadata.Edm;
//</snippetNamespaces>
//<snippetIncludes>
using System.Data.Objects;
using System.Data.Objects.DataClasses;
//</snippetIncludes>
using System.Transactions;

namespace eSQLExamplesCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReturnEntityTypeWithObectQuery();
            //ParameterizedQueryWithObjectQuery();
            //NavRelationshipWithNavProperties();
            //GroupDataWithObjectQuery();
            //AggregateDataWithObjectQuery();
            //ReturnAnonymousTypeWithObjectQuery();
            //ReturnPrimitiveTypeWithObjectQuery();
            //OrderTwoUnionizedQueriesWithObjectQuery();
            //ESQLPagingWithObjectQuery();

           //BuildingConnectionStringWithEntityCommand();
           // ParameterizedQueryWithEntityCommand();
            //NavigateWithNavOperatorWithEntityCommand();
            //ReturnNestedCollectionWithEntityCommand();
            //StoredProcWithEntityCommand();
            //ExecuteStructuralTypeQuery(@"SELECT VALUE Product FROM AdventureWorksEntities.Product AS Product");
            //ExectueRefTypeQuery(@"SELECT REF(p) FROM AdventureWorksEntities.Product as p");
            //ExecutePrimitiveTypeQuery(@"SELECT VALUE AVG(p.ListPrice) FROM AdventureWorksEntities.Product as p");

        }

        static private void PolymorphicQuery()
        {
            //<snippetPolymorphicQuery>
            using (EntityConnection conn = new EntityConnection("name=SchoolEntities"))
            {
                conn.Open();
                // Create a query that specifies to 
                // get a collection of only Students
                // with enrollment dates from 
                // a collection of People.
                string esqlQuery = @"SELECT Student.LastName, 
                    Student.EnrollmentDate FROM 
                    OFTYPE(SchoolEntities.Person, 
                    SchoolModel.Student) AS Student";

                using (EntityCommand cmd = new EntityCommand(esqlQuery, conn))
                {
                    // Execute the command.
                    using (DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        // Start reading.
                        while (rdr.Read())
                        {
                            // Display student's last name and enrollment date.
                            Console.Write(rdr["LastName"] + " ");
                            Console.WriteLine(rdr["EnrollmentDate"]);
                        }
                    }
                }
            }
            //</snippetPolymorphicQuery>
        }


        static private void Transactions()
        {
            //<snippetTransactionsWithEntityClient>
            using (EntityConnection con = new EntityConnection("name=AdventureWorksEntities"))
            {
                con.Open();
                EntityTransaction transaction = con.BeginTransaction();
                DbCommand cmd = con.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = @"SELECT VALUE Contact FROM AdventureWorksEntities.Contact 
                    AS Contact WHERE Contact.LastName = 'Adams'";

                using (DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    // Iterate through the collection of Contact items.
                    while (rdr.Read())
                    {
                        Console.Write("First Name: "+ rdr["FirstName"]);
                        Console.WriteLine("\tLast Name: " + rdr["LastName"]);
                    }
                }
                transaction.Commit(); 
            }
            //</snippetTransactionsWithEntityClient>

        }


        static private void ComplexTypeWithEntityCommand()
        {
            //<snippetComplexTypeWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=CustomerComplexAddrContext"))
            {
                conn.Open();

                // Create a query that returns Address complex type.
                string esqlQuery =
                    @"SELECT VALUE customers FROM
                        CustomerComplexAddrContext.CCustomers
                        AS customers WHERE customers.CustomerId < 3";
                try
                {
                    // Create an EntityCommand.
                    using (EntityCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = esqlQuery;
                        // Execute the command.
                        using (EntityDataReader rdr =
                            cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                        {
                            // The result returned by this query contains 
                            // Address complex Types.
                            while (rdr.Read())
                            {
                                // Display CustomerID
                                Console.WriteLine("Customer ID: {0}",
                                    rdr["CustomerId"]);
                                // Display Address information.
                                DbDataRecord nestedRecord =
                                    rdr["Address"] as DbDataRecord;
                                Console.WriteLine("Address:");
                                for (int i = 0; i < nestedRecord.FieldCount; i++)
                                {
                                    Console.WriteLine("  " + nestedRecord.GetName(i) +
                                        ": " + nestedRecord.GetValue(i));
                                }
                            }
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            //</snippetComplexTypeWithEntityCommand>
        }

        static private void StoredProcWithEntityCommand()
        {
            //<snippetStoredProcWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();
                try
                {
                    // Create an EntityCommand.
                    using (EntityCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "AdventureWorksEntities.GetOrderDetails";
                        cmd.CommandType = CommandType.StoredProcedure;
                        EntityParameter param = new EntityParameter();
                        param.Value = "43659";
                        param.ParameterName = "SalesOrderHeaderId";
                        cmd.Parameters.Add(param);

                        // Execute the command.
                        using (EntityDataReader rdr =
                            cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                        {
                            // Read the results returned by the stored procedure.
                            while (rdr.Read())
                            {
                                Console.WriteLine("Header#: {0} " +
                                "Order#: {1} ProductID: {2} Quantity: {3} Price: {4}",
                                rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                            }
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            //</snippetStoredProcWithEntityCommand>
        }

        static private void BuildingConnectionStringWithEntityCommand()
        {
            //<snippetBuildingConnectionStringWithEntityCommand>

            // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            string serverName = ".";
            string databaseName = "AdventureWorks";

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/AdventureWorksModel.csdl|
                                        res://*/AdventureWorksModel.ssdl|
                                        res://*/AdventureWorksModel.msl";
            Console.WriteLine(entityBuilder.ToString());

            using (EntityConnection conn =
                new EntityConnection(entityBuilder.ToString()))
            {
                conn.Open();
                Console.WriteLine("Just testing the connection.");
                conn.Close();
            }
            //</snippetBuildingConnectionStringWithEntityCommand>
        }

        static private void ParameterizedQueryWithEntityCommand()
        {
            //<snippetParameterizedQueryWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();
                // Create a query that takes two parameters.
                string esqlQuery =
                    @"SELECT VALUE Contact FROM AdventureWorksEntities.Contact 
                                AS Contact WHERE Contact.LastName = @ln AND
                                Contact.FirstName = @fn";

                try
                {
                    using (EntityCommand cmd = new EntityCommand(esqlQuery, conn))
                    {
                        // Create two parameters and add them to 
                        // the EntityCommand's Parameters collection 
                        EntityParameter param1 = new EntityParameter();
                        param1.ParameterName = "ln";
                        param1.Value = "Adams";
                        EntityParameter param2 = new EntityParameter();
                        param2.ParameterName = "fn";
                        param2.Value = "Frances";

                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);

                        using (DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                        {
                            // Iterate through the collection of Contact items.
                            while (rdr.Read())
                            {
                                Console.WriteLine(rdr["FirstName"]);
                                Console.WriteLine(rdr["LastName"]);
                            }
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            //</snippetParameterizedQueryWithEntityCommand>
        }

        static private void NavigateWithNavOperatorWithEntityCommand()
        {
            //<snippetNavigateWithNavOperatorWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();
                try
                {
                    // Create an EntityCommand.
                    using (EntityCommand cmd = conn.CreateCommand())
                    {
                        // Create an Entity SQL query.
                        string esqlQuery =
                            @"SELECT address.AddressID, (SELECT VALUE DEREF(soh) FROM 
                          NAVIGATE(address, AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID) 
                          AS soh) FROM AdventureWorksEntities.Address AS address";

                        cmd.CommandText = esqlQuery;

                        // Execute the command.
                        using (DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                        {
                            // Start reading.
                            while (rdr.Read())
                            {
                                Console.WriteLine(rdr["AddressID"]);
                            }
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            //</snippetNavigateWithNavOperatorWithEntityCommand>
        }

        static private void ReturnNestedCollectionWithEntityCommand()
        {
            //<snippetReturnNestedCollectionWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();
                try
                {
                    // Create an EntityCommand.
                    using (EntityCommand cmd = conn.CreateCommand())
                    {
                        // Create a nested query.
                        string esqlQuery =
                            @"Select c.ContactID, c.SalesOrderHeader
                        From AdventureWorksEntities.Contact as c";

                        cmd.CommandText = esqlQuery;
                        // Execute the command.
                        using (EntityDataReader rdr =
                            cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                        {
                            // The result returned by this query contains 
                            // ContactID and a nested collection of SalesOrderHeader items.
                            // associated with this Contact.
                            while (rdr.Read())
                            {
                                // the first column contains Contact ID.
                                Console.WriteLine("Contact ID: {0}", rdr["ContactID"]);

                                // The second column contains a collection of SalesOrderHeader 
                                // items associated with the Contact.
                                DbDataReader nestedReader = rdr.GetDataReader(1);
                                while (nestedReader.Read())
                                {
                                    Console.WriteLine("   SalesOrderID: {0} ", nestedReader["SalesOrderID"]);
                                    Console.WriteLine("   OrderDate: {0} ", nestedReader["OrderDate"]);
                                }
                            }
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            //</snippetReturnNestedCollectionWithEntityCommand>
        }

        static private void ReturnEntityTypeWithObectQuery()
        {
            //<snippetReturnEntityTypeWithObectQuery>
            using (AdventureWorksEntities advWorksContext =
                new AdventureWorksEntities())
            {
                try
                {
                    string queryString =
                        @"SELECT VALUE Product FROM AdventureWorksEntities.Product AS Product";

                    ObjectQuery<Product> productQuery =
                        new ObjectQuery<Product>(queryString, advWorksContext, MergeOption.NoTracking);

                    // Iterate through the collection of Product items.
                    foreach (Product result in productQuery)
                        Console.WriteLine("Product Name: {0}; Product ID: {1}",
                            result.Name, result.ProductID);
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetReturnEntityTypeWithObectQuery>
        }

        static private void ParameterizedQueryWithObjectQuery()
        {
            //<snippetParameterizedQueryWithObjectQuery>
            using (AdventureWorksEntities advWorksContext =
                new AdventureWorksEntities())
            {
                try
                {
                    // Create a query that takes two parameters.
                    string queryString =
                        @"SELECT VALUE Contact FROM AdventureWorksEntities.Contact 
                                AS Contact WHERE Contact.LastName = @ln AND
                                Contact.FirstName = @fn";

                    ObjectQuery<Contact> contactQuery =
                        new ObjectQuery<Contact>(queryString, advWorksContext);

                    // Add parameters to the collection.
                    contactQuery.Parameters.Add(new ObjectParameter("ln", "Adams"));
                    contactQuery.Parameters.Add(new ObjectParameter("fn", "Frances"));

                    // Iterate through the collection of Contact items.
                    foreach (Contact result in contactQuery)
                        Console.WriteLine("Last Name: {0}; First Name: {1}",
                        result.LastName, result.FirstName);
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetParameterizedQueryWithObjectQuery>
        }

        static private void NavRelationshipWithNavProperties()
        {
            //<snippetNavRelationshipWithNavProperties>

            using (AdventureWorksEntities advWorksContext =
                new AdventureWorksEntities())
            {
                string esqlQuery = @"SELECT c.FirstName, c.SalesOrderHeader 
                    FROM AdventureWorksEntities.Contact AS c where c.LastName = 'Zhou'";

                try
                {
                    foreach (DbDataRecord rec in
                        new ObjectQuery<DbDataRecord>(esqlQuery, advWorksContext))
                    {

                        // Display contact's first name.
                        Console.WriteLine("First Name {0}: ", rec[0]);
                        List<SalesOrderHeader> list = rec[1] as List<SalesOrderHeader>;
                        // Display SalesOrderHeader information 
                        // associated with the contact.
                        foreach (SalesOrderHeader soh in list)
                        {
                            Console.WriteLine("   Order ID: {0}, Order date: {1}, Total Due: {2}",
                                soh.SalesOrderID, soh.OrderDate, soh.TotalDue);
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetNavRelationshipWithNavProperties>
        }

        static private void ReturnAnonymousTypeWithObjectQuery()
        {
            //<snippetReturnAnonymousTypeWithObjectQuery>
            using (AdventureWorksEntities advWorksContext =
                new AdventureWorksEntities())
            {
                string myQuery = @"SELECT p.ProductID, p.Name FROM 
                    AdventureWorksEntities.Product as p";
                try
                {
                    foreach (DbDataRecord rec in
                        new ObjectQuery<DbDataRecord>(myQuery, advWorksContext))
                    {
                        Console.WriteLine("ID {0}; Name {1}", rec[0], rec[1]);
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetReturnAnonymousTypeWithObjectQuery>
        }

        static private void ReturnPrimitiveTypeWithObjectQuery()
        {
            //<snippetReturnPrimitiveTypeWithObjectQuery>
            using (AdventureWorksEntities advWorksContext =
                new AdventureWorksEntities())
            {
                string queryString = @"SELECT VALUE Length(p.Name)FROM 
                AdventureWorksEntities.Product AS p";

                try
                {
                    ObjectQuery<Int32> productQuery =
                        new ObjectQuery<Int32>(queryString, advWorksContext, MergeOption.NoTracking);
                    foreach (Int32 result in productQuery)
                        Console.WriteLine("{0}", result);
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetReturnPrimitiveTypeWithObjectQuery>
        }
        static private void GroupDataWithObjectQuery()
        {
            //<snippetGroupDataWithObjectQuery>
            using (AdventureWorksEntities advWorksContext =
                new AdventureWorksEntities())
            {
                string esqlQuery = @"SELECT ln, 
                    (SELECT c1.LastName FROM AdventureWorksEntities.Contact 
                        AS c1 WHERE SUBSTRING(c1.LastName ,1,1) = ln) 
                    AS CONTACT 
                    FROM AdventureWorksEntities.CONTACT AS c2 GROUP BY SUBSTRING(c2.LastName ,1,1) AS ln
                    ORDER BY ln";
                try
                {
                    foreach (DbDataRecord rec in
                        new ObjectQuery<DbDataRecord>(esqlQuery, advWorksContext))
                    {
                        Console.WriteLine("Last names that start with the letter '{0}':",
                                    rec[0]);
                        List<DbDataRecord> list = rec[1] as List<DbDataRecord>;
                        foreach (DbDataRecord nestedRec in list)
                        {
                            for (int i = 0; i < nestedRec.FieldCount; i++)
                            {
                                Console.WriteLine("   {0} ", nestedRec[i]);
                            }
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetGroupDataWithObjectQuery>
        }

        static private void AggregateDataWithObjectQuery()
        {

            //<snippetAggregateDataWithObjectQuery>
            using (AdventureWorksEntities advWorksContext =
                new AdventureWorksEntities())
            {
                string esqlQuery = @"SELECT contactID, AVG(order.TotalDue) 
                                        FROM AdventureWorksEntities.SalesOrderHeader 
                                        AS order GROUP BY order.Contact.ContactID as contactID";

                try
                {
                    foreach (DbDataRecord rec in
                        new ObjectQuery<DbDataRecord>(esqlQuery, advWorksContext))
                    {
                        Console.WriteLine("ContactID = {0}  Average TotalDue = {1} ",
                            rec[0], rec[1]);
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetAggregateDataWithObjectQuery>
        }

        static private void OrderTwoUnionizedQueriesWithObjectQuery()
        {
            //<snippetOrderTwoUnionizedQueriesWithObjectQuery>
            using (AdventureWorksEntities advWorksContext =
                new AdventureWorksEntities())
            {
                String esqlQuery = @"SELECT P2.Name, P2.ListPrice
                    FROM ((SELECT P1.Name, P1.ProductID as Pid, P1.ListPrice 
                        FROM AdventureWorksEntities.Product as P1
                        where P1.Name like 'A%')
                    union all
                        (SELECT P1.Name, P1.ProductID as Pid, P1.ListPrice 
                        FROM AdventureWorksEntities.Product as P1
                        WHERE P1.Name like 'B%')
                    ) as P2
                    ORDER BY P2.Name";
                try
                {
                    foreach (DbDataRecord rec in
                        new ObjectQuery<DbDataRecord>(esqlQuery, advWorksContext))
                    {
                        Console.WriteLine("Name: {0}; ListPrice: {1}", rec[0], rec[1]);
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetOrderTwoUnionizedQueriesWithObjectQuery>
        }

        static private void ESQLPagingWithObjectQuery()
        {
            //<snippetESQLPagingWithObjectQuery>
            using (AdventureWorksEntities advWorksContext =
                new AdventureWorksEntities())
            {
                try
                {
                    // Create a query that takes two parameters.
                    string queryString =
                        @"SELECT VALUE product FROM 
                          AdventureWorksEntities.Product AS product 
                          order by product.ListPrice SKIP @skip LIMIT @limit";

                    ObjectQuery<Product> productQuery =
                        new ObjectQuery<Product>(queryString, advWorksContext);

                    // Add parameters to the collection.
                    productQuery.Parameters.Add(new ObjectParameter("skip", 3));
                    productQuery.Parameters.Add(new ObjectParameter("limit", 5));

                    // Iterate through the collection of Contact items.
                    foreach (Product result in productQuery)
                        Console.WriteLine("ID: {0}; Name: {1}",
                        result.ProductID, result.Name);
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            //</snippetESQLPagingWithObjectQuery>
        }

       
        //string esqlQuery = @"SELECT VALUE Product FROM AdventureWorksEntities.Product AS Product";
        //<snippeteSQLStructuralTypes>
        static void ExecuteStructuralTypeQuery(string esqlQuery)
        {
            if (esqlQuery.Length == 0)
            {
                Console.WriteLine("The query string is empty.");
                return;
            }

            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();

                try
                {
                    // Create an EntityCommand.
                    using (EntityCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = esqlQuery;
                        // Execute the command.
                        using (EntityDataReader rdr =
                            cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                        {
                            // Start reading results.
                            while (rdr.Read())
                            {
                                StructuralTypeVisitRecord(rdr as IExtendedDataRecord);
                            }
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
        }

        static void StructuralTypeVisitRecord(IExtendedDataRecord record)
        {
            int fieldCount = record.DataRecordInfo.FieldMetadata.Count;
            for (int fieldIndex = 0; fieldIndex < fieldCount; fieldIndex++)
            {
                Console.Write(record.GetName(fieldIndex) + ": ");

                // If the field is flagged as DbNull, the shape of the value is undetermined.
                // An attempt to get such a value may trigger an exception.
                if (record.IsDBNull(fieldIndex) == false)
                {
                    BuiltInTypeKind fieldTypeKind = record.DataRecordInfo.FieldMetadata[fieldIndex].
                        FieldType.TypeUsage.EdmType.BuiltInTypeKind;
                    // The EntityType, ComplexType and RowType are structural types
                    // that have members. 
                    // Read only the PrimitiveType members of this structural type.
                    if (fieldTypeKind == BuiltInTypeKind.PrimitiveType)
                    {
                        // Primitive types are surfaced as plain objects.
                        Console.WriteLine(record.GetValue(fieldIndex).ToString());
                    }
                }
            }
        }
        //</snippeteSQLStructuralTypes>
        
        
        //string esqlQuery = @"SELECT REF(p) FROM AdventureWorksEntities.Product as p";
        //<snippeteSQLRefTypes>
                static void ExectueRefTypeQuery(string esqlQuery)
                {
                    if (esqlQuery.Length == 0)
                    {
                        Console.WriteLine("The query string is empty.");
                        return;
                    }

                    using (EntityConnection conn =
                        new EntityConnection("name=AdventureWorksEntities"))
                    {
                        conn.Open();

                        try
                        {
                            // Create an EntityCommand.
                            using (EntityCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = esqlQuery;
                                // Execute the command.
                                using (EntityDataReader rdr =
                                    cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                                {
                                    // Start reading results.
                                    while (rdr.Read())
                                    {
                                        RefTypeVisitRecord(rdr as IExtendedDataRecord);
                                    }
                                }
                            }
                        }
                        catch (EntityException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        conn.Close();
                    }
                }

                static void RefTypeVisitRecord(IExtendedDataRecord record)
                {
                    // For RefType the record contains exactly one field.
                    int fieldIndex = 0;

                    // If the field is flagged as DbNull, the shape of the value is undetermined.
                    // An attempt to get such a value may trigger an exception.
                    if (record.IsDBNull(fieldIndex) == false)
                    {
                        BuiltInTypeKind fieldTypeKind = record.DataRecordInfo.FieldMetadata[fieldIndex].
                            FieldType.TypeUsage.EdmType.BuiltInTypeKind;
                        //read only fields that contain PrimitiveType
                        if (fieldTypeKind == BuiltInTypeKind.RefType)
                        {
                            // Ref types are surfaced as EntityKey instances. 
                            // The containing record sees them as atomic.
                            EntityKey key = record.GetValue(fieldIndex) as EntityKey;
                            // Get the EntitySet name.
                            Console.WriteLine("EntitySetName " + key.EntitySetName);
                            // Get the Name and the Value information of the EntityKey.
                            foreach (EntityKeyMember keyMember in key.EntityKeyValues)
                            {
                                Console.WriteLine("   Key Name: " + keyMember.Key);
                                Console.WriteLine("   Key Value: " + keyMember.Value);
                            }
                        }
                    }
                }
                //</snippeteSQLRefTypes>
        
        
                //string esqlQuery = @"SELECT VALUE AVG(p.ListPrice) FROM AdventureWorksEntities.Product as p";
                //<snippeteSQLPrimitiveTypes>
                static void ExecutePrimitiveTypeQuery(string esqlQuery)
                {
                    if (esqlQuery.Length == 0)
                    {
                        Console.WriteLine("The query string is empty.");
                        return;
                    }

                    using (EntityConnection conn =
                        new EntityConnection("name=AdventureWorksEntities"))
                    {
                        conn.Open();

                        try
                        {
                            // Create an EntityCommand.
                            using (EntityCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = esqlQuery;
                                // Execute the command.
                                using (EntityDataReader rdr =
                                    cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                                {
                                    // Start reading results.
                                    while (rdr.Read())
                                    {
                                        IExtendedDataRecord record = rdr as IExtendedDataRecord;
                                        // For PrimitiveType 
                                        // the record contains exactly one field.
                                        int fieldIndex = 0;
                                        Console.WriteLine("Value: " + record.GetValue(fieldIndex));
                                    }
                                }
                            }
                        }
                        catch (EntityException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        conn.Close();
                    }
                }
        //</snippeteSQLPrimitiveTypes>
         
    }
}
