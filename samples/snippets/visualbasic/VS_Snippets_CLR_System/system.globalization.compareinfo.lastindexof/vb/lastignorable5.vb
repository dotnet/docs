' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo
      
      Dim softHyphen As String = ChrW(&h00AD)
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      Console.WriteLine("Culture-sensitive comparison:")
      ' Use culture-sensitive comparison to find the last soft hyphen.
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen, CompareOptions.None))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen, CompareOptions.None))
      
      ' Use culture-sensitive comparison to find the last soft hyphen followed by "n".
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "n", CompareOptions.None))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "n", CompareOptions.None))
      
      ' Use culture-sensitive comparison to find the last soft hyphen followed by "m".
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "m", CompareOptions.None))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "m", CompareOptions.None))
      
      Console.WriteLine("Ordinal comparison:")
      ' Use ordinal comparison to find the last soft hyphen.
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen, CompareOptions.Ordinal))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen, CompareOptions.Ordinal))
      
      ' Use ordinal comparison to find the last soft hyphen followed by "n".
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "n", CompareOptions.Ordinal))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "n", CompareOptions.Ordinal))
      
      ' Use ordinal comparison to find the last soft hyphen followed by "m".
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "m", CompareOptions.Ordinal))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "m", CompareOptions.Ordinal))
   End Sub
End Module
' The example displays the following output:
'       6
'       5
'       1
'       1
'       4
'       3
'       Ordinal comparison:
'       3
'       -1
'       -1
'       -1
'       3
'       -1
' </Snippet6>

