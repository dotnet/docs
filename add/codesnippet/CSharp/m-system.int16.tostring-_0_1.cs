      Int16[] values = {-23805, 32194};
      string[] formats = {"C4", "D6", "e1", "E2", "F1", "G", "N1", 
                          "P0", "X4", "000000.0000", "##000.0"};
      foreach (string format in formats)
      {
         Console.WriteLine("'{0,2}' format specifier: {1,17}   {2,17}",  
                           format, 
                           values[0].ToString(format), 
                           values[1].ToString(format));
      }                                                               
      // The example displays the following output to the console:
      //    'C4' format specifier:    ($23,805.0000)        $32,194.0000
      //    'D6' format specifier:           -023805              032194
      //    'e1' format specifier:         -2.4e+004            3.2e+004
      //    'E2' format specifier:        -2.38E+004           3.22E+004
      //    'F1' format specifier:          -23805.0             32194.0
      //    ' G' format specifier:            -23805               32194
      //    'N1' format specifier:         -23,805.0            32,194.0
      //    'P0' format specifier:      -2,380,500 %         3,219,400 %
      //    'X4' format specifier:              A303                7DC2
      //    '000000.0000' format specifier:      -023805.0000         032194.0000
      //    '##000.0' format specifier:          -23805.0             32194.0      