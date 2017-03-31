' System.Windows.Forms.DataGridTableStyle.ResetGridLineColor

' The following example demonstrates the 'ResetGridLineColor'  method 
' of 'DataGridTableStyle' class. It adds a 'DataGrid' and two buttons 
' to a form. Then it creates a 'DataGridTableStyle' and adds it to the 
' 'DataGrid'. When the user clicks, the 'Change the GridLineColor' 
' button it changes the GridLineColor to 'blue'. If the user clicks the 
' 'Reset GridLineColor' button it changes the GridLineColor to  default color.

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private WithEvents myButton As Button
   Private WithEvents myButton1 As Button
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private myDataGridColumnStyle As DataGridColumnStyle
   Private myDataTableStyle As DataGridTableStyle
   
   
   Public Sub New()
      InitializeComponent()
      MakeDataSet()
      myDataGrid.SetDataBinding(myDataSet, "Customers")
      AddCustomDataTableStyle()
   End Sub 'New
   
   
   Private Sub InitializeComponent()
      ' Create the form and its controls.
      Me.myButton = New Button()
      Me.myButton1 = New Button()
      
      Me.myDataGrid = New DataGrid()
      Me.Text = "DataGridTableStyle Sample"
      Me.ClientSize = New Size(450, 330)
      
      Me.myButton.Location = New Point(50, 16)
      Me.myButton.Name = "button1"
      Me.myButton.Size = New Size(176, 23)
      Me.myButton.TabIndex = 2
      Me.myButton.Text = "Change the GridLineColor"
      
      Me.myButton1.Location = New Point(230, 16)
      Me.myButton1.Name = "myButton"
      Me.myButton1.Size = New Size(140, 24)
      Me.myButton1.TabIndex = 0
      Me.myButton1.Text = "Reset GridLineColor"
      
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(240, 150)
      myDataGrid.CaptionText = "DataGridTableStyle"
      Me.Controls.Add(myButton)
      Me.Controls.Add(myDataGrid)
      Me.Controls.Add(myButton1)
   End Sub 'InitializeComponent
   
   
   Public Shared Sub Main()
      Application.Run(New Form1())
   End Sub 'Main
   
   
' <Snippet1>
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles myButton.Click
        ' Change the 'GridLineColor'.
        myDataTableStyle.GridLineColor = Color.Blue
    End Sub 'Button_Click
   
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles myButton1.Click
        ' Reset the 'GridLineColor' to its orginal color.
        myDataTableStyle.ResetGridLineColor()
    End Sub 'Button1_Click
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
   
   
   ' Create a DataSet with two tables and populate it.
   Private Sub MakeDataSet()
      myDataSet = New DataSet("myDataSet")
      
      Dim myTable As New DataTable("Customers")
      Dim myColumn As New DataColumn("CustName", GetType(String))
      myTable.Columns.Add(myColumn)
      
      myDataSet.Tables.Add(myTable)
      
      Dim newRow1 As DataRow
      Dim i As Integer
      For i = 0 To 4
         newRow1 = myTable.NewRow()
         newRow1("CustName") = i
         myTable.Rows.Add(newRow1)
      Next i
      myTable.Rows(0)("CustName") = "Jones"
      myTable.Rows(1)("CustName") = "James"
      myTable.Rows(2)("CustName") = "David"
      myTable.Rows(3)("CustName") = "Robert"
      myTable.Rows(4)("CustName") = "John"
   End Sub 'MakeDataSet
End Class 'Form1