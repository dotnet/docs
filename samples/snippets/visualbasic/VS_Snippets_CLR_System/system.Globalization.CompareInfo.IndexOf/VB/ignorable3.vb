' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo
      
      Dim softHyphen As Char = ChrW(&h00AD)
      
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the index of the soft hyphen using culture-sensitive comparison.
      Console.WriteLine(ci.IndexOf(s1, softHyphen, CompareOptions.IgnoreCase))
      Console.WriteLine(ci.IndexOf(s2, softHyphen, CompareOptions.IgnoreCase))
      
      ' Find the index of the soft hyphen using ordinal comparison.
      Console.WriteLine(ci.IndexOf(s1, softHyphen, CompareOptions.Ordinal))
      Console.WriteLine(ci.IndexOf(s2, softHyphen, CompareOptions.Ordinal))
   End Sub
End Module
' The example displays the following output:
'       0
'       0
'       3
'       -1
' </Snippet4>

