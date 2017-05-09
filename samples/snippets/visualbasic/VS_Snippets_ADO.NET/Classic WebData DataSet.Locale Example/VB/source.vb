imports System
imports System.Xml
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub GetCultureInfo()
    Dim culture As System.Globalization.CultureInfo
    culture = DataSet1.Locale
    Console.WriteLine(culture.DisplayName, culture.EnglishName)
 End Sub
' </Snippet1>

End Class
