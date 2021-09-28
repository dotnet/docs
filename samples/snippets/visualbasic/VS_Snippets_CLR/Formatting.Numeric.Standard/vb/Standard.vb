' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain

    Public Sub Main()
        Console.Clear()
        Console.WriteLine(CultureInfo.CurrentUICulture.Name)
        Console.WriteLine(CultureInfo.CurrentCulture.Name)
        Console.WriteLine()
        Console.WriteLine("Currency Format Specifier:")
        ShowCurrency()
        Console.WriteLine()
        Console.WriteLine("Decimal Format Specifier:")
        ShowDecimal()
        Console.WriteLine()
        Console.WriteLine("Exponentiation Format Specifier:")
        ShowExponentiation()
        Console.WriteLine()
        Console.WriteLine("Fixed Point Format Specifier:")
        ShowFixedPoint()
        Console.WriteLine()
        Console.WriteLine("'G' Format Specifier:")
        ShowGeneral()
        Console.WriteLine()
        Console.WriteLine("'N' Format Specifier:")
        ShowNumeric()
        Console.WriteLine()
        Console.WriteLine("Percent Format Specifier:")
        ShowPercent()
        Console.WriteLine()
        Console.WriteLine("Round-trip Format Specifier:")
        ShowRoundTrip()
        Console.WriteLine()
        Console.WriteLine("Hexadecimal Format Specifier:")
        ShowHex()
        Console.WriteLine()
        Console.WriteLine("Invalid Format Specifier")
        ShowInvalid()
    End Sub

    Private Sub ShowCurrency()
        ' <Snippet1>
        Dim value As Double = 12345.6789
        Console.WriteLine(value.ToString("C", CultureInfo.CurrentCulture))

        Console.WriteLine(value.ToString("C3", CultureInfo.CurrentCulture))

        Console.WriteLine(value.ToString("C3", _
                          CultureInfo.CreateSpecificCulture("da-DK")))
        ' The example displays the following output on a system whose
        ' current culture is English (United States):
        '       $12,345.68
        '       $12,345.679
        '       kr 12.345,679
        ' </Snippet1> 
    End Sub

    Private Sub ShowDecimal()
        ' <Snippet2>
        Dim value As Integer

        value = 12345
        Console.WriteLine(value.ToString("D"))
        ' Displays 12345   
        Console.WriteLine(value.ToString("D8"))
        ' Displays 00012345

        value = -12345
        Console.WriteLine(value.ToString("D"))
        ' Displays -12345
        Console.WriteLine(value.ToString("D8"))
        ' Displays -00012345
        ' </Snippet2>
    End Sub

    Private Sub ShowExponentiation()
        ' <Snippet3>
        Dim value As Double = 12345.6789
        Console.WriteLine(value.ToString("E", CultureInfo.InvariantCulture))
        ' Displays 1.234568E+004

        Console.WriteLine(value.ToString("E10", CultureInfo.InvariantCulture))
        ' Displays 1.2345678900E+004

        Console.WriteLine(value.ToString("e4", CultureInfo.InvariantCulture))
        ' Displays 1.2346e+004

        Console.WriteLine(value.ToString("E", _
                          CultureInfo.CreateSpecificCulture("fr-FR")))
        ' Displays 1,234568E+004
        ' </Snippet3>
    End Sub

    Private Sub ShowFixedPoint()
        ' <Snippet4>
        Dim integerNumber As Integer
        integerNumber = 17843
        Console.WriteLine(integerNumber.ToString("F", CultureInfo.InvariantCulture))
        ' Displays 17843.00

        integerNumber = -29541
        Console.WriteLine(integerNumber.ToString("F3", CultureInfo.InvariantCulture))
        ' Displays -29541.000

        Dim doubleNumber As Double
        doubleNumber = 18934.1879
        Console.WriteLine(doubleNumber.ToString("F", CultureInfo.InvariantCulture))
        ' Displays 18934.19

        Console.WriteLine(doubleNumber.ToString("F0", CultureInfo.InvariantCulture))
        ' Displays 18934

        doubleNumber = -1898300.1987
        Console.WriteLine(doubleNumber.ToString("F1", CultureInfo.InvariantCulture))
        ' Displays -1898300.2

        Console.WriteLine(doubleNumber.ToString("F3", _
                          CultureInfo.CreateSpecificCulture("es-ES")))
        ' Displays -1898300,199                        
        ' </Snippet4>
    End Sub

    Private Sub ShowGeneral()
        ' <Snippet5>
        Dim number As Double

        number = 12345.6789
        Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture))
        ' Displays  12345.6789
        Console.WriteLine(number.ToString("G", _
                          CultureInfo.CreateSpecificCulture("fr-FR")))
        ' Displays 12345,6789

        Console.WriteLine(number.ToString("G7", CultureInfo.InvariantCulture))
        ' Displays 12345.68 

        number = .0000023
        Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture))
        ' Displays 2.3E-06       
        Console.WriteLine(number.ToString("G", _
                          CultureInfo.CreateSpecificCulture("fr-FR")))
        ' Displays 2,3E-06

        number = .0023
        Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture))
        ' Displays 0.0023

        number = 1234
        Console.WriteLine(number.ToString("G2", CultureInfo.InvariantCulture))
        ' Displays 1.2E+03

        number = Math.Pi
        Console.WriteLine(number.ToString("G5", CultureInfo.InvariantCulture))
        ' Displays 3.1416    
        ' </Snippet5>
    End Sub

    Private Sub ShowNumeric()
        ' <Snippet6>
        Dim dblValue As Double = -12445.6789
        Console.WriteLine(dblValue.ToString("N", CultureInfo.InvariantCulture))
        ' Displays -12,445.68
        Console.WriteLine(dblValue.ToString("N1", _
                          CultureInfo.CreateSpecificCulture("sv-SE")))
        ' Displays -12 445,7

        Dim intValue As Integer = 123456789
        Console.WriteLine(intValue.ToString("N1", CultureInfo.InvariantCulture))
        ' Displays 123,456,789.0 
        ' </Snippet6>
    End Sub

    Private Sub ShowPercent()
        ' <Snippet7>
        Dim number As Double = .2468013
        Console.WriteLine(number.ToString("P", CultureInfo.InvariantCulture))
        ' Displays 24.68 %
        Console.WriteLine(number.ToString("P", _
                          CultureInfo.CreateSpecificCulture("hr-HR")))
        ' Displays 24,68%     
        Console.WriteLine(number.ToString("P1", CultureInfo.InvariantCulture))
        ' Displays 24.7 %
        ' </Snippet7>
    End Sub

    Private Sub ShowRoundTrip()
        ' <Snippet8>
        Dim value As Double

        value = Math.Pi
        Console.WriteLine(value.ToString("r"))
        ' Displays 3.1415926535897931
        Console.WriteLine(value.ToString("r", _
                          CultureInfo.CreateSpecificCulture("fr-FR")))
        ' Displays 3,1415926535897931
        value = 1.623e-21
        Console.WriteLine(value.ToString("r"))
        ' Displays 1.623E-21
        ' </Snippet8>
    End Sub

    Private Sub ShowHex()
        ' <Snippet9>
        Dim value As Integer

        value = &h2045e
        Console.WriteLine(value.ToString("x"))
        ' Displays 2045e
        Console.WriteLine(value.ToString("X"))
        ' Displays 2045E
        Console.WriteLine(value.ToString("X8"))
        ' Displays 0002045E

        value = 123456789
        Console.WriteLine(value.ToString("X"))
        ' Displays 75BCD15
        Console.WriteLine(value.ToString("X2"))
        ' Displays 75BCD15
        ' </Snippet9>
    End Sub

    Private Sub ShowInvalid()
        Dim value As Integer = 12
        Dim specifier AS String = "Z"
        Try
            Console.WriteLine(value.ToString("Z"))
        Catch e As Exception
            Console.WriteLine("{0}: {1} is not a valid format specifier.", _
                              e.GetType().Name, specifier)
        End Try
    End Sub
End Module



