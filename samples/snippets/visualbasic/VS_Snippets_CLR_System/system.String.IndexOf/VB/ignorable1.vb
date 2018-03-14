' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim softHyphen As String = ChrW(&h00AD)
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the index of the soft hyphen.
      Console.WriteLine(s1.IndexOf(softHyphen))
      Console.WriteLine(s2.IndexOf(softHyphen))
      
      ' Find the index of the soft hyphen followed by "n".
      Console.WriteLine(s1.IndexOf(softHyphen + "n"))
      Console.WriteLine(s2.IndexOf(softHyphen + "n"))
      
      ' Find the index of the soft hyphen followed by "m".
      Console.WriteLine(s1.IndexOf(softHyphen + "m"))
      Console.WriteLine(s2.IndexOf(softHyphen + "m"))
   End Sub
End Module
' The example displays the following output if run under
' .NET 4 or later:
'       0
'       0
'       1
'       1
'       4
'       3
' </Snippet2>

