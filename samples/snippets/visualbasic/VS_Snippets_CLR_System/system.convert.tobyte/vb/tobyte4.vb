Option Strict On

' <Snippet14>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Create a NumberFormatInfo object and set several of its
      ' properties that apply to unsigned bytes.
      Dim provider As New NumberFormatInfo()
      With provider 
         ' These properties affect the conversion.
         .PositiveSign = "pos "
         .NegativeSign = "neg "

         ' This property does not affect the conversion.
         ' The input string cannot have a decimal separator.
         .NumberDecimalSeparator = "."
      End With
      
      ' Define an array of numeric strings.
      Dim numericStrings() As String = { "234", "+234", "pos 234", "234.", _
                                         "255", "256", "-1" }

      For Each numericString As String In numericStrings
         Console.Write("'{0,-8}' ->   ", numericString)
         Try
            Dim number As Byte = Convert.ToByte(numericString, provider)
            Console.WriteLine(number)
         Catch ex As FormatException
            Console.WriteLine("Incorrect Format")                          
         Catch ex As OverflowException
            Console.WriteLine("Overflows a Byte")
         End Try   
      Next
   End Sub   
End Module 
' The example displays the following output:
'       '234     ' ->   234
'       '+234    ' ->   Incorrect Format
'       'pos 234 ' ->   234
'       '234.    ' ->   Incorrect Format
'       '255     ' ->   255
'       '256     ' ->   Overflows a Byte
'       '-1      ' ->   Incorrect Format
' </Snippet14>
