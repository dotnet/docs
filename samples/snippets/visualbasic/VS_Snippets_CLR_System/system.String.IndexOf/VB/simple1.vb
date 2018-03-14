' <Snippet12>
Public Module Example
   Public Sub Main()
      Dim str As String = "animal"
      Dim toFind As String = "n"
      Dim index As Integer = str.IndexOf("n")
      Console.WriteLine("Found '{0}' in '{1}' at position {2}",
                        toFind, str, index)
   End Sub
End Module
' The example displays the following output:
'       Found 'n' in 'animal' at position 1
' </Snippet12>