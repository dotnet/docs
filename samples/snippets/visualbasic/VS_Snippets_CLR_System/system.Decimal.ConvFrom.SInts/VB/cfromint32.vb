' <Snippet2>
Module Example
    Public Sub Main()
       ' Define an array of 32-bit integer values.
       Dim values() As Integer = { Integer.MinValue, Integer.MaxValue, 
                                   &hFFFFFF, 123456789, -1000000000 }
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
'       -2147483648 (Int32) --> -2147483648 (Decimal)
'       2147483647 (Int32) --> 2147483647 (Decimal)
'       16777215 (Int32) --> 16777215 (Decimal)
'       123456789 (Int32) --> 123456789 (Decimal)
'       -1000000000 (Int32) --> -1000000000 (Decimal)
' </Snippet2>