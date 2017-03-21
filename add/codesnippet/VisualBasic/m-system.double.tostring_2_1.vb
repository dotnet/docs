      Dim value As Double 
      
      value = -16325.62015
      ' Display value using the invariant culture.
      Console.WriteLine(value.ToString(CultureInfo.InvariantCulture))
      ' Display value using the en-GB culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("en-GB")))
      ' Display value using the de-DE culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("de-DE")))

      value = 16034.125E21
      ' Display value using the invariant culture.
      Console.WriteLine(value.ToString(CultureInfo.InvariantCulture))
      ' Display value using the en-GB culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("en-GB")))
      ' Display value using the de-DE culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("de-DE")))
      ' This example displays the following output to the console:
      '       -16325.62015
      '       -16325.62015
      '       -16325,62015
      '       1.6034125E+25
      '       1.6034125E+25
      '       1,6034125E+25