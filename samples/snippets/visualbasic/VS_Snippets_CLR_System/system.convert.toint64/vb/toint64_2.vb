' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Module Example
   Public Sub Main()
      Dim hexStrings() As String = { "8000000000000000", "0FFFFFFFFFFFFFFF", _
                                     "f0000000000001000", "00A30", "D", "-13", "GAD" }
      For Each hexString As String In hexStrings
         Try
            Dim number As Long = Convert.ToInt64(hexString, 16)
            Console.WriteLine("Converted '{0}' to {1:N0}.", hexString, number)
         Catch e As FormatException
            Console.WriteLine("'{0}' is not in the correct format for a hexadecimal number.", _
                              hexString)
         Catch e As OverflowException
            Console.WriteLine("'{0}' is outside the range of an Int64.", hexString)
         Catch e As ArgumentException
            Console.WriteLine("'{0}' is invalid in base 16.", hexString)
         End Try
      Next                                            
   End Sub
End Module
' The example displays the following output:
'       Converted '8000000000000000' to -9,223,372,036,854,775,808.
'       Converted '0FFFFFFFFFFFFFFF' to 1,152,921,504,606,846,975.
'       'f0000000000001000' is outside the range of an Int64.
'       Converted '00A30' to 2,608.
'       Converted 'D' to 13.
'       '-13' is invalid in base 16.
'       'GAD' is not in the correct format for a hexadecimal number.
' </Snippet15>
