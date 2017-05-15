' Visual Basic .NET Document
Option Strict On
' <Snippet22>
Module Example
   Public Sub Main()
      Dim searchString As String = Chrw(&h00AD) + "m"
      Dim s1 As String = "ani" + ChrW(&h00AD) + "mal"
      Dim s2 As String = "animal"

      Console.WriteLine(s1.IndexOf(searchString, 2))
      Console.WriteLine(s2.IndexOf(searchString, 2))
   End Sub
End Module
' The example displays the following output:
'       4
'       3 
' </Snippet22>
