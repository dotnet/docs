' <Snippet4>
Option Strict On

Module Example
    Public Sub Main()
        ' Define an array of decimal values.
        Dim values() As Decimal = { 78d, New Decimal(78000, 0, 0, False, 3),
                                    78.999d, 255.999d, 256d, 127.999d,
                                    128d, -0.999d, -1d, -128.999d, 
                                    -129d }           
        For Each value In values
           Try
              Dim byteValue As Byte = CByte(value)
              Console.WriteLine("{0} ({1}) --> {2} ({3})", value,
                                value.GetType().Name, byteValue, 
                                byteValue.GetType().Name)
           Catch e As OverflowException
              Console.WriteLine("OverflowException: Cannot convert {0}",
                                value)
           End Try
        Next   
    End Sub
End Module
' The example displays the following output:
'       78 (Decimal) --> 78 (Byte)
'       78.000 (Decimal) --> 78 (Byte)
'       78.999 (Decimal) --> 79 (Byte)
'       OverflowException: Cannot convert 255.999
'       OverflowException: Cannot convert 256
'       127.999 (Decimal) --> 128 (Byte)
'       128 (Decimal) --> 128 (Byte)
'       OverflowException: Cannot convert -0.999
'       OverflowException: Cannot convert -1
'       OverflowException: Cannot convert -128.999
'       OverflowException: Cannot convert -129
' </Snippet4>
