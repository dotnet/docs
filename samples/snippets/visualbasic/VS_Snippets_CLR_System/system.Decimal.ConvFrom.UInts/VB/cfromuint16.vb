' <Snippet3>
Module Example
    Public Sub Main()
        ' Define an array of 16-bit unsigned integer values.
        Dim values() As Decimal = { UShort.MinValue, UShort.MaxValue,     
                                    &hFFF, 12345, 40000 }
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
'       0 (Decimal) --> 0 (Decimal)
'       65535 (Decimal) --> 65535 (Decimal)
'       4095 (Decimal) --> 4095 (Decimal)
'       12345 (Decimal) --> 12345 (Decimal)
'       40000 (Decimal) --> 40000 (Decimal)
' </Snippet3>
