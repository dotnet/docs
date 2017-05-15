' System.Windows.Forms.DataGridTableStyle.ResetAlternatingBackColor

' The following example demonstrates the 'ResetAlternatingBackColor' 
' method of 'DataGridTableStyle' class. It adds a 'DataGrid' and two buttons 
' to a form. The instance of 'DataGridTableStyle' is mapped to a table of 
' DataGrid. One button sets the Alternating background color of 'DataGrid' 
' and other resets it to its default value.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public Class DataGridTableStyle_resetcolor
   Inherits Form
   Private myDataGridTableStyle As New DataGridTableStyle()
   Private myDataGrid As DataGrid
   Private myButton1 As Button
   Private myButton2 As Button
   
   Private Sub InitializeComponent()
      myButton1 = New Button()
      myButton2 = New Button()
      myDataGrid = New DataGrid()
      
      myButton1.Location = New Point(56, 184)
      myButton1.Size = New Size(176, 24)
      myButton1.Text = "Alternating back color "
      AddHandler myButton1.Click, AddressOf myButton1_Click
      
      myButton2.Location = New Point(56, 224)
      myButton2.Size = New Size(184, 24)
      myButton2.Text = "Reset"
      AddHandler myButton2.Click, AddressOf myButton2_Click
      
      myDataGrid.LinkColor = SystemColors.Desktop
      myDataGrid.Location = New Point(56, 32)
      myDataGrid.Name = "myDataGrid"
      myDataGrid.Size = New Size(168, 144)
      myDataGrid.TabIndex = 1
      
      ClientSize = New Size(292, 273)
      Controls.AddRange(New Control() {myButton2, myDataGrid, myButton1})
      Text = "Test DataGridTableStyle.ResetAlternatingBackColor method"
      AddHandler Load, AddressOf DataGridTableStyle_Reset_color
   End Sub 'InitializeComponent
   
   Shared Sub Main()
      Application.Run(New DataGridTableStyle_resetcolor())
   End Sub 'Main
   
   
   Public Sub New()
      InitializeComponent()
      ' Create and bind DataSet to DataGrid.
      CreateDataSet()
   End Sub 'New
   
   Private Sub CreateDataSet()
      ' Create a DataSet
      Dim myDataSet As New DataSet("myDataSet")
      ' Create a DataTable.
      Dim myEmpTable As New DataTable("Employee")
      Dim myEmpID As New DataColumn("EmpID", GetType(Integer))
      myEmpTable.Columns.Add(myEmpID)
      ' Add the table to the DataSet.
      myDataSet.Tables.Add(myEmpTable)
      Dim newRow1 As DataRow
      Dim i As Integer
      For i = 1 To 5
         newRow1 = myEmpTable.NewRow()
         newRow1("EmpID") = i
         ' Add the row to the Employee table.
         myEmpTable.Rows.Add(newRow1)
      Next i
      
      ' Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Employee")
   End Sub 'CreateDataSet
   
   Private Sub DataGridTableStyle_Reset_color(sender As Object, e As EventArgs)
      myDataGridTableStyle.MappingName = "Employee"
      myDataGrid.TableStyles.Add(myDataGridTableStyle)
   End Sub 'DataGridTableStyle_Reset_color
   
' <Snippet1>
   Private Sub myButton1_Click(sender As Object, e As EventArgs)
      'Set the 'AlternatingBackColor'.
      myDataGridTableStyle.AlternatingBackColor = Color.Blue
   End Sub 'myButton1_Click
   
   Private Sub myButton2_Click(sender As Object, e As EventArgs)
      ' Reset the 'AlternatingBackColor'.
      myDataGridTableStyle.ResetAlternatingBackColor()
   End Sub 'myButton2_Click
' </Snippet1>
End Class 'DataGridTableStyle_resetcolor 