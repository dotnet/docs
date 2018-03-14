' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim s1 As String = "ani" + ChrW(&h00AD) + "mal"
      Dim o1 As Object = "animal"
      
      Console.WriteLine("Comparison of '{0}' and '{1}': {2}", 
                        s1, o1, s1.CompareTo(o1))
  End Sub
End Module
' The example displays the following output:
'       Comparison of 'ani-mal' and 'animal': 0
' </Snippet1>
