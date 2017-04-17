' System.Windows.Forms.DataGridColumnStyle.MappingNameChanged
'
' The following example demonstrates the 'MappingNameChanged' event of
' 'DataGridColumnStyle' class. It adds a DataGrid and a button to a Form.
' When the user clicks on the 'Change Mapping Name' button, it changes
' mapping name and generates 'MappingNameChanged' event.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports System.Data

Public Class MyForm
   Inherits Form
   Private myDataGrid As DataGrid
   Private flag As Boolean
   Private myButton As Button
   Private myDataSet As DataSet
   Private myColumnStyle As DataGridColumnStyle

   Public Sub New()
      InitializeComponent()
      SetUp()
   End Sub 'New

   Private Sub InitializeComponent()
      myDataGrid = New DataGrid()
      myButton = New Button()
      myDataGrid.Location = New Point(24, 24)
      myDataGrid.Name = "myDataGrid"
      myDataGrid.CaptionText = "DataGridColumn"
      myDataGrid.Height = 130
      myDataGrid.Width = 150
      myDataGrid.TabIndex = 0

      myButton.Location = New Point(60, 208)
      myButton.Name = "myButton "
      myButton.TabIndex = 3
      myButton.Size = New Size(140, 20)
      myButton.Text = "Change Mapping Name"
      AddHandler myButton.Click, AddressOf button_Click

      ClientSize = New Size(292, 273)
      Controls.AddRange(New Control() {myButton, myDataGrid})
      Name = "Form1"
      Text = "MappingNameChanged Event"
      ResumeLayout(False)
   End Sub 'InitializeComponent

   Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main

   Private Sub SetUp()
      MakeDataSet()
      myDataGrid.SetDataBinding(myDataSet, "Orders")
   End Sub 'SetUp

   Private Sub MakeDataSet()
      myDataSet = New DataSet("myDataSet")
      Dim myTable As New DataTable("Orders")
      Dim myColumn As New DataColumn("Amount", GetType(Decimal))
      Dim myColumn1 As New DataColumn("Orders", GetType(Decimal))

      myTable.Columns.Add(myColumn)
      myTable.Columns.Add(myColumn1)
      myDataSet.Tables.Add(myTable)
      Dim newRow As DataRow
      Dim j As Integer
      For j = 1 To 14
         newRow = myTable.NewRow()
         newRow("Amount") = j * 10
         newRow("Orders") = 10
         myTable.Rows.Add(newRow)
      Next j
      AddCustomColumnStyle()
   End Sub 'MakeDataSet

' <Snippet1>
   Private Sub AddCustomColumnStyle()
      Dim myTableStyle As New DataGridTableStyle()
      myTableStyle.MappingName = "Orders"
      myColumnStyle = New DataGridTextBoxColumn()
      myColumnStyle.MappingName = "Orders"
      myColumnStyle.HeaderText = "Orders"
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      myDataGrid.TableStyles.Add(myTableStyle)
      AddHandler myColumnStyle.MappingNameChanged, AddressOf columnStyle_MappingNameChanged
      flag = True
   End Sub 'AddCustomColumnStyle

   ' MappingNameChanged event handler of DataGridColumnStyle.
   Private Sub columnStyle_MappingNameChanged(ByVal sender As Object, ByVal e As EventArgs)
      MessageBox.Show("Mapping Name changed")
   End Sub 'columnStyle_MappingNameChanged
' </Snippet1>

   Private Sub button_Click(ByVal sender As Object, ByVal e As EventArgs)
      ' Change the Mapping name.
      If flag Then
         myColumnStyle = myDataGrid.TableStyles(0).GridColumnStyles("Orders")
         myColumnStyle.MappingName = "Amount"
         myColumnStyle.HeaderText = "Amount"
         Me.Refresh()
         flag = False
      Else
         myColumnStyle = myDataGrid.TableStyles(0).GridColumnStyles("Amount")
         myColumnStyle.MappingName = "Orders"
         myColumnStyle.HeaderText = "Orders"
         Me.Refresh()
         flag = True
      End If
   End Sub 'button_Click
End Class 'MyForm

