' System.Windows.Forms.DataGrid.ParentRowsLabelStyleChanged
' System.Windows.Forms.DataGrid.ParentRowsVisibleChanged

' The following program demonstrates the 'ParentRowsLabelStyleChanged', and
' 'ParentRowsVisibleChanged' events. It creates a DataGrid and
' two DataTables, Person(parent) and Detail(child) which are related 
' together by a DataRelation, are linked to it. The "Toggle LabelStyle" button
' sets the 'ParentRowsLabelStyle' property and the "Toggle Visible" button sets the 
' 'ParentRowsVisible' property. When the event is raised a message will be displayed.
'
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.Interaction

Public Class MyForm
   Inherits Form
   Private components As System.ComponentModel.Container = Nothing
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private toggleStyleButton As Button
   Private toggleVisibleButton As Button
   
   
   Public Sub New()
      InitializeComponent()
      SetUp()
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
   
   
   Public Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
   
   Private Sub InitializeComponent()
      Me.toggleStyleButton = New Button()
      Me.toggleVisibleButton = New Button()
      Me.myDataGrid = New DataGrid()
      
      Me.ClientSize = New Size(292, 300)
      Me.Name = "DataGridForm"
      Me.Text = "Testing DataGrid Events"
      Me.MaximizeBox = False
      
      toggleStyleButton.Location = New Point(70, 15)
      toggleStyleButton.Size = New Size(130, 40)
      toggleStyleButton.Text = "Toggle LabelStyle"
      AddHandler toggleStyleButton.Click, AddressOf ToggleStyle_Clicked
      
      toggleVisibleButton.Location = New Point(70, 250)
      toggleVisibleButton.Size = New Size(130, 40)
      toggleVisibleButton.Text = "Toggle Visible"
      AddHandler toggleVisibleButton.Click, AddressOf ToggleVisible_Clicked
      
      myDataGrid.Location = New Point(20, 70)
      myDataGrid.Size = New Size(250, 170)
      myDataGrid.CaptionText = "MS DataGrid Control"
      myDataGrid.ReadOnly = True
      
      ' Call the methods that instantiate the Event Handlers.
      CallParentRowsLabelStyleChanged()
      CallParentRowsVisibleChanged()
      
      Me.Controls.Add(toggleStyleButton)
      Me.Controls.Add(toggleVisibleButton)
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
      
      Dim personID As New DataColumn("SSN", GetType(Integer))
      Dim personName As New DataColumn("PersonName")
      personTable.Columns.Add(personID)
      personTable.Columns.Add(personName)
      
      Dim detailID As New DataColumn("SSN", GetType(Integer))
      Dim detailPhone As New DataColumn("Phone")
      detailTable.Columns.Add(detailID)
      detailTable.Columns.Add(detailPhone)
      
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(personTable)
      myDataSet.Tables.Add(detailTable)
      
      Dim newRow1 As DataRow
      Dim newRow2 As DataRow
      
      ' Create a DataRelation, and add it to the DataSet.
      Dim myDataRelation As New DataRelation("PersonDetail", personID, detailID)
      myDataSet.Relations.Add(myDataRelation)
      
      Dim i As Integer
      For i = 1 To 3
         newRow1 = personTable.NewRow()
         newRow1("SSN") = i
         personTable.Rows.Add(newRow1)
      Next i
      
      ' Give each person a distinct name.
      personTable.Rows(0)("PersonName") = "Robert"
      personTable.Rows(1)("PersonName") = "Michael"
      personTable.Rows(2)("PersonName") = "John"
      
      ' For each person, create a detail row in 'Detail' table.
      For i = 0 To 2
         newRow2 = detailTable.NewRow()
         newRow2("SSN") = personTable.Rows(i)("SSN")
         newRow2("Phone") = 1000 + i
         ' Add the row to the 'Detail' table.
         detailTable.Rows.Add(newRow2)
      Next i
   End Sub 'MakeDataSet
' <Snippet1>
   Private Sub CallParentRowsLabelStyleChanged()
      AddHandler myDataGrid.ParentRowsLabelStyleChanged, AddressOf _
                                           DataGridParentRowsLabelStyleChanged_Clicked
   End Sub 'CallParentRowsLabelStyleChanged
   
   
   ' Set the 'ParentRowsLabelStyle' property on click of a button.
    Private Sub ToggleStyle_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        If myDataGrid.ParentRowsLabelStyle.ToString() = "Both" Then
            myDataGrid.ParentRowsLabelStyle = DataGridParentRowsLabelStyle.TableName
        Else
            myDataGrid.ParentRowsLabelStyle = DataGridParentRowsLabelStyle.Both
        End If
    End Sub 'ToggleStyle_Clicked

    ' raise the event when 'ParentRowsLabelStyle' property is changed.
    Private Sub DataGridParentRowsLabelStyleChanged_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim myMessage As String = "ParentRowsLabelStyleChanged event raised, LabelStyle is : "
        ' Get the state of 'ParentRowsLabelStyle' property.
        Dim myLabelStyle As String = myDataGrid.ParentRowsLabelStyle.ToString()
        myMessage += myLabelStyle

        MessageBox.Show(myMessage, "ParentRowsLabelStyle information")
    End Sub 'DataGridParentRowsLabelStyleChanged_Clicked

    ' </Snippet1>
    ' <Snippet2>
    Private Sub CallParentRowsVisibleChanged()
        AddHandler myDataGrid.ParentRowsVisibleChanged, AddressOf _
                                                  DataGridParentRowsVisibleChanged_Clicked
    End Sub 'CallParentRowsVisibleChanged


    ' Set the 'ParentRowsVisible' property on click of a button.
    Private Sub ToggleVisible_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        If myDataGrid.ParentRowsVisible = True Then
            myDataGrid.ParentRowsVisible = False
        Else
            myDataGrid.ParentRowsVisible = True
        End If
    End Sub 'ToggleVisible_Clicked

    ' raise the event when 'ParentRowsVisible' property is changed.
    Private Sub DataGridParentRowsVisibleChanged_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim myMessage As String = "ParentRowsVisibleChanged event raised, Parent row is : "
        Dim visible As Boolean = myDataGrid.ParentRowsVisible
        myMessage += IIF(visible, " ", "Not") + "Visible"
        MessageBox.Show(myMessage, "ParentRowsVisible information")
    End Sub 'DataGridParentRowsVisibleChanged_Clicked
    ' </Snippet2>
End Class 'MyForm 