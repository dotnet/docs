      ' Create a negative hexadecimal value out of range of the UInt64 type.
      Dim sourceNumber As Long = Long.MinValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As UInt64
      Try
         targetNumber = Convert.ToUInt64(value, 16)
         If isSigned And ((targetNumber And &H8000000000000000ul) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned long integer.", _
                           value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0x8000' to an unsigned long integer.     