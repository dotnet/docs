Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet    
    
    Public Sub Method()
' <Snippet1>
Dim uniqueConstraint As New UniqueConstraint( _
    DataSet1.Tables("Table1").Columns("Column1"))
' </Snippet1>
    End Sub
End Class
