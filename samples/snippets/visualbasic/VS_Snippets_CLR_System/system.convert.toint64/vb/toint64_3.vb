' Visual Basic .NET Document
Option Strict On

' <Snippet16>
Imports System.Globalization

Public Module Example
   Public Sub Main()
      ' Create a NumberFormatInfo object and set the properties that
      ' affect conversions using Convert.ToInt64(String, IFormatProvider).
      Dim customProvider As New NumberFormatInfo()
      customProvider.NegativeSign = "neg "
      customProvider.PositiveSign = "pos "

      ' Create an array of providers with the custom provider and the
      ' NumberFormatInfo object for the invariant culture.
      Dim providers() As NumberFormatInfo = {customProvider, _
                                             NumberFormatInfo.InvariantInfo }
      
      ' Define an array of strings to parse.
      Dim numericStrings() As String = { "123456789", "+123456789", _
                                         "pos 123456789", "-123456789", _
                                         "neg 123456789", "123456789.", _
                                         "123,456,789", "(123456789)", _
                                         "9223372036854775808", "-9223372036854775809" }

      For ctr As Integer = 0 to 1
         Dim provider As IFormatProvider = providers(ctr)
         Console.WriteLine(IIf(ctr = 0, "Custom Provider:", "Invariant Culture:"))
         For Each numericString As String In numericStrings
            Console.Write("   {0,-22} -->  ", numericString)
            Try
               Console.WriteLine("{0,22}", Convert.ToInt32(numericString, provider))
            Catch e As FormatException
               Console.WriteLine("{0,22}", "Unrecognized Format")
            Catch e As OverflowException
               Console.WriteLine("{0,22}", "Overflow")
            End Try
         Next
         Console.WriteLine()
      Next
   End Sub 
End Module 
' The example displays the following output:
'       Custom Provider:
'          123456789              -->               123456789
'          +123456789             -->     Unrecognized Format
'          pos 123456789          -->               123456789
'          -123456789             -->     Unrecognized Format
'          neg 123456789          -->              -123456789
'          123456789.             -->     Unrecognized Format
'          123,456,789            -->     Unrecognized Format
'          (123456789)            -->     Unrecognized Format
'          9223372036854775808    -->                Overflow
'          -9223372036854775809   -->     Unrecognized Format
'       
'       Invariant Culture:
'          123456789              -->               123456789
'          +123456789             -->               123456789
'          pos 123456789          -->     Unrecognized Format
'          -123456789             -->              -123456789
'          neg 123456789          -->     Unrecognized Format
'          123456789.             -->     Unrecognized Format
'          123,456,789            -->     Unrecognized Format
'          (123456789)            -->     Unrecognized Format
'          9223372036854775808    -->                Overflow
'          -9223372036854775809   -->                Overflow
' </Snippet16>
