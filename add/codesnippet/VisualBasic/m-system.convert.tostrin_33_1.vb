      ' Define an array of numbers to display.
      Dim numbers() As Double = { -1.5345e16, -123.4321, 19092.123, _
                                  1.1734231911290e16 }
      ' Define the culture names used to display them.
      Dim cultureNames() As String = { "en-US", "fr-FR", "ja-JP", "ru-RU" }
      
      For Each number As Double In numbers
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
      '    -1.5345E+16:
      '       en-US:          -1.5345E+16
      '       fr-FR:          -1,5345E+16
      '       ja-JP:          -1.5345E+16
      '       ru-RU:          -1,5345E+16
      '    
      '    -123.4321:
      '       en-US:            -123.4321
      '       fr-FR:            -123,4321
      '       ja-JP:            -123.4321
      '       ru-RU:            -123,4321
      '    
      '    19092.123:
      '       en-US:            19092.123
      '       fr-FR:            19092,123
      '       ja-JP:            19092.123
      '       ru-RU:            19092,123
      '    
      '    1.173423191129E+16:
      '       en-US:   1.173423191129E+16
      '       fr-FR:   1,173423191129E+16
      '       ja-JP:   1.173423191129E+16
      '       ru-RU:   1,173423191129E+16