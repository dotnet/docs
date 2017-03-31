' System.Windows.Forms.DataGridColumnStyle.HeaderTextChanged
'
'
' The following example demonstrates 'HeaderTextChanged' event of
' 'DataGridColumnStyle' class. It adds a DataGrid and a Button and to a
' form. When user clicks on the button, it changes the'HeaderText' property
'  to 'Amount in $'. This raises the 'HeaderTextChanged' event which calls
' user defined EventHandler function and displays a message on form.
'

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class myDataForm
   Inherits Form
   Private myButton As Button
   Private myLabel As Label
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private TablesAlreadyAdded As Boolean

   Public Sub New()
      InitializeComponent()
      MakeDataSet()
      myDataGrid.SetDataBinding(myDataSet, "Orders")
   End Sub 'New

   Private Sub InitializeComponent()
      Me.Text = "HeaderTextChanged Example"
      myButton = New Button()
      myDataGrid = New DataGrid()
      ClientSize = New Size(450, 330)
      myButton.Location = New Point(24, 16)
      myButton.Size = New Size(120, 24)
      myButton.Text = "Currency Format"
      AddHandler myButton.Click, AddressOf myButton_Click

      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(170, 200)
      myDataGrid.CaptionText = "DataGridColumnStyle"

      myLabel = New Label()
      myLabel.Location = New Point(24, 270)
      myLabel.Width = 500

      Controls.Add(myButton)
      Controls.Add(myDataGrid)
      Controls.Add(myLabel)
   End Sub 'InitializeComponent

   Public Shared Sub Main()
      Application.Run(New myDataForm())
   End Sub 'Main

    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If TablesAlreadyAdded Then
            Return
        End If
        AddCustomDataTableStyle()
    End Sub 'myButton_Click

' <Snippet1>
   Private Sub AddCustomDataTableStyle()
      Dim myTableStyle As New DataGridTableStyle()
      ' Map DataGridTableStyle to a DataTable.
      myTableStyle.MappingName = "Orders"
      ' Get CurrencyManager object.
      Dim myCurrencyManager As CurrencyManager = CType(BindingContext(myDataSet, "Orders"), CurrencyManager)
      ' Use the CurrencyManager to get the PropertyDescriptor for the column.
      Dim myPropertyDescriptor As PropertyDescriptor = myCurrencyManager.GetItemProperties()("Amount")
      ' Change the HeaderText.
      Dim myColumnStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(myPropertyDescriptor, "c", True)
      ' Attach a event handler function with the 'HeaderTextChanged' event.
      AddHandler myColumnStyle.HeaderTextChanged, AddressOf MyHeaderText_Changed
      myColumnStyle.Width = 130
      myColumnStyle.HeaderText = "Amount in $"
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      myDataGrid.TableStyles.Add(myTableStyle)
      TablesAlreadyAdded = True
   End Sub 'AddCustomDataTableStyle

    Private Sub MyHeaderText_Changed(ByVal sender As Object, ByVal e As EventArgs)
        myLabel.Text = "Header Descriptor Property of DataGridColumnStyle has changed"
    End Sub 'MyHeaderText_Changed
' </Snippet1>

   Private Sub MakeDataSet()
      ' Create a DataSet.
      myDataSet = New DataSet("myDataSet")
      Dim myTable As New DataTable("Orders")
      Dim myColumn As New DataColumn("Amount", GetType(Decimal))
      myTable.Columns.Add(myColumn)
      myDataSet.Tables.Add(myTable)
      Dim newRow As DataRow
      Dim j As Integer
      For j = 1 To 14
         newRow = myTable.NewRow()
         newRow("Amount") = j * 10 + j * 0.1
         myTable.Rows.Add(newRow)
      Next j
   End Sub 'MakeDataSet
End Class 'myDataForm

