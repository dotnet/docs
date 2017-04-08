'<snippetNamespaces> 
Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.EntityClient
Imports System.Data.Metadata.Edm
'</snippetNamespaces> 
'<snippetIncludes> 
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
'</snippetIncludes> 


Class Source
    Public Shared Sub GroupByPartition()
        Console.WriteLine("Starting method 'GroupPartition'")
        '<snippetGroupByPartition> 

        Using context As New AdventureWorksEntities()
            ' Query that returns average TotalDue for a contact. 
            Dim queryString As String = "SELECT TOP(@number1) contactID, AVG(GroupPartition(order.TotalDue)) " & _
                " FROM AdventureWorksEntities.SalesOrderHeaders " & _
                " AS order GROUP BY order.Contact.ContactID as contactID"

            Dim query1 = New ObjectQuery(Of DbDataRecord)(queryString, context)
            query1.Parameters.Add(New ObjectParameter("number1", 10))

            For Each rec As DbDataRecord In query1
                Console.WriteLine("ContactID = {0} Average TotalDue = {1} ", rec(0), rec(1))
            Next

            queryString = "SELECT TOP(@number2) contactID, AVG(order.TotalDue) " & _
                " FROM AdventureWorksEntities.SalesOrderHeaders " & _
                " AS order GROUP BY order.Contact.ContactID as contactID"
            Dim query2 = New ObjectQuery(Of DbDataRecord)(queryString, context)
            query2.Parameters.Add(New ObjectParameter("number2", 10))

            For Each rec As DbDataRecord In query2
                Console.WriteLine("ContactID = {0} Average TotalDue = {1} ", rec(0), rec(1))
            Next
        End Using
        '</snippetGroupByPartition> 
    End Sub
    Public Shared Sub CallInlineFunction()

        Console.WriteLine("Starting method 'CallInlineFunction'")
        '<snippetCallInlineFunction> 
        ' Query that calls the OrderTotal function to recalculate the order total. 
        Dim queryString As String = "USING Microsoft.Samples.Entity;" & _
            " FUNCTION OrderTotal(o SalesOrderHeader) AS (o.SubTotal + o.TaxAmt + o.Freight)" & _
            " SELECT order.TotalDue AS currentTotal, OrderTotal(order) AS calculated" & _
            " FROM AdventureWorksEntities.SalesOrderHeaders AS order WHERE order.Contact.ContactID = @customer"

        Dim customerId As Integer = 364


        Using context As New AdventureWorksEntities()
            Dim query As New ObjectQuery(Of DbDataRecord)(queryString, context)
            query.Parameters.Add(New ObjectParameter("customer", customerId))

            For Each rec As DbDataRecord In query
                Console.WriteLine("Order Total: Current - {0}, Calculated - {1}.", rec(0), rec(1))
            Next
        End Using
        '</snippetCallInlineFunction> 
    End Sub
    Public Shared Sub PolymorphicQuery()
        '<snippetPolymorphicQuery> 
        Using conn As New EntityConnection("name=SchoolEntities")
            conn.Open()
            ' Create a query that specifies to 
            ' get a collection of only OnsiteCourses. 

            Dim esqlQuery As String = "SELECT VAlUE onsiteCourse FROM " & _
                "OFTYPE(SchoolEntities.Courses, SchoolModel.OnsiteCourse) AS onsiteCourse"
            Using cmd As New EntityCommand(esqlQuery, conn)
                ' Execute the command. 
                Using rdr As DbDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' Start reading. 
                    While rdr.Read()
                        ' Display OnsiteCourse's location. 
                        Console.WriteLine("CourseID: {0} ", rdr("CourseID"))
                        Console.WriteLine("Location: {0} ", rdr("Location"))
                    End While
                End Using
            End Using
        End Using
        '</snippetPolymorphicQuery> 
    End Sub


    Public Shared Sub Transactions()
        '<snippetTransactionsWithEntityClient> 
        Using con As New EntityConnection("name=AdventureWorksEntities")
            con.Open()
            Dim transaction As EntityTransaction = con.BeginTransaction()
            Dim cmd As DbCommand = con.CreateCommand()
            cmd.Transaction = transaction
            cmd.CommandText = "SELECT VALUE Contact FROM AdventureWorksEntities.Contacts " & _
                " AS Contact WHERE Contact.LastName = @ln"
            Dim param As New EntityParameter()
            param.ParameterName = "ln"
            param.Value = "Adams"
            cmd.Parameters.Add(param)

            Using rdr As DbDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                ' Iterate through the collection of Contact items. 
                While rdr.Read()
                    Console.Write("First Name: " & rdr("FirstName"))
                    Console.WriteLine(vbTab & "Last Name: " & rdr("LastName"))
                End While
            End Using
            transaction.Commit()
        End Using
        '</snippetTransactionsWithEntityClient> 
    End Sub


    Public Shared Sub ComplexTypeWithEntityCommand()
        '<snippetComplexTypeWithEntityCommand> 
        Using conn As New EntityConnection("name=AdventureWorksEntities")
            conn.Open()

            Dim esqlQuery As String = "SELECT VALUE contacts FROM" & _
                " AdventureWorksEntities.Contacts AS contacts WHERE contacts.ContactID == @id"

            ' Create an EntityCommand. 
            Using cmd As EntityCommand = conn.CreateCommand()
                cmd.CommandText = esqlQuery
                Dim param As New EntityParameter()
                param.ParameterName = "id"
                param.Value = 3
                cmd.Parameters.Add(param)
                ' Execute the command. 
                Using rdr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' The result returned by this query contains 
                    ' Address complex Types. 
                    While rdr.Read()
                        ' Display CustomerID 
                        Console.WriteLine("Contact ID: {0}", rdr("ContactID"))
                        ' Display Address information. 
                        Dim nestedRecord As DbDataRecord = TryCast(rdr("EmailPhoneComplexProperty"), DbDataRecord)
                        Console.WriteLine("Email and Phone Info:")
                        For i As Integer = 0 To nestedRecord.FieldCount - 1
                            Console.WriteLine((" " & nestedRecord.GetName(i) & ": ") + nestedRecord.GetValue(i))
                        Next
                    End While
                End Using
            End Using
            conn.Close()
        End Using
        '</snippetComplexTypeWithEntityCommand> 
    End Sub

    Public Shared Sub StoredProcWithEntityCommand()
        '<snippetStoredProcWithEntityCommand> 
        Using conn As New EntityConnection("name=SchoolEntities")
            conn.Open()
            ' Create an EntityCommand. 
            Using cmd As EntityCommand = conn.CreateCommand()
                cmd.CommandText = "SchoolEntities.GetStudentGrades"
                cmd.CommandType = CommandType.StoredProcedure
                Dim param As New EntityParameter()
                param.Value = 2
                param.ParameterName = "StudentID"
                cmd.Parameters.Add(param)

                ' Execute the command. 
                Using rdr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' Read the results returned by the stored procedure. 
                    While rdr.Read()
                        Console.WriteLine("ID: {0} Grade: {1}", rdr("StudentID"), rdr("Grade"))
                    End While
                End Using
            End Using
            conn.Close()
        End Using
        '</snippetStoredProcWithEntityCommand> 
    End Sub

    Public Shared Sub BuildingConnectionStringWithEntityCommand()
        '<snippetBuildingConnectionStringWithEntityCommand> 

        ' Specify the provider name, server and database. 
        Dim providerName As String = "System.Data.SqlClient"
        Dim serverName As String = "."
        Dim databaseName As String = "AdventureWorks"

        ' Initialize the connection string builder for the 
        ' underlying provider. 
        Dim sqlBuilder As New SqlConnectionStringBuilder()

        ' Set the properties for the data source. 
        sqlBuilder.DataSource = serverName
        sqlBuilder.InitialCatalog = databaseName
        sqlBuilder.IntegratedSecurity = True

        ' Build the SqlConnection connection string. 
        Dim providerString As String = sqlBuilder.ToString()

        ' Initialize the EntityConnectionStringBuilder. 
        Dim entityBuilder As New EntityConnectionStringBuilder()

        'Set the provider name. 
        entityBuilder.Provider = providerName

        ' Set the provider-specific connection string. 
        entityBuilder.ProviderConnectionString = providerString

        ' Set the Metadata location. 
        entityBuilder.Metadata = "res://*/AdventureWorksModel.csdl|res://*/AdventureWorksModel.ssdl|res://*/AdventureWorksModel.msl"
        Console.WriteLine(entityBuilder.ToString())

        Using conn As New EntityConnection(entityBuilder.ToString())
            conn.Open()
            Console.WriteLine("Just testing the connection.")
            conn.Close()
        End Using
        '</snippetBuildingConnectionStringWithEntityCommand> 
    End Sub

    Public Shared Sub ParameterizedQueryWithEntityCommand()
        '<snippetParameterizedQueryWithEntityCommand> 
        Using conn As New EntityConnection("name=AdventureWorksEntities")
            conn.Open()
            ' Create a query that takes two parameters. 
            Dim esqlQuery As String = "SELECT VALUE Contact FROM AdventureWorksEntities.Contacts " & _
                " AS Contact WHERE Contact.LastName = @ln AND Contact.FirstName = @fn"

            Using cmd As New EntityCommand(esqlQuery, conn)
                ' Create two parameters and add them to 
                ' the EntityCommand's Parameters collection 
                Dim param1 As New EntityParameter()
                param1.ParameterName = "ln"
                param1.Value = "Adams"
                Dim param2 As New EntityParameter()
                param2.ParameterName = "fn"
                param2.Value = "Frances"

                cmd.Parameters.Add(param1)
                cmd.Parameters.Add(param2)

                Using rdr As DbDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' Iterate through the collection of Contact items. 
                    While rdr.Read()
                        Console.WriteLine(rdr("FirstName"))
                        Console.WriteLine(rdr("LastName"))
                    End While
                End Using
            End Using
            conn.Close()
        End Using
        '</snippetParameterizedQueryWithEntityCommand> 
    End Sub

    Public Shared Sub NavigateWithNavOperatorWithEntityCommand()
        '<snippetNavigateWithNavOperatorWithEntityCommand> 
        Using conn As New EntityConnection("name=AdventureWorksEntities")
            conn.Open()
            ' Create an EntityCommand. 
            Using cmd As EntityCommand = conn.CreateCommand()
                ' Create an Entity SQL query. 
                Dim esqlQuery As String = "SELECT address.AddressID, (SELECT VALUE DEREF(soh) FROM " & _
                    " NAVIGATE(address, AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID) " & _
                    " AS soh) FROM AdventureWorksEntities.Addresses AS address"


                cmd.CommandText = esqlQuery

                ' Execute the command. 
                Using rdr As DbDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' Start reading. 
                    While rdr.Read()
                        Console.WriteLine(rdr("AddressID"))
                    End While
                End Using
            End Using
            conn.Close()
        End Using
        '</snippetNavigateWithNavOperatorWithEntityCommand> 
    End Sub

    Public Shared Sub ReturnNestedCollectionWithEntityCommand()
        '<snippetReturnNestedCollectionWithEntityCommand> 
        Using conn As New EntityConnection("name=AdventureWorksEntities")
            conn.Open()
            ' Create an EntityCommand. 
            Using cmd As EntityCommand = conn.CreateCommand()
                ' Create a nested query. 
                Dim esqlQuery As String = "Select c.ContactID, c.SalesOrderHeaders" & _
                    " From AdventureWorksEntities.Contacts as c"

                cmd.CommandText = esqlQuery
                ' Execute the command. 
                Using rdr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' The result returned by this query contains 
                    ' ContactID and a nested collection of SalesOrderHeader items. 
                    ' associated with this Contact. 
                    While rdr.Read()
                        ' the first column contains Contact ID. 
                        Console.WriteLine("Contact ID: {0}", rdr("ContactID"))

                        ' The second column contains a collection of SalesOrderHeader 
                        ' items associated with the Contact. 
                        Dim nestedReader As DbDataReader = rdr.GetDataReader(1)
                        While nestedReader.Read()
                            Console.WriteLine(" SalesOrderID: {0} ", nestedReader("SalesOrderID"))
                            Console.WriteLine(" OrderDate: {0} ", nestedReader("OrderDate"))
                        End While
                    End While
                End Using
            End Using
            conn.Close()
        End Using
        '</snippetReturnNestedCollectionWithEntityCommand> 
    End Sub

    Public Shared Sub ReturnEntityTypeWithObectQuery()
        '<snippetQueryEntityTypeCollection> 
        Using context As New AdventureWorksEntities()

            Dim esqlString As String = "SELECT VALUE Contact " & _
                "FROM AdventureWorksEntities.Contacts as Contact where Contact.LastName = @ln"

            Dim query As New ObjectQuery(Of Contact)(esqlString, context, MergeOption.NoTracking)
            query.Parameters.Add(New ObjectParameter("ln", "Zhou"))

            ' Iterate through the collection of Contact items. 
            For Each result As Contact In query
                Console.WriteLine("Contact First Name: {0}; Last Name: {1}", _
                        result.FirstName, result.LastName)
            Next
        End Using
        '</snippetQueryEntityTypeCollection> 
    End Sub

    Public Shared Sub ParameterizedQueryWithObjectQuery()
        '<snippetParameterizedQueryWithObjectQuery> 
        Using context As New AdventureWorksEntities()
            ' Create a query that takes two parameters. 
            Dim queryString As String = "SELECT VALUE Contact FROM AdventureWorksEntities.Contacts " & _
                " AS Contact WHERE Contact.LastName = @ln AND Contact.FirstName = @fn"

            Dim contactQuery As New ObjectQuery(Of Contact)(queryString, context)

            ' Add parameters to the collection. 
            contactQuery.Parameters.Add(New ObjectParameter("ln", "Adams"))
            contactQuery.Parameters.Add(New ObjectParameter("fn", "Frances"))

            ' Iterate through the collection of Contact items. 
            For Each result As Contact In contactQuery
                Console.WriteLine("Last Name: {0}; First Name: {1}", result.LastName, result.FirstName)
            Next
        End Using
        '</snippetParameterizedQueryWithObjectQuery> 
    End Sub

    Public Shared Sub NavRelationshipWithNavProperties()
        '<snippetNavRelationshipWithNavProperties> 

        Using context As New AdventureWorksEntities()
            Dim esqlQuery As String = "SELECT c.FirstName, c.SalesOrderHeaders " & _
                " FROM AdventureWorksEntities.Contacts AS c where c.LastName = @ln"

            Dim query As New ObjectQuery(Of DbDataRecord)(esqlQuery, context)

            ' Add parameters to the collection. 
            query.Parameters.Add(New ObjectParameter("ln", "Zhou"))

            For Each rec As DbDataRecord In query

                ' Display contact's first name. 
                Console.WriteLine("First Name {0}: ", rec(0))
                Dim list As List(Of SalesOrderHeader) = TryCast(rec(1), List(Of SalesOrderHeader))
                ' Display SalesOrderHeader information 
                ' associated with the contact. 
                For Each soh As SalesOrderHeader In list
                    Console.WriteLine(" Order ID: {0}, Order date: {1}, Total Due: {2}",
                                      soh.SalesOrderID, soh.OrderDate, soh.TotalDue)
                Next
            Next
        End Using
        '</snippetNavRelationshipWithNavProperties> 
    End Sub

    Public Shared Sub ReturnAnonymousTypeWithObjectQuery()
        '<snippetReturnAnonymousTypeWithObjectQuery> 
        Using context As New AdventureWorksEntities()
            Dim myQuery As String = "SELECT p.ProductID, p.Name FROM AdventureWorksEntities.Products as p"
            For Each rec As DbDataRecord In New ObjectQuery(Of DbDataRecord)(myQuery, context)
                Console.WriteLine("ID {0}; Name {1}", rec(0), rec(1))
            Next
        End Using
        '</snippetReturnAnonymousTypeWithObjectQuery> 
    End Sub

    Public Shared Sub ReturnPrimitiveTypeWithObjectQuery()
        '<snippetReturnPrimitiveTypeWithObjectQuery> 
        Using context As New AdventureWorksEntities()
            Dim queryString As String = "SELECT VALUE Length(p.Name)FROM AdventureWorksEntities.Products AS p"

            Dim productQuery As New ObjectQuery(Of Int32)(queryString, context, MergeOption.NoTracking)
            For Each result As Int32 In productQuery
                Console.WriteLine("{0}", result)
            Next
        End Using
        '</snippetReturnPrimitiveTypeWithObjectQuery> 
    End Sub
    Public Shared Sub GroupDataWithObjectQuery()
        '<snippetGroupDataWithObjectQuery> 
        Using context As New AdventureWorksEntities()
            Dim esqlQuery As String = "SELECT ln, (SELECT c1.LastName FROM AdventureWorksEntities.Contacts " & _
                " AS c1 WHERE SUBSTRING(c1.LastName ,1,1) = ln) AS CONTACT FROM AdventureWorksEntities.Contacts AS c2 " & _
                " GROUP BY SUBSTRING(c2.LastName ,1,1) AS ln ORDER BY ln"

            For Each rec As DbDataRecord In New ObjectQuery(Of DbDataRecord)(esqlQuery, context)
                Console.WriteLine("Last names that start with the letter '{0}':", rec(0))
                Dim list As List(Of DbDataRecord) = TryCast(rec(1), List(Of DbDataRecord))
                For Each nestedRec As DbDataRecord In list
                    For i As Integer = 0 To nestedRec.FieldCount - 1
                        Console.WriteLine(" {0} ", nestedRec(i))
                    Next
                Next
            Next
        End Using
        '</snippetGroupDataWithObjectQuery> 
    End Sub

    Public Shared Sub AggregateDataWithObjectQuery()

        '<snippetAggregateDataWithObjectQuery> 
        Using context As New AdventureWorksEntities()
            Dim esqlQuery As String = "SELECT contactID, AVG(order.TotalDue) FROM AdventureWorksEntities.SalesOrderHeaders " & _
                " AS order GROUP BY order.Contact.ContactID as contactID"

            For Each rec As DbDataRecord In New ObjectQuery(Of DbDataRecord)(esqlQuery, context)
                Console.WriteLine("ContactID = {0} Average TotalDue = {1} ", rec(0), rec(1))
            Next
        End Using
        '</snippetAggregateDataWithObjectQuery> 
    End Sub

    Public Shared Sub OrderTwoUnionizedQueriesWithObjectQuery()
        '<snippetOrderTwoUnionizedQueriesWithObjectQuery> 
        Using context As New AdventureWorksEntities()
            Dim esqlQuery As String = "SELECT P2.Name, P2.ListPrice FROM ((SELECT P1.Name, P1.ProductID as Pid, P1.ListPrice " & _
                " FROM AdventureWorksEntities.Products as P1 where P1.Name like 'A%') union all" & _
                " (SELECT P1.Name, P1.ProductID as Pid, P1.ListPrice FROM AdventureWorksEntities.Products as P1" & _
                " WHERE P1.Name like 'B%')) as P2 ORDER BY P2.Name"

            For Each rec As DbDataRecord In New ObjectQuery(Of DbDataRecord)(esqlQuery, context)
                Console.WriteLine("Name: {0}; ListPrice: {1}", rec(0), rec(1))
            Next
        End Using
        '</snippetOrderTwoUnionizedQueriesWithObjectQuery> 
    End Sub

    Public Shared Sub ESQLPagingWithObjectQuery()
        '<snippetESQLPagingWithObjectQuery> 
        Using context As New AdventureWorksEntities()
            ' Create a query that takes two parameters. 
            Dim queryString As String = "SELECT VALUE product FROM AdventureWorksEntities.Products AS product " & _
                " order by product.ListPrice SKIP @skip LIMIT @limit"

            Dim productQuery As New ObjectQuery(Of Product)(queryString, context)

            ' Add parameters to the collection. 
            productQuery.Parameters.Add(New ObjectParameter("skip", 3))
            productQuery.Parameters.Add(New ObjectParameter("limit", 5))

            ' Iterate through the collection of Contact items. 
            For Each result As Product In productQuery
                Console.WriteLine("ID: {0}; Name: {1}", result.ProductID, result.Name)
            Next
        End Using
        '</snippetESQLPagingWithObjectQuery> 
    End Sub


    'string esqlQuery = @"SELECT VALUE Product FROM AdventureWorksEntities.Products AS Product"; 
    '<snippeteSQLStructuralTypes> 
    Private Shared Sub ExecuteStructuralTypeQuery(ByVal esqlQuery As String)
        If esqlQuery.Length = 0 Then
            Console.WriteLine("The query string is empty.")
            Exit Sub
        End If

        Using conn As New EntityConnection("name=AdventureWorksEntities")
            conn.Open()

            ' Create an EntityCommand. 
            Using cmd As EntityCommand = conn.CreateCommand()
                cmd.CommandText = esqlQuery
                ' Execute the command. 
                Using rdr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' Start reading results. 
                    While rdr.Read()
                        StructuralTypeVisitRecord(TryCast(rdr, IExtendedDataRecord))
                    End While
                End Using
            End Using
            conn.Close()
        End Using
    End Sub

    Private Shared Sub StructuralTypeVisitRecord(ByVal record As IExtendedDataRecord)
        Dim fieldCount As Integer = record.DataRecordInfo.FieldMetadata.Count
        For fieldIndex As Integer = 0 To fieldCount - 1
            Console.Write(record.GetName(fieldIndex) & ": ")

            ' If the field is flagged as DbNull, the shape of the value is undetermined. 
            ' An attempt to get such a value may trigger an exception. 
            If record.IsDBNull(fieldIndex) = False Then
                Dim fieldTypeKind As BuiltInTypeKind = record.DataRecordInfo.FieldMetadata(fieldIndex).FieldType.TypeUsage.EdmType.BuiltInTypeKind
                ' The EntityType, ComplexType and RowType are structural types 
                ' that have members. 
                ' Read only the PrimitiveType members of this structural type. 
                If fieldTypeKind = BuiltInTypeKind.PrimitiveType Then
                    ' Primitive types are surfaced as plain objects. 
                    Console.WriteLine(record.GetValue(fieldIndex).ToString())
                End If
            End If
        Next
    End Sub
    '</snippeteSQLStructuralTypes> 


    'string esqlQuery = @"SELECT REF(p) FROM AdventureWorksEntities.Products as p"; 
    '<snippeteSQLRefTypes> 
    Private Shared Sub ExectueRefTypeQuery(ByVal esqlQuery As String)
        If esqlQuery.Length = 0 Then
            Console.WriteLine("The query string is empty.")
            Exit Sub
        End If

        Using conn As New EntityConnection("name=AdventureWorksEntities")
            conn.Open()

            ' Create an EntityCommand. 
            Using cmd As EntityCommand = conn.CreateCommand()
                cmd.CommandText = esqlQuery
                ' Execute the command. 
                Using rdr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' Start reading results. 
                    While rdr.Read()
                        RefTypeVisitRecord(TryCast(rdr, IExtendedDataRecord))
                    End While
                End Using
            End Using
            conn.Close()
        End Using
    End Sub

    Private Shared Sub RefTypeVisitRecord(ByVal record As IExtendedDataRecord)
        ' For RefType the record contains exactly one field. 
        Dim fieldIndex As Integer = 0

        ' If the field is flagged as DbNull, the shape of the value is undetermined. 
        ' An attempt to get such a value may trigger an exception. 
        If record.IsDBNull(fieldIndex) = False Then
            Dim fieldTypeKind As BuiltInTypeKind = record.DataRecordInfo.FieldMetadata(fieldIndex).FieldType.TypeUsage.EdmType.BuiltInTypeKind
            'read only fields that contain PrimitiveType 
            If fieldTypeKind = BuiltInTypeKind.RefType Then
                ' Ref types are surfaced as EntityKey instances. 
                ' The containing record sees them as atomic. 
                Dim key As EntityKey = TryCast(record.GetValue(fieldIndex), EntityKey)
                ' Get the EntitySet name. 
                Console.WriteLine("EntitySetName " & key.EntitySetName)
                ' Get the Name and the Value information of the EntityKey. 
                For Each keyMember As EntityKeyMember In key.EntityKeyValues
                    Console.WriteLine(" Key Name: " & keyMember.Key)
                    Console.WriteLine(" Key Value: " & keyMember.Value)
                Next
            End If
        End If
    End Sub
    '</snippeteSQLRefTypes> 


    'string esqlQuery = @"SELECT VALUE AVG(p.ListPrice) FROM AdventureWorksEntities.Products as p"; 
    '<snippeteSQLPrimitiveTypes> 
    Private Shared Sub ExecutePrimitiveTypeQuery(ByVal esqlQuery As String)
        If esqlQuery.Length = 0 Then
            Console.WriteLine("The query string is empty.")
            Exit Sub
        End If

        Using conn As New EntityConnection("name=AdventureWorksEntities")
            conn.Open()

            ' Create an EntityCommand. 
            Using cmd As EntityCommand = conn.CreateCommand()
                cmd.CommandText = esqlQuery
                ' Execute the command. 
                Using rdr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' Start reading results. 
                    While rdr.Read()
                        Dim record As IExtendedDataRecord = TryCast(rdr, IExtendedDataRecord)
                        ' For PrimitiveType 
                        ' the record contains exactly one field. 
                        Dim fieldIndex As Integer = 0
                        Console.WriteLine("Value: " & record.GetValue(fieldIndex))
                    End While
                End Using
            End Using
            conn.Close()
        End Using
    End Sub
    '</snippeteSQLPrimitiveTypes> 

End Class