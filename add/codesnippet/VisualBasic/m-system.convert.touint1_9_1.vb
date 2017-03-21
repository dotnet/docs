      ' Create a hexadecimal value out of range of the UInt16 type.
      Dim value As String = Convert.ToString(Short.MinValue, 16)
      ' Convert it back to a number.
      Try
         Dim number As UInt16 = Convert.ToUInt16(value, 16)
         Console.WriteLine("0x{0} converts to {1}.", value, number)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned short integer.", _
                           value)
      End Try   