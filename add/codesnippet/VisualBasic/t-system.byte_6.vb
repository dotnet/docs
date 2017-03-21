      Dim numbers() As Byte = { 0, 16, 104, 213 }
      Console.WriteLine("{0}   {1,8}   {2,5}   {3,5}", _
                        "Value", "Binary", "Octal", "Hex")
      For Each number As Byte In numbers
         Console.WriteLine("{0,5}   {1,8}   {2,5}   {3,5}", _
                           number, Convert.ToString(number, 2), _
                           Convert.ToString(number, 8), _
                           Convert.ToString(number, 16))
      Next      
      ' The example displays the following output:
      '       Value     Binary   Octal     Hex
      '           0          0       0       0
      '          16      10000      20      10
      '         104    1101000     150      68
      '         213   11010101     325      d5      