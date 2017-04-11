' System.Windows.Forms.DataGridColumnStyle.ReadOnlyChanged
'
'
' The following example demonstrates 'ReadOnlyChanged' Event of
' 'DataGridColumnStyle' class. It adds DataGrid and Button to a form. When
' user clicks on button the 'ReadOnly'  property of 'DataGridColumnStyle' is
' changed . This raises the'ReadOnlyChanged' event which calls the user defined
' EventHandler function.
'

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data

Namespace MyDataGridColumnStyle

   Public Class MyForm1
      Inherits Form
      Private myDataGrid As DataGrid
      Private myButton As Button

      Private myDataSet As DataSet
      Private myDataGridTableStyle As DataGridTableStyle
      Private myDataGridColumnStyle As DataGridColumnStyle
      Private myDataTable As DataTable
      Private myDataColumn1 As DataColumn

      Public Sub New()
         InitializeComponent()
         SetUp()
      End Sub 'New

      Private Sub InitializeComponent()
         myDataGrid = New DataGrid()
         myDataGrid.Location = New Point(52, 32)
         myDataGrid.Size = New Size(115, 125)
         ClientSize = New Size(215, 273)
         myButton = New Button()
         myButton.Location = New Point(35, 210)
         myButton.Size = New Size(145, 24)
         myButton.Text = "Make column read only"
         AddHandler myButton.Click, AddressOf Button_Click
         Controls.AddRange(New Control() {myDataGrid, myButton})
         Name = "MyForm1"
         Text = "DataGridColumnStyle"
      End Sub 'InitializeComponent

      Shared Sub Main()
         Application.Run(New MyForm1())
      End Sub 'Main

' <Snippet1>
        Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            If myButton.Text = "Make column read/write" Then
                myDataGridColumnStyle.ReadOnly = False
                myButton.Text = "Make column read only"
            Else
                myDataGridColumnStyle.ReadOnly = True
                myButton.Text = "Make column read/write"
            End If
        End Sub 'Button_Click

      Private Sub AddCustomDataTableStyle()
         myDataGridTableStyle = New DataGridTableStyle()
         myDataGridTableStyle.MappingName = "Customers"
         myDataGridColumnStyle = New DataGridTextBoxColumn()
         myDataGridColumnStyle.MappingName = "CustName"
         ' Add EventHandler function for readonlychanged event.
         AddHandler myDataGridColumnStyle.ReadOnlyChanged, AddressOf myDataGridColumnStyle_ReadOnlyChanged
         myDataGridColumnStyle.HeaderText = "Customer"
         myDataGridTableStyle.GridColumnStyles.Add(myDataGridColumnStyle)
         ' Add the 'DataGridTableStyle' instance to the 'DataGrid'.
         myDataGrid.TableStyles.Add(myDataGridTableStyle)
      End Sub 'AddCustomDataTableStyle

        Private Sub myDataGridColumnStyle_ReadOnlyChanged(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("'Readonly' property is changed")
        End Sub 'myDataGridColumnStyle_ReadOnlyChanged
' </Snippet1>

      Sub SetUp()
         MakeDataSet()
         myDataGrid.SetDataBinding(myDataSet, "Customers")
         AddCustomDataTableStyle()
      End Sub 'SetUp

      Private Sub MakeDataSet()
         myDataSet = New DataSet("myDataSet")
         myDataTable = New DataTable("Customers")
         myDataColumn1 = New DataColumn("CustName")
         myDataTable.Columns.Add(myDataColumn1)
         myDataSet.Tables.Add(myDataTable)
         Dim newRow1 As DataRow
         Dim i As Integer
         For i = 1 To 3
            newRow1 = myDataTable.NewRow()
            ' Add the row to the customers table.
            myDataTable.Rows.Add(newRow1)
         Next i
         myDataTable.Rows(0)("custName") = "Alpha"
         myDataTable.Rows(1)("custName") = "Beta"
         myDataTable.Rows(2)("custName") = "Omega"
      End Sub 'MakeDataSet
   End Class 'MyForm1
End Namespace 'MyDataGridColumnStyle


