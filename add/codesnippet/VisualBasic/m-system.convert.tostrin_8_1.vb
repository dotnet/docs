      ' Define an array of numbers to display.
      Dim numbers() As Decimal = { 1734231911290.16d, -17394.32921d, _
                                   3193.23d, 98012368321.684d }
      ' Define the culture names used to display them.
      Dim cultureNames() As String = { "en-US", "fr-FR", "ja-JP", "ru-RU" }
      
      For Each number As Decimal In numbers
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
      '    1734231911290.16:
      '       en-US:     1734231911290.16
      '       fr-FR:     1734231911290,16
      '       ja-JP:     1734231911290.16
      '       ru-RU:     1734231911290,16
      '    
      '    -17394.32921:
      '       en-US:         -17394.32921
      '       fr-FR:         -17394,32921
      '       ja-JP:         -17394.32921
      '       ru-RU:         -17394,32921
      '    
      '    3193.23:
      '       en-US:              3193.23
      '       fr-FR:              3193,23
      '       ja-JP:              3193.23
      '       ru-RU:              3193,23
      '    
      '    98012368321.684:
      '       en-US:      98012368321.684
      '       fr-FR:      98012368321,684
      '       ja-JP:      98012368321.684
      '       ru-RU:      98012368321,684