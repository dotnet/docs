' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo
      
      Dim position As Integer
      Dim softHyphen As String = ChrW(&h00AD)
      
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' All the following are culture-sensitive comparisons.
      Console.WriteLine("Culture-sensitive comparisons:")
      ' Find the index of the soft hyphen.
      position = ci.LastIndexOf(s1, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s1, softHyphen, position, 
                           position + 1, CompareOptions.None))
      End If
         
      position = ci.LastIndexOf(s2, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s2, softHyphen, position, 
                           position + 1, CompareOptions.None))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = ci.LastIndexOf(s1, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "n", position, 
                           position + 1, CompareOptions.IgnoreCase))
      End If
         
      position = ci.LastIndexOf(s2, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "n", position, 
                           position + 1, CompareOptions.IgnoreCase))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = ci.LastIndexOf(s1, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "m", position, 
                           position + 1, CompareOptions.IgnoreCase))
      End If
      
      position = ci.LastIndexOf(s2, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "m", position, 
                           position + 1, CompareOptions.IgnoreCase))
      End If

      ' All the following are ordinal comparisons.
      Console.WriteLine()
      Console.WriteLine("Ordinal comparisons:")
      ' Find the index of the soft hyphen.
      position = ci.LastIndexOf(s1, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s1, softHyphen, position, 
                           position + 1, CompareOptions.Ordinal))
      End If
         
      position = ci.LastIndexOf(s2, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s2, softHyphen, position, 
                           position + 1, CompareOptions.Ordinal))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = ci.LastIndexOf(s1, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "n", position, 
                           position + 1, CompareOptions.Ordinal))
      End If
         
      position = ci.LastIndexOf(s2, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "n", position, 
                           position + 1, CompareOptions.Ordinal))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = ci.LastIndexOf(s1, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "m", position, 
                           position + 1, CompareOptions.Ordinal))
      End If
      
      position = ci.LastIndexOf(s2, "m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "m", position, 
                           position + 1, CompareOptions.Ordinal))
      End If
   End Sub
End Module
' The example displays the following output:
'       'm' at position 1
'       1
'       'm' at position 1
'       1
'       'm' at position 1
'       1
'       'm' at position 1
'       1
'       'm' at position 1
'       4
'       'm' at position 1
'       3
'       
'       Ordinal comparisons:
'       'm' at position 1
'       3
'       'm' at position 1
'       -1
'       'm' at position 1
'       -1
'       'm' at position 1
'       -1
'       'm' at position 1
'       3
'       'm' at position 1
'       -1
' </Snippet13>

