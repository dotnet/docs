' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module Example17
    Public Sub Main()
        TestForIsNullOrEmpty()
        Console.WriteLine("-----")
        TestForIsNullOrEmptyOrWhitespaceOnly()
    End Sub

    Private Sub TestForIsNullOrEmpty()
        Dim str As String = Nothing
        ' <Snippet1>
        If str Is Nothing OrElse str.Equals(String.Empty) Then
            ' </Snippet1>   

        Else

        End If
    End Sub

    Private Sub TestForIsNullOrEmptyOrWhitespaceOnly()
        Dim str As String = "   "
        ' <Snippet2>
        If str Is Nothing OrElse str.Equals(String.Empty) OrElse str.Trim().Equals(String.Empty) Then
            ' </Snippet2>   
            Console.WriteLine("Bad!")
        Else
            Console.WriteLine("Good!")
        End If
    End Sub
End Module

Public Class Temperature : Implements IFormattable
    Dim temp As Double

    Public Sub New(temp As Double)
        Me.temp = temp
    End Sub

    Public Overrides Function ToString() As String
        Return Me.ToString("G", CultureInfo.CurrentCulture)
    End Function

    Public Overloads Function ToString(fmt As String) As String
        Return Me.ToString(fmt, CultureInfo.CurrentCulture)
    End Function

    ' <Snippet3>
    Public Overloads Function ToString(fmt As String, provider As IFormatProvider) As String _
                   Implements IFormattable.ToString
        If String.IsNullOrEmpty(fmt) Then fmt = "G"
        If provider Is Nothing Then provider = CultureInfo.CurrentCulture

        Select Case fmt.ToUpperInvariant()
         ' Return degrees in Celsius.    
            Case "G", "C"
                Return temp.ToString("F2", provider) + "°C"
         ' Return degrees in Fahrenheit.
            Case "F"
                Return (temp * 9 / 5 + 32).ToString("F2", provider) + "°F"
         ' Return degrees in Kelvin.
            Case "K"
                Return (temp + 273.15).ToString()
            Case Else
                Throw New FormatException(
                  String.Format("The {0} format string is not supported.",
                                fmt))
        End Select
    End Function
    ' </Snippet3>
End Class
