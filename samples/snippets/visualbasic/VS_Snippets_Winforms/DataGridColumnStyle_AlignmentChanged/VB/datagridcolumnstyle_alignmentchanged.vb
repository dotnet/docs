' System.Windows.Forms.DataGridColumnStyle.AlignmentChanged
'
'
' The following example demonstrates the 'AlignmentChanged' event of
' 'DataGridColumnStyle' class. It adds a DataGrid and a button to a form.
' Then it creates a 'DataGridColumnStyle' object  and adds an eventhandler
' for the 'AlignmentChanged' event. When  user clicks the 'Change Alignment'
' button it changes the alignment of the 'DataGridColumnStyle' and the
' 'AlignmentChanged' event is raised.

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private myButton As Button
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private myDataGridColumnStyle As DataGridColumnStyle
   Private components As System.ComponentModel.IContainer

   Public Sub New()
      InitializeComponent()
      MakeDataSet()
      myDataGrid.SetDataBinding(myDataSet, "Customers")
      AddCustomDataTableStyle()
   End Sub 'New

   Private Sub InitializeComponent()
     ' Create the form and its controls.
      Me.myButton = New Button()

      Me.myDataGrid = New DataGrid()
      Me.Text = "DataGrid Control Sample"
      Me.ClientSize = New Size(450, 330)
      myButton.Location = New Point(150, 16)
      myButton.Size = New Size(120, 24)
      myButton.Text = "Change Alignment"
      AddHandler myButton.Click, AddressOf Button_Click

      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(300, 200)
      myDataGrid.CaptionText = "DataGridColumnStyle"
      Me.Controls.Add(myButton)
      Me.Controls.Add(myDataGrid)
   End Sub 'InitializeComponent

   Public Shared Sub Main()
      Application.Run(New Form1())
   End Sub 'Main
   Private myMessage As String = Nothing

    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        myDataGridColumnStyle.Alignment = HorizontalAlignment.Center
        MessageBox.Show(myMessage)
    End Sub 'Button_Click

' <Snippet1>
    Private Sub AlignmentChanged_Click(ByVal sender As Object, ByVal e As EventArgs)
        myMessage = "Alignment has been Changed"
    End Sub 'AlignmentChanged_Click

   Private Sub AddCustomDataTableStyle()
      ' Create a 'DataGridTableStyle'.
      Dim myDataTableStyle As New DataGridTableStyle()
      myDataTableStyle.MappingName = "Customers"
      ' Create a 'DataGridColumnStyle'.
      myDataGridColumnStyle = New DataGridTextBoxColumn()
      myDataGridColumnStyle.MappingName = "CustName"
      myDataGridColumnStyle.HeaderText = "Customer Name"
      myDataGridColumnStyle.Width = 250
      AddHandler myDataGridColumnStyle.AlignmentChanged, AddressOf AlignmentChanged_Click
      ' Add the 'DataGridColumnStyle' to 'DataGridTableStyle'.
      myDataTableStyle.GridColumnStyles.Add(myDataGridColumnStyle)
      ' Add the 'DataGridTableStyle' to 'DataGrid'.
      myDataGrid.TableStyles.Add(myDataTableStyle)
   End Sub 'AddCustomDataTableStyle
' </Snippet1>

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

