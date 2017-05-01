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
      position = ci.IndexOf(s1, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen, position, 
                           s1.Length - position, CompareOptions.None))
      End If
         
      position = ci.IndexOf(s2, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen, position, 
                           s2.Length - position, CompareOptions.None))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = ci.IndexOf(s1, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen + "n", position, 
                           s1.Length - position, CompareOptions.IgnoreCase))
      End If
         
      position = ci.IndexOf(s2, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen + "n", position, 
                           s2.Length - position, CompareOptions.IgnoreCase))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = ci.IndexOf(s1, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen + "m", position, 
                           s1.Length - position, CompareOptions.IgnoreCase))
      End If
      
      position = ci.IndexOf(s2, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen + "m", position, 
                           s2.Length - position, CompareOptions.IgnoreCase))
      End If

      ' All the following are ordinal comparisons.
      Console.WriteLine()
      Console.WriteLine("Ordinal comparisons:")
      ' Find the index of the soft hyphen.
      position = ci.IndexOf(s1, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen, position, 
                           s1.Length - position, CompareOptions.Ordinal))
      End If
         
      position = ci.IndexOf(s2, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen, position, 
                           s2.Length - position, CompareOptions.Ordinal))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = ci.IndexOf(s1, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen + "n", position, 
                           s1.Length - position, CompareOptions.Ordinal))
      End If
         
      position = ci.IndexOf(s2, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen + "n", position, 
                           s2.Length - position, CompareOptions.Ordinal))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = ci.IndexOf(s1, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s1, softHyphen + "m", position, 
                           s1.Length - position, CompareOptions.Ordinal))
      End If
      
      position = ci.IndexOf(s2, "n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(ci.IndexOf(s2, softHyphen + "m", position, 
                           s2.Length - position, CompareOptions.Ordinal))
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
'       
'       Ordinal comparisons:
'       'n' at position 1
'       3
'       'n' at position 1
'       -1
'       'n' at position 1
'       -1
'       'n' at position 1
'       -1
'       'n' at position 1
'       3
'       'n' at position 1
'       -1
' </Snippet13>

