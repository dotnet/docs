' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As Decimal = { 123d, New Decimal(123000, 0, 0, false, 3), 
                                  123.999d, 65535.999d, 65536d,
                                  32767.999d, 32768d, -0.999d, 
                                  -1d,  -32768.999d, -32769d }

      For Each value In values
         Try
            Dim number As UShort = Decimal.ToUInt16(value)
            Console.WriteLine("{0} --> {1}", value, number)       
         Catch e As OverflowException
             Console.WriteLine("{0}: {1}", e.GetType().Name, value)
         End Try   
      Next
   End Sub
End Module
' The example displays the following output:
'     123 --> 123
'     123.000 --> 123
'     123.999 --> 123
'     65535.999 --> 65535
'     OverflowException: 65536
'     32767.999 --> 32767
'     32768 --> 32768
'     -0.999 --> 0
'     OverflowException: -1
'     OverflowException: -32768.999
'     OverflowException: -32769
' </Snippet1> 
