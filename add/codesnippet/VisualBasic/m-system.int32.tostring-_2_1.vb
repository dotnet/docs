      Dim value As Integer = -16325
      ' Display value using the invariant culture.
      Console.WriteLine(value.ToString(CultureInfo.InvariantCulture))
      ' Display value using the en-GB culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("en-GB")))
      ' Display value using the de-DE culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("de-DE")))
      ' This example displays the following output to the console:
      '       -16325
      '       -16325
      '       -16325