 ' System.Windows.Forms.DataGridTableStyle.ResetBackColor

' The following example demonstrates the 'ResetBackColor' method of 
' 'DataGridTableStyle' class. A  DataGrid and  a button are added to 
' 'Form'. The initial back color of the DataGridTableStyle is set to
' pink. When the user clicks on 'ResetBackColor' button, then the value 
' of DataGridBackColor is set to its default value.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports System.Data

Public Class MyForm
   Inherits Form
   Private myDataGrid As DataGrid
   Private myButton1 As Button
   Private myDataSet As DataSet
   Private myTableStyle As DataGridTableStyle
   Private myColumnStyle As DataGridColumnStyle
   
   
   Public Sub New()
      InitializeComponent()
      ' Create a DataSet with a table.
      MakeDataSet()
      ' Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "customerTable")
      AddCustomColumnStyle()
   End Sub 'New
   
   
   ' Initialilze form and its controls.
   Private Sub InitializeComponent()
      myDataGrid = New DataGrid()
      myTableStyle = New DataGridTableStyle()
      myColumnStyle = New DataGridTextBoxColumn()
      myButton1 = New Button()
      
      myDataGrid.Location = New Point(24, 24)
      myDataGrid.Name = "myDataGrid"
      myDataGrid.CaptionText = "DataGridColumn "
      myDataGrid.Size = New Size(150, 153)
      myDataGrid.TabIndex = 0
      
      myButton1.Location = New Point(16, 184)
      myButton1.Name = "myButton1"
      myButton1.Size = New Size(112, 23)
      myButton1.TabIndex = 1
      
      myButton1.Text = "Reset BackColor"
      AddHandler myButton1.Click, AddressOf myButton1_Click
      ClientSize = New Size(360, 273)
      Controls.AddRange(New Control() {myButton1, myDataGrid})
      
      Name = "Form1"
      Text = "Reset BackColor"
      ResumeLayout(False)
   End Sub 'InitializeComponent
   
' <Snippet1>
   Private Sub AddCustomColumnStyle()
      ' Set the TableStyle Mapping name.
      myTableStyle.MappingName = "customerTable"
      myTableStyle.BackColor = Color.Pink
      
      ' Set the ColumnStyle properties and add to TableStyle.
      myColumnStyle.MappingName = "Customers"
      myColumnStyle.HeaderText = "Customer Name"
      myColumnStyle.Width = 250
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      myDataGrid.TableStyles.Add(myTableStyle)
   End Sub 'AddCustomColumnStyle
   
   
   Private Sub myButton1_Click(sender As Object, e As EventArgs)
      ' Reset the background color.
      myTableStyle.ResetBackColor()
   End Sub 'myButton1_Click
' </Snippet1>
   
   Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
   
   
   Private Sub MakeDataSet()
      myDataSet = New DataSet("myDataSet")
      Dim customerTable As New DataTable("customerTable")
      Dim customerName As New DataColumn("Customers")
      customerTable.Columns.Add(customerName)
      myDataSet.Tables.Add(customerTable)
      Dim newRow1 As DataRow
      Dim i As Integer
      For i = 1 To 5
         newRow1 = customerTable.NewRow()
         newRow1("Customers") = i
         
         ' Add the row to the Customers table.
         customerTable.Rows.Add(newRow1)
      Next i
      customerTable.Rows(0)("Customers") = "Alpha"
      customerTable.Rows(1)("Customers") = "Beta"
      customerTable.Rows(2)("Customers") = "Omega"
      customerTable.Rows(3)("Customers") = "Cust1"
      customerTable.Rows(4)("Customers") = "Cust2"
   End Sub 'MakeDataSet
End Class 'MyForm