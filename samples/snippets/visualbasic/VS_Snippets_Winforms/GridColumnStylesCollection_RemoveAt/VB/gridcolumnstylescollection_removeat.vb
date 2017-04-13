' System.Windows.Forms.GridColumnStylesCollection.RemoveAt

' The following program demonstrates the 'RemoveAt(int)' method of
' 'GridColumnStylesCollection' class. An instance of DataGrid is created
' by associating the DataGrid with a data source and column style
' collections are added to it. A Remove button is provided to delete the
' CustomerName column style collection.

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections

Public Class MyForm
   Inherits Form
   Private components As Container
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private WithEvents removeStyle As Button
   Private myColumns As GridColumnStylesCollection
   
   
   Public Sub New()
      InitializeComponent()
      SetUp()
   End Sub 'New
   
   
   Private Sub InitializeComponent()
      ' Create the form and its controls.
      components = New Container()
      myDataGrid = New DataGrid()
      removeStyle = New Button()
      
      
      ' Set the myDataGrid properties.
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(300, 200)
      myDataGrid.CaptionText = "Microsoft DataGrid Control"
      
      ' Set the removeStyle properties.
      removeStyle.Location = New Point(276, 16)
      removeStyle.Name = "removeStyle"
      removeStyle.Size = New Size(120, 24)
      removeStyle.Text = "Remove"
      
      
      ClientSize = New Size(600, 500)
      Name = "GridColumnStylesCollection_RemoveAt"
      [Text] = "DataGrid Control Sample"
      
      ' Add the controls to the form.
      Controls.Add(removeStyle)
      Controls.Add(myDataGrid)
   End Sub 'InitializeComponent
   
   
   Public Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
   
   Private Sub SetUp()
      ' Create the data source.
      MakeDataSet()
      
      ' Associate the data set.
      myDataGrid.SetDataBinding(myDataSet, "Customers")
   End Sub 'SetUp
   
   
   ' Create a DataSet with two tables and populate it.
   Private Sub MakeDataSet()
      ' Create a DataSet.
      myDataSet = New DataSet("myDataSet")
      
      ' Create two DataTables.
      Dim myCustomer As New DataTable("Customers")
      Dim myOrders As New DataTable("Orders")
      
      ' Create two columns, and add them to the first table.
      Dim myCustomerID As New DataColumn("CustID", GetType(Integer))
      Dim myCustomerName As New DataColumn("CustName")
      Dim myCurrent As New DataColumn("Current", GetType(Boolean))
      myCustomer.Columns.Add(myCustomerID)
      myCustomer.Columns.Add(myCustomerName)
      myCustomer.Columns.Add(myCurrent)
      
      ' Create three columns, and add them to the second table.
      Dim myID As New DataColumn("CustID", GetType(Integer))
      Dim myOrderDate As New DataColumn("OrderDate", GetType(DateTime))
      Dim myOrderAmount As New DataColumn("OrderAmount", GetType(Decimal))
      myOrders.Columns.Add(myOrderAmount)
      myOrders.Columns.Add(myID)
      myOrders.Columns.Add(myOrderDate)
      
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(myCustomer)
      myDataSet.Tables.Add(myOrders)
      
      ' Create a DataRelation, and add it to the DataSet.
      Dim myDataRelation As New DataRelation("custToOrders", myCustomerID, myID)
      myDataSet.Relations.Add(myDataRelation)
      
      Dim myNewRow1 As DataRow
      Dim myNewRow2 As DataRow
      
      ' Create three customers in the Customers Table.
      Dim i As Integer
      For i = 1 To 4
         myNewRow1 = myCustomer.NewRow()
         myNewRow1("CustID") = i
         myNewRow1("CustName") = "Item" + i.ToString()
         myNewRow1("Current") = True
         
         ' Add the row to the Customers table.
         myCustomer.Rows.Add(myNewRow1)
      Next i
      
      ' For each customer, create five rows in the Orders table.
      For i = 1 To 4
         Dim j As Integer
         For j = 1 To 5
            myNewRow2 = myOrders.NewRow()
            myNewRow2("CustID") = i
            myNewRow2("OrderDate") = New DateTime(2001, i, j * 2)
            myNewRow2("OrderAmount") = i * 10 + j * 0.1
            
            ' Add the row to the Orders table.
            myOrders.Rows.Add(myNewRow2)
         Next j
      Next i
      ' Add column styles collection.
      AddCustomDataTableStyle()
   End Sub 'MakeDataSet
   
   
   
   Private Sub AddCustomDataTableStyle()
      ' Create a 'DataGridTableStyle'.
      Dim myTableStyle1 As New DataGridTableStyle()
      
      ' Map the table style.
      myTableStyle1.MappingName = "Customers"
      myTableStyle1.AlternatingBackColor = Color.LightGray
      
      ' Add a Name column style.
      Dim myTextCol = New DataGridTextBoxColumn()
      myTextCol.MappingName = "CustName"
      myTextCol.HeaderText = "Customer Name"
      myTextCol.Width = 100
      myTableStyle1.GridColumnStyles.Add(myTextCol)
      
      ' Add a Current column style.
      Dim myBoolCol = New DataGridBoolColumn()
      myBoolCol.MappingName = "Current"
      myBoolCol.HeaderText = "IsCurrent Customer"
      myBoolCol.Width = 125
      myTableStyle1.GridColumnStyles.Add(myBoolCol)
      
      ' Create the second table style with columns.
      Dim myTableStyle2 As New DataGridTableStyle()
      myTableStyle2.MappingName = "Orders"
      myTableStyle2.AlternatingBackColor = Color.LightBlue
      
      ' Create Order Date Column Style.
      Dim myOrderDate = New DataGridTextBoxColumn()
      myOrderDate.MappingName = "OrderDate"
      myOrderDate.HeaderText = "Order Date"
      myOrderDate.Width = 100
      myTableStyle2.GridColumnStyles.Add(myOrderDate)
      
      ' Get the PropertyDescriptor of data set.
      Dim myPCol As PropertyDescriptorCollection = Me.BindingContext _
                                 (myDataSet, "Customers.custToOrders").GetItemProperties()
      ' Create the Order Amount Column style.
      Dim myOrderAmount = New DataGridTextBoxColumn(myPCol("OrderAmount"), "c", True)
      myOrderAmount.MappingName = "OrderAmount"
      myOrderAmount.HeaderText = "Total"
      myOrderAmount.Width = 100
      myTableStyle2.GridColumnStyles.Add(myOrderAmount)
      
      ' Add the DataGridTableStyle objects to the GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle1)
      myDataGrid.TableStyles.Add(myTableStyle2)
   End Sub 'AddCustomDataTableStyle
   
' <Snippet1>
   Private Sub RemoveColumnStyle_Clicked(sender As Object, e As EventArgs) Handles removeStyle.Click
      Dim myTableStyle As DataGridTableStyle = myDataGrid.TableStyles(0)
      
      ' Get the GridColumnStylesCollection of Data Grid.
      myColumns = myTableStyle.GridColumnStyles
      Dim i As Integer
      
      ' Remove the CustName ColumnStyle from the data grid.
      If myColumns.Contains("CustName") Then
         Dim myDataColumnStyle As DataGridColumnStyle = myColumns("CustName")
         i = myColumns.IndexOf(myDataColumnStyle)
         myColumns.RemoveAt(i)
      End If
   End Sub 'RemoveColumnStyle_Clicked
' </Snippet1>
End Class 'MyForm 