 ' System.Windows.Forms.DataGridTableStyle.ResetForeColor

' The following example demonstrates 'ResetForeColor' method of 
' 'DataGridTableStyle' class. A DataGrid and two Buttons are added to 
' the form. A 'DataGridTableStyle' instance is mapped to table of 
' 'DataGrid'. When the user clicks on 'Set ForeColor' button foreground 
' color is set to blue. When 'Reset ForeColor' button is clicked foreground 
' color is reset to its default value. 

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data


Namespace MyDataGridColumnStyle
   Public Class MyForm1
      Inherits Form
      Private myDataGrid As DataGrid
      Private btnSetForeColor As Button
      Private btnResetForeColor As Button
      Private myDataSet As DataSet
      Private myDataGridTableStyle As DataGridTableStyle
      Private myDataTable As DataTable
      Private myDataColumn1 As DataColumn
      
      Public Sub New()
         InitializeComponent()
         ' Call 'SetUp' method to bind the controls.
         SetUp()
      End Sub 'New
      
      
      Private Sub InitializeComponent()
         btnResetForeColor = New Button()
         btnSetForeColor = New Button()
         myDataGrid = New DataGrid()
         
         ' Initialize Buttons.
         btnSetForeColor.Location = New Point(35, 290)
         btnSetForeColor.Name = "btnSetForeColor"
         btnSetForeColor.Size = New Size(110, 30)
         btnSetForeColor.TabIndex = 1
         btnSetForeColor.Text = "Set ForeColor"
         AddHandler btnSetForeColor.Click, AddressOf BtnSetForeColor_Click
         
         btnResetForeColor.Location = New Point(155, 290)
         btnResetForeColor.Name = "btnResetForeColor"
         btnResetForeColor.Size = New Size(110, 30)
         btnResetForeColor.TabIndex = 2
         btnResetForeColor.Text = "Reset ForeColor"
         AddHandler btnResetForeColor.Click, AddressOf BtnResetForeColor_Click
         
         ' Initialize DataGrid.
         myDataGrid.DataMember = ""
         myDataGrid.Location = New Point(48, 72)
         myDataGrid.Name = "myDataGrid"
         myDataGrid.Size = New Size(200, 200)
         myDataGrid.TabIndex = 0
         ClientSize = New Size(296, 389)
         
         ' Add the Buttons and the DataGrid to the Window.
         Controls.Add(myDataGrid)
         Controls.Add(btnSetForeColor)
         Controls.Add(btnResetForeColor)
         
         Name = "MyForm1"
         Text = "MyForm1"
         CType(myDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
         ResumeLayout(False)
      End Sub 'InitializeComponent
      
      
      Shared Sub Main()
         Application.Run(New MyForm1())
      End Sub 'Main
      
      
' <Snippet1>
        Private Sub BtnSetForeColor_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Set the foreground color of table.
            myDataGridTableStyle.ForeColor = Color.Blue
            myDataGrid.TableStyles.Add(myDataGridTableStyle)
        End Sub 'BtnSetForeColor_Click
      
        Private Sub BtnResetForeColor_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Reset the foreground color of table to its default value.
            myDataGridTableStyle.ResetForeColor()
        End Sub 'BtnResetForeColor_Click
' </Snippet1>

      Private Sub AddCustomDataTableStyle()
         myDataGridTableStyle = New DataGridTableStyle()
         myDataGridTableStyle.MappingName = "Customers"
      End Sub 'AddCustomDataTableStyle
      
      Sub SetUp()
         MakeDataSet()
         ' Bind the datagrid to the dataset.
         myDataGrid.SetDataBinding(myDataSet, "Customers")
         AddCustomDataTableStyle()
      End Sub 'SetUp
      
      
      Private Sub MakeDataSet()
         ' Create dataset.
         myDataSet = New DataSet("myDataSet")
         myDataTable = New DataTable("Customers")
         myDataColumn1 = New DataColumn("CustName")
         myDataTable.Columns.Add(myDataColumn1)
         
         ' Add table to dataset.
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

