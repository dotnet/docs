Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Module Example
    Public Sub Main()
        ' Define text to be parsed.
        Dim input As String = "Office expenses on 2/13/2008:" + vbCrLf + _
                              "Paper (500 sheets)                      $3.95" + vbCrLf + _
                              "Pencils (box of 10)                     $1.00" + vbCrLf + _
                              "Pens (box of 10)                        $4.49" + vbCrLf + _
                              "Erasers                                 $2.19" + vbCrLf + _
                              "Ink jet printer                        $69.95" + vbCrLf + vbCrLf + _
                              "Total Expenses                        $ 81.58" + vbCrLf
        ' Get current culture's NumberFormatInfo object.
        Dim nfi As NumberFormatInfo = CultureInfo.CurrentCulture.NumberFormat
        ' Assign needed property values to variables.
        Dim currencySymbol As String = nfi.CurrencySymbol
        Dim symbolPrecedesIfPositive As Boolean = CBool(nfi.CurrencyPositivePattern Mod 2 = 0)
        Dim groupSeparator As String = nfi.CurrencyGroupSeparator
        Dim decimalSeparator As String = nfi.CurrencyDecimalSeparator

        ' Form regular expression pattern.
        Dim pattern As String = Regex.Escape(CStr(IIf(symbolPrecedesIfPositive, currencySymbol, ""))) + _
                                "\s*[-+]?" + "([0-9]{0,3}(" + groupSeparator + "[0-9]{3})*(" + _
                                Regex.Escape(decimalSeparator) + "[0-9]+)?)" + _
                                CStr(IIf(Not symbolPrecedesIfPositive, currencySymbol, ""))
        Console.WriteLine("The regular expression pattern is: ")
        Console.WriteLine("   " + pattern)

        ' Get text that matches regular expression pattern.
        Dim matches As MatchCollection = Regex.Matches(input, pattern, RegexOptions.IgnorePatternWhitespace)
        Console.WriteLine("Found {0} matches. ", matches.Count)

        ' Get numeric string, convert it to a value, and add it to List object.
        Dim expenses As New List(Of Decimal)

        For Each match As Match In matches
            expenses.Add(Decimal.Parse(match.Groups.Item(1).Value))
        Next

        ' Determine whether total is present and if present, whether it is correct.
        Dim total As Decimal
        For Each value As Decimal In expenses
            total += value
        Next

        If total / 2 = expenses(expenses.Count - 1) Then
            Console.WriteLine("The expenses total {0:C2}.", expenses(expenses.Count - 1))
        Else
            Console.WriteLine("The expenses total {0:C2}.", total)
        End If
    End Sub
End Module
' The example displays the following output:
'       The regular expression pattern is:
'          \$\s*[-+]?([0-9]{0,3}(,[0-9]{3})*(\.[0-9]+)?)
'       Found 6 matches.
'       The expenses total $81.58.
' </Snippet1>
