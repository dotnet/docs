' <Snippet1>
Module Example
    Public Sub Main()
        ' Define an array of 64-bit integer values.
        Dim values() As Long = { Long.MinValue, Long.MaxValue, 
                                 &hFFFFFFFFFFFF, 123456789123456789,
                                 -1000000000000000 }
        ' Convert each value to a Decimal.
        For Each value In values
           Dim decValue As Decimal = value
           Console.WriteLine("{0} ({1}) --> {2} ({3})", value,
                             value.GetType().Name, decValue,
                             decValue.GetType().Name)
        Next
    End Sub 
End Module
' The example displays the following output:
'    -9223372036854775808 (Int64) --> -9223372036854775808 (Decimal)
'    9223372036854775807 (Int64) --> 9223372036854775807 (Decimal)
'    281474976710655 (Int64) --> 281474976710655 (Decimal)
'    123456789123456789 (Int64) --> 123456789123456789 (Decimal)
'    -1000000000000000 (Int64) --> -1000000000000000 (Decimal)
' </Snippet1>