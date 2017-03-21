     ' Create a hexadecimal value out of range of the Integer type.
     Dim value As String = Convert.ToString(CLng(Integer.MaxValue) + 1, 16)
     ' Convert it back to a number.
     Try
        Dim number As Integer = Convert.ToInt32(value, 16)
        Console.WriteLine("0x{0} converts to {1}.", value, number)
     Catch e As OverflowException
        Console.WriteLine("Unable to convert '0x{0}' to an integer.", value)
     End Try   