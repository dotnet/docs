' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Module Example
   Public Sub Main()
      ' Get the current NumberFormatInfo object to build the regular 
      ' expression pattern dynamically.
      Dim nfi As NumberFormatInfo = CultureInfo.GetCultureInfo("en-US").NumberFormat

      ' Define the regular expression pattern.
      Dim pattern As String 
      pattern = "^\s*["
      ' Get the positive and negative sign symbols.
      pattern += Regex.Escape(nfi.PositiveSign + nfi.NegativeSign) + "]?\s?"
      ' Get the currency symbol.
      pattern += Regex.Escape(nfi.CurrencySymbol) + "?\s?"
      ' Add integral digits to the pattern.
      pattern += "(\d*"
      ' Add the decimal separator.
      pattern += Regex.Escape(nfi.CurrencyDecimalSeparator) + "?"
      ' Add the fractional digits.
      pattern += "(\d{"
      ' Determine the number of fractional digits in currency values.
      pattern += nfi.CurrencyDecimalDigits.ToString() + "})?){1}$"
      
      Console.WriteLine("Pattern is {0}", pattern)
      Console.WriteLine()
      
      Dim rgx As New Regex(pattern)

      ' Define some test strings.
      Dim tests() As String = {"-42", "19.99", "0.001", "100 USD", _
                               ".34", "0.34", "1,052.21", "$10.62", _
                               "+1.43", "-$0.23" }

      ' Check each test string against the regular expression.
      For Each test As String In tests
         If rgx.IsMatch(test) Then
            Console.WriteLine("{0} is a currency value.", test)
         Else
            Console.WriteLine("{0} is not a currency value.", test)
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'       Pattern is ^\s*[\+-]?\s?\$?\s?(\d*\.?(\d{2})?){1}$
'
'       -42 is a currency value.
'       19.99 is a currency value.
'       0.001 is not a currency value.
'       100 USD is not a currency value.
'       .34 is a currency value.
'       0.34 is a currency value.
'       1,052.21 is not a currency value.
'       $10.62 is a currency value.
'       +1.43 is a currency value.
'       -$0.23 is a currency value.
' </Snippet1>
