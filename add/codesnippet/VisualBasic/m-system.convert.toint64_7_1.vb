      ' Create a hexadecimal value out of range of the Long type.
      Dim value As String = ULong.MaxValue.ToString("X")
      ' Call Convert.ToInt64 to convert it back to a number.
      Try
         Dim number As Long = Convert.ToInt64(value, 16)
         Console.WriteLine("0x{0} converts to {1}.", value, number)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to a long integer.", value)
      End Try   