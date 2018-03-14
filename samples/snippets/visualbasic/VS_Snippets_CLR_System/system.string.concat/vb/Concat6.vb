' <Snippet6>
Imports System

Public Module Example
   Public Sub Main()
      Dim s1 As String = "We went to a bookstore, "
      Dim s2 As String = "a movie, "
      Dim s3 As String = "and a restaurant."

      Dim s = String.Concat(s1, s2, s3)
      Console.WriteLine(s)
   End Sub
End Module
' The example displays the following output:
'      We went to a bookstore, a movie, and a restaurant. 
' </Snippet6>
