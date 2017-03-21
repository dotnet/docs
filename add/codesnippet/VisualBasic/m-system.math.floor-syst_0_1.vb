      Dim values() As Double = {7.03, 7.64, 0.12, -0.12, -7.1, -7.6}
      Console.WriteLine("  Value          Ceiling          Floor")
      Console.WriteLine()
      For Each value As Double In values
         Console.WriteLine("{0,7} {1,16} {2,14}", _
                           value, Math.Ceiling(value), Math.Floor(value))
      Next   
      ' The example displays the following output to the console:
      '         Value          Ceiling          Floor
      '       
      '          7.03                8              7
      '          7.64                8              7
      '          0.12                1              0
      '         -0.12                0             -1
      '          -7.1               -7             -8
      '          -7.6               -7             -8