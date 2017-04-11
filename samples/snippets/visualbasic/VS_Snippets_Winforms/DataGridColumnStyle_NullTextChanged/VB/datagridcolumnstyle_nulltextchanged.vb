' System.Windows.Forms.DataGridColumnStyle.NullTextChanged
'
'
' The following example demonstrates the 'NullTextChanged' event of
' 'DataGridColumnStyle' class. It adds  a DataGrid and a Button.to a 'Form'.
' When user clicks the 'Delete Column values' button, the column becomes
' empty and  'NullTextChanged' event is raised  which is handled by event
' handler function.
'

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports System.Data

Public Class MyForm
   Inherits Form
   Private myDataGrid As DataGrid
   Private myButton As Button
   Private myDataSet As DataSet
   Private myTableStyle As DataGridTableStyle
   Private myCell As DataGridCell
   Private myColumnStyle As DataGridColumnStyle
   Private myCurrencyManager As CurrencyManager
   Public myRowcount As Integer

   Public Sub New()
      InitializeComponent()
      MakeDataSet()
      myDataGrid.SetDataBinding(myDataSet, "CustTable")
      myCurrencyManager = CType(Me.BindingContext(myDataSet, "CustTable"), CurrencyManager)
   End Sub 'New

   Private Sub InitializeComponent()
      myDataGrid = New DataGrid()
      myCell = New DataGridCell()
      myButton = New Button()

      myDataGrid.Location = New Point(24, 24)
      myDataGrid.Name = "myDataGrid"
      myDataGrid.CaptionText = "DataGridColumn "
      myDataGrid.Size = New Size(130, 93)

      myButton.Location = New Point(60, 208)
      myButton.Size = New Size(130, 20)
      myButton.Text = "Delete Column Values"
      AddHandler myButton.Click, AddressOf button_Click

      ClientSize = New Size(360, 273)
      Controls.AddRange(New Control() {myButton, myDataGrid})
      Text = "NullTextChanged "
   End Sub 'InitializeComponent

   Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main

   Private Sub MakeDataSet()
      myDataSet = New DataSet("myDataSet")
      Dim custTable As New DataTable("CustTable")
      Dim custName As New DataColumn("Customers")
      custTable.Columns.Add(custName)
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(custTable)
      ' Create a DataRow variable.
      Dim newRow1 As DataRow
      Dim i As Integer
      For i = 1 To 3
         newRow1 = custTable.NewRow()
         newRow1("Customers") = i
         ' Add the row to the Customers table.
         custTable.Rows.Add(newRow1)
      Next i
      ' Give each customer a distinct name.
      custTable.Rows(0)("Customers") = "Alpha"
      custTable.Rows(1)("Customers") = "Beta"
      custTable.Rows(2)("Customers") = "Omega"
      AddCustomColumnStyle()
   End Sub 'MakeDataSet

' <Snippet1>
   Private Sub AddCustomColumnStyle()
      myTableStyle = New DataGridTableStyle()
      myColumnStyle = New DataGridTextBoxColumn()
      AddHandler myColumnStyle.NullTextChanged, AddressOf columnStyle_NullTextChanged
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      myDataGrid.TableStyles.Add(myTableStyle)
   End Sub 'AddCustomColumnStyle

   ' NullTextChanged event handler of DataGridColumnStyle.
   Private Sub columnStyle_NullTextChanged(ByVal sender As Object, ByVal e As EventArgs)
      Dim i As Integer
      For i = 0 To myRowcount - 1
         myCell.RowNumber = i
         myDataGrid(myCell) = Nothing
      Next i
      MessageBox.Show("NullTextChanged Event is handled")
   End Sub 'columnStyle_NullTextChanged
' </Snippet1>

   Private Sub button_Click(ByVal sender As Object, ByVal e As EventArgs)
      myRowcount = myCurrencyManager.Count
      ' Set the column to null reference.
      Dim i As Integer
      For i = 0 To myRowcount - 1
         myCell.RowNumber = i
         myDataGrid(myCell) = ""
      Next i
      myColumnStyle.NullText = Nothing
   End Sub 'button_Click
End Class 'MyForm


