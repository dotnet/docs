' System.Windows.Forms.DataGridColumnStyle.ResetHeaderText
'
' The following example demonstrates 'ResetHeaderText' method of
' 'DataGridColumnStyle' class. A 'DataGrid' and two Buttons are added
' to a form. An instance of 'DataGridColumnStyle' is mapped to column of
' 'DataGrid'.On clicking the set button,the Header Text is set. The reset
' button resets the HeaderText to its default value.

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data

Public Class DataGridColumnStyle_Header
   Inherits Form
   Private myDataGrid As DataGrid
   Private resetButton As Button
   Private setButton As Button
   Private myDataGridTableStyle As New DataGridTableStyle()
   Private myDataGridColumnStyle = New DataGridTextBoxColumn()

   Private Sub InitializeComponent()
      setButton = New Button()
      resetButton = New Button()
      myDataGrid = New DataGrid()
      setButton.Location = New Point(32, 208)
      setButton.Size = New Size(120, 23)
      setButton.Text = "Set Header Text"
      AddHandler setButton.Click, AddressOf SetHeaderText
      resetButton.Location = New Point(152, 208)
      resetButton.Size = New Size(120, 23)
      resetButton.Text = "Reset Header Text"
      AddHandler resetButton.Click, AddressOf ResetHeaderText
      ' Grid Initialisation.
      myDataGrid.DataMember = ""
      myDataGrid.Location = New Point(56, 32)
      myDataGrid.Name = "myDataGrid"
      myDataGrid.CaptionText = "DataGrid"
      myDataGrid.Size = New Size(120, 130)
      myDataGrid.TabIndex = 0
      ClientSize = New Size(292, 273)
      Controls.AddRange(New Control() {resetButton, myDataGrid, setButton})
      Name = "DataGridColumnStyle_Width"
      Text = "Change Header Text"
      AddHandler Load, AddressOf DataGridColumnStyle_Reset_Header
   End Sub 'InitializeComponent

   Shared Sub Main()
      Application.Run(New DataGridColumnStyle_Header())
   End Sub 'Main

   Public Sub New()
      InitializeComponent()
      CreateDataSet()
   End Sub 'New

   Private Sub CreateDataSet()
      Dim myDataSet As New DataSet("myDataSet")
      Dim myEmpTable As New DataTable("Employee")
      Dim myEmpID As New DataColumn("EmpID", GetType(Integer))
      myEmpTable.Columns.Add(myEmpID)
      myDataSet.Tables.Add(myEmpTable)
      Dim newRow1 As DataRow
      Dim i As Integer
      For i = 1 To 5
         newRow1 = myEmpTable.NewRow()
         newRow1("EmpID") = i
         myEmpTable.Rows.Add(newRow1)
      Next i
      myDataGrid.SetDataBinding(myDataSet, "Employee")
   End Sub 'CreateDataSet

   Private Sub DataGridColumnStyle_Reset_Header(ByVal sender As Object, ByVal e As EventArgs)
      myDataGridTableStyle.MappingName = "Employee"
      myDataGridColumnStyle.MappingName = "EmpID"
      myDataGridColumnStyle.Width = 50
      myDataGridTableStyle.GridColumnStyles.Add(myDataGridColumnStyle)
      myDataGrid.TableStyles.Add(myDataGridTableStyle)
   End Sub 'DataGridColumnStyle_Reset_Header

' <Snippet1>
   Private Sub SetHeaderText(ByVal sender As Object, ByVal e As EventArgs)
      ' Set the HeaderText property.
      myDataGridColumnStyle.HeaderText = "Emp ID"
      myDataGrid.Invalidate()
   End Sub 'SetHeaderText

   Private Sub ResetHeaderText(ByVal sender As Object, ByVal e As EventArgs)
      ' Reset the HeaderText property to its default value.
      myDataGridColumnStyle.ResetHeaderText()
      myDataGrid.Invalidate()
   End Sub 'ResetHeaderText
' </Snippet1>
End Class 'DataGridColumnStyle_Header



