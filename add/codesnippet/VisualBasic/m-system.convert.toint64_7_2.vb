      ' Create a negative hexadecimal value out of range of the Long type.
      Dim sourceNumber As ULong = ULong.MaxValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = sourceNumber.ToString("X")
      Dim targetNumber As Long
      Try
         targetNumber = Convert.ToInt64(value, 16)
         If Not isSigned And ((targetNumber And &H8000000000) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a long integer.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0xFFFFFFFFFFFFFFFF' to a long integer.     