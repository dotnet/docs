' <Snippet1>
Module Example
    Public Sub Main()
        Dim values() As ULong = { ULong.MinValue, ULong.MaxValue, 
                           &hFFFFFFFFFFFF, 123456789123456789, 
                           1000000000000000 }
        For Each value In values
           Dim decValue As Decimal = value
           Console.WriteLine("{0} ({1}) --> {2} ({3})", value,
                             value.GetType().Name, decValue,
                             decValue.GetType().Name)
        Next                              
    End Sub 
End Module
' The example displays the following output:
'    0 (UInt64) --> 0 (Decimal)
'    18446744073709551615 (UInt64) --> 18446744073709551615 (Decimal)
'    281474976710655 (UInt64) --> 281474976710655 (Decimal)
'    123456789123456789 (UInt64) --> 123456789123456789 (Decimal)
'    1000000000000000 (UInt64) --> 1000000000000000 (Decimal)
' </Snippet1>