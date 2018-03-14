' System.Windows.Forms.DataGridTextBoxColumn.DataGridTextBoxColumn(PropertyDescriptor)
' System.Windows.Forms.DataGridTextBoxColumn.DataGridTextBoxColumn(PropertyDescriptor, string)

' The following program demonstrates various constructors of
' 'DataGridTextBoxColumn' class. An instance of 'DataGrid' class is constructed and
' it is associated with data source. When the button "Change Appearance" is clicked,
' the format of the Date column in the grid is modified to a specific format.

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class MyForm
   Inherits Form
   Private myComponents As Container
   Private myButton As Button
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   
   
   Public Sub New()
      ' Required for Windows Form Designer support.
      InitializeComponent()
      
      ' Call MyDataSource to bind the controls.
      MyDataSource()
   End Sub 'New
   
   Private Sub InitializeComponent()
      ' Create the form and its controls.
      Me.myComponents = New Container()
      Me.Text = "DataGrid Control Sample"
      
      Me.myButton = New Button()
      myButton.Location = New Point(24, 16)
      myButton.Size = New Size(124, 30)
      myButton.Text = "Change Appearance"
      AddHandler myButton.Click, AddressOf Button_Click
      
      Me.myDataGrid = New DataGrid()
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(300, 200)
      myDataGrid.CaptionText = "Microsoft DataGrid Control"
      
      Me.Controls.Add(myButton)
      Me.Controls.Add(myDataGrid)
   End Sub 'InitializeComponent
   
   
   Public Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
   
   Private Sub MyDataSource()
      ' Create a DataSet with one table
      CreateDataSet()
      
      ' Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Customers")
   End Sub 'MyDataSource
   
   
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        MyAddCustomDataTableStyle()
        myButton.Enabled = False
    End Sub 'Button_Click
   
   
' <Snippet1>
' <Snippet2>
   Private Sub MyAddCustomDataTableStyle()
      ' Get the currency manager for 'myDataSet'.
      Dim myCurrencyManger As CurrencyManager = CType(Me.BindingContext(myDataSet), CurrencyManager)
      
      Dim myTableStyle As New DataGridTableStyle()
      myTableStyle.MappingName = "Customers"
      
      Dim proprtyDescriptorName As PropertyDescriptor = myCurrencyManger.GetItemProperties()("CustName")
      
      Dim myCustomerNameStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(proprtyDescriptorName)
      
      myCustomerNameStyle.MappingName = "custName"
      myCustomerNameStyle.HeaderText = "Customer Name"
      myTableStyle.GridColumnStyles.Add(myCustomerNameStyle)
      
      ' Add style for 'Date' column.
      Dim myDateDescriptor As PropertyDescriptor = myCurrencyManger.GetItemProperties()("Date")
      ' 'G' is for MM/dd/yyyy HH:mm:ss date format.
      Dim myDateStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(myDateDescriptor, "G")
      
      myDateStyle.MappingName = "Date"
      myDateStyle.HeaderText = "Date"
      myDateStyle.Width = 150
      myTableStyle.GridColumnStyles.Add(myDateStyle)
      
      ' Add DataGridTableStyle instances to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle)
   End Sub 'MyAddCustomDataTableStyle
   
   
' </Snippet2>
' </Snippet1>
   Private Sub CreateDataSet()
      ' Create a DataSet.
      myDataSet = New DataSet("myDataSet")
      
      ' Create an instance of 'DataTable'.
      Dim myCustomerTable As New DataTable("Customers")
      
      ' Create two columns, and add them to the table.
      Dim myCustomerName As New DataColumn("CustName")
      Dim myDate As New DataColumn("Date", GetType(System.DateTime))
      myCustomerTable.Columns.Add(myCustomerName)
      myCustomerTable.Columns.Add(myDate)
      
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(myCustomerTable)
      
      ' Create two customers in the Customers Table.
      Dim myNewRow As DataRow
      Dim i As Integer
      For i = 1 To 2
         myNewRow = myCustomerTable.NewRow()
         
         ' Add the row to the Customers table.
         myCustomerTable.Rows.Add(myNewRow)
      Next i
      
      ' Populate customer name column.
      myCustomerTable.Rows(0)("custName") = "Customer1"
      myCustomerTable.Rows(1)("custName") = "Customer2"
      
      ' Populate date column.
      myCustomerTable.Rows(0)("Date") = System.DateTime.Now
      myCustomerTable.Rows(1)("Date") = System.DateTime.Today
   End Sub 'CreateDataSet 
End Class 'MyForm