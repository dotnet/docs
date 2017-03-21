      ' Define an array of numbers to display.
      Dim numbers() As Byte = { 12, 100, Byte.MaxValue }
      ' Define the culture names used to display them.
      Dim cultureNames() As String = { "en-US", "fr-FR" }
      
      For Each number As Byte In numbers
         Console.WriteLine("{0}:", Convert.ToString(number, _
                                   System.Globalization.CultureInfo.InvariantCulture))
         For Each cultureName As String In cultureNames
            Dim culture As New System.Globalization.CultureInfo(cultureName)
            Console.WriteLine("   {0}: {1,20}", _
                              culture.Name, Convert.ToString(number, culture))
         Next
         Console.WriteLine()
      Next   
      ' The example displays the following output:
      '       12:
      '          en-US:                   12
      '          fr-FR:                   12
      '       
      '       100:
      '          en-US:                  100
      '          fr-FR:                  100
      '       
      '       255:
      '          en-US:                  255
      '          fr-FR:                  255      