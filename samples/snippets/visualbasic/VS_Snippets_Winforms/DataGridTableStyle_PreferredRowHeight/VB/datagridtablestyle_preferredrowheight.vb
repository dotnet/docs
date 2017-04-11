' System.Windows.Forms.DataGridTableStyle.PreferredRowHeight

' The following example demonstrates 'PreferredRowHeight' property of 'DataGridTableStyle' 
' class. It adds a DataGrid, Button and a TextBox to a form. It changes the 
' 'PreferredRowHeight' property by taking the value entered in the textbox.

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class myDataForm
   Inherits Form
   Private myButton As Button
   Private myTextBox As TextBox
   Private myLabel As Label
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private myTableStyle As DataGridTableStyle
   
   Public Sub New()
      ' Required for Windows Form Designer support.
      InitializeComponent()
      ' Call SetUp to bind the controls.
      SetUp()
   End Sub 'New
   
   Private Sub InitializeComponent()
      ' Create the form and its controls.
      myButton = New Button()
      myDataGrid = New DataGrid()
      ClientSize = New Size(450, 330)
      myButton.Location = New Point(100, 16)
      myButton.Size = New Size(200, 24)
      myButton.Text = "Change Row Height"
      AddHandler myButton.Click, AddressOf myButton_Click
      myTextBox = New TextBox()
      myTextBox.Location = New Point(24, 16)
      myTextBox.Size = New Size(40, 24)
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(120, 200)
      myDataGrid.CaptionText = "DataGridTableStyle Example"
      myLabel = New Label()
      myLabel.Location = New Point(24, 270)
      myLabel.Width = 500
      Controls.Add(myButton)
      Controls.Add(myTextBox)
      Controls.Add(myDataGrid)
      Controls.Add(myLabel)
      Text = "PreferredRowHeight example"
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
   
   
    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)

        If myTextBox.Text.Trim() = "" Then
            MessageBox.Show("Enter the height between 18 and 134")
            Return
        End If
        Try
            ' <Snippet1>
            Dim myPreferredRowHeight As Integer = Convert.ToInt32(myTextBox.Text.Trim())
            If myPreferredRowHeight < 18 Or myPreferredRowHeight > 134 Then
                MessageBox.Show("Enter the height between 18 and 134")
                Return
            End If
            ' Set the 'PreferredRowHeight' property of DataGridTableStyle instance.
            myTableStyle.PreferredRowHeight = myPreferredRowHeight
            ' Add the DataGridTableStyle instance to the GridTableStylesCollection. 
            myDataGrid.TableStyles.Add(myTableStyle)
            ' </Snippet1>
        Catch ex As Exception
            MessageBox.Show(ex.Message & "Enter Integer only .")
        End Try
    End Sub 'myButton_Click
   
   ' Create a DataSet with a table and populate it.
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