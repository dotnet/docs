﻿' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Globalization

Public Class Temperature : Implements IFormattable
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
            Return Me.m_Temp + 273.15d
        End Get
    End Property

    Public ReadOnly Property Fahrenheit() As Decimal
        Get
            Return Math.Round(CDec(Me.m_Temp * 9 / 5 + 32), 2)
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.ToString("G", Nothing)
    End Function

    Public Overloads Function ToString(format As String) As String
        Return Me.ToString(format, Nothing)
    End Function

    Public Overloads Function ToString(format As String, provider As IFormatProvider) As String _
       Implements IFormattable.ToString

        ' Handle null or empty arguments.
        If String.IsNullOrEmpty(format) Then format = "G"
        ' Remove any white space and convert to uppercase.
        format = format.Trim().ToUpperInvariant()

        If provider Is Nothing Then provider = NumberFormatInfo.CurrentInfo

        Select Case format
         ' Convert temperature to Fahrenheit and return string.
            Case "F"
                Return Me.Fahrenheit.ToString("N2", provider) & "°F"
         ' Convert temperature to Kelvin and return string.
            Case "K"
                Return Me.Kelvin.ToString("N2", provider) & "K"
         ' Return temperature in Celsius.
            Case "C", "G"
                Return Me.Celsius.ToString("N2", provider) & "°C"
            Case Else
                Throw New FormatException(String.Format("The '{0}' format string is not supported.", format))
        End Select
    End Function
End Class
' </Snippet12>

' <Snippet13>
Public Module Example
    Public Sub Main()
        Dim temp As New Temperature(22d)
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US")
        Console.WriteLine(Convert.ToString(temp1, New CultureInfo("ja-JP")))
        Console.WriteLine("Temperature: {0:K}", temp)
        Console.WriteLine("Temperature: {0:F}", temp)
        Console.WriteLine(String.Format(New CultureInfo("fr-FR"), "Temperature: {0:F}", temp))
    End Sub
End Module
' The example displays the following output:
'       22.00°C
'       Temperature: 295.15K
'       Temperature: 71.60°F
'       Temperature: 71,60°F
' </Snippet13>
