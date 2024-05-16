Option Strict On

Namespace HotAndCold

    ' <Snippet7>
    Public Class Temperature
        Private m_Temp As Decimal

        Public Sub New(temperature As Decimal)
            Me.m_Temp = temperature
        End Sub

        Public ReadOnly Property Celsius() As Decimal
            Get
                Return Me.m_Temp
            End Get
        End Property

        Public ReadOnly Property Kelvin() As Decimal
            Get
                Return Me.m_Temp + 273.15D
            End Get
        End Property

        Public ReadOnly Property Fahrenheit() As Decimal
            Get
                Return Math.Round(CDec(Me.m_Temp * 9 / 5 + 32), 2)
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Me.ToString("C")
        End Function

        Public Overloads Function ToString(format As String) As String
            ' Handle null or empty string.
            If String.IsNullOrEmpty(format) Then format = "C"
            ' Remove spaces and convert to uppercase.
            format = format.Trim().ToUpperInvariant()

            Select Case format
                Case "F"
                    ' Convert temperature to Fahrenheit and return string.
                    Return Me.Fahrenheit.ToString("N2") & " °F"
                Case "K"
                    ' Convert temperature to Kelvin and return string.
                    Return Me.Kelvin.ToString("N2") & " K"
                Case "C", "G"
                    ' Return temperature in Celsius.
                    Return Me.Celsius.ToString("N2") & " °C"
                Case Else
                    Throw New FormatException(String.Format("The '{0}' format string is not supported.", format))
            End Select
        End Function
    End Class

    Public Module Example1
        Public Sub Main1()
            Dim temp1 As New Temperature(0D)
            Console.WriteLine(temp1.ToString())
            Console.WriteLine(temp1.ToString("G"))
            Console.WriteLine(temp1.ToString("C"))
            Console.WriteLine(temp1.ToString("F"))
            Console.WriteLine(temp1.ToString("K"))

            Dim temp2 As New Temperature(-40D)
            Console.WriteLine(temp2.ToString())
            Console.WriteLine(temp2.ToString("G"))
            Console.WriteLine(temp2.ToString("C"))
            Console.WriteLine(temp2.ToString("F"))
            Console.WriteLine(temp2.ToString("K"))

            Dim temp3 As New Temperature(16D)
            Console.WriteLine(temp3.ToString())
            Console.WriteLine(temp3.ToString("G"))
            Console.WriteLine(temp3.ToString("C"))
            Console.WriteLine(temp3.ToString("F"))
            Console.WriteLine(temp3.ToString("K"))

            Console.WriteLine(String.Format("The temperature is now {0:F}.", temp3))
        End Sub
    End Module
    ' The example displays the following output:
    '       0.00 °C
    '       0.00 °C
    '       0.00 °C
    '       32.00 °F
    '       273.15 K
    '       -40.00 °C
    '       -40.00 °C
    '       -40.00 °C
    '       -40.00 °F
    '       233.15 K
    '       16.00 °C
    '       16.00 °C
    '       16.00 °C
    '       60.80 °F
    '       289.15 K
    '       The temperature is now 16.00 °C.
    ' </Snippet7>

End Namespace
