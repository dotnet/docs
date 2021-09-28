
Module Example
   Public Sub Main()
      Dim arr(99) As Integer
      Console.WriteLine(arr.Length)
      
      Redim arr(50)
      Console.WriteLine(arr.Length)
   End Sub
End Module
' The example displays the following output:
'     100
'     51

 