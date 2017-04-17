' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Create a NumberFormatInfo object and set several of its
      ' properties that apply to numbers.
      Dim provider As New NumberFormatInfo() 
      provider.PositiveSign = "pos "
      provider.NegativeSign = "neg "

      ' Define an array of numeric strings.
      Dim values() As String = { "123456789", "+123456789", "pos 123456789", _
                                 "123456789.", "123,456,789",  "4294967295", _
                                 "4294967296", "-1", "neg 1" }

      For Each value As String In values
         Console.Write("{0,-20} -->", value)
         Try
            Console.WriteLine("{0,20}", Convert.ToUInt32(value, provider))
         Catch e As FormatException
            Console.WriteLine("{0,20}", "Bad Format")
         Catch e As OverflowException
            Console.WriteLine("{0,20}", "Numeric Overflow")
         End Try   
      Next
    End Sub 
End Module 
' The example displays the following output:
'       123456789            -->           123456789
'       +123456789           -->          Bad Format
'       pos 123456789        -->           123456789
'       123456789.           -->          Bad Format
'       123,456,789          -->          Bad Format
'       4294967295           -->          4294967295
'       4294967296           -->    Numeric Overflow
'       -1                   -->          Bad Format
'       neg 1                -->    Numeric Overflow
' </Snippet15>
