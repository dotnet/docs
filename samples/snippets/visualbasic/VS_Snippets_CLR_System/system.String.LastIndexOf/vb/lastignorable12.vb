' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Module Example
   Public Sub Main()
      Dim position As Integer
      Dim softHyphen As String = ChrW(&h00AD)
      
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' All the following are culture-sensitive comparisons.
      Console.WriteLine("Culture-sensitive comparisons:")
      ' Find the index of the soft hyphen.
      position = s1.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(softHyphen, position, 
                           position + 1, StringComparison.CurrentCulture))
      End If
         
      position = s2.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(softHyphen, position, 
                           position + 1, StringComparison.CurrentCulture))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = s1.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(softHyphen + "n", position, 
                           position + 1, StringComparison.CurrentCultureIgnoreCase))
      End If
         
      position = s2.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(softHyphen + "n", position, 
                           position + 1, StringComparison.CurrentCultureIgnoreCase))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = s1.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(softHyphen + "m", position, 
                           position + 1, StringComparison.CurrentCultureIgnoreCase))
      End If
      
      position = s2.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(softHyphen + "m", position, 
                           position + 1, StringComparison.CurrentCultureIgnoreCase))
      End If

      ' All the following are ordinal comparisons.
      Console.WriteLine()
      Console.WriteLine("Ordinal comparisons:")
      ' Find the index of the soft hyphen.
      position = s1.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(softHyphen, position, 
                           position + 1, StringComparison.Ordinal))
      End If
         
      position = s2.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(softHyphen, position, 
                           position + 1, StringComparison.Ordinal))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = s1.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(softHyphen + "n", position, 
                           position + 1, StringComparison.Ordinal))
      End If
         
      position = s2.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(softHyphen + "n", position, 
                           position + 1, StringComparison.Ordinal))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = s1.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(softHyphen + "m", position, 
                           position + 1, StringComparison.Ordinal))
      End If
      
      position = s2.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(softHyphen + "m", position, 
                           position + 1, StringComparison.Ordinal))
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

