' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Create a NumberFormatInfo object and set several properties.
      Dim provider As New NumberFormatInfo()
      provider.PositiveSign = "pos "
      provider.NegativeSign = "neg "

      ' Define an array of numeric strings.
      Dim values() As String = { "123456789012", "+123456789012", _
                                 "pos 123456789012", "123456789012.", _
                                 "123,456,789,012", "18446744073709551615", _
                                 "18446744073709551616", "neg 1", "-1" }
      '  Convert the strings using the format provider.
      For Each value As String In values
         Console.Write("{0,-20}  -->  ", value)
         Try
            Console.WriteLine("{0,20}", Convert.ToUInt64(value, provider))
         Catch e As FormatException
            Console.WriteLine("{0,20}", "Invalid Format")
         Catch e As OverflowException
            Console.WriteLine("{0,20}", "Numeric Overflow")
         End Try               
      Next
    End Sub 
End Module 
' The example displays the following output:
'    123456789012          -->          123456789012
'    +123456789012         -->        Invalid Format
'    pos 123456789012      -->          123456789012
'    123456789012.         -->        Invalid Format
'    123,456,789,012       -->        Invalid Format
'    18446744073709551615  -->  18446744073709551615
'    18446744073709551616  -->      Numeric Overflow
'    neg 1                 -->      Numeric Overflow
'    -1                    -->        Invalid Format
' </Snippet15>
