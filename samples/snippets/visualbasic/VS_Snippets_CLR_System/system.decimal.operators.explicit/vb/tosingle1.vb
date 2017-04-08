' <Snippet2>
Module Example
    Public Sub Main( )
        ' Define an array of Decimal values.
        Dim values() As Decimal= { 0.0000000000000000000000000001d, 
                                   0.0000000000123456789123456789d,
                                   123d, 
                                   New Decimal(123000000, 0, 0, False, 6),
                                   123456789.123456789d, 
                                   123456789123456789123456789d, 
                                   Decimal.MinValue, Decimal.MaxValue }
        For Each value In values
            Dim dblValue As Single = CSng(value)
            Console.WriteLine("{0} ({1}) --> {2} ({3})", value,
                              value.GetType().Name, dblValue, 
                              dblValue.GetType().Name)
        Next
    End Sub
End Module
' The example displays the following output:
'    0.0000000000000000000000000001 (Decimal) --> 1E-28 (Single)
'    0.0000000000123456789123456789 (Decimal) --> 1.234568E-11 (Single)
'    123 (Decimal) --> 123 (Single)
'    123.000000 (Decimal) --> 123 (Single)
'    123456789.123456789 (Decimal) --> 1.234568E+08 (Single)
'    123456789123456789123456789 (Decimal) --> 1.234568E+26 (Single)
'    -79228162514264337593543950335 (Decimal) --> -7.922816E+28 (Single)
'    79228162514264337593543950335 (Decimal) --> 7.922816E+28 (Single)
' </Snippet2>

