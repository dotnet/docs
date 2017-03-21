      ' Create a hexadecimal value out of range of the Integer type.
      Dim sourceNumber As Long = CLng(Integer.MaxValue) + 1
      Dim isNegative As Boolean = (Math.Sign(sourceNumber) = -1)
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As Integer
      Try
         targetNumber = Convert.ToInt32(value, 16)
         If Not isNegative And ((targetNumber And &H80000000) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an integer.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x80000000' to an integer.     