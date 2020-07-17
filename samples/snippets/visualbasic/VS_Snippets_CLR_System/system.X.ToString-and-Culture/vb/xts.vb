' This older code snippet replaced by a new one
' This code example demonstrates the ToString(String) and 
' ToString(String, IFormatProvider) methods for integral and
' floating-point numbers, in conjunction with the standard 
' numeric format specifiers.
' This code example uses the System.Int32 integral type and 
' the System.Double floating-point type, but would yield 
' similar results for any of the numeric types. The integral 
' numeric types are System.Byte, SByte, Int16, Int32, Int64, 
' UInt16, UInt32, and UInt64. The floating-point numeric types 
' are Decimal, Single, and Double.

' Imports System.Globalization
' Imports System.Threading

' 
' Class Sample
'     Public Shared Sub Main() 
'         ' Format a negative integer or floating-point number in various ways.
'         Dim integralVal As Integer = -12345
'         Dim floatingVal As Double  = -1234.567
'         
'         Dim msgCurrency As String =    "(C) Currency: . . . . . . "
'         Dim msgDecimal As String =     "(D) Decimal:. . . . . . . "
'         Dim msgScientific As String =  "(E) Scientific: . . . . . "
'         Dim msgFixedPoint As String =  "(F) Fixed point:. . . . . "
'         Dim msgGeneral As String =     "(G) General (default):. . "
'         Dim msgNumber As String =      "(N) Number: . . . . . . . "
'         Dim msgPercent As String =     "(P) Percent:. . . . . . . "
'         Dim msgRoundTrip As String =   "(R) Round-trip: . . . . . "
'         Dim msgHexadecimal As String = "(X) Hexadecimal:. . . . . "
'         
'         Dim msg1 As String = "Use ToString(String) and the current thread culture." + vbLf
'         Dim msg2 As String = "Use ToString(String, IFormatProvider) and a specified culture." + vbLf
'         Dim msgCulture As String = "Culture:"
'         Dim msgIntegralVal As String = "Integral value:"
'         Dim msgFloatingVal As String = "Floating-point value:"
'         
'         Dim ci As CultureInfo
'         '
'         Console.Clear()
'         Console.WriteLine("Standard Numeric Format Specifiers:" & vbLf)
'         ' Display the values.
'         Console.WriteLine(msg1)
'         
'         ' Display the thread current culture, which is used to format the values.
'         ci = Thread.CurrentThread.CurrentCulture
'         Console.WriteLine("{0,-26}{1}", msgCulture, ci.DisplayName)
'         
'         ' Display the integral and floating-point values.
'         Console.WriteLine("{0,-26}{1}", msgIntegralVal, integralVal)
'         Console.WriteLine("{0,-26}{1}", msgFloatingVal, floatingVal)
'         Console.WriteLine()
'         
'         ' Use the format specifiers that are only for integral types.
'         Console.WriteLine("Format specifiers only for integral types:")
'         Console.WriteLine(msgDecimal     & integralVal.ToString("D"))
'         Console.WriteLine(msgHexadecimal & integralVal.ToString("X"))
'         Console.WriteLine()
'         
'         ' Use the format specifier that is only for the Single and Double 
'         ' floating-point types.
'         Console.WriteLine("Format specifier only for the Single and Double types:")
'         Console.WriteLine(msgRoundTrip   & floatingVal.ToString("R"))
'         Console.WriteLine()
'         
'         ' Use the format specifiers that are for integral or floating-point types.
'         Console.WriteLine("Format specifiers for integral or floating-point types:")
'         Console.WriteLine(msgCurrency    & floatingVal.ToString("C"))
'         Console.WriteLine(msgScientific  & floatingVal.ToString("E"))
'         Console.WriteLine(msgFixedPoint  & floatingVal.ToString("F"))
'         Console.WriteLine(msgGeneral     & floatingVal.ToString("G"))
'         Console.WriteLine(msgNumber      & floatingVal.ToString("N"))
'         Console.WriteLine(msgPercent     & floatingVal.ToString("P"))
'         Console.WriteLine()
'         
'         ' Display the same values using a CultureInfo object. The CultureInfo class 
'         ' implements IFormatProvider.
'         Console.WriteLine(msg2)
'         
'         ' Display the culture used to format the values. 
'         ' Create a European culture and change its currency symbol to "euro" because 
'         ' this particular code example uses a thread current UI culture that cannot 
'         ' display the euro symbol (€).
'         ci = New CultureInfo("de-DE")
'         ci.NumberFormat.CurrencySymbol = "euro"
'         Console.WriteLine("{0,-26}{1}", msgCulture, ci.DisplayName)
'         
'         ' Display the integral and floating-point values.
'         Console.WriteLine("{0,-26}{1}", msgIntegralVal, integralVal)
'         Console.WriteLine("{0,-26}{1}", msgFloatingVal, floatingVal)
'         Console.WriteLine()
'         
'         ' Use the format specifiers that are only for integral types.
'         Console.WriteLine("Format specifiers only for integral types:")
'         Console.WriteLine(msgDecimal     & integralVal.ToString("D", ci))
'         Console.WriteLine(msgHexadecimal & integralVal.ToString("X", ci))
'         Console.WriteLine()
'         
'         ' Use the format specifier that is only for the Single and Double 
'         ' floating-point types.
'         Console.WriteLine("Format specifier only for the Single and Double types:")
'         Console.WriteLine(msgRoundTrip   & floatingVal.ToString("R", ci))
'         Console.WriteLine()
'         
'         ' Use the format specifiers that are for integral or floating-point types.
'         Console.WriteLine("Format specifiers for integral or floating-point types:")
'         Console.WriteLine(msgCurrency    & floatingVal.ToString("C", ci))
'         Console.WriteLine(msgScientific  & floatingVal.ToString("E", ci))
'         Console.WriteLine(msgFixedPoint  & floatingVal.ToString("F", ci))
'         Console.WriteLine(msgGeneral     & floatingVal.ToString("G", ci))
'         Console.WriteLine(msgNumber      & floatingVal.ToString("N", ci))
'         Console.WriteLine(msgPercent     & floatingVal.ToString("P", ci))
'         Console.WriteLine()
'     End Sub
' End Class
'
'This code example produces the following results:
'
'Standard Numeric Format Specifiers:
'
'Use ToString(String) and the current thread culture.
'
'Culture:                  English (United States)
'Integral value:           -12345
'Floating-point value:     -1234.567
'
'Format specifiers only for integral types:
'(D) Decimal:. . . . . . . -12345
'(X) Hexadecimal:. . . . . FFFFCFC7
'
'Format specifier only for the Single and Double types:
'(R) Round-trip: . . . . . -1234.567
'
'Format specifiers for integral or floating-point types:
'(C) Currency: . . . . . . ($1,234.57)
'(E) Scientific: . . . . . -1.234567E+003
'(F) Fixed point:. . . . . -1234.57
'(G) General (default):. . -1234.567
'(N) Number: . . . . . . . -1,234.57
'(P) Percent:. . . . . . . -123,456.70 %
'
'Use ToString(String, IFormatProvider) and a specified culture.
'
'Culture:                  German (Germany)
'Integral value:           -12345
'Floating-point value:     -1234.567
'
'Format specifiers only for integral types:
'(D) Decimal:. . . . . . . -12345
'(X) Hexadecimal:. . . . . FFFFCFC7
'
'Format specifier only for the Single and Double types:
'(R) Round-trip: . . . . . -1234,567
'
'Format specifiers for integral or floating-point types:
'(C) Currency: . . . . . . -1.234,57 euro
'(E) Scientific: . . . . . -1,234567E+003
'(F) Fixed point:. . . . . -1234,57
'(G) General (default):. . -1234,567
'(N) Number: . . . . . . . -1.234,57
'(P) Percent:. . . . . . . -123.456,70%
'
' END OF OLD CODE SNIPPET

