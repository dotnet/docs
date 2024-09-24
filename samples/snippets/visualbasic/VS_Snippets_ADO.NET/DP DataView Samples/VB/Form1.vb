Option Explicit On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms


Public Class Form1
    Dim dataSet As DataSet

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Fill the DataSet.
        dataSet = New DataSet()
        dataSet.Locale = CultureInfo.InvariantCulture
        FillDataSet(dataSet)

        dataGridView1.DataSource = bindingSource1
    End Sub

    Private Shared Sub FillDataSet(ByVal ds As DataSet)
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
    End Sub

    ' <SnippetSoundEx>
    Private Function SoundEx(ByVal word As String) As String

        Dim length As Integer = 4
        ' Value to return
        Dim value As String = ""
        ' Size of the word to process
        Dim size As Integer = word.Length
        ' Make sure the word is at least two characters in length
        If (size > 1) Then
            ' Convert the word to all uppercase
            word = word.ToUpper(System.Globalization.CultureInfo.InvariantCulture)
            ' Convert the word to character array for faster processing
            Dim chars As Char() = word.ToCharArray()
            ' Buffer to build up with character codes
            Dim buffer As StringBuilder = New StringBuilder()
            ' The current and previous character codes
            Dim prevCode As Integer = 0
            Dim currCode As Integer = 0
            ' Append the first character to the buffer
            buffer.Append(chars(0))
            ' Loop through all the characters and convert them to the proper character code
            For i As Integer = 1 To size - 1
                Select Case chars(i)

                    Case "A", "E", "I", "O", "U", "H", "W", "Y"
                        currCode = 0

                    Case "B", "F", "P", "V"
                        currCode = 1

                    Case "C", "G", "J", "K", "Q", "S", "X", "Z"
                        currCode = 2

                    Case "D", "T"
                        currCode = 3

                    Case "L"
                        currCode = 4

                    Case "M", "N"
                        currCode = 5

                    Case "R"
                        currCode = 6
                End Select

                ' Check to see if the current code is the same as the last one
                If (currCode <> prevCode) Then

                    ' Check to see if the current code is 0 (a vowel); do not process vowels
                    If (currCode <> 0) Then
                        buffer.Append(currCode)
                    End If
                End If
                ' Set the new previous character code
                prevCode = currCode
                ' If the buffer size meets the length limit, then exit the loop
                If (buffer.Length = length) Then
                    Exit For
                End If
            Next
            ' Pad the buffer, if required
            size = buffer.Length
            If (size < length) Then
                buffer.Append("0", (length - size))
            End If
            ' Set the value to return
            value = buffer.ToString()
        End If
        ' Return the value
        Return value
    End Function
    ' </SnippetSoundEx>

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        ' <SnippetCreateLDVFromQuery1>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of Boolean)("OnlineOrderFlag") = True _
            Order By order.Field(Of Decimal)("TotalDue") _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetCreateLDVFromQuery1>
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        ' <SnippetCreateLDVFromQuery2>
        Dim orders As DataTable = dataSet.Tables("SalesOrderDetail")

        Dim query = _
            From order In orders.AsEnumerable() _
            Where (order.Field(Of Int16)("OrderQty") > 2 And _
                   order.Field(Of Int16)("OrderQty") < 6) _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        dataGridView1.AutoResizeColumns()
        ' </SnippetCreateLDVFromQuery2>
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        ' <SnippetCreateLDVFromQuery3>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Where contact.Field(Of String)("LastName").StartsWith("S") _
            Select contact

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetCreateLDVFromQuery3>
    End Sub

    Private Sub button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button4.Click
        ' <SnippetCreateLDVFromQuery4>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of DateTime)("OrderDate") > New DateTime(2002, 9, 15) _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetCreateLDVFromQuery4>
    End Sub

    Private Sub button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button5.Click
        ' <SnippetCreateLDVFromTable>
        Dim orders As DataTable = dataSet.Tables("SalesOrderDetail")

        Dim view As DataView = orders.AsDataView()
        bindingSource1.DataSource = view
        dataGridView1.AutoResizeColumns()
        ' </SnippetCreateLDVFromTable>
    End Sub

    Private Sub button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button6.Click
        ' <SnippetCreateLDVFromQueryOrderBy>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Order By order.Field(Of DateTime)("OrderDate") _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetCreateLDVFromQueryOrderBy>
    End Sub

    Private Sub button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button7.Click
        ' <SnippetCreateLDVFromQueryStringSort>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Where contact.Field(Of String)("LastName").StartsWith("S") _
            Select contact

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        view.Sort = "LastName desc, FirstName asc"
        ' </SnippetCreateLDVFromQueryStringSort>
    End Sub

    Private Sub button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button8.Click
        ' <SnippetCreateLDVFromQueryOrderByThenBy>
        Dim orders As DataTable = dataSet.Tables("SalesOrderDetail")

        Dim query = _
            From order In orders.AsEnumerable() _
            Order By order.Field(Of Int16)("OrderQty"), order.Field(Of Integer)("SalesOrderID") _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetCreateLDVFromQueryOrderByThenBy>
    End Sub

    Private Sub button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button9.Click
        ' <SnippetCreateLDVFromQueryOrderBy2>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Order By order.Field(Of Decimal)("TotalDue") _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetCreateLDVFromQueryOrderBy2>
    End Sub

    Private Sub button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button10.Click
        ' <SnippetCreateLDVFromQueryOrderByDescending>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Order By order.Field(Of DateTime)("OrderDate") Descending _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetCreateLDVFromQueryOrderByDescending>
    End Sub

    Private Sub button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button11.Click
        ' <SnippetLDVStringSort>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim view As DataView = contacts.AsDataView()

        view.Sort = "LastName desc, FirstName asc"

        bindingSource1.DataSource = view
        dataGridView1.AutoResizeColumns()
        ' </SnippetLDVStringSort>
    End Sub

    Private Sub button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button12.Click
        ' <SnippetLDVClearSort>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Order By order.Field(Of Decimal)("TotalDue") _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        view.Sort = ""
        ' </SnippetLDVClearSort>
    End Sub

    Private Sub button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button13.Click
        ' <SnippetLDVClearRowFilter>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim view As DataView = contacts.AsDataView()
        view.RowFilter = "LastName='Zhu'"
        bindingSource1.DataSource = view
        dataGridView1.AutoResizeColumns()

        ' Clear the row filter.
        view.RowFilter = ""
        ' </SnippetLDVClearRowFilter>
    End Sub

    Private Sub button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button14.Click
        ' <SnippetLDVRowFilter>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim view As DataView = contacts.AsDataView()
        view.RowFilter = "LastName='Zhu'"
        bindingSource1.DataSource = view
        dataGridView1.AutoResizeColumns()
        ' </SnippetLDVRowFilter>
    End Sub

    Private Sub button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button15.Click
        ' <SnippetLDVSoundExFilter>
        Dim contacts As DataTable = dataSet.Tables("Contact")
        Dim soundExCode As String = SoundEx("Zhu")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Where SoundEx(contact.Field(Of String)("LastName")) = soundExCode _
            Select contact

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        dataGridView1.AutoResizeColumns()
        ' </SnippetLDVSoundExFilter>
    End Sub

    Private Sub button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button16.Click
        ' <SnippetLDVFromQueryWhere>
        Dim orders As DataTable = dataSet.Tables("SalesOrderDetail")

        Dim query = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of Int16)("OrderQty") > 2 And _
                  order.Field(Of Int16)("OrderQty") < 6 _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetLDVFromQueryWhere>
    End Sub

    Private Sub button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button17.Click
        ' <SnippetLDVFromQueryWhere2>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Where contact.Field(Of String)("LastName") = "Hernandez" _
            Select contact

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetLDVFromQueryWhere2>
    End Sub

    Private Sub button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button18.Click
        ' <SnippetLDVFromQueryWhere3>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of DateTime)("OrderDate") > New DateTime(2002, 6, 1) _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetLDVFromQueryWhere3>
    End Sub

    Private Sub button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button19.Click
        ' <SnippetLDVFromQueryWhereOrderByThenBy>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Where contact.Field(Of String)("LastName").StartsWith("S") _
            Order By contact.Field(Of String)("LastName"), contact.Field(Of String)("FirstName") _
            Select contact

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        dataGridView1.AutoResizeColumns()
        ' </SnippetLDVFromQueryWhereOrderByThenBy>
    End Sub

    Private Sub button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button20.Click
        ' <SnippetLDVFromQueryWhereOrderByThenBy2>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of DateTime)("OrderDate") > New DateTime(2002, 9, 15) _
            Order By order.Field(Of DateTime)("OrderDate"), order.Field(Of Decimal)("TotalDue") _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetLDVFromQueryWhereOrderByThenBy2>
    End Sub

    Private Sub button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button21.Click
        ' <SnippetLDVFromQueryOrderByFind>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Order By contact.Field(Of String)("LastName") _
            Select contact

        Dim view As DataView = query.AsDataView()

        Dim found As Integer = view.Find("Zhu")

        ' </SnippetLDVFromQueryOrderByFind>
    End Sub

    Private Sub button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button22.Click
        ' <SnippetLDVFromQueryFindRows>
        Dim products As DataTable = dataSet.Tables("Product")

        Dim query = _
        From product In products.AsEnumerable() _
        Order By product.Field(Of Decimal)("ListPrice"), product.Field(Of String)("Color") _
        Select product

        Dim view As DataView = query.AsDataView()
        view.Sort = "Color"

        Dim criteria As Object() = New Object() {"Red"}

        Dim foundRowsView As DataRowView() = view.FindRows(criteria)
        ' </SnippetLDVFromQueryFindRows>
    End Sub

    Private Sub button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button23.Click
        ' <SnippetLDVFromQueryWhereSetRowFilter>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim query = _
            From contact In contacts.AsEnumerable() _
            Where contact.Field(Of String)("LastName") = "Hernandez" _
            Select contact

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view

        dataGridView1.AutoResizeColumns()
        view.RowFilter = "LastName='Zhu'"
        ' </SnippetLDVFromQueryWhereSetRowFilter>
    End Sub

    Private Sub button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button24.Click
        ' <SnippetLDVClearRowFilter2>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Where order.Field(Of DateTime)("OrderDate") > New DateTime(2002, 11, 20) _
                And order.Field(Of Decimal)("TotalDue") < New Decimal(60.0) _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        view.RowFilter = Nothing
        ' </SnippetLDVClearRowFilter2>
    End Sub



    Private Sub button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button26.Click
        ' <SnippetLDVClearSort2>
        Dim contacts As DataTable = dataSet.Tables("Contact")

        Dim view As DataView = contacts.AsDataView()
        view.Sort = "LastName desc"

        bindingSource1.DataSource = view
        dataGridView1.AutoResizeColumns()

        'Clear the sort.
        view.Sort = Nothing
        ' </SnippetLDVClearSort2>
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        ' <SnippetCreateLDVFromQueryOrderByYear>
        Dim orders As DataTable = dataSet.Tables("SalesOrderHeader")

        Dim query = _
            From order In orders.AsEnumerable() _
            Order By order.Field(Of DateTime)("OrderDate").Year _
            Select order

        Dim view As DataView = query.AsDataView()
        bindingSource1.DataSource = view
        ' </SnippetCreateLDVFromQueryOrderByYear>
    End Sub

    Private Sub button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button27.Click
        Dim products As DataTable = dataSet.Tables("Product")

        ' Query for red colored products.
        Dim redProductsQuery = _
        From product In products.AsEnumerable() _
        Order By product.Field(Of Decimal)("ListPrice") _
        Select product

        Dim boundView As DataView = redProductsQuery.AsDataView()

        bindingSource1.DataSource = boundView

        ' <SnippetQueryDataView1>
        ' Create a table from the bound view representing a query of
        ' available products.
        Dim view As DataView = CType(bindingSource1.DataSource, DataView)
        Dim productsTable As DataTable = CType(view.Table, DataTable)

        ' Set RowStateFilter to display the current rows.
        view.RowStateFilter = DataViewRowState.CurrentRows

        ' Query the DataView for red colored products ordered by list price.
        Dim productQuery = From rowView As DataRowView In view _
                           Where rowView.Row.Field(Of String)("Color") = "Red" _
                           Order By rowView.Row.Field(Of Decimal)("ListPrice") _
                           Select New With {.Name = rowView.Row.Field(Of String)("Name"), _
                                        .Color = rowView.Row.Field(Of String)("Color"), _
                                        .Price = rowView.Row.Field(Of Decimal)("ListPrice")}

        ' Bind the query results to another DataGridView.
        dataGridView2.DataSource = productQuery.ToList()

        ' </SnippetQueryDataView1>
    End Sub

    Private Sub button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button28.Click
        ' <SnippetQueryDataView2>
        Dim products As DataTable = dataSet.Tables("Product")

        ' Query for red colored products.
        Dim redProductsQuery = _
        From product In products.AsEnumerable() _
        Where product.Field(Of String)("Color") = "Red" _
        Order By product.Field(Of Decimal)("ListPrice") _
        Select product
        ' Create a table and view from the query.
        Dim redProducts As DataTable = redProductsQuery.CopyToDataTable()
        Dim view As DataView = New DataView(redProducts)

        ' Mark a row as deleted.
        redProducts.Rows(0).Delete()

        ' Modify product price.
        redProducts.Rows(1)("ListPrice") = 20.0
        redProducts.Rows(2)("ListPrice") = 30.0

        view.RowStateFilter = DataViewRowState.ModifiedCurrent Or DataViewRowState.Deleted

        ' Query for the modified and deleted rows.
        Dim modifiedDeletedQuery = From rowView As DataRowView In view _
                                   Select rowView

        dataGridView2.DataSource = modifiedDeletedQuery.ToList()
        ' </SnippetQueryDataView2>
    End Sub
End Class
