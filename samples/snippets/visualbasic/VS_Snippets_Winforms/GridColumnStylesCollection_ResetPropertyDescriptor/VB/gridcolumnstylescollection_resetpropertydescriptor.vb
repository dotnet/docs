' System.Windows.Forms.GridColumnStylesCollection.ResetPropertyDescriptors()

' The following program demonstrates the 'ResetPropertyDecriptors()'
' method of 'GridColumnStylesCollection' class. An instance of DataGrid is
' created and associate the data source to DataGrid. Then
' column styles are added to the data grid. A Reset button is
' provided to reset the property descriptors of the DataGrid
' columns.


Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Public Class MyForm
   Inherits Form
   Private myComponents As Container
   Private resetButton As Button
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
      
      Me.resetButton = New Button()
      resetButton.Location = New Point(24, 16)
      resetButton.Size = New Size(124, 30)
      resetButton.Text = "Reset Property Descriptor"
      AddHandler resetButton.Click, AddressOf ResetButton_Click
      
      Me.myDataGrid = New DataGrid()
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(300, 200)
      myDataGrid.CaptionText = "Microsoft DataGrid Control"
      
      Me.Controls.Add(resetButton)
      Me.Controls.Add(myDataGrid)
   End Sub 'InitializeComponent
   
   
   Public Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
   
   Private Sub MyDataSource()
      ' Create a DataSet with one table
      MakeDataSet()
      ' Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Customers")
   End Sub 'MyDataSource
   
   
' <Snippet1>
    Private Sub ResetButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim myTableStyle As DataGridTableStyle = myDataGrid.TableStyles(0)
        Dim myColumns As GridColumnStylesCollection = myTableStyle.GridColumnStyles

        ' Reset the property descriptor of column styles collection.
        myColumns.ResetPropertyDescriptors()
    End Sub 'ResetButton_Click
   
' </Snippet1>
   
   Private Sub AddCustomDataTableStyle()
      ' Get the currency manager for 'myDataSet' data source.
      Dim myCurrencyManger As CurrencyManager = CType(Me.BindingContext(myDataSet), CurrencyManager)
      
      ' Associate the 'DataGridTableStyle' to the 'myDataSet' data source.
      Dim myTableStyle As New DataGridTableStyle()
      myTableStyle.MappingName = "Customers"
      
      ' Add style for 'Name' column.
      Dim pdName As PropertyDescriptor = myCurrencyManger.GetItemProperties()("CustName")
      
      ' Create an instance of 'DataGridColumnStyle'.
      Dim myCustomerNameStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(pdName)
      
      myCustomerNameStyle.MappingName = "custName"
      myCustomerNameStyle.HeaderText = "Customer Name"
      myTableStyle.GridColumnStyles.Add(myCustomerNameStyle)
      
      ' Add style for 'Date' column.
      Dim myDateDescriptor As PropertyDescriptor = myCurrencyManger.GetItemProperties()("Date")
      
      Dim myDateStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(myDateDescriptor, "G")
      
      myDateStyle.MappingName = "Date"
      myDateStyle.HeaderText = "Date"
      myDateStyle.Width = 150
      myTableStyle.GridColumnStyles.Add(myDateStyle)
      
      ' Add DataGridTableStyle instances to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle)
   End Sub 'AddCustomDataTableStyle
   
   
   Private Sub MakeDataSet()
      myDataSet = New DataSet("myDataSet")
      
      Dim myCustomerTable As New DataTable("Customers")
      
      ' Create two columns, and add them to the table.
      Dim myCustomerName As New DataColumn("CustName")
      Dim myDate As New DataColumn("Date", GetType(System.DateTime))
      myCustomerTable.Columns.Add(myCustomerName)
      myCustomerTable.Columns.Add(myDate)
      
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(myCustomerTable)
      
      Dim myNewRow As DataRow
      Dim i As Integer
      For i = 1 To 2
         myNewRow = myCustomerTable.NewRow()
         
         ' Add the row to the Customers table.
         myCustomerTable.Rows.Add(myNewRow)
      Next i
      
      myCustomerTable.Rows(0)("custName") = "Customer1"
      myCustomerTable.Rows(1)("custName") = "Customer2"
      
      myCustomerTable.Rows(0)("Date") = System.DateTime.Now
      myCustomerTable.Rows(1)("Date") = System.DateTime.Today
      
      ' Add column style collections.
      AddCustomDataTableStyle()
   End Sub 'MakeDataSet
End Class 'MyForm