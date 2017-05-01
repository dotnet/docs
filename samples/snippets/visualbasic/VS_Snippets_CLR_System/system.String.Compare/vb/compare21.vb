' Visual Basic .NET Document
Option Strict On

' <Snippet21>
Module Example
   Public Sub Main()
      Dim s1 As String = "ani" + ChrW(&h00AD) + "mal"
      Dim s2 As String = "animal"
      
      Console.WriteLine("Comparison of '{0}' and '{1}': {2}", 
                        s1, s2, String.Compare(s1, s2))
  End Sub
End Module
' The example displays the following output:
'       Comparison of 'ani-mal' and 'animal': 0
' </Snippet21>
