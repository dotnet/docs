' <Snippet1>
Public Class Example
   Public Shared Sub Main()
      Dim str As String
      Dim pad As Char
      str = "forty-two"
      pad = "."c
      Console.WriteLine(str.PadLeft(15, pad)) 
      Console.WriteLine(str.PadLeft(2,  pad))
    End Sub
End Class
' The example displays the following output:
'       ......forty-two
'       forty-two
' </Snippet1>
