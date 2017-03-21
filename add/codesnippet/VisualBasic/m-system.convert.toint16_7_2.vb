      ' Create a hexadecimal value out of range of the Short type.
      Dim sourceNumber As Integer = CInt(Short.MaxValue) + 1
      Dim isNegative As Boolean = (Math.Sign(sourceNumber) = -1)
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As Short
      Try
         targetNumber = Convert.ToInt16(value, 16)
         If Not isNegative And ((targetNumber And &H8000) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a 16-bit integer.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x8000' to a 16-bit integer.     