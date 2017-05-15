' System.Windows.Forms.DataGridTextBox.IsInEditOrNavigateMode

' The following program demonstrates the 'IsInEditOrNavigateMode'
' property of the 'System.Windows.Forms.DataGridTextBox' class.
' It creates a form with 'DataGrid' that has a 'DataTable'.
' A DataGridTextBox is shown which is bound to the DataSet that 
' contains the 'DataTable'. A button is used to display the state of
' 'IsInEditOrNavigateMode' property. Editing of the 
' 'DataGridTextBox' changes the value of 'IsInEditOrNavigateMode'
' from true to false. 

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class MyDataGridTextBox
   Inherits Form
   Private components As System.ComponentModel.Container = Nothing
   Private myDataGridTableStyle As DataGridTableStyle
   Private myTextBoxColumn As DataGridTextBoxColumn
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private myButton As Button
   Private myDataGridTextBox As DataGridTextBox
   
   Public Sub New()
      ' Create the form.
      InitializeComponent()
      
      ' Bind the controls.
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
      Application.Run(New MyDataGridTextBox())
   End Sub 'Main
   
   Private Sub InitializeComponent()
      ' Create the form and its controls.
      Me.myDataGridTableStyle = New DataGridTableStyle()
      Me.myDataGridTextBox = New DataGridTextBox()
      Me.myTextBoxColumn = New DataGridTextBoxColumn()
      Me.myDataGrid = New DataGrid()
      Me.myButton = New Button()
      
      Me.ClientSize = New Size(292, 300)
      Me.Name = "DataGridForm"
      Me.Text = "Testing DataGridTextBox"
      Me.MaximizeBox = False
      
      myDataGridTextBox.Location = New Point(20, 5)
      myDataGridTextBox.Size = New Size(100, 65)
      
      myDataGrid.Location = New Point(20, 70)
      myDataGrid.Size = New Size(250, 170)
      myDataGrid.CaptionText = "MS DataGrid Control"
      
      myButton.Location = New Point(71, 250)
      myButton.Size = New Size(150, 40)
      myButton.Text = " IsInEditOrNavigateMode"
      AddHandler myButton.Click, AddressOf Button_ClickEvent
      
      Me.Controls.Add(myDataGrid)
      Me.Controls.Add(myDataGridTextBox)
      Me.Controls.Add(myButton)
      
      ' Create 'DataTableStyle' for the DataGrid.
      AddCustomDataTableStyle()
      
      ' Set the properties of DataGridTextBox.
      myDataGridTextBox.ScrollBars = ScrollBars.Vertical
      myDataGridTextBox.ForeColor = Color.Red
      myDataGridTextBox.Multiline = True
      myDataGridTextBox.WordWrap = True
   End Sub 'InitializeComponent
   
   Private Sub AddCustomDataTableStyle()
      ' Map the DataGridTableStyle to the Table name.
      myDataGridTableStyle.MappingName = "Person"
      ' Set other properties.
      myDataGridTableStyle.AlternatingBackColor = Color.LightGray
      
      Dim TextCol = New DataGridTextBoxColumn()
      
      ' Map the DataGridColumnStyle to the Column name of the Table.
      TextCol.MappingName = "PersonName"
      TextCol.HeaderText = "Person Name"
      TextCol.Width = 100
      
      myDataGridTableStyle.GridColumnStyles.Add(TextCol)
      myDataGridTableStyle.GridLineColor = Color.Aquamarine
      
      ' Add the DataGridTableStyle to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myDataGridTableStyle)
   End Sub 'AddCustomDataTableStyle
   
   ' Create a DataSet with a table and populate it.
   Private Sub MakeDataSet()
      myDataSet = New DataSet("myDataSet")
      
      Dim tPer As New DataTable("Person")
      
      Dim cPerName As New DataColumn("PersonName")
      tPer.Columns.Add(cPerName)
      
      myDataSet.Tables.Add(tPer)
      
      Dim newRow1 As DataRow
      
      Dim i As Integer
      For i = 1 To 5
         newRow1 = tPer.NewRow()
         tPer.Rows.Add(newRow1)
      Next i
      
      tPer.Rows(0)("PersonName") = "Robert"
      tPer.Rows(1)("PersonName") = "Michael"
      tPer.Rows(2)("PersonName") = "John"
      tPer.Rows(3)("PersonName") = "Walter"
      tPer.Rows(4)("PersonName") = "Simon"
      
      ' Bind the 'DataSet' to the 'DataGrid'.
      myDataGrid.SetDataBinding(myDataSet, "Person")
      myDataGridTextBox.DataBindings.Add("Text", myDataSet, _
               "Person.PersonName")
      ' Set the DataGrid to the DataGridTextBox.
      myDataGridTextBox.SetDataGrid(myDataGrid)
   End Sub 'MakeDataSet

' <Snippet1>
   ' Handle event to show the state of 'IsInEditOrNavigateMode'.
   Private Sub Button_ClickEvent(sender As Object, e As EventArgs)
      
      If myDataGridTextBox.IsInEditOrNavigateMode Then
         ' DataGridTextBox has not been edited.
         MessageBox.Show("Editing of DataGridTextBox not begun,IsInEditOrNavigateMode = True")
      Else
         ' DataGridTextBox has been edited.
         MessageBox.Show("Editing of DataGridTextBox begun,IsInEditOrNavigateMode = False")
      End If
   End Sub 'Button_ClickEvent
' </Snippet1>
End Class 'MyDataGridTextBox
