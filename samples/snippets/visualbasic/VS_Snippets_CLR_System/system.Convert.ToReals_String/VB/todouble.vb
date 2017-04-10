' <Snippet2>
Imports System.Globalization

Module Example
    Sub Main()
        ' Create a NumberFormatInfo object and set some of its properties.
        Dim provider As New NumberFormatInfo() 
        provider.NumberDecimalSeparator = ","
        provider.NumberGroupSeparator = "."
        provider.NumberGroupSizes = { 3 }

        ' Define an array of numeric strings to convert.
        Dim values() As String = { "123456789", "12345.6789", "12345,6789", 
                                   "123,456.789", "123.456,789", 
                                   "123,456,789.0123", "123.456.789,0123" }

        Console.WriteLine("Default Culture: {0}", 
                          CultureInfo.CurrentCulture.Name)
        Console.WriteLine()                          
        Console.WriteLine("{0,-22} {1,-20} {2,-20}", "String to Convert",
                          "Default/Exception", "Provider/Exception")
        Console.WriteLine()
        ' Convert each string to a Double with and without the provider.
        For Each value In values
           Console.Write("{0,-22} ", value)
           Try
              Console.Write("{0,-20} ", Convert.ToDouble(value))
           Catch e As FormatException
              Console.Write("{0,-20} ", e.GetType().Name)
           End Try
           Try
              Console.WriteLine("{0,-20} ", Convert.ToDouble(value, provider))
           Catch e As FormatException
              Console.WriteLine("{0,-20} ", e.GetType().Name)
           End Try
        Next
    End Sub 
End Module 
' The example displays the following output:
'       Default Culture: en-US
'       
'       String to Convert      Default/Exception    Provider/Exception
'       
'       123456789              123456789            123456789
'       12345.6789             12345.6789           123456789
'       12345,6789             123456789            12345.6789
'       123,456.789            123456.789           FormatException
'       123.456,789            FormatException      123456.789
'       123,456,789.0123       123456789.0123       FormatException
'       123.456.789,0123       FormatException      123456789.0123
'</Snippet2>