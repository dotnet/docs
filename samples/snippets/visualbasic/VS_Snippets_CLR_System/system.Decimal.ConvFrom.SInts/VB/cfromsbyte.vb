' <Snippet4>
Module Example
    Public Sub Main()
        ' Define an array of 8-bit signed integer values.
        Dim values() As SByte = { SByte.MinValue, SByte.MaxValue,     
                                  &h3F, 123, -100 }
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
'       -128 (SByte) --> -128 (Decimal)
'       127 (SByte) --> 127 (Decimal)
'       63 (SByte) --> 63 (Decimal)
'       123 (SByte) --> 123 (Decimal)
'       -100 (SByte) --> -100 (Decimal)
' </Snippet4>