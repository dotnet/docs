' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      Dim softHyphen As String = ChrW(&h00AD)
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the index of the last soft hyphen.
      Console.WriteLine(s1.LastIndexOf(softHyphen))
      Console.WriteLine(s2.LastIndexOf(softHyphen))
      
      ' Find the index of the last soft hyphen followed by "n".
      Console.WriteLine(s1.LastIndexOf(softHyphen + "n"))
      Console.WriteLine(s2.LastIndexOf(softHyphen + "n"))
      
      ' Find the index of the last soft hyphen followed by "m".
      Console.WriteLine(s1.LastIndexOf(softHyphen + "m"))
      Console.WriteLine(s2.LastIndexOf(softHyphen + "m"))
   End Sub
End Module
' The example displays the following output:
'       6
'       5
'       1
'       1
'       4
'       3
' </Snippet3>

