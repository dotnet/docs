
Module Example
   Public Sub Main()
      Dim bytes(9,9) As Byte
      Console.WriteLine($"Type of {nameof(bytes)} array: {bytes.GetType().Name}")
      Console.WriteLine($"Base class of {nameof(bytes)}: {bytes.GetType().BaseType.Name}")
      Console.WriteLine()
      Console.WriteLine($"Type of {nameof(bytes)} array: {TypeName(bytes)}")
   End Sub
End Module
' The example displays the following output:
' Type of bytes array: Byte[,]
' Base class of bytes: Array
' 
' Type of bytes array: Byte(,)


