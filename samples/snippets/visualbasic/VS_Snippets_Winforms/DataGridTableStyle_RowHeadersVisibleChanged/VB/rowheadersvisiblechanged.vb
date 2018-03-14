' System.Windows.Forms.DataGridTableStyle.RowHeadersVisibleChanged
' System.Windows.Forms.DataGridTableStyle.RowHeadersVisible

' The following program demonstrates the 'RowHeadersVisible' 
' method and 'RowHeadersVisibleChanged' event of 
' System.Windows.Forms.DataGridTableStyle' class. It makes the 
' row headers visible or invisible on button click */
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class MyDataGridTableStyle_RowHeadersVisibleChanged
   Inherits Form
   Private components As System.ComponentModel.Container = Nothing
   Private myDataGridTableStyle As DataGridTableStyle
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private myButton As Button
   
   Public Sub New()
      ' Create the form.
      InitializeComponent()
      
      ' Bind the controls to the DataGrid.
      MakeDataSet()
   End Sub 'New
   
   
   ' Clean up any resources being used.
   Protected Overrides Overloads Sub Dispose(disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub 'Dispose
   
   
   ' Main entry point for the application.
   Shared Sub Main()
      Application.Run(New MyDataGridTableStyle_RowHeadersVisibleChanged())
   End Sub 'Main
   
   
   Private Sub InitializeComponent()
      ' Create the form and its controls.
      Me.myDataGridTableStyle = New DataGridTableStyle()
      Me.myDataGrid = New DataGrid()
      Me.myButton = New Button()
      
      Me.ClientSize = New Size(292, 300)
      Me.Name = "DataGridForm"
      Me.Text = "Testing DataGridTableStyle"
      Me.MaximizeBox = False
      
      myButton.Location = New Point(80, 15)
      myButton.Size = New Size(130, 40)
      myButton.Text = "Toggle Row Headers"
      AddHandler myButton.Click, AddressOf myButton_Click
      
      myDataGrid.Location = New Point(20, 70)
      myDataGrid.Size = New Size(250, 170)
      myDataGrid.CaptionText = "MS DataGrid Control"
      myDataGrid.ReadOnly = False
      
      Me.Controls.Add(myButton)
      Me.Controls.Add(myDataGrid)
   End Sub 'InitializeComponent
    
   
   Private Sub MakeDataSet()
      ' Create a DataSet.
      myDataSet = New DataSet("myDataSet")
      
      ' Create a DataTable.
      Dim tPer As New DataTable("Person")
      
      ' Create two columns, and add them to the Person table.
      Dim cPerID As New DataColumn("SSN", GetType(Integer))
      Dim cPerName As New DataColumn("PersonName")
      tPer.Columns.Add(cPerID)
      tPer.Columns.Add(cPerName)
      
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(tPer)
      
      ' For each person create a DataRow variable.
      Dim newRow1 As DataRow
      
      ' Create five persons in the Person Table.
      Dim i As Integer
      For i = 1 To 5
         newRow1 = tPer.NewRow()
         newRow1("SSN") = i
         ' Add the row to the Person table.
         tPer.Rows.Add(newRow1)
      Next i
      
      ' Give each person a distinct name.
      tPer.Rows(0)("PersonName") = "Robert"
      tPer.Rows(1)("PersonName") = "Michael"
      tPer.Rows(2)("PersonName") = "John"
      tPer.Rows(3)("PersonName") = "Walter"
      tPer.Rows(4)("PersonName") = "Simon"
      
      myDataGrid.SetDataBinding(myDataSet, "Person")
   End Sub 'MakeDataSet
   
   
   Private Sub DataGridTableStyle_RowHeadersVisible_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      myDataGridTableStyle.MappingName = "Person"
      ' Set other properties.
      myDataGridTableStyle.AlternatingBackColor = Color.LightGray
      
      ' Create DataGridColumnStyle 
      Dim IdCol = New DataGridTextBoxColumn()
      Dim TextCol = New DataGridTextBoxColumn()
      
      ' Set MappingName to DataColumn name in DataTable.
      IdCol.MappingName = "SSN"
      
      ' Set the HeaderText and Width properties.
      IdCol.HeaderText = "SSN"
      IdCol.Width = 50
      
      ' Add a second column style.
      TextCol.MappingName = "PersonName"
      TextCol.HeaderText = "Person Name"
      TextCol.Width = 150
      
      ' Add the GridColumnStyles to DataGridTableStyle.
      myDataGridTableStyle.GridColumnStyles.Add(IdCol)
      myDataGridTableStyle.GridColumnStyles.Add(TextCol)
      
      ' Add the DataGridTableStyle to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myDataGridTableStyle)
      myDataGridTableStyle.GridLineColor = Color.Aquamarine
      AttachRowHeaderVisibleChanged()
   End Sub 'DataGridTableStyle_RowHeadersVisible_Load
   
' <Snippet1>
' <Snippet2>
   ' Instantiate the EventHandler.
   Public Sub AttachRowHeaderVisibleChanged()
      AddHandler myDataGridTableStyle.RowHeadersVisibleChanged, AddressOf MyDelegateRowHeadersVisibleChanged
   End Sub 'AttachRowHeaderVisibleChanged
   
   
   ' raise the event when RowHeadersVisible property is changed.
    Private Sub MyDelegateRowHeadersVisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim myString As String = "'RowHeadersVisibleChanged' event raised, Row Headers are"
        If myDataGridTableStyle.RowHeadersVisible Then
            myString += " visible"
        Else
            myString += " not visible"
        End If
        MessageBox.Show(myString, "RowHeader information")
    End Sub 'MyDelegateRowHeadersVisibleChanged
   
   
   ' raise the event when a button is clicked.
   Private Sub myButton_Click(sender As Object, e As System.EventArgs)
      If myDataGridTableStyle.RowHeadersVisible Then
         myDataGridTableStyle.RowHeadersVisible = False
      Else
         myDataGridTableStyle.RowHeadersVisible = True
      End If
   End Sub 'myButton_Click 
' </Snippet2>
' </Snippet1>
End Class 'MyDataGridTableStyle_RowHeadersVisibleChanged 