' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo
      
      Dim position As Integer
      Dim softHyphen As String = ChrW(&h00AD)
      
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the index of the soft hyphen.
      position = ci.IndexOf(s1, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen, position))
      End If
         
      position = ci.IndexOf(s2, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen, position))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = ci.IndexOf(s1, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen + "n", position))
      End If
         
      position = ci.IndexOf(s2, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen + "n", position))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = ci.IndexOf(s1, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen + "m", position))
      End If
      
      position = ci.IndexOf(s2, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen + "m", position))
      End If
   End Sub
End Module
' The example displays the following output:
'       'n' at position 1
'       1
'       'n' at position 1
'       1
'       'n' at position 1
'       1
'       'n' at position 1
'       1
'       'n' at position 1
'       4
'       'n' at position 1
'       3
' </Snippet7>

