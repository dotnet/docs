' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As Decimal = { 78d, New Decimal(78000, 0, 0, false, 3), 
                                  78.999d, 255.999d, 256d,
                                  127.999d, 128d, -0.999d, 
                                  -1d,  -128.999d, -129d }

      For Each value In values
         Try
            Dim number As Byte = Decimal.ToByte(value)
            Console.WriteLine("{0} --> {1}", value, number)       
         Catch e As OverflowException
             Console.WriteLine("{0}: {1}", e.GetType().Name, value)
         End Try   
      Next
   End Sub
End Module
' The example displays the following output:
'     78 --> 78
'     78.000 --> 78
'     78.999 --> 78
'     255.999 --> 255
'     OverflowException: 256
'     127.999 --> 127
'     128 --> 128
'     -0.999 --> 0
'     OverflowException: -1
'     OverflowException: -128.999
'     OverflowException: -129
' </Snippet1>

