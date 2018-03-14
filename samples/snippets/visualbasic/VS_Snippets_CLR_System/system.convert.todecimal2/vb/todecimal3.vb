' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim values() As String = { "123456789", "12345.6789", "12 345,6789", _
                                 "123,456.789", "123 456,789", "123,456,789.0123", _
                                 "123 456 789,0123" }
      Dim cultures() As CultureInfo = { New CultureInfo("en-US"), _
                                        New CultureInfo("fr-FR") } 

      For Each culture As CultureInfo In cultures
         Console.WriteLine("String -> Decimal Conversion Using the {0} Culture", _
                           culture.Name)
         For Each value As String In values
            Console.Write("{0,20}  ->  ", value)
            Try
               Console.WriteLine(Convert.ToDecimal(value, culture))
            Catch e As FormatException
               Console.WriteLine("FormatException")
            End Try   
         Next
         Console.WriteLine()
      Next                     
   End Sub
End Module
' The example displays the following output:
'       String -> Decimal Conversion Using the en-US Culture
'                  123456789  ->  123456789
'                 12345.6789  ->  12345.6789
'                12 345,6789  ->  FormatException
'                123,456.789  ->  123456.789
'                123 456,789  ->  FormatException
'           123,456,789.0123  ->  123456789.0123
'           123 456 789,0123  ->  FormatException
'       
'       String -> Decimal Conversion Using the fr-FR Culture
'                  123456789  ->  123456789
'                 12345.6789  ->  FormatException
'                12 345,6789  ->  12345.6789
'                123,456.789  ->  FormatException
'                123 456,789  ->  123456.789
'           123,456,789.0123  ->  FormatException
'           123 456 789,0123  ->  123456789.0123
' </Snippet12>
