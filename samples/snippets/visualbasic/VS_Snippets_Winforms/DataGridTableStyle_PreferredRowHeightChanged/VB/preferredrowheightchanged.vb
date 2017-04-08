' System.Windows.Forms.DataGridTableStyle.PreferredRowHeightChanged

' The following example demonstrates 'PreferredRowHeightChanged' Event 
' of 'DataGridTableStyle' class. A DataGrid, Button and TextBox are 
' added to a form. The 'PreferredRowHeight' property of 'DataGridTableStyle' 
' class is set to the value entered by user in the textbox.
' When user clicks the set button, it raises 'PreferredRowHeightChanged'
' Event which calls user defined  EventHandler function.

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class MyDataForm
   Inherits Form
   Private myButton As Button
   Private myTextBox As TextBox
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
      myButton = New Button()
      myDataGrid = New DataGrid()
      ClientSize = New Size(450, 330)
      
      myButton.Location = New Point(70, 16)
      myButton.Size = New Size(200, 24)
      myButton.Text = "Set Row Height(in pixels)"
      AddHandler myButton.Click, AddressOf myButton_Click
      
      myTextBox = New TextBox()
      myTextBox.Location = New Point(24, 16)
      myTextBox.Size = New Size(40, 24)
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(120, 200)
      myDataGrid.CaptionText = "DataGrid Control"
      
      myLabel = New Label()
      myLabel.Location = New Point(24, 270)
      myLabel.Width = 500
      
      Controls.Add(myButton)
      Controls.Add(myTextBox)
      Controls.Add(myDataGrid)
      Controls.Add(myLabel)
      Text = "PreferredRowHeightChanged example"
   End Sub 'InitializeComponent
   
   
   Public Shared Sub Main()
      Application.Run(New MyDataForm())
   End Sub 'Main
   
   
' <Snippet1>
   Private Sub SetUp()
      ' Create a DataSet with a table.
      MakeDataSet()
      ' Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Orders")
      myTableStyle = New DataGridTableStyle()
      ' Map 'DataGridTableStyle' instance to the DataTable.
      myTableStyle.MappingName = "Orders"
      ' Add EventHandler function for 'PreferredRowHeightChanged' Event.
      AddHandler myTableStyle.PreferredRowHeightChanged, AddressOf RowHeight_Changed
   End Sub 'SetUp

   ' Called when the PreferredRowHeight property of myTableStyle is modified
    Private Sub RowHeight_Changed(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("PreferredRowHeight property is changed")
    End Sub 'RowHeight_Changed
   
' </Snippet1>
    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If myTextBox.Text.Trim() = "" Then
                MessageBox.Show("Enter the height between 18 and 134")
                Return
            End If

            Dim myPreferredRowHeight As Integer = Convert.ToInt32(myTextBox.Text.Trim())
            If myPreferredRowHeight < 18 Or myPreferredRowHeight > 134 Then
                MessageBox.Show("Enter the height between 18 and 134")
                Return
            End If

            ' Set the 'PrefferedRowHeight' property of DataGridTableStyle instance.
            myTableStyle.PreferredRowHeight = myPreferredRowHeight

            ' Add the DataGridTableStyle instance to the GridTableStylesCollection. 
            myDataGrid.TableStyles.Add(myTableStyle)
        Catch ex As Exception
            ' Handle raised Exception.
            If (ex IsNot Nothing) Then
                MessageBox.Show("Please enter a numeric value between 18 and 134")
                myTextBox.Text = " "
                myTextBox.Focus()
            End If
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
End Class 'MyDataForm