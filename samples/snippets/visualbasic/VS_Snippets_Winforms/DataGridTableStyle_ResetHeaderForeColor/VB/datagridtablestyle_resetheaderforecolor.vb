 ' System.Windows.Forms.DataGridTableStyle.ResetHeaderForeColor

' The following example demonstrates 'ResetHeaderForeColor' method of 
' 'DataGridTableStyle' class. It adds a datagrid and two buttons to a 
' form. A 'DataGridTableStyle' instance is mapped to the table of 
' 'DataGrid'. When the user clicks on 'Set the HeaderForeColor' button 
' it sets the header fore color. If the user clicks on 'Reset HeaderForeColor'
' button it resets the grid 'HeaderForeColor' to its default value.

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Public Class MyForm1
   Inherits Form
   Private myButton1 As Button
   Private myButton2 As Button
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private myDataGridColumnStyle As DataGridColumnStyle
   Private myDataTableStyle As DataGridTableStyle
   
   
   Public Sub New()
      InitializeComponent()
      ' Create a dataset.
      MakeDataSet()
      ' Bind datagrid to the dataset.
      myDataGrid.SetDataBinding(myDataSet, "Customers")
      AddCustomDataTableStyle()
   End Sub 'New
   
   
   Private Sub InitializeComponent()
      ' Create the form and its controls.
      myButton1 = New Button()
      myButton2 = New Button()
      
      myDataGrid = New DataGrid()
      Text = "DataGridTableStyle Sample"
      ClientSize = New Size(450, 330)
      
      myButton1.Location = New Point(50, 16)
      myButton1.Size = New Size(176, 23)
      myButton1.Text = "Set the HeaderForeColor"
      AddHandler myButton1.Click, AddressOf myButton1_Click
      
      myButton2.Location = New Point(230, 16)
      myButton2.Size = New Size(140, 24)
      myButton2.Text = "Reset HeaderForeColor"
      AddHandler myButton2.Click, AddressOf myButton2_Click
      
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(240, 150)
      myDataGrid.CaptionText = "DataGridTableStyle Example"
      Controls.Add(myButton1)
      Controls.Add(myDataGrid)
      Controls.Add(myButton2)
   End Sub 'InitializeComponent
   
   
   Public Shared Sub Main()
      Application.Run(New MyForm1())
   End Sub 'Main
   
   
' <Snippet1>
    Private Sub myButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Set the 'HeaderForeColor' property.
        myDataTableStyle.HeaderForeColor = Color.Blue
    End Sub 'myButton1_Click
   
    Private Sub myButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset the 'HeaderForeColor' property to its default value.
        myDataTableStyle.ResetHeaderForeColor()
    End Sub 'myButton2_Click
   
' </Snippet1>

   Private Sub AddCustomDataTableStyle()
      ' Create a 'DataGridTableStyle'.
      myDataTableStyle = New DataGridTableStyle()
      myDataTableStyle.MappingName = "Customers"
      ' Create a 'DataGridColumnStyle'.
      myDataGridColumnStyle = New DataGridTextBoxColumn()
      myDataGridColumnStyle.MappingName = "CustName"
      myDataGridColumnStyle.HeaderText = "Customer Name"
      myDataGridColumnStyle.Width = 150
      ' Add the 'DataGridColumnStyle' to 'DataGridTableStyle'.
      myDataTableStyle.GridColumnStyles.Add(myDataGridColumnStyle)
      ' Add the 'DataGridTableStyle' to 'DataGrid'.
      myDataGrid.TableStyles.Add(myDataTableStyle)
   End Sub 'AddCustomDataTableStyle
   
   
   ' Create a dataset with one table and populate it.
   Private Sub MakeDataSet()
      ' Create a dataset.
      myDataSet = New DataSet("myDataSet")
      Dim myTable As New DataTable("Customers")
      ' Create a column, and add it to the table.
      Dim myColumn As New DataColumn("CustName", GetType(String))
      myTable.Columns.Add(myColumn)
      
      ' Add the table to dataset.
      myDataSet.Tables.Add(myTable)
      
      Dim newRow1 As DataRow
      Dim i As Integer
      For i = 0 To 4
         newRow1 = myTable.NewRow()
         newRow1("CustName") = i
         ' Add the row to customers table.
         myTable.Rows.Add(newRow1)
      Next i
      myTable.Rows(0)("CustName") = "Jones"
      myTable.Rows(1)("CustName") = "James"
      myTable.Rows(2)("CustName") = "David"
      myTable.Rows(3)("CustName") = "Robert"
      myTable.Rows(4)("CustName") = "John"
   End Sub 'MakeDataSet
End Class 'MyForm1