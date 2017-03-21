      Dim numbers() As Short = {-23092, 0, 14894, Int16.MaxValue}
      Dim providers() As CultureInfo = {New CultureInfo("en-us"), _
                                        New CultureInfo("fr-fr"), _
                                        New CultureInfo("de-de"), _
                                        New CultureInfo("es-es")}
      For Each int16Value As Short In Numbers
         For Each provider As CultureInfo In providers
            Console.Write("{0, 6} ({1})     ", _
                          int16Value.ToString(provider), _
                          provider.Name)
         Next                     
         Console.WriteLine()
      Next 
      ' The example displays the following output to the console:
      '       -23092 (en-US)     -23092 (fr-FR)     -23092 (de-DE)     -23092 (es-ES)
      '            0 (en-US)          0 (fr-FR)          0 (de-DE)          0 (es-ES)
      '        14894 (en-US)      14894 (fr-FR)      14894 (de-DE)      14894 (es-ES)
      '        32767 (en-US)      32767 (fr-FR)      32767 (de-DE)      32767 (es-ES)      