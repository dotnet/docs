' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo
      
      Dim softHyphen As Char = ChrW(&h00AD)
      
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the index of the last soft hyphen.
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen))
   End Sub
End Module
' The example displays the following output:
'       6
'       5
' </Snippet3>

