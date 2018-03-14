' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Module Example
   Public Sub Main()
      Dim hexStrings() As String = { "8000", "0FFF", "f000", "00A30", "D", _
                                     "-13", "9AC61", "GAD" }
      For Each hexString As String In hexStrings
         Try
            Dim number As UShort = Convert.ToUInt16(hexString, 16)
            Console.WriteLine("Converted '{0}' to {1:N0}.", hexString, number)
         Catch e As FormatException
            Console.WriteLine("'{0}' is not in the correct format for a hexadecimal number.", _
                              hexString)
         Catch e As OverflowException
            Console.WriteLine("'{0}' is outside the range of an Int16.", hexString)
         Catch e As ArgumentException
            Console.WriteLine("'{0}' is invalid in base 16.", hexString)
         End Try
      Next                                            
   End Sub
End Module
'    ' The example displays the following output:
'    Converted '8000' to 32,768.
'    Converted '0FFF' to 4,095.
'    Converted 'f000' to 61,440.
'    Converted '00A30' to 2,608.
'    Converted 'D' to 13.
'    '-13' is invalid in base 16.
'    '9AC61' is outside the range of an Int16.
'    'GAD' is not in the correct format for a hexadecimal number.
' </Snippet15>
