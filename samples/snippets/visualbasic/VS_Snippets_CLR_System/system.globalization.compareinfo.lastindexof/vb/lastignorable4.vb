' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo
      
      Dim position As Integer
      Dim softHyphen As Char = ChrW(&h00AD)
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the last index of the soft hyphen.
      position = ci.LastIndexOf(s1, "m"c)
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s1, softHyphen, position))
      End If
      
      position = ci.LastIndexOf(s2, "m"c)
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s2, softHyphen, position))
      End If   
   End Sub
End Module
' The example displays the following output:
'       'm' at position 4
'       4
'       'm' at position 3
'       3
' </Snippet5>

