 ' System.Windows.Forms.DataGridTableStyle.ResetHeaderBackColor

' The following example demonstrates the 'ResetHeaderBackColor' method 
' of 'DataGridTableStyle' class. It adds a 'DataGrid' and two buttons 
' to a form. Then it creates a 'DataGridTableStyle' and maps it to the 
' table of 'DataGrid'. When the user clicks on  'Change the ResetHeaderBackColor' 
' button it changes the Header Background color to light pink. If the 
' user clicks the 'ResetHeaderBackColor' button it changes the Header 
' Background Color to default color.

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private myButton As Button
   Private myButton1 As Button
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
      myButton = New Button()
      myButton1 = New Button()
      
      myDataGrid = New DataGrid()
      Text = "DataGridTableStyle Sample"
      ClientSize = New Size(450, 330)
      
      myButton.Location = New Point(50, 16)
      myButton.Name = "button1"
      myButton.Size = New Size(176, 23)
      myButton.TabIndex = 2
      myButton.Text = "Change the HeaderBackColor"
      AddHandler myButton.Click, AddressOf Button_Click
      
      myButton1.Location = New Point(230, 16)
      myButton1.Name = "myButton"
      myButton1.Size = New Size(140, 24)
      myButton1.TabIndex = 0
      myButton1.Text = "Reset HeaderBackColor"
      AddHandler myButton1.Click, AddressOf Button1_Click
      
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(240, 150)
      myDataGrid.CaptionText = "DataGridTableStyle"
      Controls.Add(myButton)
      Controls.Add(myDataGrid)
      Controls.Add(myButton1)
   End Sub 'InitializeComponent
   
   
   Public Shared Sub Main()
      Application.Run(New Form1())
   End Sub 'Main
   
   
' <Snippet1>
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Change the color of 'HeaderBack'.
        myDataTableStyle.HeaderBackColor = Color.LightPink
    End Sub 'Button_Click
   
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset the 'HeaderBack' to its origanal color.
        myDataTableStyle.ResetHeaderBackColor()
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
         ' Add the row to the Customers table.
         myTable.Rows.Add(newRow1)
      Next i
      myTable.Rows(0)("CustName") = "Jones"
      myTable.Rows(1)("CustName") = "James"
      myTable.Rows(2)("CustName") = "David"
      myTable.Rows(3)("CustName") = "Robert"
      myTable.Rows(4)("CustName") = "John"
   End Sub 'MakeDataSet
End Class 'Form1