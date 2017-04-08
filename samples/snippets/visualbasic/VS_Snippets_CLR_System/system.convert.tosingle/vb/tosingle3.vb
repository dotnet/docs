' Visual Basic .NET Document
Option Strict On

' <Snippet16>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim values() As String = { "123456789", "12345.6789", "12 345,6789", _
                                 "123,456.789", "123 456,789", "123,456,789.0123", _
                                 "123 456 789,0123", "1.235e12", "1.03221e-05", _
                                 Double.MaxValue.ToString() }
      Dim cultures() As CultureInfo = { New CultureInfo("en-US"), _
                                        New CultureInfo("fr-FR") } 

      For Each culture As CultureInfo In cultures
         Console.WriteLine("String -> Single Conversion Using the {0} Culture", _
                           culture.Name)
         For Each value As String In values
            Console.Write("{0,22}  ->  ", value)
            Try
               Console.WriteLine(Convert.ToSingle(value, culture))
            Catch e As FormatException
               Console.WriteLine("FormatException")
            CAtch e As OverflowException
               Console.WriteLine("Overflow")
            End Try   
         Next
         Console.WriteLine()
      Next                     
   End Sub
End Module
' The example displays the following output:
'    String -> Single Conversion Using the en-US Culture
'                 123456789  ->  1.234568E+08
'                12345.6789  ->  12345.68
'               12 345,6789  ->  FormatException
'               123,456.789  ->  123456.8
'               123 456,789  ->  FormatException
'          123,456,789.0123  ->  1.234568E+08
'          123 456 789,0123  ->  FormatException
'                  1.235e12  ->  1.235E+12
'               1.03221e-05  ->  1.03221E-05
'     1.79769313486232E+308  ->  Overflow
'    
'    String -> Single Conversion Using the fr-FR Culture
'                 123456789  ->  1.234568E+08
'                12345.6789  ->  FormatException
'               12 345,6789  ->  12345.68
'               123,456.789  ->  FormatException
'               123 456,789  ->  123456.8
'          123,456,789.0123  ->  FormatException
'          123 456 789,0123  ->  1.234568E+08
'                  1.235e12  ->  FormatException
'               1.03221e-05  ->  FormatException
'     1.79769313486232E+308  ->  FormatException
' </Snippet16>
