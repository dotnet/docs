Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Reflection
Imports System.Runtime.CompilerServices

Module Module1

    Sub Main()

        'JoinQuery()
        'LoadItemsExpandSchema()
        'LoadItemsIntoExistingTable()
        'LoadItemsIntoTable()
        LoadScalarSequence()


        Console.WriteLine("Hit enter...")
        Console.Read()

    End Sub

    Sub JoinQuery()
        ' <SnippetJoin>
        ' Fill the DataSet.
        Dim ds As New DataSet()
        ds.Locale = CultureInfo.InvariantCulture
        ' See the FillDataSet method in the Loading Data Into a DataSet topic.
        FillDataSet(ds)

        Dim orders As DataTable = ds.Tables("SalesOrderHeader")
        Dim details As DataTable = ds.Tables("SalesOrderDetail")


        Dim query = _
            From order In orders.AsEnumerable() _
            Join detail In details.AsEnumerable() _
            On order.Field(Of Integer)("SalesOrderID") Equals _
                    detail.Field(Of Integer)("SalesOrderID") _
            Where order.Field(Of Boolean)("OnlineOrderFlag") = True And _
                    order.Field(Of DateTime)("OrderDate").Month = 8 _
            Select New With _
            { _
                .SalesOrderID = order.Field(Of Integer)("SalesOrderID"), _
                .SalesOrderDetailID = detail.Field(Of Integer)("SalesOrderDetailID"), _
                .OrderDate = order.Field(Of DateTime)("OrderDate"), _
                .ProductID = detail.Field(Of Integer)("ProductID") _
            }

        Dim table As DataTable = query.CopyToDataTable()
        ' </SnippetJoin>

        DisplayTable(table)
    End Sub

    Private Sub LoadItemsExpandSchema()
        ' <SnippetLoadItemsExpandSchema>
        Dim book1 As New Book()
        book1.Id = 1
        book1.Price = 13.5
        book1.Genre = "Comedy"
        book1.Author = "Gustavo Achong"

        Dim book2 As New Book
        book2.Id = 2
        book2.Price = 8.5
        book2.Genre = "Drama"
        book2.Author = "Jessie Zeng"

        Dim movie1 As New Movie
        movie1.Id = 1
        movie1.Price = 22.99
        movie1.Genre = "Comedy"
        movie1.Director = "Marissa Barnes"

        Dim movie2 As New Movie
        movie2.Id = 1
        movie2.Price = 13.4
        movie2.Genre = "Action"
        movie2.Director = "Emmanuel Fernandez"

        Dim items(3) As Item
        items(0) = book1
        items(1) = book2
        items(2) = movie1
        items(3) = movie2

        ' Load into an existing DataTable, expand the schema and
        ' autogenerate a new Id.
        Dim table As DataTable = New DataTable()
        Dim dc As DataColumn = table.Columns.Add("NewId", GetType(Integer))
        dc.AutoIncrement = True
        table.Columns.Add("ExtraColumn", GetType(String))

        Dim query = From i In items _
                    Where i.Price > 9.99 _
                    Order By i.Price _
                    Select New With {i.Price, i.Genre}

        query.CopyToDataTable(table, LoadOption.PreserveChanges)
        '</SnippetLoadItemsExpandSchema>
        DisplayTable(table)

    End Sub

    Private Sub LoadItemsIntoExistingTable()
        ' <SnippetLoadItemsIntoExistingTable>
        Dim book1 As New Book()
        book1.Id = 1
        book1.Price = 13.5
        book1.Genre = "Comedy"
        book1.Author = "Gustavo Achong"

        Dim book2 As New Book
        book2.Id = 2
        book2.Price = 8.5
        book2.Genre = "Drama"
        book2.Author = "Jessie Zeng"

        Dim movie1 As New Movie
        movie1.Id = 1
        movie1.Price = 22.99
        movie1.Genre = "Comedy"
        movie1.Director = "Marissa Barnes"

        Dim movie2 As New Movie
        movie2.Id = 1
        movie2.Price = 13.4
        movie2.Genre = "Action"
        movie2.Director = "Emmanuel Fernandez"

        Dim items(3) As Item
        items(0) = book1
        items(1) = book2
        items(2) = movie1
        items(3) = movie2

        ' Create a table with a schema that matches that of the query results.
        Dim table As DataTable = New DataTable()
        table.Columns.Add("Price", GetType(Integer))
        table.Columns.Add("Genre", GetType(String))

        ' Query for items with price greater than 9.99.
        Dim query = From i In items _
                    Where i.Price > 9.99 _
                    Order By i.Price _
                    Select New With {i.Price, i.Genre}

        query.CopyToDataTable(table, LoadOption.PreserveChanges)
        '</SnippetLoadItemsIntoExistingTable>
        DisplayTable(table)
    End Sub

    Private Sub LoadItemsIntoTable()
        ' <SnippetLoadItemsIntoTable>
        Dim book1 As New Book()
        book1.Id = 1
        book1.Price = 13.5
        book1.Genre = "Comedy"
        book1.Author = "Gustavo Achong"

        Dim book2 As New Book
        book2.Id = 2
        book2.Price = 8.5
        book2.Genre = "Drama"
        book2.Author = "Jessie Zeng"

        Dim movie1 As New Movie
        movie1.Id = 1
        movie1.Price = 22.99
        movie1.Genre = "Comedy"
        movie1.Director = "Marissa Barnes"

        Dim movie2 As New Movie
        movie2.Id = 1
        movie2.Price = 13.4
        movie2.Genre = "Action"
        movie2.Director = "Emmanuel Fernandez"

        Dim items(3) As Item
        items(0) = book1
        items(1) = book2
        items(2) = movie1
        items(3) = movie2

        ' Query for items with price greater than 9.99.
        Dim query = From i In items _
                    Where i.Price > 9.99 _
                    Order By i.Price _
                    Select New With {i.Price, i.Genre}

        Dim table As DataTable
        table = query.CopyToDataTable()
        ' </SnippetLoadItemsIntoTable>
        DisplayTable(table)
    End Sub

    Private Sub LoadScalarSequence()
        ' <SnippetLoadScalarSequence>
        Dim book1 As New Book()
        book1.Id = 1
        book1.Price = 13.5
        book1.Genre = "Comedy"
        book1.Author = "Gustavo Achong"

        Dim book2 As New Book
        book2.Id = 2
        book2.Price = 8.5
        book2.Genre = "Drama"
        book2.Author = "Jessie Zeng"

        Dim movie1 As New Movie
        movie1.Id = 1
        movie1.Price = 22.99
        movie1.Genre = "Comedy"
        movie1.Director = "Marissa Barnes"

        Dim movie2 As New Movie
        movie2.Id = 1
        movie2.Price = 13.4
        movie2.Genre = "Action"
        movie2.Director = "Emmanuel Fernandez"

        Dim items(3) As Item
        items(0) = book1
        items(1) = book2
        items(2) = movie1
        items(3) = movie2

        Dim query = From i In items _
                    Where i.Price > 9.99 _
                    Order By i.Price _
                    Select i.Price

        Dim table As DataTable
        table = query.CopyToDataTable()
        ' </SnippetLoadScalarSequence>
        DisplayTable(table)
    End Sub



    Private Sub DisplayTable(ByVal table As DataTable)
        Dim i As Integer
        For i = 0 To table.Rows.Count - 1
            Dim j As Integer
            For j = 0 To table.Columns.Count - 1
                Console.WriteLine((table.Columns.Item(j).ColumnName & ": " & table.Rows.Item(i).Item(j).ToString))
            Next j
            Console.WriteLine("")
        Next i
    End Sub

    Sub FillDataSet(ByRef ds As DataSet)
        ' <SnippetFillDataSet>
        Try
            Dim connectionString As String

            connectionString = "..."

            ' Create a new adapter and give it a query to fetch sales order, contact,
            ' address, and product information for sales in the year 2002. Point connection
            ' information to the configuration setting "AdventureWorks".
            Dim da = New SqlDataAdapter( _
            "SELECT SalesOrderID, ContactID, OrderDate, OnlineOrderFlag, " & _
                "TotalDue, SalesOrderNumber, Status, ShipToAddressID, BillToAddressID " & _
                "FROM Sales.SalesOrderHeader " & _
                "WHERE DATEPART(YEAR, OrderDate) = @year; " & _
                "SELECT d.SalesOrderID, d.SalesOrderDetailID, d.OrderQty, " & _
                "d.ProductID, d.UnitPrice " & _
                "FROM Sales.SalesOrderDetail d " & _
                "INNER JOIN Sales.SalesOrderHeader h " & _
                "ON d.SalesOrderID = h.SalesOrderID  " & _
                "WHERE DATEPART(YEAR, OrderDate) = @year; " & _
                "SELECT p.ProductID, p.Name, p.ProductNumber, p.MakeFlag, " & _
                "p.Color, p.ListPrice, p.Size, p.Class, p.Style  " & _
                "FROM Production.Product p; " & _
                "SELECT DISTINCT a.AddressID, a.AddressLine1, a.AddressLine2, " & _
                "a.City, a.StateProvinceID, a.PostalCode " & _
                "FROM Person.Address a " & _
                "INNER JOIN Sales.SalesOrderHeader h " & _
                "ON  a.AddressID = h.ShipToAddressID OR a.AddressID = h.BillToAddressID " & _
                "WHERE DATEPART(YEAR, OrderDate) = @year; " & _
                "SELECT DISTINCT c.ContactID, c.Title, c.FirstName, " & _
                "c.LastName, c.EmailAddress, c.Phone " & _
                "FROM Person.Contact c " & _
                "INNER JOIN Sales.SalesOrderHeader h " & _
                "ON c.ContactID = h.ContactID " & _
                "WHERE DATEPART(YEAR, OrderDate) = @year;", _
            connectionString)

            ' Add table mappings.
            da.SelectCommand.Parameters.AddWithValue("@year", 2002)
            da.TableMappings.Add("Table", "SalesOrderHeader")
            da.TableMappings.Add("Table1", "SalesOrderDetail")
            da.TableMappings.Add("Table2", "Product")
            da.TableMappings.Add("Table3", "Address")
            da.TableMappings.Add("Table4", "Contact")

            da.Fill(ds)

            ' Add data relations.
            Dim orderHeader As DataTable = ds.Tables("SalesOrderHeader")
            Dim orderDetail As DataTable = ds.Tables("SalesOrderDetail")
            Dim co As DataRelation = New DataRelation("SalesOrderHeaderDetail", _
                                            orderHeader.Columns("SalesOrderID"), _
                                            orderDetail.Columns("SalesOrderID"), True)
            ds.Relations.Add(co)

            Dim contact As DataTable = ds.Tables("Contact")
            Dim orderContact As DataRelation = New DataRelation("SalesOrderContact", _
                                            contact.Columns("ContactID"), _
                                            orderHeader.Columns("ContactID"), True)
            ds.Relations.Add(orderContact)
        Catch ex As SqlException
            Console.WriteLine("SQL exception occurred: " & ex.Message)
        End Try
        ' </SnippetFillDataSet>
    End Sub


    '<SnippetItemClass>
    Public Class Item
        Private _Id As Int32
        Private _Price As Double
        Private _Genre As String

        Public Property Id() As Int32
            Get
                Return Id
            End Get
            Set(ByVal value As Int32)
                _Id = value
            End Set
        End Property

        Public Property Price() As Double
            Get
                Return _Price
            End Get
            Set(ByVal value As Double)
                _Price = value
            End Set
        End Property

        Public Property Genre() As String
            Get
                Return _Genre
            End Get
            Set(ByVal value As String)
                _Genre = value
            End Set
        End Property

    End Class
    Public Class Book
        Inherits Item
        Private _Author As String
        Public Property Author() As String
            Get
                Return _Author
            End Get
            Set(ByVal value As String)
                _Author = value
            End Set
        End Property
    End Class

    Public Class Movie
        Inherits Item
        Private _Director As String
        Public Property Director() As String
            Get
                Return _Director
            End Get
            Set(ByVal value As String)
                _Director = value
            End Set
        End Property

    End Class
    '</SnippetItemClass>

