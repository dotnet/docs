' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
   Public Sub Main()
      CallToString()
      Console.WriteLIne()
      SpecifyFormatProvider()
      Console.WRiteLine()
      SpecifyFormatString()
      Console.WriteLine()
      FormatWithProviders()
   End Sub
   
   Private Sub CallToString()
      ' <Snippet2>
      Dim bytes() As Byte = {0, 1, 14, 168, 255}
      For Each byteValue As Byte In Bytes
         Console.WriteLine(byteValue)
      Next   
      ' The example displays the following output to the console if the current
      ' culture is en-US:
      '       0
      '       1
      '       14
      '       168
      '       255      
      ' </Snippet2>
   End Sub
   
   Private Sub SpecifyFormatProvider()
      ' <Snippet3>
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
      ' </Snippet3>
   End Sub
   
   Private Sub SpecifyFormatString()
      ' <Snippet4>
      Dim formats() As String = {"C3", "D4", "e1", "E2", "F1", "G", _
                                 "N1", "P0", "X4", "0000.0000"}
      Dim number As Byte = 240
      For Each format As String In formats
         Console.WriteLine("'{0}' format specifier: {1}", _
                           format, number.ToString(format))
      Next  
      ' The example displays the following output to the console if the
      ' current culture is en-us:
      '       'C3' format specifier: $240.000
      '       'D4' format specifier: 0240
      '       'e1' format specifier: 2.4e+002
      '       'E2' format specifier: 2.40E+002
      '       'F1' format specifier: 240.0       
      '       'G' format specifier: 240
      '       'N1' format specifier: 240.0
      '       'P0' format specifier: 24,000 %
      '       'X4' format specifier: 00F0
      '       '0000.0000' format specifier: 0240.0000           
      ' </Snippet4>                   
   End Sub
   
   Private Sub FormatWithProviders()
      ' <Snippet5>
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
      ' </Snippet5>
   End Sub
End Module

