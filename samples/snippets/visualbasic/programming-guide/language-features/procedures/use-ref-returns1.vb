Module Example
   Public Sub Main()
      Dim n As New NumericValue(15)
      n.IncrementValue() += 12
      Console.WriteLine(n.GetValue) 
   End Sub
End Module
' Output:   28

