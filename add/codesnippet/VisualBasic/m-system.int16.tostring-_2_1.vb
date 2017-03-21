      Dim value As Int16 = 14603
      Dim formats() As String = {"C", "D6", "e1", "E2", "F1", "G", "N1", _
                                 "P0", "X4", "000000.0000", "##000.0"}
      Dim providers() As CultureInfo = {New CultureInfo("en-us"), _
                                        New CultureInfo("fr-fr"), _
                                        New CultureInfo("de-de"), _
                                        New CultureInfo("es-es")}
      ' Display header.
      Console.WriteLine("{0,24}{1,14}{2,14}{3,14}", providers(0), providers(1), _
                        providers(2), providers(3))
      Console.WriteLine()                        
      ' Display a value using each format string.
      For Each format As String In formats
         ' Display the value for each provider on the same line.
         Console.Write("{0,-12}", format)
         For Each provider As CultureInfo In providers
            Console.Write("{0,12}  ", _
                          value.ToString(format, provider)) 
         Next
         Console.WriteLine()
      Next
      ' The example displays the following output to the console:
      '                       en-US         fr-FR         de-DE         es-ES
      '    
      '    C             $14,603.00   14 603,00 €   14.603,00 €   14.603,00 €  
      '    D6                014603        014603        014603        014603  
      '    e1              1.5e+004      1,5e+004      1,5e+004      1,5e+004  
      '    E2             1.46E+004     1,46E+004     1,46E+004     1,46E+004  
      '    F1               14603.0       14603,0       14603,0       14603,0  
      '    G                  14603         14603         14603         14603  
      '    N1              14,603.0      14 603,0      14.603,0      14.603,0  
      '    P0           1,460,300 %   1 460 300 %    1.460.300%   1.460.300 %  
      '    X4                  390B          390B          390B          390B  
      '    000000.0000  014603.0000   014603,0000   014603,0000   014603,0000  
      '    ##000.0          14603.0       14603,0       14603,0       14603,0  