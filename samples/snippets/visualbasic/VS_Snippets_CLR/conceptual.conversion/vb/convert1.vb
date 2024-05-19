Option Strict On

Public Module ConvertExample
    Public Sub Main()
        PerformConversions()
        Console.WriteLine("-----")
        LosePrecision()
    End Sub

    Private Sub PerformConversions()
        ' <Snippet8> 
        ' Convert an Int32 value to a Decimal (a widening conversion).
        Dim integralValue As Integer = 12534
        Dim decimalValue As Decimal = Convert.ToDecimal(integralValue)
        Console.WriteLine("Converted the {0} value {1} to the {2} value {3:N2}.",
                          integralValue.GetType().Name,
                          integralValue,
                          decimalValue.GetType().Name,
                          decimalValue)

        ' Convert a Byte value to an Int32 value (a widening conversion).
        Dim byteValue As Byte = Byte.MaxValue
        Dim integralValue2 As Integer = Convert.ToInt32(byteValue)
        Console.WriteLine("Converted the {0} value {1} to " +
                                          "the {2} value {3:G}.",
                                          byteValue.GetType().Name,
                                          byteValue,
                                          integralValue2.GetType().Name,
                                          integralValue2)

        ' Convert a Double value to an Int32 value (a narrowing conversion).
        Dim doubleValue As Double = 16.32513e12
        Try
            Dim longValue As Long = Convert.ToInt64(doubleValue)
            Console.WriteLine("Converted the {0} value {1:E} to " +
                                              "the {2} value {3:N0}.",
                                              doubleValue.GetType().Name,
                                              doubleValue,
                                              longValue.GetType().Name,
                                              longValue)
        Catch e As OverflowException
            Console.WriteLine("Unable to convert the {0:E} value {1}.",
                                              doubleValue.GetType().Name, doubleValue)
        End Try

        ' Convert a signed byte to a byte (a narrowing conversion).     
        Dim sbyteValue As SByte = -16
        Try
            Dim byteValue2 As Byte = Convert.ToByte(sbyteValue)
            Console.WriteLine("Converted the {0} value {1} to " +
                                              "the {2} value {3:G}.",
                                              sbyteValue.GetType().Name,
                                              sbyteValue,
                                              byteValue2.GetType().Name,
                                              byteValue2)
        Catch e As OverflowException
            Console.WriteLine("Unable to convert the {0} value {1}.",
                                              sbyteValue.GetType().Name, sbyteValue)
        End Try
        ' The example displays the following output:
        '       Converted the Int32 value 12534 to the Decimal value 12,534.00.
        '       Converted the Byte value 255 to the Int32 value 255.
        '       Converted the Double value 1.632513E+013 to the Int64 value 16,325,130,000,000.
        '       Unable to convert the SByte value -16.
        ' </Snippet8>
    End Sub

    Private Sub LosePrecision()
        ' <Snippet9>
        Dim doubleValue As Double

        ' Convert a Double to a Decimal.
        Dim decimalValue As Decimal = 13956810.96702888123451471211d
        doubleValue = Convert.ToDouble(decimalValue)
        Console.WriteLine("{0} converted to {1}.", decimalValue, doubleValue)

        doubleValue = 42.72
        Try
            Dim integerValue As Integer = Convert.ToInt32(doubleValue)
            Console.WriteLine("{0} converted to {1}.",
                                              doubleValue, integerValue)
        Catch e As OverflowException
            Console.WriteLine("Unable to convert {0} to an integer.",
                                              doubleValue)
        End Try
        ' The example displays the following output:
        '       13956810.96702888123451471211 converted to 13956810.9670289.
        '       42.72 converted to 43.
        ' </Snippet9>
    End Sub
End Module
