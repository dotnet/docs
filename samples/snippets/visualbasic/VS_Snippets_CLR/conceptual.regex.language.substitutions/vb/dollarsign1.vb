' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Globalization
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        ' Define array of decimal values.
        Dim values() As String = {"16.35", "19.72", "1234", "0.99"}
        ' Determine whether currency precedes (True) or follows (False) number.
        Dim precedes As Boolean = (NumberFormatInfo.CurrentInfo.CurrencyPositivePattern Mod 2 = 0)
        ' Get decimal separator.
        Dim cSeparator As String = NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
        ' Get currency symbol.
        Dim symbol As String = NumberFormatInfo.CurrentInfo.CurrencySymbol
        ' If symbol is a "$", add an extra "$".
        If symbol = "$" Then symbol = "$$"

        ' Define regular expression pattern and replacement string.
        Dim pattern As String = "\b(\d+)(" + cSeparator + "(\d+))?"
        Dim replacement As String = "$1$2"
        replacement = If(precedes, symbol + " " + replacement, replacement + " " + symbol)
        For Each value In values
            Console.WriteLine("{0} --> {1}", value, Regex.Replace(value, pattern, replacement))
        Next
    End Sub
End Module
' The example displays the following output:
'       16.35 --> $ 16.35
'       19.72 --> $ 19.72
'       1234 --> $ 1234
'       0.99 --> $ 0.99
' </Snippet8>
