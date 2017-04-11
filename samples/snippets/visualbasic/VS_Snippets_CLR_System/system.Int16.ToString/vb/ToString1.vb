' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain

   Public Sub Main()
      CallDefaultToString()
      Console.WriteLine("------")
      CallToStringWithProvider()
      Console.WriteLine("------")
      CallToStringWithSpecifiers()
      Console.WriteLine("------")
      CallToStringWithSpecifiersAndProviders()
   End Sub
   
   Private Sub CallDefaultToString()
      ' <Snippet1>   
      Dim numbers() As Short = {0, 14624, 13982, Short.MaxValue, _
                               Short.MinValue, -16667}
      For Each number As Short In numbers
         Console.WriteLine(number.ToString())
      Next        
      ' The example displays the following output to the console:
      '       0
      '       14624
      '       13982
      '       32767
      '       -32768
      '       -16667                             
      ' </Snippet1>   
   End Sub
   
   Private Sub CallToStringWithProvider()
      ' <Snippet2>
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
      ' </Snippet2>
   End Sub

   Private Sub CallToStringWithSpecifiers()
      ' <Snippet3>
      Dim values() As Int16 = {-23805, 32194}
      Dim formats() As String = {"C4", "D6", "e1", "E2", "F1", "G", "N1", _
                                 "P0", "X4", "000000.0000", "##000.0"}
      For Each format As String In formats
         Console.WriteLine("'{0,2}' format specifier: {1,17}   {2,17}", _ 
                           format, _
                           values(0).ToString(format), _
                           values(1).ToString(format))
      Next                                                               
      ' The example displays the following output to the console:
      '    'C4' format specifier:    ($23,805.0000)        $32,194.0000
      '    'D6' format specifier:           -023805              032194
      '    'e1' format specifier:         -2.4e+004            3.2e+004
      '    'E2' format specifier:        -2.38E+004           3.22E+004
      '    'F1' format specifier:          -23805.0             32194.0
      '    ' G' format specifier:            -23805               32194
      '    'N1' format specifier:         -23,805.0            32,194.0
      '    'P0' format specifier:      -2,380,500 %         3,219,400 %
      '    'X4' format specifier:              A303                7DC2
      '    '000000.0000' format specifier:      -023805.0000         032194.0000
      '    '##000.0' format specifier:          -23805.0             32194.0      
      ' </Snippet3>
   End Sub

   Private Sub CallToStringWithSpecifiersAndProviders()
      ' <Snippet4>
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
      ' </Snippet4>                                              
   End Sub
End Module

