      Dim numbers() As Integer = { Int32.MinValue, -1000, 0, 1000, Int32.MaxValue }
      Dim result As Single
      
      For Each number As Integer In numbers
         result = Convert.ToSingle(number)
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the Int32 value '-2147483648' to the Single value -2.147484E+09.
      '    Converted the Int32 value '-1000' to the Single value -1000.
      '    Converted the Int32 value '0' to the Single value 0.
      '    Converted the Int32 value '1000' to the Single value 1000.
      '    Converted the Int32 value '2147483647' to the Single value 2.147484E+09.