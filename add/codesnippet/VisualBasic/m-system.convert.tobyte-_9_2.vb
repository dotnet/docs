      ' Create a negative hexadecimal value out of range of the Byte type.
      Dim sourceNumber As SByte = SByte.MinValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = sourceNumber.ToString("X")
      Dim targetNumber As Byte
      Try
         targetNumber = Convert.ToByte(value, 16)
         If isSigned And ((targetNumber And &H80) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned byte.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x80' to an unsigned byte.     