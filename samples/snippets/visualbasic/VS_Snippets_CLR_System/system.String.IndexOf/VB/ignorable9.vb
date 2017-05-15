' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Module Example
   Public Sub Main()
      Dim position As Integer
      Dim softHyphen As String = ChrW(&h00AD)
      
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Use culture-sensitive comparison for the following searches:
      Console.WriteLine("Culture-sensitive comparisons:")
      ' Find the index of the soft hyphen.
      position = s1.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.IndexOf(softHyphen, position, StringComparison.CurrentCulture))
      End If
         
      position = s2.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.IndexOf(softHyphen, position, StringComparison.CurrentCulture))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = s1.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.IndexOf(softHyphen + "n", position, StringComparison.CurrentCultureIgnoreCase))
      End If
         
      position = s2.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.IndexOf(softHyphen + "n", position, StringComparison.CurrentCultureIgnoreCase))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = s1.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.IndexOf(softHyphen + "m", position, StringComparison.CurrentCultureIgnoreCase))
      End If
      
      position = s2.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.IndexOf(softHyphen + "m", position, StringComparison.CurrentCultureIgnoreCase))
      End If
      Console.WriteLine()
      
      ' Use ordinal comparison for the following searches:
      Console.WriteLine("Ordinal comparisons:")
      ' Find the index of the soft hyphen.
      position = s1.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.IndexOf(softHyphen, position, StringComparison.Ordinal))
      End If
         
      position = s2.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.IndexOf(softHyphen, position, StringComparison.Ordinal))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = s1.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.IndexOf(softHyphen + "n", position, StringComparison.Ordinal))
      End If
         
      position = s2.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.IndexOf(softHyphen + "n", position, StringComparison.Ordinal))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = s1.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.IndexOf(softHyphen + "m", position, StringComparison.Ordinal))
      End If
      
      position = s2.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.IndexOf(softHyphen + "m", position, StringComparison.Ordinal))
      End If
   End Sub
End Module
' The example displays the following output:
'       Culture-sensitive comparisons:
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
' </Snippet10>

