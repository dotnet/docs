' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Public Class ComplexFormatter
    Implements IFormatProvider, ICustomFormatter

    Public Function GetFormat(formatType As Type) As Object _
                    Implements IFormatProvider.GetFormat
        If formatType Is GetType(ICustomFormatter) Then
            Return Me
        Else
            Return Nothing
        End If
    End Function

    Public Function Format(fmt As String, arg As Object,
                           provider As IFormatProvider) As String _
                    Implements ICustomFormatter.Format
        If TypeOf arg Is Complex Then
            Dim c1 As Complex = DirectCast(arg, Complex)
            ' Check if the format string has a precision specifier.
            Dim precision As Integer
            Dim fmtString As String = String.Empty
            If fmt.Length > 1 Then
                Try
                    precision = Integer.Parse(fmt.Substring(1))
                Catch e As FormatException
                    precision = 0
                End Try
                fmtString = "N" + precision.ToString()
            End If
            ' Determine the sign to display.
            Dim sign As Char = If(c1.Imaginary < 0.0, "-"c, "+"c)
            ' Display the determined sign and the absolute value of the imaginary part.
            If fmt.Substring(0, 1).Equals("I", StringComparison.OrdinalIgnoreCase) Then
                Return c1.Real.ToString(fmtString) + " " + sign + " " + Math.Abs(c1.Imaginary).ToString(fmtString) + "i"
            ElseIf fmt.Substring(0, 1).Equals("J", StringComparison.OrdinalIgnoreCase) Then
                Return c1.Real.ToString(fmtString) + " " + sign + " " + Math.Abs(c1.Imaginary).ToString(fmtString) + "j"
            Else
                Return c1.ToString(fmt, provider)
            End If
        Else
            If TypeOf arg Is IFormattable Then
                Return DirectCast(arg, IFormattable).ToString(fmt, provider)
            ElseIf arg IsNot Nothing Then
                Return arg.ToString()
            Else
                Return String.Empty
            End If
        End If
    End Function
End Class
' </Snippet1>

' <Snippet4>
Module Example2
    Public Sub Run()
        Dim c1 As New Complex(12.1, 15.4)
        Console.WriteLine($"Formatting with ToString():       {c1}")
        Console.WriteLine($"Formatting with ToString(format): {c1:N2}")
        Console.WriteLine($"Custom formatting with I0:        " +
                          $"{String.Format(New ComplexFormatter(), "{0:I0}", c1)}")
        Console.WriteLine($"Custom formatting with J3:        " +
                          $"{String.Format(New ComplexFormatter(), "{0:J3}", c1)}")
    End Sub
End Module

' The example displays the following output:
'    Formatting with ToString():       <12.1; 15.4>
'    Formatting with ToString(format): <12.10; 15.40>
'    Custom formatting with I0:        12 + 15i
'    Custom formatting with J3:        12.100 + 15.400j
' </Snippet4>
