Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Private Sub ShowRejectChanges(table As DataTable)
     ' Print the values of row 1, in the column named "CompanyName."
     Console.WriteLine(table.Rows(1)("CompanyName"))

     ' Make Changes to the column named "CompanyName."
     table.Rows(1)("CompanyName") = "Taro"

     ' Reject the changes.
     table.RejectChanges()

     ' Print the original values:
     Console.WriteLine(table.Rows(1)("CompanyName"))
 End Sub
' </Snippet1>
End Class
