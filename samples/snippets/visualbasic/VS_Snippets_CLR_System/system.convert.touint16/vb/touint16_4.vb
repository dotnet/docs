' Visual Basic .NET Document
Option Strict On

' <Snippet18>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Create a NumberFormatInfo object and set several of its
      ' properties that apply to numbers.
      Dim provider As New NumberFormatInfo()
      provider.PositiveSign = "pos "
      provider.NegativeSign = "neg "

      ' Define an array of strings to convert to UInt16 values.
      Dim values() As String = { "34567", "+34567", "pos 34567", _
                                 "34567.", "34567.", "65535", _
                                 "65535", "65535" }         

      For Each value As String In values
         Console.Write("{0,-12:}  -->  ", value)
         Try
            Console.WriteLine("{0,17}", Convert.ToUInt16(value, provider))
         Catch e As FormatException       
            Console.WriteLine("{0,17}", e.GetType().Name)
         End Try     
      Next
    End Sub 
End Module 
' The example displays the following output:
'       34567         -->              34567
'       +34567        -->    FormatException
'       pos 34567     -->              34567
'       34567.        -->    FormatException
'       34567.        -->    FormatException
'       65535         -->              65535
'       65535         -->              65535
'       65535         -->              65535
' </Snippet18>