' Visual Basic .NET Document
' <Snippet1>
Option Strict On

Imports System.Globalization
Imports System.Threading

Module NumericFormats
    Public Sub Main()
        ' Display string representations of numbers for en-us culture
        Dim ci As New CultureInfo("en-us")

        ' Output floating point values
        Dim floating As Double = 10761.937554
        Console.WriteLine("C: {0}", _
                floating.ToString("C", ci))           ' Displays "C: $10,761.94"
        Console.WriteLine("E: {0}", _
                floating.ToString("E03", ci))         ' Displays "E: 1.076E+004"
        Console.WriteLine("F: {0}", _
                floating.ToString("F04", ci))         ' Displays "F: 10761.9376"         
        Console.WriteLine("G: {0}", _
                floating.ToString("G", ci))           ' Displays "G: 10761.937554"
        Console.WriteLine("N: {0}", _
                floating.ToString("N03", ci))         ' Displays "N: 10,761.938"
        Console.WriteLine("P: {0}", _
                (floating / 10000).ToString("P02", ci)) ' Displays "P: 107.62 %"
        Console.WriteLine("R: {0}", _
                floating.ToString("R", ci))           ' Displays "R: 10761.937554"            
        Console.WriteLine()

        ' Output integral values
        Dim integral As Integer = 8395
        Console.WriteLine("C: {0}", _
                integral.ToString("C", ci))           ' Displays "C: $8,395.00"
        Console.WriteLine("D: {0}", _
                integral.ToString("D6"))              ' Displays "D: 008395" 
        Console.WriteLine("E: {0}", _
                integral.ToString("E03", ci))         ' Displays "E: 8.395E+003"
        Console.WriteLine("F: {0}", _
                integral.ToString("F01", ci))         ' Displays "F: 8395.0"    
        Console.WriteLine("G: {0}", _
                integral.ToString("G", ci))           ' Displays "G: 8395"
        Console.WriteLine("N: {0}", _
                integral.ToString("N01", ci))         ' Displays "N: 8,395.0"
        Console.WriteLine("P: {0}", _
                (integral / 10000).ToString("P02", ci)) ' Displays "P: 83.95 %"
        Console.WriteLine("X: 0x{0}", _
                integral.ToString("X", ci))           ' Displays "X: 0x20CB"
        Console.WriteLine()
    End Sub
End Module
' </Snippet1>

