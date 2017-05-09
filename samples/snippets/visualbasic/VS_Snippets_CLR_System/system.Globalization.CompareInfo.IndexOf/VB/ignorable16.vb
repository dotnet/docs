' Visual Basic .NET Document
Option Strict On
' <Snippet17>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo

      Dim searchString As String = Chrw(&h00AD) + "m"
      Dim s1 As String = "ani" + ChrW(&h00AD) + "mal"
      Dim s2 As String = "animal"

      Console.WriteLine(ci.IndexOf(s1, searchString, 2, 4))
      Console.WriteLine(ci.IndexOf(s2, searchString, 2, 4))
   End Sub
End Module
' The example displays the following output:
'       4
'       3
' </Snippet17>
