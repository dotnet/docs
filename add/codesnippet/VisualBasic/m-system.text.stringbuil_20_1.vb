      Dim sb As New System.Text.StringBuilder("The range of a 64-bit unsigned integer: ")
      sb.Append(UInt64.MinValue).Append(" to ").Append(UInt64.MaxValue)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       The range of a 64-bit unsigned integer: 0 to 18446744073709551615