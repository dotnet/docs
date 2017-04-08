' Visual Basic .NET Document
Option Strict On

' <Snippet22>
Module Example
   Public Sub Main()
      Dim position As Integer
      Dim softHyphen As String = ChrW(&h00AD)
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the index of the soft hyphen.
      position = s1.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(softHyphen, position))
      End If
         
      position = s2.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(softHyphen, position))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = s1.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(softHyphen + "n", position))
      End If
         
      position = s2.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(softHyphen + "n", position))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = s1.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(softHyphen + "m", position))
      End If
      
      position = s2.LastIndexOf("m")
      Console.WriteLine("'m' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(softHyphen + "m", position))
      End If
   End Sub
End Module
' The example displays the following output:
'       'm' at position 4
'       4
'       'm' at position 3
'       3
'       'm' at position 4
'       1
'       'm' at position 3
'       1
'       'm' at position 4
'       4
'       'm' at position 3
'       3
' </Snippet22>

