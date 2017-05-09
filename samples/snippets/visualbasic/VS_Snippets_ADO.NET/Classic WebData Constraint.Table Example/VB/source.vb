Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form   
    
' <Snippet1>
 Private Sub GetDataTable(constraint As UniqueConstraint)
     Dim table As DataTable = constraint.Table
     Console.WriteLine(table.TableName)
 End Sub
' </Snippet1>
End Class
