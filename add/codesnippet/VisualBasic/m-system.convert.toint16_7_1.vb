     ' Create a hexadecimal value out of range of the Int16 type.
     Dim value As String = Convert.ToString(CInt(Short.MaxValue) + 1, 16)
     ' Convert it back to a number.
     Try
        Dim number As Short = Convert.ToInt16(value, 16)
        Console.WriteLine("0x{0} converts to {1}.", value, number)
     Catch e As OverflowException
        Console.WriteLine("Unable to convert '0x{0}' to a 16-bit integer.", value)
     End Try   