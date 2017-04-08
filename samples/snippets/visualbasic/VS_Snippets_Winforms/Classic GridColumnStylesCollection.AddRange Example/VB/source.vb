Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid    
    
' <Snippet1>
 Private Sub AddStyleRange()
     ' Create two DataGridColumnStyle objects.
     Dim col1 As New DataGridTextBoxColumn()
     col1.MappingName = "FirstName"
     Dim col2 As New DataGridBoolColumn()
     col2.MappingName = "Current"
        
     ' Create an array and use AddRange to add to collection.
     Dim cols() As DataGridColumnStyle = {col1, col2}
     dataGrid1.TableStyles(0).GridColumnStyles.AddRange(cols)
 End Sub
' </Snippet1>
End Class
