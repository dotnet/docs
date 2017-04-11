' <Snippet2>
Module Example
    Public Sub Main()
        ' Define an array of 32-bit unsigned integer values.
        Dim values() As UInteger = { UInteger.MinValue, UInteger.MaxValue, 
                                     &hFFFFFF, 123456789, 4000000000 }
        For Each value In values
           Dim decValue As Decimal = value
           Console.WriteLine("{0} ({1}) --> {2} ({3})", value,
                             value.GetType().Name, decValue,
                             decValue.GetType().Name)           
        Next   
    End Sub 
End Module
' The example displays the following output:
'       0 (UInt32) --> 0 (Decimal)
'       4294967295 (UInt32) --> 4294967295 (Decimal)
'       16777215 (UInt32) --> 16777215 (Decimal)
'       123456789 (UInt32) --> 123456789 (Decimal)
'       4000000000 (UInt32) --> 4000000000 (Decimal)
' </Snippet2>

