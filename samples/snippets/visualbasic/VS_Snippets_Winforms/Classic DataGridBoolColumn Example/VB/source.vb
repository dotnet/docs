Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1: Inherits Form

protected dataGrid1 As DataGrid

' <Snippet1>
Private Sub AddDataGridBoolColumnStyle()
   Dim myColumn As DataGridBoolColumn  = new DataGridBoolColumn()
   myColumn.MappingName = "Current"
   myColumn.Width = 200
   dataGrid1.TableStyles("Customers").GridColumnStyles.Add(myColumn)
End Sub 
' </Snippet1>
End Class
