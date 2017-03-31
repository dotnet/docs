' System.Windows.Forms.DataGridTableStyle.ResetHeaderFont

' The following example demonstrates 'ResetHeaderFont' method of 'DataGridTableStyle'
' class. A DataGrid and two Button's are added to a form. When user clicks 
' 'Set Header Font' button the Header Font of  DataGrid is changed. The 
' HeaderFont is reset to its default value when the 'Reset Header Font' 
' button is clicked.


Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class myDataForm
   Inherits Form
   Private mySetButton As Button
   Private myResetButton As Button
   Private myLabel As Label
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private myTableStyle As DataGridTableStyle
   
   Public Sub New()
      InitializeComponent()
      SetUp()
   End Sub 'New
   
   Private Sub InitializeComponent()
      ' Create the form and its controls.
      mySetButton = New Button()
      myDataGrid = New DataGrid()
      ClientSize = New Size(450, 330)
      mySetButton.Location = New Point(24, 16)
      mySetButton.Size = New Size(220, 24)
      mySetButton.Text = "Set Header Font To 'Impact'"
      AddHandler mySetButton.Click, AddressOf MySetButton_Click
      myResetButton = New Button()
      myResetButton.Location = New Point(250, 16)
      myResetButton.Size = New Size(130, 24)
      myResetButton.Text = "Reset Header Font"
      AddHandler myResetButton.Click, AddressOf MyResetButton_Click
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(120, 200)
      myDataGrid.CaptionText = "DataGrid Control"
      myLabel = New Label()
      myLabel.Location = New Point(24, 270)
      myLabel.Width = 500
      Controls.Add(mySetButton)
      Controls.Add(myResetButton)
      Controls.Add(myDataGrid)
      Controls.Add(myLabel)
      Text = "ResetHeaderFont example"

   End Sub 'InitializeComponent
   
   Public Shared Sub Main()
      Application.Run(New myDataForm())
   End Sub 'Main
   
   Private Sub SetUp()
      ' Create a DataSet with a table.
      MakeDataSet()
      ' Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Orders")
      ' Create the DataGridTableStyle.
      myTableStyle = New DataGridTableStyle()
      ' Map DataGridTableStyle to a DataTable.
      myTableStyle.MappingName = "Orders"
   End Sub 'SetUp
   
' <Snippet1>
    Private Sub MySetButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Set the 'HeaderFont' property of DataGridTableStyle instance.
        myTableStyle.HeaderFont = New Font("Impact", 10)
        ' Add the DataGridTableStyle instance to the GridTableStylesCollection. 
        myDataGrid.TableStyles.Add(myTableStyle)
    End Sub 'MySetButton_Click
   
    Private Sub MyResetButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset the Header Font to its default value.
        myTableStyle.ResetHeaderFont()
    End Sub 'MyResetButton_Click
' </Snippet1>

   Private Sub MakeDataSet()
      ' Create a DataSet.
      myDataSet = New DataSet("myDataSet")
      Dim myTable As New DataTable("Orders")
      Dim myColumn As New DataColumn("Amount", GetType(Decimal))
      myTable.Columns.Add(myColumn)
      ' Add the table to the DataSet.
      myDataSet.Tables.Add(myTable)
      Dim newRow As DataRow
      Dim j As Integer
      For j = 1 To 14
         newRow = myTable.NewRow()
         newRow("Amount") = j * 10
         ' Add the row to the Orders table.
         myTable.Rows.Add(newRow)
      Next j
   End Sub 'MakeDataSet
End Class 'myDataForm