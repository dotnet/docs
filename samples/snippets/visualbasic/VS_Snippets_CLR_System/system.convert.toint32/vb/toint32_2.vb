' Visual Basic .NET Document
'
' Example illustrates the Convert.ToInt32(String, IFormatProvider) overload.
'
Option Strict On

' <Snippet15>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Create a custom NumberFormatInfo object and set its two properties
      ' used by default in parsing numeric strings.
      Dim customProvider As New NumberFormatInfo()
      customProvider.NegativeSign = "neg "
      customProvider.PositiveSign = "pos "

      ' Add custom and invariant provider to an array of providers.
      Dim providers() As NumberFormatInfo = { customProvider, NumberFormatInfo.InvariantInfo }
      
      ' Define an array of strings to convert.
      Dim numericStrings() As String = { "123456789", "+123456789", "pos 123456789", _
                                         "-123456789", "neg 123456789", "123456789.", _
                                         "123,456,789", "(123456789)", "2147483648", _
                                         "-2147483649" } 
      
      ' Use each provider to parse all the numeric strings.
      For ctr As Integer = 0 To 1
         Dim provider As IFormatPRovider = providers(ctr)
         Console.WriteLine(IIf(ctr = 0, "Custom Provider:", "Invariant Provider:"))
         For Each numericString As String In numericStrings
            Console.Write("{0,15}  --> ", numericString)
            Try
               Console.WriteLine("{0,20}", Convert.ToInt32(numericString, provider))
            Catch e As FormatException
               Console.WriteLine("{0,20}", "FormatException") 
            Catch e As OverflowException
               Console.WriteLine("{0,20}", "OverflowException")                 
            End Try
         Next
         Console.WriteLine()
      Next                  
   End Sub 
End Module 
' The example displays the following output:
'       Custom Provider:
'             123456789  -->            123456789
'            +123456789  -->      FormatException
'         pos 123456789  -->            123456789
'            -123456789  -->      FormatException
'         neg 123456789  -->           -123456789
'            123456789.  -->      FormatException
'           123,456,789  -->      FormatException
'           (123456789)  -->      FormatException
'            2147483648  -->    OverflowException
'           -2147483649  -->      FormatException
'       
'       Invariant Provider:
'             123456789  -->            123456789
'            +123456789  -->            123456789
'         pos 123456789  -->      FormatException
'            -123456789  -->           -123456789
'         neg 123456789  -->      FormatException
'            123456789.  -->      FormatException
'           123,456,789  -->      FormatException
'           (123456789)  -->      FormatException
'            2147483648  -->    OverflowException
'           -2147483649  -->    OverflowException
' </Snippet15>

