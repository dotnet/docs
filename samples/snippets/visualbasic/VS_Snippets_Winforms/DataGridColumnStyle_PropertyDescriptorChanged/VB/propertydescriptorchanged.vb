' System.Windows.Forms.DataGridColumnStyle.PropertyDescriptorChanged
'
' The following example demonstrates 'PropertyDescriptorChanged' Event of
' 'DataGridColumnStyle' class. A  DataGrid and Button are added to a form.
' When user clicks on the button, the 'PropertyDescriptor'Format of
' 'DataGridColumnStyle' is changed  to 'Currency' format . This raises
' 'PropertyDescriptorChanged' event, which then calls user defined EventHandler
' function.

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
      SetUp()
   End Sub 'New

   Private Sub InitializeComponent()
      Text = "PropertyDescriptor Example"
      myButton = New Button()
      myDataGrid = New DataGrid()
      ClientSize = New Size(450, 330)
      myButton.Location = New Point(24, 16)
      myButton.Size = New Size(120, 24)
      myButton.Text = "Currency Format"
      AddHandler myButton.Click, AddressOf myButton_Click
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(120, 200)
      myDataGrid.CaptionText = "DataGrid Control"
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

   Private Sub SetUp()
      MakeDataSet()
      myDataGrid.SetDataBinding(myDataSet, "Orders")
   End Sub 'SetUp

' <Snippet1>
    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If TablesAlreadyAdded Then
            Return
        End If
        AddCustomDataTableStyle()
    End Sub 'myButton_Click

   Private Sub AddCustomDataTableStyle()
      Dim myTableStyle As New DataGridTableStyle()
      ' Map DataGridTableStyle to a DataTable.
      myTableStyle.MappingName = "Orders"
      ' Get CurrencyManager object.
      Dim myCurrencyManager As CurrencyManager = CType(BindingContext(myDataSet, "Orders"), CurrencyManager)
      ' Use the CurrencyManager to get the PropertyDescriptor for column.
      Dim myPropertyDescriptor As PropertyDescriptor = myCurrencyManager.GetItemProperties()("Amount")
      ' Construct a 'DataGridColumnStyle' object changing its format to 'Currency'.
      Dim myColumnStyle As DataGridTextBoxColumn = New DataGridTextBoxColumn(myPropertyDescriptor, "c", True)
      ' Add EventHandler function for PropertyDescriptorChanged Event.
      AddHandler myColumnStyle.PropertyDescriptorChanged, AddressOf MyPropertyDescriptor_Changed
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      ' Add the DataGridTableStyle instance to the GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle)
      TablesAlreadyAdded = True
   End Sub 'AddCustomDataTableStyle

    Private Sub MyPropertyDescriptor_Changed(ByVal sender As Object, ByVal e As EventArgs)
        myLabel.Text = "Property Descriptor Property of DataGridColumnStyle has changed"
    End Sub 'MyPropertyDescriptor_Changed
' </Snippet1>

   Private Sub MakeDataSet()
      myDataSet = New DataSet("myDataSet")
      Dim myTable As New DataTable("Orders")
      Dim myColumn As New DataColumn("Amount", GetType(Decimal))
      myTable.Columns.Add(myColumn)
      myDataSet.Tables.Add(myTable)
      Dim newRow As DataRow
      Dim j As Integer
      For j = 1 To 14
         newRow = myTable.NewRow()
         newRow("Amount") = j * 10
         myTable.Rows.Add(newRow)
      Next j
   End Sub 'MakeDataSet
End Class 'myDataForm

