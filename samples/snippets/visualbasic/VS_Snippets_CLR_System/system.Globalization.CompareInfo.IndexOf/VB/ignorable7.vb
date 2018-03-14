' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo
      
      Dim softHyphen As Char = ChrW(&h00AD)
      Dim position As Integer
      
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the index of the soft hyphen using culture-sensitive comparison.
      position = ci.IndexOf(s1, "n"c)
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen, position, CompareOptions.IgnoreCase))
      End If
      
      position = ci.IndexOf(s2, "n"c)
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen, position, CompareOptions.IgnoreCase))
      End If  
       
      ' Find the index of the soft hyphen using ordinal comparison.
      position = ci.IndexOf(s1, "n"c)
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen, position, CompareOptions.Ordinal))
      End If
      
      position = ci.IndexOf(s2, "n"c)
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen, position, CompareOptions.Ordinal))
      End If   
   End Sub
End Module
' The example displays the following output:
'       'n' at position 1
'       1
'       'n' at position 1
'       1
'       'n' at position 1
'       3
'       'n' at position 1
'       -1
' </Snippet8>

