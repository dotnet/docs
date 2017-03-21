      Dim bytes() As Byte = {0, 1, 14, 168, 255}
      Dim providers() As CultureInfo = {New CultureInfo("en-us"), _
                                        New CultureInfo("fr-fr"), _
                                        New CultureInfo("de-de"), _
                                        New CultureInfo("es-es")}
      For Each byteValue As Byte In bytes
         For Each provider As CultureInfo In providers
            Console.Write("{0,3} ({1})      ", byteValue.ToString(provider), provider.Name)
         Next
         Console.WriteLine()                                        
      Next
      ' The example displays the following output to the console:
      '      0 (en-US)        0 (fr-FR)        0 (de-DE)        0 (es-ES)
      '      1 (en-US)        1 (fr-FR)        1 (de-DE)        1 (es-ES)
      '     14 (en-US)       14 (fr-FR)       14 (de-DE)       14 (es-ES)
      '    168 (en-US)      168 (fr-FR)      168 (de-DE)      168 (es-ES)
      '    255 (en-US)      255 (fr-FR)      255 (de-DE)      255 (es-ES)            