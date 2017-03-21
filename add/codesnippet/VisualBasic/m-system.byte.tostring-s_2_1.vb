      Dim byteValue As Byte = 250
      Dim providers() As CultureInfo = {New CultureInfo("en-us"), _
                                        New CultureInfo("fr-fr"), _
                                        New CultureInfo("es-es"), _
                                        New CultureInfo("de-de")} 
      For Each provider As CultureInfo In providers 
         Console.WriteLine("{0} ({1})", _
                           byteValue.ToString("N2", provider), provider.Name)
      Next   
      ' The example displays the following output to the console:
      '       250.00 (en-US)
      '       250,00 (fr-FR)
      '       250,00 (es-ES)
      '       250,00 (de-DE)      