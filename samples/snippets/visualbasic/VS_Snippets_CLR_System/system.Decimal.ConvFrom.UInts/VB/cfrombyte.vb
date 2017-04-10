' <Snippet4>
Module Example
    Public Sub Main
        ' Define an array of byte values.
        Dim values() As Byte = { Byte.MinValue, Byte.MaxValue, 
                                 &h3F, 123, 200 }   
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
'       0 (Byte) --> 0 (Decimal)
'       255 (Byte) --> 255 (Decimal)
'       63 (Byte) --> 63 (Decimal)
'       123 (Byte) --> 123 (Decimal)
'       200 (Byte) --> 200 (Decimal)
' </Snippet4>

