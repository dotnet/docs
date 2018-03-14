' System.Windows.Forms.DataGrid.ShowParentDetailsButtonClick

' The following program demonstrates the 'ShowParentDetailsButtonClick'
' event of 'DataGrid' class. On the click of "ParentDetailsButton" button in the
' Datagrid, a message is displayed.

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class MyForm
   Inherits Form
   Private components As System.ComponentModel.Container = Nothing
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet

   Public Sub New()
      InitializeComponent()
      SetUp()
   End Sub 'New
   
   ' Clean up any resources being used.
   Protected Overrides overloads Sub Dispose(disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub 'Dispose
   
   
   Public Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
   
   Private Sub InitializeComponent()
      ' Create the form and its controls.
      Me.myDataGrid = New DataGrid()
      
      Me.ClientSize = New Size(292, 300)
      Me.Name = "DataGridForm"
      Me.Text = "Testing DataGrid Events"
      Me.MaximizeBox = False
      
      
      myDataGrid.Location = New Point(20, 70)
      myDataGrid.Size = New Size(250, 170)
      myDataGrid.CaptionText = "MS DataGrid Control"
      myDataGrid.ReadOnly = False
      
      ' Call the method that instantiate the Event Handlers.
      CallShowParentDetailsButtonClick()
      
      Me.Controls.Add(myDataGrid)
   End Sub 'InitializeComponent
   
   
   Private Sub SetUp()
      ' Create a DataSet with two tables and one relation.
      MakeDataSet()
      ' Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Person")
   End Sub 'SetUp
   
   
   ' Create a DataSet with two tables and populate it.
   Private Sub MakeDataSet()
      myDataSet = New DataSet("myDataSet")
      
      Dim personTable As New DataTable("Person")
      Dim detailTable As New DataTable("Detail")
      
      ' Create two columns, and add them to the Person table.
      Dim personID As New DataColumn("SSN", GetType(Integer))
      Dim personName As New DataColumn("PersonName")
      personTable.Columns.Add(personID)
      personTable.Columns.Add(personName)
      
      ' Create three columns, and add them to the Detail table.
      Dim detailID As New DataColumn("SSN", GetType(Integer))
      Dim detailPhone As New DataColumn("Phone")
      detailTable.Columns.Add(detailID)
      detailTable.Columns.Add(detailPhone)
      
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(personTable)
      myDataSet.Tables.Add(detailTable)
      
      ' For each person create a DataRow variable.
      Dim newRow1 As DataRow
      Dim newRow2 As DataRow
      
      ' Create a DataRelation, and add it to the DataSet.
      Dim myDataRelation As New DataRelation("PersonDetail", personID, detailID)
      myDataSet.Relations.Add(myDataRelation)
      
      ' Create persons in the 'Person' Table.
      Dim i As Integer
      For i = 1 To 4
         newRow1 = personTable.NewRow()
         newRow1("SSN") = i
         ' Add the row to the 'Person' table.
         personTable.Rows.Add(newRow1)
      Next i
      
      ' Give each person a distinct name.
      personTable.Rows(0)("PersonName") = "Robert"
      personTable.Rows(1)("PersonName") = "Michael"
      personTable.Rows(2)("PersonName") = "John"
      personTable.Rows(3)("PersonName") = "Walter"
      
      ' For each person, create a detail row in 'Detail' table.
      For i = 0 To 3
         newRow2 = detailTable.NewRow()
         newRow2("SSN") = personTable.Rows(i)("SSN")
         newRow2("Phone") = 1000 + i
         ' Add the row to the 'Detail' table.
         detailTable.Rows.Add(newRow2)
      Next i
   End Sub 'MakeDataSet
   
   
' <Snippet1>
   Private Sub CallShowParentDetailsButtonClick()
      AddHandler myDataGrid.ShowParentDetailsButtonClick, AddressOf _
                                              DataGridShowParentDetailsButtonClick_Clicked
   End Sub 'CallShowParentDetailsButtonClick
   
   
   ' raise the event when ParentDetailsButton is clicked.
    Private Sub DataGridShowParentDetailsButtonClick_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim myMessage As String = "ShowParentDetailsButtonClick event raised"

        ' Show the message when event is raised.
        MessageBox.Show(myMessage, "ShowParentDetailsButtonClick information")
    End Sub 'DataGridShowParentDetailsButtonClick_Clicked
' </Snippet1>
End Class 'MyForm 
