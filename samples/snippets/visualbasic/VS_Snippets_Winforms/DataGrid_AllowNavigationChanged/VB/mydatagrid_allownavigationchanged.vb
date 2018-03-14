' System.Windows.Forms.DataGrid.AllowNavigationChanged
' System.Windows.Forms.DataGrid.Navigate

' The following program demonstrates the 'AllowNavigationChanged'
' and 'Navigate' events of 'System.Windows.Forms.DataGrid' class.
' It creates a DataGrid onto a form. This Datagrid is linked
' to two tables, Person (parent) table and Detail (child) table
' which are related together by a 'DataRelation'. User can look 
' for the details of a person by navigating along.
' The "Toggle Navigation" button is used to set the 
' 'AllowNavigation' property by toggling. When a property is set,
' an event associated with it is fired and is confirmed by the
' message shown by the alert message box. 

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.Interaction

Public Class MyDataGrid
   Inherits Form
   Private components As System.ComponentModel.Container = Nothing
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private myButton As Button

   Public Sub New()
      ' Create form.
      InitializeComponent()
      
      ' Call SetUp to bind the controls.
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

   ' Main entry point for the application.
   Shared Sub Main()
      Application.Run(New MyDataGrid())
   End Sub 'Main

   Private Sub InitializeComponent()
      ' Create the form and its controls.
      Me.myButton = New Button()
      Me.myDataGrid = New DataGrid()
      
      Me.ClientSize = New Size(292, 300)
      Me.Name = "DataGridForm"
      Me.Text = "Testing DataGrid Events"
      Me.MaximizeBox = False

      myButton.Location = New Point(85, 15)
      myButton.Size = New Size(130, 40)
      myButton.Text = "Toggle Navigation"
      AddHandler myButton.Click, AddressOf myButton_Click
      
      myDataGrid.Location = New Point(20, 70)
      myDataGrid.Size = New Size(250, 180)
      myDataGrid.CaptionText = "MS DataGrid Control"
      myDataGrid.ReadOnly = True
      
      ' Call the methods that instantiate the Event Handlers.
      CallAllowNavigationChanged()
      CallNavigate()
      
      Me.Controls.Add(myButton)
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
      ' Create a DataSet.
      myDataSet = New DataSet("myDataSet")
      
      ' Create a DataTable.
      Dim tPer As New DataTable("Person")
      Dim tDet As New DataTable("Detail")
      
      ' Create two columns, and add them to the Person table.
      Dim cPerID As New DataColumn("SSN", GetType(Integer))
      Dim cPerName As New DataColumn("PersonName")
      tPer.Columns.Add(cPerID)
      tPer.Columns.Add(cPerName)
      
      ' Create three columns, and add them to the Detail table.
      Dim cDetID As New DataColumn("SSN", GetType(Integer))
      Dim cDetPh As New DataColumn("Phone")
      tDet.Columns.Add(cDetID)
      tDet.Columns.Add(cDetPh)
      
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(tPer)
      myDataSet.Tables.Add(tDet)
      
      ' For each person create a DataRow variable.
      Dim newRow1 As DataRow
      Dim newRow2 As DataRow
      
      ' Create a DataRelation, and add it to the DataSet.
      Dim dr As New DataRelation("PersonDetail", cPerID, cDetID)
      myDataSet.Relations.Add(dr)
      
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
      
      ' For each person, create a detail row in Detail table.
      For i = 0 To 4
         newRow2 = tDet.NewRow()
         newRow2("SSN") = tPer.Rows(i)("SSN")
         newRow2("Phone") = 1000 + i
         ' Add the row to the 'Detail' table.
         tDet.Rows.Add(newRow2)
      Next i
   End Sub 'MakeDataSet
   
   
' <Snippet1>
   ' Create an instance of the 'AllowNavigationChanged' EventHandler.
   Private Sub CallAllowNavigationChanged()
      AddHandler myDataGrid.AllowNavigationChanged, AddressOf Grid_AllowNavChange
   End Sub 'CallAllowNavigationChanged
   
   
   ' Set the 'AllowNavigation' property on click of a button.
    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If myDataGrid.AllowNavigation = True Then
            myDataGrid.AllowNavigation = False
        Else
            myDataGrid.AllowNavigation = True
        End If
    End Sub 'myButton_Click
    
   ' Raise the event when 'AllowNavigation' property is changed.
    Private Sub Grid_AllowNavChange(ByVal sender As Object, ByVal e As EventArgs)
        Dim myString As String = "AllowNavigationChanged event raised, Navigation "
        Dim myBool As Boolean = myDataGrid.AllowNavigation
        ' Create appropriate alert message.
        myString = myString + IIF(mybool, "is", "is not") + "allowed"
        ' Show information about navigation.
        MessageBox.Show(myString, "Navigation information")
    End Sub 'Grid_AllowNavChange
   
' </Snippet1>
' <Snippet2>
   ' Create an instance of the 'Navigate' NavigateEventHandler.
   Private Sub CallNavigate()
      AddHandler myDataGrid.Navigate, AddressOf Grid_Navigate
   End Sub 'CallNavigate
   
   
   ' Raise the event when navigating to another table.
    Private Sub Grid_Navigate(ByVal sender As Object, ByVal e As NavigateEventArgs)
        ' String variable used to show message.
        Dim myString As String = "Navigate event raised, moved to another table"
        ' Show the message when navigating to another table.
        MessageBox.Show(myString, "Table navigation information")
    End Sub 'Grid_Navigate
' </Snippet2>
End Class 'MyDataGrid 
