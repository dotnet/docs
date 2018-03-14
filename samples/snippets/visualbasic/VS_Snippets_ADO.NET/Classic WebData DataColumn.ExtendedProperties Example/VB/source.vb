Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
 Private Sub SetProperty(column As DataColumn)
     column.ExtendedProperties.Add("TimeStamp", DateTime.Now)
 End Sub    
    
 Private Sub GetProperty(column As DataColumn)
     Console.WriteLine(column.ExtendedProperties("TimeStamp").ToString())
End Sub
' </Snippet1>
End Class
