' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Module Example
   Public Sub Main()
      Dim position As Integer
      Dim softHyphen As String = ChrW(&h00AD)
      
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the index of the soft hyphen.
      position = s1.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.IndexOf(softHyphen, position, s1.Length - position))
      End If
         
      position = s2.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.IndexOf(softHyphen, position, s2.Length - position))
      End If
      
      ' Find the index of the soft hyphen followed by "n".
      position = s1.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.IndexOf(softHyphen + "n", position, s1.Length - position))
      End If
         
      position = s2.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.IndexOf(softHyphen + "n", position, s2.Length - position))
      End If
      
      ' Find the index of the soft hyphen followed by "m".
      position = s1.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s1.IndexOf(softHyphen + "m", position, s1.Length - position))
      End If
      
      position = s2.IndexOf("n")
      Console.WriteLine("'n' at position {0}", position)
      If position >= 0 Then
         Console.WriteLine(s2.IndexOf(softHyphen + "m", position, s2.Length - position))
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
' </Snippet11>

