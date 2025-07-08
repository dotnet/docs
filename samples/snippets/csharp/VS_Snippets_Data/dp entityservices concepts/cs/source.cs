//<snippetNamespaces>
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
//</snippetNamespaces>
using System.Data.Objects;
using System.Data.SqlClient;                                                                           

namespace Microsoft.Samples.Entity
{
    class Source
    {
        public static void GroupByPartition()
        {
            Console.WriteLine("Starting method 'GroupPartition'");
            //<snippetGroupByPartition>

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Query that returns average TotalDue for a contact.
                string queryString = @"SELECT TOP(@number1) contactID, AVG(GroupPartition(order.TotalDue))
                            FROM AdventureWorksEntities.SalesOrderHeaders
                            AS order GROUP BY order.Contact.ContactID as contactID";

                ObjectQuery<DbDataRecord> query1 = new ObjectQuery<DbDataRecord>(queryString, context);
                query1.Parameters.Add(new ObjectParameter("number1", 10));

                foreach (DbDataRecord rec in query1)
                {
                    Console.WriteLine($"ContactID = {rec[0]}  Average TotalDue = {rec[1]} ");
                }

                queryString = @"SELECT TOP(@number2) contactID, AVG(order.TotalDue)
                            FROM AdventureWorksEntities.SalesOrderHeaders
                            AS order GROUP BY order.Contact.ContactID as contactID";
                ObjectQuery<DbDataRecord> query2 = new ObjectQuery<DbDataRecord>(queryString, context);
                query2.Parameters.Add(new ObjectParameter("number2", 10));
                foreach (DbDataRecord rec in query2)
                {
                    Console.WriteLine($"ContactID = {rec[0]}  Average TotalDue = {rec[1]} ");
                }
            }
            //</snippetGroupByPartition>
        }
        public static void CallInlineFunction()
        {

            Console.WriteLine("Starting method 'CallInlineFunction'");
            //<snippetCallInlineFunction>
            // Query that calls the OrderTotal function to recalculate the order total.
            string queryString = @"USING Microsoft.Samples.Entity;
                FUNCTION OrderTotal(o SalesOrderHeader) AS
                (o.SubTotal + o.TaxAmt + o.Freight)

                SELECT [order].TotalDue AS currentTotal, OrderTotal([order]) AS calculated
                FROM AdventureWorksEntities.SalesOrderHeaders AS [order]
                WHERE [order].Contact.ContactID = @customer";

            int customerId = 364;

            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                ObjectQuery<DbDataRecord> query = new ObjectQuery<DbDataRecord>(queryString, context);
                query.Parameters.Add(new ObjectParameter("customer",customerId));

                foreach (DbDataRecord rec in query)
                {
                    Console.WriteLine("Order Total: Current - {0}, Calculated - {1}.",
                        rec[0], rec[1]);
                }
            }
            //</snippetCallInlineFunction>
        }
        static public void PolymorphicQuery()
        {
            //<snippetPolymorphicQuery>
            using (EntityConnection conn = new EntityConnection("name=SchoolEntities"))
            {
                conn.Open();
                // Create a query that specifies to
                // get a collection of only OnsiteCourses.

                string esqlQuery = @"SELECT VAlUE onsiteCourse FROM
                    OFTYPE(SchoolEntities.Courses, SchoolModel.OnsiteCourse)
                    AS onsiteCourse";
                using (EntityCommand cmd = new EntityCommand(esqlQuery, conn))
                {
                    // Execute the command.
                    using (DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        // Start reading.
                        while (rdr.Read())
                        {
                            // Display OnsiteCourse's location.
                            Console.WriteLine($"CourseID: {rdr["CourseID"]} ");
                            Console.WriteLine($"Location: {rdr["Location"]} ");
                        }
                    }
                }
            }
            //</snippetPolymorphicQuery>
        }

        static public void Transactions()
        {
            //<snippetTransactionsWithEntityClient>
            using (EntityConnection con = new EntityConnection("name=AdventureWorksEntities"))
            {
                con.Open();
                EntityTransaction transaction = con.BeginTransaction();
                DbCommand cmd = con.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = @"SELECT VALUE Contact FROM AdventureWorksEntities.Contacts
                    AS Contact WHERE Contact.LastName = @ln";
                EntityParameter param = new EntityParameter();
                param.ParameterName = "ln";
                param.Value = "Adams";
                cmd.Parameters.Add(param);

                using (DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    // Iterate through the collection of Contact items.
                    while (rdr.Read())
                    {
                        Console.Write("First Name: " + rdr["FirstName"]);
                        Console.WriteLine("\tLast Name: " + rdr["LastName"]);
                    }
                }
                transaction.Commit();
            }
            //</snippetTransactionsWithEntityClient>
        }

        static public void ComplexTypeWithEntityCommand()
        {
            //<snippetComplexTypeWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();

                string esqlQuery = @"SELECT VALUE contacts FROM
                        AdventureWorksEntities.Contacts AS contacts
                        WHERE contacts.ContactID == @id";

                // Create an EntityCommand.
                using (EntityCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = esqlQuery;
                    EntityParameter param = new EntityParameter();
                    param.ParameterName = "id";
                    param.Value = 3;
                    cmd.Parameters.Add(param);

                    // Execute the command.
                    using (EntityDataReader rdr =
                        cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        // The result returned by this query contains
                        // Address complex Types.
                        while (rdr.Read())
                        {
                            // Display CustomerID
                            Console.WriteLine($"Contact ID: {rdr["ContactID"]}");
                            // Display Address information.
                            DbDataRecord nestedRecord =
                                rdr["EmailPhoneComplexProperty"] as DbDataRecord;
                            Console.WriteLine("Email and Phone Info:");
                            for (int i = 0; i < nestedRecord.FieldCount; i++)
                            {
                                Console.WriteLine("  " + nestedRecord.GetName(i) +
                                    ": " + nestedRecord.GetValue(i));
                            }
                        }
                    }
                }
                conn.Close();
            }
            //</snippetComplexTypeWithEntityCommand>
        }

        static public void StoredProcWithEntityCommand()
        {
            //<snippetStoredProcWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=SchoolEntities"))
            {
                conn.Open();
                // Create an EntityCommand.
                using (EntityCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SchoolEntities.GetStudentGrades";
                    cmd.CommandType = CommandType.StoredProcedure;
                    EntityParameter param = new EntityParameter();
                    param.Value = 2;
                    param.ParameterName = "StudentID";
                    cmd.Parameters.Add(param);

                    // Execute the command.
                    using (EntityDataReader rdr =
                        cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        // Read the results returned by the stored procedure.
                        while (rdr.Read())
                        {
                            Console.WriteLine($"ID: {rdr["StudentID"]} Grade: {rdr["Grade"]}");
                        }
                    }
                }
                conn.Close();
            }
            //</snippetStoredProcWithEntityCommand>
        }

        static public void BuildingConnectionStringWithEntityCommand()
        {
            throw new NotImplementedException();
        }

        static public void ParameterizedQueryWithEntityCommand()
        {
            //<snippetParameterizedQueryWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();
                // Create a query that takes two parameters.
                string esqlQuery =
                    @"SELECT VALUE Contact FROM AdventureWorksEntities.Contacts
                                AS Contact WHERE Contact.LastName = @ln AND
                                Contact.FirstName = @fn";

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
                conn.Close();
            }
            //</snippetParameterizedQueryWithEntityCommand>
        }

        static public void NavigateWithNavOperatorWithEntityCommand()
        {
            //<snippetNavigateWithNavOperatorWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();
                // Create an EntityCommand.
                using (EntityCommand cmd = conn.CreateCommand())
                {
                    // Create an Entity SQL query.
                    string esqlQuery =
                        @"SELECT address.AddressID, (SELECT VALUE DEREF(soh) FROM
                      NAVIGATE(address, AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID)
                      AS soh) FROM AdventureWorksEntities.Addresses AS address";

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
                conn.Close();
            }
            //</snippetNavigateWithNavOperatorWithEntityCommand>
        }

        static public void ReturnNestedCollectionWithEntityCommand()
        {
            //<snippetReturnNestedCollectionWithEntityCommand>
            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();
                // Create an EntityCommand.
                using (EntityCommand cmd = conn.CreateCommand())
                {
                    // Create a nested query.
                    string esqlQuery =
                        @"Select c.ContactID, c.SalesOrderHeaders
                    From AdventureWorksEntities.Contacts as c";

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
                            Console.WriteLine($"Contact ID: {rdr["ContactID"]}");

                            // The second column contains a collection of SalesOrderHeader
                            // items associated with the Contact.
                            DbDataReader nestedReader = rdr.GetDataReader(1);
                            while (nestedReader.Read())
                            {
                                Console.WriteLine($"   SalesOrderID: {nestedReader["SalesOrderID"]} ");
                                Console.WriteLine($"   OrderDate: {nestedReader["OrderDate"]} ");
                            }
                        }
                    }
                }
                conn.Close();
            }
            //</snippetReturnNestedCollectionWithEntityCommand>
        }

        static public void ReturnEntityTypeWithObjectQuery()
        {
            //<snippetQueryEntityTypeCollection>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string esqlQuery = @"SELECT VALUE Contact
                    FROM AdventureWorksEntities.Contacts as Contact where Contact.LastName = @ln";

                // The following query returns a collection of Contact objects.
                ObjectQuery<Contact> query = new ObjectQuery<Contact>(esqlQuery, context, MergeOption.NoTracking);
                query.Parameters.Add(new ObjectParameter("ln", "Zhou"));

                // Iterate through the collection of Contact items.
                foreach (Contact result in query)
                    Console.WriteLine($"Contact First Name: {result.FirstName}; Last Name: {result.LastName}");
            }
            //</snippetQueryEntityTypeCollection>
        }

        static public void ParameterizedQueryWithObjectQuery()
        {
            //<snippetParameterizedQueryWithObjectQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Create a query that takes two parameters.
                string queryString =
                    @"SELECT VALUE Contact FROM AdventureWorksEntities.Contacts
                            AS Contact WHERE Contact.LastName = @ln AND
                            Contact.FirstName = @fn";

                ObjectQuery<Contact> contactQuery =
                    new ObjectQuery<Contact>(queryString, context);

                // Add parameters to the collection.
                contactQuery.Parameters.Add(new ObjectParameter("ln", "Adams"));
                contactQuery.Parameters.Add(new ObjectParameter("fn", "Frances"));

                // Iterate through the collection of Contact items.
                foreach (Contact result in contactQuery)
                    Console.WriteLine($"Last Name: {result.LastName}; First Name: {result.FirstName}");
            }
            //</snippetParameterizedQueryWithObjectQuery>
        }

        static public void NavRelationshipWithNavProperties()
        {
            //<snippetNavRelationshipWithNavProperties>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string esqlQuery = @"SELECT c.FirstName, c.SalesOrderHeaders
                    FROM AdventureWorksEntities.Contacts AS c where c.LastName = @ln";
                ObjectQuery<DbDataRecord> query = new ObjectQuery<DbDataRecord>(esqlQuery, context);
                query.Parameters.Add(new ObjectParameter("ln", "Zhou"));

                foreach (DbDataRecord rec in query)
                {

                    // Display contact's first name.
                    Console.WriteLine($"First Name {rec[0]}: ");
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
            //</snippetNavRelationshipWithNavProperties>
        }

        static public void ReturnAnonymousTypeWithObjectQuery()
        {
            //<snippetReturnAnonymousTypeWithObjectQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string myQuery = @"SELECT p.ProductID, p.Name FROM
                    AdventureWorksEntities.Products as p";

                foreach (DbDataRecord rec in
                    new ObjectQuery<DbDataRecord>(myQuery, context))
                {
                    Console.WriteLine($"ID {rec[0]}; Name {rec[1]}");
                }
            }
            //</snippetReturnAnonymousTypeWithObjectQuery>
        }

        static public void ReturnPrimitiveTypeWithObjectQuery()
        {
            //<snippetReturnPrimitiveTypeWithObjectQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string queryString = @"SELECT VALUE Length(p.Name)FROM
                AdventureWorksEntities.Products AS p";

                ObjectQuery<Int32> productQuery =
                    new ObjectQuery<Int32>(queryString, context, MergeOption.NoTracking);
                foreach (Int32 result in productQuery)
                    Console.WriteLine($"{result}");
            }
            //</snippetReturnPrimitiveTypeWithObjectQuery>
        }
        static public void GroupDataWithObjectQuery()
        {
            //<snippetGroupDataWithObjectQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string esqlQuery = @"SELECT ln,
                    (SELECT c1.LastName FROM AdventureWorksEntities.Contacts
                        AS c1 WHERE SUBSTRING(c1.LastName ,1,1) = ln)
                    AS CONTACT
                    FROM AdventureWorksEntities.Contacts AS c2 GROUP BY SUBSTRING(c2.LastName ,1,1) AS ln
                    ORDER BY ln";

                foreach (DbDataRecord rec in
                    new ObjectQuery<DbDataRecord>(esqlQuery, context))
                {
                    Console.WriteLine($"Last names that start with the letter '{rec[0]}':");
                    List<DbDataRecord> list = rec[1] as List<DbDataRecord>;
                    foreach (DbDataRecord nestedRec in list)
                    {
                        for (int i = 0; i < nestedRec.FieldCount; i++)
                        {
                            Console.WriteLine($"   {nestedRec[i]} ");
                        }
                    }
                }
            }
            //</snippetGroupDataWithObjectQuery>
        }

        static public void AggregateDataWithObjectQuery()
        {

            //<snippetAggregateDataWithObjectQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                string esqlQuery = @"SELECT contactID, AVG(order.TotalDue)
                                        FROM AdventureWorksEntities.SalesOrderHeaders
                                        AS order GROUP BY order.Contact.ContactID as contactID";

                foreach (DbDataRecord rec in
                    new ObjectQuery<DbDataRecord>(esqlQuery, context))
                {
                    Console.WriteLine($"ContactID = {rec[0]}  Average TotalDue = {rec[1]} ");
                }
            }
            //</snippetAggregateDataWithObjectQuery>
        }

        static public void OrderTwoUnionizedQueriesWithObjectQuery()
        {
            //<snippetOrderTwoUnionizedQueriesWithObjectQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                String esqlQuery = @"SELECT P2.Name, P2.ListPrice
                    FROM ((SELECT P1.Name, P1.ProductID as Pid, P1.ListPrice
                        FROM AdventureWorksEntities.Products as P1
                        where P1.Name like 'A%')
                    union all
                        (SELECT P1.Name, P1.ProductID as Pid, P1.ListPrice
                        FROM AdventureWorksEntities.Products as P1
                        WHERE P1.Name like 'B%')
                    ) as P2
                    ORDER BY P2.Name";

                foreach (DbDataRecord rec in
                    new ObjectQuery<DbDataRecord>(esqlQuery, context))
                {
                    Console.WriteLine($"Name: {rec[0]}; ListPrice: {rec[1]}");
                }
            }
            //</snippetOrderTwoUnionizedQueriesWithObjectQuery>
        }

        static public void ESQLPagingWithObjectQuery()
        {
            //<snippetESQLPagingWithObjectQuery>
            using (AdventureWorksEntities context =
                new AdventureWorksEntities())
            {
                // Create a query that takes two parameters.
                string queryString =
                    @"SELECT VALUE product FROM
                      AdventureWorksEntities.Products AS product
                      order by product.ListPrice SKIP @skip LIMIT @limit";

                ObjectQuery<Product> productQuery =
                    new ObjectQuery<Product>(queryString, context);

                // Add parameters to the collection.
                productQuery.Parameters.Add(new ObjectParameter("skip", 3));
                productQuery.Parameters.Add(new ObjectParameter("limit", 5));

                // Iterate through the collection of Contact items.
                foreach (Product result in productQuery)
                    Console.WriteLine($"ID: {result.ProductID}; Name: {result.Name}");
            }
            //</snippetESQLPagingWithObjectQuery>
        }

        //string esqlQuery = @"SELECT VALUE Product FROM AdventureWorksEntities.Products AS Product";
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

        //string esqlQuery = @"SELECT REF(p) FROM AdventureWorksEntities.Products as p";
        //<snippeteSQLRefTypes>
        static public void ExecuteRefTypeQuery(string esqlQuery)
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

        //string esqlQuery = @"SELECT VALUE AVG(p.ListPrice) FROM AdventureWorksEntities.Products as p";
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
                conn.Close();
            }
        }
        //</snippeteSQLPrimitiveTypes>

        public static void TestESQL()
        {
            EntitySQL.TestEntitySQL();
        }
    }
}
