imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub GetAndSetExtendedProperties(ByVal myTable As DataTable)
    ' Add an item to the collection.
    myTable.ExtendedProperties.Add("TimeStamp", DateTime.Now)
    ' Print the item.
    Console.WriteLine(myTable.ExtendedProperties.Item("TimeStamp"))
 End Sub
' </Snippet1>

End Class
