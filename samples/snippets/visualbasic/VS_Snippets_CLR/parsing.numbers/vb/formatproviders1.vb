' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
    Public Sub Main()
        Dim values() As String = {"1,304.16", "$1,456.78", "1,094", "152",
                                   "123,45 €", "1 304,16", "Ae9f"}
        Dim number As Double
        Dim culture As CultureInfo = Nothing

        For Each value As String In values
            Try
                culture = CultureInfo.CreateSpecificCulture("en-US")
                number = Double.Parse(value, culture)
                Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number)
            Catch e As FormatException
                Console.WriteLine("{0}: Unable to parse '{1}'.",
                                  culture.Name, value)
                culture = CultureInfo.CreateSpecificCulture("fr-FR")
                Try
                    number = Double.Parse(value, culture)
                    Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number)
                Catch ex As FormatException
                    Console.WriteLine("{0}: Unable to parse '{1}'.",
                                      culture.Name, value)
                End Try
            End Try
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output:
'    en-US: 1,304.16 --> 1304.16
'    
'    en-US: Unable to parse '$1,456.78'.
'    fr-FR: Unable to parse '$1,456.78'.
'    
'    en-US: 1,094 --> 1094
'    
'    en-US: 152 --> 152
'    
'    en-US: Unable to parse '123,45 €'.
'    fr-FR: Unable to parse '123,45 €'.
'    
'    en-US: Unable to parse '1 304,16'.
'    fr-FR: 1 304,16 --> 1304.16
'    
'    en-US: Unable to parse 'Ae9f'.
'    fr-FR: Unable to parse 'Ae9f'.
' </Snippet1>
