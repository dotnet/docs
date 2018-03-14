' System.BindingManagerBase.RemoveAt

' This program demonstrates the 'RemoveAt' method of 'BindingManagerBase' class.
' It creates a 'DataGrid' control and a 'button' control. If Remove button is pressed it deletes 
' the selected row from the 'DataGrid' control.
'

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic

Namespace WindowsApplication1

   Public Class Form1
      Inherits Form
      Private button1 As Button
      Private dataGrid1 As DataGrid
      Private myDataTable As DataTable
      
      Public Sub New()
         InitializeComponent()
         MakeDataTableAndDisplay()
      End Sub 'New
      
      Private Sub InitializeComponent()
         dataGrid1 = New DataGrid()
         button1 = New Button()
         CType(dataGrid1,ISupportInitialize).BeginInit()
         SuspendLayout()
         ' Create the 'DataGrid'.
         dataGrid1.DataMember = ""
         dataGrid1.Location = New Point(32, 32)
         dataGrid1.Name = "dataGrid1"
         dataGrid1.Size = New Size(208, 80)
         dataGrid1.TabIndex = 3
         
         button1.Location = New Point(280, 40)
         button1.Name = "button1"
         button1.Size = New Size(96, 23)
         button1.TabIndex = 1
         button1.Text = "Remove Row"
         AddHandler button1.Click, AddressOf button1_Click
         
         ' Create the 'Form'.
         ClientSize = New Size(400, 273)
         Controls.AddRange(New Control() {dataGrid1, button1})
         Name = "Form1"
         [Text] = "Form1"
         CType(dataGrid1, ISupportInitialize).EndInit()
         ResumeLayout(False)
      End Sub 'InitializeComponent
       
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
      
' <Snippet1>
      Private Sub button1_Click(sender As Object, e As EventArgs)
         Try
            ' Get the 'BindingManagerBase' object.
            Dim myBindingManagerBase As BindingManagerBase = BindingContext(myDataTable)
            ' Remove the selected row from the grid.
            myBindingManagerBase.RemoveAt(myBindingManagerBase.Position)
         Catch ex As Exception
            MessageBox.Show(ex.Source)
            MessageBox.Show(ex.Message)
         End Try
      End Sub 'button1_Click
      
' </Snippet1>
      Private Sub MakeDataTableAndDisplay()
         ' Create new DataTable.
         myDataTable = New DataTable("MyDataTable")
         
         Dim myDataColumn As DataColumn
         Dim myDataRow As DataRow
         
         ' Create new 'DataColumn'.
         myDataColumn = New DataColumn()
         ' Set the 'DataType'.
         myDataColumn.DataType = Type.GetType("System.Int32")
         ' Set the 'ColumnName'.
         myDataColumn.ColumnName = "id"
         ' Add the column to the 'DataTable'.    
         myDataTable.Columns.Add(myDataColumn)
         
         ' Create second column.
         myDataColumn = New DataColumn()
         myDataColumn.DataType = Type.GetType("System.String")
         myDataColumn.ColumnName = "item"
         myDataTable.Columns.Add(myDataColumn)
         
         ' Create new DataRow objects and add to DataTable.    
         Dim i As Integer
         For i = 0 To 9
            myDataRow = myDataTable.NewRow()
            myDataRow("id") = i
            myDataRow("item") = "item " + i.ToString()
            myDataTable.Rows.Add(myDataRow)
         Next i
         ' Attach the 'myDataTable' to the DataGrid.
         dataGrid1.DataSource = myDataTable
      End Sub 'MakeDataTableAndDisplay
   End Class 'Form1
End Namespace 'WindowsApplication1