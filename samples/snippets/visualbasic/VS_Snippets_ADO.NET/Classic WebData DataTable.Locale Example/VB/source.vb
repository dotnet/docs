imports System
imports System.Xml
imports System.Data
imports System.Globalization
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub ChangeCultureInfo(table As DataTable)
    ' Print the LCID  of the present CultureInfo.
    Console.WriteLine(table.Locale.LCID)

    ' Create a new CultureInfo for the United Kingdom.
    Dim myCultureInfo As CultureInfo = New CultureInfo("en-gb")
    table.Locale = myCultureInfo

    ' Print the new LCID.
    Console.WriteLine(table.Locale.LCID) 
 End Sub
' </Snippet1>

End Class
