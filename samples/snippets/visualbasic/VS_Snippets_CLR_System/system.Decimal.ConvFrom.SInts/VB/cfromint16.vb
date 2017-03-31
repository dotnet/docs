'<Snippet3>
Module Example
    Public Sub Main()
        ' Define an array of 16-bit integer values.
        Dim values() As Short = { Short.MinValue, Short.MaxValue, 
                                  &hFFF, 12345, -10000 }   
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
'    -32768 (Int16) --> -32768 (Decimal)
'    32767 (Int16) --> 32767 (Decimal)
'    4095 (Int16) --> 4095 (Decimal)
'    12345 (Int16) --> 12345 (Decimal)
'    -10000 (Int16) --> -10000 (Decimal)
'</Snippet3>
' 60 lines