End Module

' <SnippetCustomCopyToDataTableMethods>
Public Module CustomLINQtoDataSetMethods
    <Extension()> _
    Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T)) As DataTable
        Return New ObjectShredder(Of T)().Shred(source, Nothing, Nothing)
    End Function

    <Extension()> _
    Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As LoadOption?) As DataTable
        Return New ObjectShredder(Of T)().Shred(source, table, options)
    End Function

End Module
' </SnippetCustomCopyToDataTableMethods>

' <SnippetObjectShredderClass>
Public Class ObjectShredder(Of T)
    ' Fields
    Private _fi As FieldInfo()
    Private _ordinalMap As Dictionary(Of String, Integer)
    Private _pi As PropertyInfo()
    Private _type As Type

    ' Constructor
    Public Sub New()
        Me._type = GetType(T)
        Me._fi = Me._type.GetFields
        Me._pi = Me._type.GetProperties
        Me._ordinalMap = New Dictionary(Of String, Integer)
    End Sub

    Public Function ShredObject(ByVal table As DataTable, ByVal instance As T) As Object()
        Dim fi As FieldInfo() = Me._fi
        Dim pi As PropertyInfo() = Me._pi
        If (Not instance.GetType Is GetType(T)) Then
            ' If the instance is derived from T, extend the table schema
            ' and get the properties and fields.
            Me.ExtendTable(table, instance.GetType)
            fi = instance.GetType.GetFields
            pi = instance.GetType.GetProperties
        End If

        ' Add the property and field values of the instance to an array.
        Dim values As Object() = New Object(table.Columns.Count - 1) {}
        Dim f As FieldInfo
        For Each f In fi
            values(Me._ordinalMap.Item(f.Name)) = f.GetValue(instance)
        Next
        Dim p As PropertyInfo
        For Each p In pi
            values(Me._ordinalMap.Item(p.Name)) = p.GetValue(instance, Nothing)
        Next

        ' Return the property and field values of the instance.
        Return values
    End Function


    ' Summary:           Loads a DataTable from a sequence of objects.
    ' source parameter:  The sequence of objects to load into the DataTable.</param>
    ' table parameter:   The input table. The schema of the table must match that
    '                    the type T.  If the table is null, a new table is created
    '                    with a schema created from the public properties and fields
    '                    of the type T.
    ' options parameter: Specifies how values from the source sequence will be applied to
    '                    existing rows in the table.
    ' Returns:           A DataTable created from the source sequence.

    Public Function Shred(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As LoadOption?) As DataTable

        ' Load the table from the scalar sequence if T is a primitive type.
        If GetType(T).IsPrimitive Then
            Return Me.ShredPrimitive(source, table, options)
        End If

        ' Create a new table if the input table is null.
        If (table Is Nothing) Then
            table = New DataTable(GetType(T).Name)
        End If

        ' Initialize the ordinal map and extend the table schema based on type T.
        table = Me.ExtendTable(table, GetType(T))

        ' Enumerate the source sequence and load the object values into rows.
        table.BeginLoadData()
        Using e As IEnumerator(Of T) = source.GetEnumerator
            Do While e.MoveNext
                If options.HasValue Then
                    table.LoadDataRow(Me.ShredObject(table, e.Current), options.Value)
                Else
                    table.LoadDataRow(Me.ShredObject(table, e.Current), True)
                End If
            Loop
        End Using
        table.EndLoadData()

        ' Return the table.
        Return table
    End Function


    Public Function ShredPrimitive(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As LoadOption?) As DataTable
        ' Create a new table if the input table is null.
        If (table Is Nothing) Then
            table = New DataTable(GetType(T).Name)
        End If
        If Not table.Columns.Contains("Value") Then
            table.Columns.Add("Value", GetType(T))
        End If

        ' Enumerate the source sequence and load the scalar values into rows.
        table.BeginLoadData()
        Using e As IEnumerator(Of T) = source.GetEnumerator
            Dim values As Object() = New Object(table.Columns.Count - 1) {}
            Do While e.MoveNext
                values(table.Columns.Item("Value").Ordinal) = e.Current
                If options.HasValue Then
                    table.LoadDataRow(values, options.Value)
                Else
                    table.LoadDataRow(values, True)
                End If
            Loop
        End Using
        table.EndLoadData()

        ' Return the table.
        Return table
    End Function

    Public Function ExtendTable(ByVal table As DataTable, ByVal type As Type) As DataTable
        ' Extend the table schema if the input table was null or if the value
        ' in the sequence is derived from type T.
        Dim f As FieldInfo
        Dim p As PropertyInfo

        For Each f In type.GetFields
            If Not Me._ordinalMap.ContainsKey(f.Name) Then
                Dim dc As DataColumn

                ' Add the field as a column in the table if it doesn't exist
                ' already.
                dc = IIf(table.Columns.Contains(f.Name), table.Columns.Item(f.Name), table.Columns.Add(f.Name, f.FieldType))

                ' Add the field to the ordinal map.
                Me._ordinalMap.Add(f.Name, dc.Ordinal)
            End If

        Next

        For Each p In type.GetProperties
            If Not Me._ordinalMap.ContainsKey(p.Name) Then
                ' Add the property as a column in the table if it doesn't exist
                ' already.
                Dim dc As DataColumn
                dc = IIf(table.Columns.Contains(p.Name), table.Columns.Item(p.Name), table.Columns.Add(p.Name, p.PropertyType))

                ' Add the property to the ordinal map.
                Me._ordinalMap.Add(p.Name, dc.Ordinal)
            End If
        Next

        ' Return the table.
        Return table
    End Function

End Class
' </SnippetObjectShredderClass>
