'<snippetNamespaces>
Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.Common
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.EntityClient
Imports System.Data.Metadata.Edm
Imports System.IO
' Add AdventureWorksModel prepended with the root namespace for the project.
'Imports ProjectName.AdventureWorksModel
'</snippetNamespaces>
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports eSQLExamplesVB.AdventureWorksModel
Imports System.Transactions

Module Program

    Sub PolymorphicQuery()
        '<snippetPolymorphicQuery>
        Using connection As EntityConnection = New EntityConnection("name= SchoolEntities ")
            connection.Open()

            ' Create a query that specifies to 
            ' get a collection of Students
            ' with enrollment dates from
            ' a collection of People.
            Dim esqlQuery As String = "SELECT Student.LastName, " & _
                    " Student.EnrollmentDate FROM " & _
                    " OFTYPE(SchoolEntities.Person, " & _
                    " SchoolModel.Student) AS Student "

            ' Create an EntityCommand and pass the connection object 
            ' and Enity SQL query to its constructor.
            Using command As EntityCommand = New EntityCommand(esqlQuery, connection)
                ' Execute the command.
                Using reader As DbDataReader = command.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' Start reading.
                    Do While reader.Read
                        ' Display student's last name and enrollment date.
                        Console.Write(reader.Item("LastName"))
                        Console.WriteLine(reader.Item("EnrollmentDate"))
                    Loop
                End Using
            End Using
        End Using
        '</snippetPolymorphicQuery>
    End Sub

    Sub Transactions()
        '<snippetTransactionsWithEntityClient>
        Using con As EntityConnection = _
                        New EntityConnection("name=AdventureWorksEntities")

            con.Open()
            Dim transaction As EntityTransaction = con.BeginTransaction()
            Dim cmd As DbCommand = con.CreateCommand()
            cmd.Transaction = transaction
            cmd.CommandText = "SELECT VALUE Contact FROM AdventureWorksEntities.Contact " & _
                "AS Contact WHERE Contact.LastName = 'Adams'"

            Dim rdr As DbDataReader = cmd.ExecuteReader( _
                System.Data.CommandBehavior.SequentialAccess)

            ' Iterate through the collection of Contact items.
            While (rdr.Read())
                Console.Write("First Name: " + rdr.Item("FirstName"))
                Console.WriteLine(Chr(9) + "Last Name: " + rdr.Item("LastName"))
            End While

            transaction.Commit()
        End Using
        '</snippetTransactionsWithEntityClient>
    End Sub


    Sub ComplexTypeWithEntityCommand()
        '<snippetComplexTypeWithEntityCommand>
        Using conn As EntityConnection = New EntityConnection("name=CustomerComplexAddrContext")
            conn.Open()

            ' Create an EntityCommand.
            Using cmd As EntityCommand = conn.CreateCommand()

                ' Create a query that returns Address complex type.
                Dim esqlQuery As String = "SELECT VALUE customers FROM " & _
                    "CustomerComplexAddrContext.CCustomers " & _
                    "AS customers WHERE customers.CustomerId < 3"
                cmd.CommandText = esqlQuery
                ' Execute the command.
                Using rdr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    ' The result returned by this query contains 
                    ' Address complex Types.
                    Do While rdr.Read
                        ' Display CustomerID
                        Console.WriteLine("Customer ID: {0}", _
                            rdr.Item("CustomerId"))
                        ' Display Address information.
                        Dim nestedRecord As DbDataRecord = DirectCast(rdr.Item("Address"), DbDataRecord)
                        Console.WriteLine("Address:")
                        For i = 0 To nestedRecord.FieldCount - 1
                            Console.WriteLine("  " + nestedRecord.GetName(i) & _
                                    ": " + nestedRecord.GetValue(i))
                        Next i
                    Loop
                End Using
            End Using
            conn.Close()
        End Using
        '</snippetComplexTypeWithEntityCommand>
    End Sub

    Sub StoredProcWithEntityCommand()
        '<snippetStoredProcWithEntityCommand>
        Using conn As EntityConnection = New EntityConnection("name=AdventureWorksEntities")
            conn.Open()

            Try

                ' Create an EntityCommand.
                Using cmd As EntityCommand = conn.CreateCommand()
                    cmd.CommandText = "AdventureWorksEntities.GetOrderDetails"
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim param As New EntityParameter()
                    param.Value = "43659"
                    param.ParameterName = "SalesOrderHeaderId"
                    cmd.Parameters.Add(param)

                    Using rdr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                        Do While rdr.Read
                            ' Read the results returned by the stored procedure.
                            Console.WriteLine("Header#: {0} " & _
                            "Order#: {1} ProductID: {2} Quantity: {3} Price: {4}", _
                            rdr.Item(0), rdr.Item(1), rdr.Item(2), rdr.Item(3), rdr.Item(4))
                        Loop
                    End Using
                End Using
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            End Try
            conn.Close()
        End Using
        '</snippetStoredProcWithEntityCommand>
    End Sub

    Sub ESQLPagingWithObjectQuery()
        '<snippetESQLPagingWithObjectQuery>
        Using advWorksContext As New AdventureWorksEntities()
            ' Define the parameters used to define the "page" of returned data.
            Try
                ' Create a query that takes two parameters.
                Dim esqlQuery As String = "SELECT VALUE product FROM " & _
                          " AdventureWorksEntities.Product AS product " & _
                          " order by product.ListPrice SKIP @skip LIMIT @limit"

                Dim productQuery As New ObjectQuery(Of Product)(esqlQuery, advWorksContext)
                ' Add parameters to the collection.
                productQuery.Parameters.Add(New ObjectParameter("skip", 3))
                productQuery.Parameters.Add(New ObjectParameter("limit", 5))


                ' Iterate through the page of Product items.
                For Each result As Product In productQuery
                    Console.WriteLine("ID: {0} Name: {1}", _
                    result.ProductID, result.Name)
                Next
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.ToString())
            End Try
        End Using

        '</snippetESQLPagingWithObjectQuery>
    End Sub
    Sub OrderTwoUnionizedQueries()
        '<snippetOrderTwoUnionizedQueriesWithObjectQuery>
        Using advWorksContext As AdventureWorksEntities = New AdventureWorksEntities
            Dim esqlQuery As String = "SELECT P2.Name, P2.ListPrice " & _
                " FROM ((SELECT P1.Name, P1.ProductID as Pid, P1.ListPrice " & _
                " FROM AdventureWorksEntities.Product as P1 " & _
                " where P1.Name like 'A%') " & _
                " union all " & _
                " (SELECT P1.Name, P1.ProductID as Pid, P1.ListPrice  " & _
                " FROM AdventureWorksEntities.Product as P1 " & _
                " WHERE P1.Name like 'B%') " & _
                " ) as P2 " & _
                " ORDER BY P2.Name"
            Try
                Dim objQuery As New ObjectQuery(Of DbDataRecord)(esqlQuery, advWorksContext)
                For Each rec As DbDataRecord In objQuery
                    Console.WriteLine("Name: {0} ListPrice: {1}", rec.Item(0), rec.Item(1))
                Next
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetOrderTwoUnionizedQueriesWithObjectQuery>
    End Sub

    Sub ReturnPrimitiveTypeWithObjectQuery()
        '<snippetReturnPrimitiveTypeWithObjectQuery>
        Using advWorksContext As AdventureWorksEntities = New AdventureWorksEntities
            Dim commandText As String = "SELECT VALUE SqlServer.DATALENGTH(p.Name)FROM " & _
                "AdventureWorksEntities.Product AS p"
            Try
                Dim query As New ObjectQuery(Of Integer)(commandText, advWorksContext, MergeOption.NoTracking)
                For Each result As Integer In query
                    Console.WriteLine(result)
                Next
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetReturnPrimitiveTypeWithObjectQuery>
    End Sub

    Sub ReturnAnonymousTypeWithObjectQuery()
        '<snippetReturnAnonymousTypeWithObjectQuery>
        Using advWorksContext As AdventureWorksEntities = New AdventureWorksEntities
            Dim commandText As String = "SELECT p.ProductID, p.Name FROM " & _
                "AdventureWorksEntities.Product as p"

            Try
                Dim query As New ObjectQuery(Of DbDataRecord)(commandText, advWorksContext)

                For Each result As DbDataRecord In query
                    Console.WriteLine("ID {0} Name {1}", result.Item(0), result.Item(1))
                Next
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetReturnAnonymousTypeWithObjectQuery>
    End Sub

    Sub NavRelationshipWithNavProperties()
        '<snippetNavRelationshipWithNavProperties>

        Using advWorksContext As New AdventureWorksEntities
            Dim esqlQuery As String = "SELECT c.FirstName, c.SalesOrderHeader " & _
                    " FROM AdventureWorksEntities.Contact AS c where c.LastName = 'Zhou'"
            Try
                Dim objQuery As New ObjectQuery(Of DbDataRecord)(esqlQuery, advWorksContext)
                For Each rec As DbDataRecord In objQuery
                    ' Display contact's first name.
                    Console.WriteLine("First Name {0}: ", rec.Item(0))
                    Dim list As List(Of SalesOrderHeader) = DirectCast(rec.Item(1), List(Of SalesOrderHeader))
                    ' Display SalesOrderHeader information 
                    ' associated with the contact.
                    For Each soh As SalesOrderHeader In list
                        Console.WriteLine("   Order ID: {0}, Order date: {1}, Total Due: {2}", _
                                soh.SalesOrderID, soh.OrderDate, soh.TotalDue)
                    Next
                Next
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        ' </snippetNavRelationshipWithNavProperties>
    End Sub

    Sub ParamQueryWithObjectQuery()
        ' <snippetParameterizedQueryWithObjectQuery>
        Using advWorksContext As New AdventureWorksEntities
            Try
                ' Create a query that takes two parameters.
                Dim queryString As String = "SELECT VALUE Contact FROM AdventureWorksEntities.Contact " & _
                    "AS Contact WHERE Contact.LastName = @ln AND " & _
                    "Contact.FirstName = @fn"

                ' Add parameters to the collection.
                Dim contactQuery As New ObjectQuery(Of Contact)(queryString, advWorksContext, MergeOption.NoTracking)
                contactQuery.Parameters.Add(New ObjectParameter("ln", "Adams"))
                contactQuery.Parameters.Add(New ObjectParameter("fn", "Frances"))

                ' Iterate through the collection of Contact items.
                For Each result As Contact In contactQuery
                    Console.WriteLine("Last Name: {0} First Name: {1}", _
                    result.LastName, result.FirstName)
                Next

            Catch ex As EntityException
                Console.WriteLine(ex.ToString)
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        ' </snippetParameterizedQueryWithObjectQuery>
    End Sub

    Sub ReturnEntityTypeWithObectQuery()
        '<snippetReturnEntityTypeWithObectQuery>
        Using advWorksContext As AdventureWorksEntities = New AdventureWorksEntities
            Try
                Dim queryString As String = "SELECT VALUE Product FROM AdventureWorksEntities.Product AS Product"

                Dim query As New ObjectQuery(Of Product)(queryString, advWorksContext, MergeOption.NoTracking)

                ' Iterate through the collection of Product items.
                For Each result As Product In query
                    Console.WriteLine("Product Name: {0} Product ID: {1}", _
                    result.Name, result.ProductID)
                Next

            Catch exception As EntityException
                Console.WriteLine(exception.ToString)
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetReturnEntityTypeWithObectQuery>
    End Sub

    Sub ReturnNestedCollectionWithEntityCommand()
        ' <snippetReturnNestedCollectionWithEntityCommand>
        Using conn As EntityConnection = New EntityConnection("name=AdventureWorksEntities")
            conn.Open()
            Try
                ' Create an EntityCommand.
                Using cmd As EntityCommand = conn.CreateCommand()

                    ' Create a nested query.
                    Dim esqlQuery As String = "Select c.ContactID, c.SalesOrderHeader " & _
                            "From AdventureWorksEntities.Contact as c"

                    cmd.CommandText = esqlQuery
                    ' Execute the command.
                    Using rdr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                        ' The result returned by this query contains 
                        ' ContactID and a nested collection of SalesOrderHeader items.
                        ' associated with this Contact.
                        Do While rdr.Read
                            ' the first column contains Contact ID.
                            Console.WriteLine("Contact ID: {0}", rdr.Item("ContactID"))

                            ' The second column contains a collection of SalesOrderHeader 
                            ' items associated with the Contact.
                            Dim nestedReader As DbDataReader = rdr.GetDataReader(1)
                            Do While nestedReader.Read
                                Console.WriteLine("   SalesOrderID: {0} ", nestedReader.Item("SalesOrderID"))
                                Console.WriteLine("   OrderDate: {0} ", nestedReader.Item("OrderDate"))
                            Loop
                        Loop
                    End Using
                End Using
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            End Try

            conn.Close()
        End Using
        '</snippetReturnNestedCollectionWithEntityCommand>

    End Sub

    Sub NavigateWithNavOperatorWithEntityCommand()
        ' <snippetNavigateWithNavOperatorWithEntityCommand>
        Using connection As EntityConnection = New EntityConnection("name=AdventureWorksEntities")
            connection.Open()

            Try
                ' Create an EntityCommand and pass the connection object 
                ' and Entity SQL query to its constructor.
                Using cmd As EntityCommand = connection.CreateCommand()
                    ' Create an Entity SQL query.
                    Dim esqlQuery As String = "SELECT address.AddressID, (SELECT VALUE DEREF(soh) FROM " & _
                        "NAVIGATE(address, AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID) " & _
                        "AS soh) FROM AdventureWorksEntities.Address AS address"

                    cmd.CommandText = esqlQuery
                    ' Execute the command.
                    Using reader As DbDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                        ' Start reading.
                        Do While reader.Read
                            Console.WriteLine(reader.Item("AddressID"))
                        Loop
                    End Using
                End Using
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            End Try
            connection.Close()
        End Using
        ' </snippetNavigateWithNavOperatorWithEntityCommand>
    End Sub

    Sub ParameterizedQueryWithEntityCommand()
        ' <snippetParameterizedQueryWithEntityCommand>
        Using conn As EntityConnection = New EntityConnection("name=AdventureWorksEntities")
            conn.Open()

            ' Create a query that takes two parameters.
            Dim esqlQuery As String = "SELECT VALUE Contact FROM AdventureWorksEntities.Contact " & _
                "AS Contact WHERE Contact.LastName = @ln AND " & _
                "Contact.FirstName = @fn"

            Try
                Using cmd As EntityCommand = New EntityCommand(esqlQuery, conn)
                    ' Create two parameters and add them to 
                    ' the EntityCommand's Parameters collection 
                    Dim param1 As New EntityParameter
                    param1.ParameterName = "ln"
                    param1.Value = "Adams"
                    Dim param2 As New EntityParameter
                    param2.ParameterName = "fn"
                    param2.Value = "Frances"
                    cmd.Parameters.Add(param1)
                    cmd.Parameters.Add(param2)

                    Using rdr As DbDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                        ' Iterate through the collection of Contact items.
                        Do While rdr.Read
                            Console.WriteLine(rdr.Item("FirstName"))
                            Console.WriteLine(rdr.Item("LastName"))
                        Loop
                    End Using
                End Using
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            End Try
            conn.Close()
        End Using
        ' </snippetParameterizedQueryWithEntityCommand>
    End Sub

    Sub GroupDataWithObjectQuery()
        '<snippetGropuDataWithObjectQuery>
        Using advWorksContext As New AdventureWorksEntities
            Dim esqlQuery As String = "SELECT ln, " & _
                "(SELECT c1.LastName FROM AdventureWorksEntities.Contact AS c1 " & _
                    "WHERE SUBSTRING(c1.LastName ,1,1) = ln) " & _
                "AS CONTACT " & _
                " FROM AdventureWorksEntities.CONTACT AS c2 GROUP BY SUBSTRING(c2.LastName ,1,1) AS ln " & _
                "ORDER BY ln"
            Try
                Dim rec As DbDataRecord
                Dim query As New ObjectQuery(Of DbDataRecord)(esqlQuery, advWorksContext)

                For Each rec In query
                    Console.WriteLine("Last names that start with the letter '{0}':", _
                        rec.Item(0))
                    Dim list As List(Of DbDataRecord) = DirectCast(rec.Item(1), List(Of DbDataRecord))

                    For Each r In list
                        For i = 0 To r.FieldCount - 1
                            Console.WriteLine("{0}", r.Item(i))
                        Next i
                    Next
                Next
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        '</snippetGropuDataWithObjectQuery>
    End Sub

    Sub BuildingConnectionStringWithEntityCommand()
        '<snippetBuildingConnectionStringWithEntityCommand>
        ' Specify the provider name, server and database.
        Dim providerName As String = "System.Data.SqlClient"
        Dim serverName As String = "."
        Dim databaseName As String = "AdventureWorks"

        ' Initialize the connection string builder for the
        ' underlying provider.
        Dim sqlBuilder As New SqlConnectionStringBuilder

        ' Set the properties for the data source.
        sqlBuilder.DataSource = serverName
        sqlBuilder.InitialCatalog = databaseName
        sqlBuilder.IntegratedSecurity = True

        ' Build the SqlConnection connection string.
        Dim providerString As String = sqlBuilder.ToString

        ' Initialize the EntityConnectionStringBuilder.
        Dim entityBuilder As New EntityConnectionStringBuilder

        'Set the provider name.
        entityBuilder.Provider = providerName
        ' Set the provider-specific connection string.
        entityBuilder.ProviderConnectionString = providerString
        ' Set the Metadata location to the current directory.
        entityBuilder.Metadata = "res://*/AdventureWorksModel.csdl|" & _
                                    "res://*/AdventureWorksModel.ssdl|" & _
                                    "res://*/AdventureWorksModel.msl"

        Console.WriteLine(entityBuilder.ToString)

        Using conn As EntityConnection = New EntityConnection(entityBuilder.ToString)
            conn.Open()
            Console.WriteLine("Just testing the connection.")
            conn.Close()
        End Using
        '</snippetBuildingConnectionStringWithEntityCommand>
    End Sub

    Sub AggregateDataWithObjectQuery()
        '<snippetAggregateDataWithObjectQuery>
        Using advWorksContext As AdventureWorksEntities = New AdventureWorksEntities
            Dim esqlQuery As String = "SELECT contactID, AVG(order.TotalDue) " & _
                                            " FROM(AdventureWorksEntities.SalesOrderHeader)" & _
                                            " AS order GROUP BY order.Contact.ContactID as contactID"

            Try
                Dim rec As DbDataRecord
                Dim query As New ObjectQuery(Of DbDataRecord)(esqlQuery, advWorksContext)
                For Each rec In query
                    Console.WriteLine("ContactID = {0}  Average TotalDue = {1} ", _
                            rec.Item(0), rec.Item(1))
                Next
            Catch ex As EntityException
                Console.WriteLine(ex.ToString())
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.ToString())
            End Try

        End Using
        '</snippetAggregateDataWithObjectQuery>
    End Sub



    'string esqlQuery = @"SELECT VALUE Product FROM AdventureWorksEntities.Product AS Product"
    '<snippeteSQLStructuralTypes>
    Sub ExecuteStructuralTypeQuery(ByVal esqlQuery As String)
        If (esqlQuery.Length = 0) Then
            Console.WriteLine("The query string is empty.")
            Return
        End If


        Using conn As EntityConnection = New EntityConnection("name=AdventureWorksEntities")
            conn.Open()

            Try
                ' Create an EntityCommand.
                Using cmd As EntityCommand = conn.CreateCommand()
                    cmd.CommandText = esqlQuery
                    ' Execute the command.
                    Using reader As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                        Do While (reader.Read())
                            StructuralTypeVisitRecord(CType(reader, IExtendedDataRecord))
                        Loop
                    End Using
                End Using
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
            conn.Close()
        End Using
    End Sub

    Sub StructuralTypeVisitRecord(ByVal record As IExtendedDataRecord)
        Dim fieldCount As Integer
        fieldCount = record.DataRecordInfo.FieldMetadata.Count
        Dim fieldIndex As Integer
        For fieldIndex = 0 To fieldCount - 1
            Console.Write(record.GetName(fieldIndex) + ": ")

            ' If the field is flagged as DbNull, the shape of the value is undetermined.
            ' An attempt to get such a value may trigger an exception.
            If (record.IsDBNull(fieldIndex) = False) Then
                Dim fieldTypeKind As BuiltInTypeKind = record.DataRecordInfo.FieldMetadata(fieldIndex).FieldType.TypeUsage.EdmType.BuiltInTypeKind()
                ' The EntityType, ComplexType and RowType are structural types
                ' that have members. 
                ' Read only the PrimitiveType members of this structural type.
                If (fieldTypeKind = BuiltInTypeKind.PrimitiveType) Then
                    ' Primitive types are surfaced as plain objects.
                    Console.WriteLine(record.GetValue(fieldIndex).ToString())
                End If
            End If
        Next
    End Sub
    '</snippeteSQLStructuralTypes>


    'string esqlQuery = @"SELECT REF(p) FROM AdventureWorksEntities.Product as p"
    '<snippeteSQLRefTypes>
    Sub ExectueRefTypeQuery(ByVal esqlQuery As String)
        If (esqlQuery.Length = 0) Then
            Console.WriteLine("The query string is empty.")
            Return
        End If

        Using conn As EntityConnection = New EntityConnection("name=AdventureWorksEntities")
            conn.Open()

            Try
                ' Create an EntityCommand.
                Using cmd As EntityCommand = conn.CreateCommand()
                    cmd.CommandText = esqlQuery
                    ' Execute the command.
                    Using reader As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                        Do While (reader.Read())
                            RefTypeVisitRecord(CType(reader, IExtendedDataRecord))
                        Loop
                    End Using
                End Using
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
            conn.Close()
        End Using
    End Sub

    Sub RefTypeVisitRecord(ByVal record As IExtendedDataRecord)
        ' For RefType the record contains exactly one field.
        Dim fieldIndex As Integer
        fieldIndex = 0

        ' If the field is flagged as DbNull, the shape of the value is undetermined.
        ' An attempt to get such a value may trigger an exception.
        If (record.IsDBNull(fieldIndex) = False) Then
            Dim fieldTypeKind As BuiltInTypeKind = record.DataRecordInfo.FieldMetadata(fieldIndex).FieldType.TypeUsage.EdmType.BuiltInTypeKind()

            'read only fields that contain PrimitiveType
            If (fieldTypeKind = BuiltInTypeKind.RefType) Then
                ' Ref types are surfaced as EntityKey instances. 
                ' The containing record sees them as atomic.
                Dim key As EntityKey = CType(record.GetValue(fieldIndex), EntityKey)
                ' Get the EntitySet name.
                Console.WriteLine("EntitySetName " + key.EntitySetName)
                ' Get the Name and the Value information of the EntityKey.
                Dim keyMember As EntityKeyMember
                For Each keyMember In key.EntityKeyValues
                    Console.WriteLine("   Key Name: " + keyMember.Key)
                    Console.WriteLine("   Key Value: " + keyMember.Value)
                Next
            End If
        End If
    End Sub
    '</snippeteSQLRefTypes>


    'string esqlQuery = @"SELECT VALUE AVG(p.ListPrice) FROM AdventureWorksEntities.Product as p"
    '<snippeteSQLPrimitiveTypes>
    Sub ExecutePrimitiveTypeQuery(ByVal esqlQuery As String)
        If (esqlQuery.Length = 0) Then
            Console.WriteLine("The query string is empty.")
            Return
        End If

        Using conn As EntityConnection = New EntityConnection("name=AdventureWorksEntities")
            conn.Open()

            Try
                ' Create an EntityCommand.
                Using cmd As EntityCommand = conn.CreateCommand()
                    cmd.CommandText = esqlQuery
                    ' Execute the command.
                    Using reader As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                        Do While (reader.Read())
                            Dim record As IExtendedDataRecord = CType(reader, IExtendedDataRecord)
                            ' For PrimitiveType 
                            ' the record contains exactly one field.
                            Dim fieldIndex As Integer
                            fieldIndex = 0
                            Console.WriteLine("Value: " + record.GetValue(fieldIndex))
                        Loop
                    End Using
                End Using
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
            conn.Close()
        End Using
    End Sub
    '</snippeteSQLPrimitiveTypes>

    Sub Main()
        'ReturnEntityTypeWithObectQuery()
        'ParameterizedQueryWithObjectQuery()
        'NavRelationshipWithNavProperties()
        'GroupDataWithObjectQuery()
        'AggregateDataWithObjectQuery()
        'ReturnAnonymousTypeWithObjectQuery()
        'ReturnPrimitiveTypeWithObjectQuery()
        'OrderTwoUnionizedQueriesWithObjectQuery()
        'ESQLPagingWithObjectQuery()

        'BuildingConnectionStringWithEntityCommand()
        'ParameterizedQueryWithEntityCommand()
        'NavigateWithNavOperatorWithEntityCommand()
        'ReturnNestedCollectionWithEntityCommand()
        'StoredProcWithEntityCommand()
        'ExecuteStructuralTypeQuery("SELECT VALUE Product FROM AdventureWorksEntities.Product AS Product")
        'ExectueRefTypeQuery("SELECT REF(p) FROM AdventureWorksEntities.Product as p")
        'ExecutePrimitiveTypeQuery("SELECT VALUE AVG(p.ListPrice) FROM AdventureWorksEntities.Product as p")

    End Sub

End Module
