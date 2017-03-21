      ' Create a negative hexadecimal value out of range of the Long type.
      Dim sourceNumber As Byte = Byte.MaxValue
      Dim isSigned As Boolean = Math.Sign(sourceNumber.MinValue) = -1
      Dim value As String = Convert.ToString(sourceNumber, 16)
      Dim targetNumber As SByte
      Try
         targetNumber = Convert.ToSByte(value, 16)
         If Not isSigned And ((targetNumber And &H80) <> 0) Then
            Throw New OverflowException()
         Else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber)
         End If    
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a signed byte.", value)
      End Try 
      ' Displays the following to the console:
      '    Unable to convert '0xff' to a signed byte.     