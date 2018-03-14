' <Snippet12>
Public Module Example
   Public Sub Main()
      ' Define a set of Decimal values.
      Dim values() As Decimal = { 1.45d, 1.55d, 123.456789d, 123.456789d, 
                                  123.456789d, -123.456d, 
                                  New Decimal(1230000000, 0, 0, true, 7 ),
                                  New Decimal(1230000000, 0, 0, true, 7 ), 
                                  -9999999999.9999999999d, 
                                  -9999999999.9999999999d }
      ' Define a set of integers to for decimals argument.
      Dim decimals() As Integer = { 1, 1, 4, 6, 8, 0, 3, 11, 9, 10}
      
      Console.WriteLine("{0,26}{1,8}{2,26}", 
                        "Argument", "Digits", "Result" )
      Console.WriteLine("{0,26}{1,8}{2,26}", 
                        "--------", "------", "------" )
      For ctr As Integer = 0 To values.Length - 1
        Console.WriteLine("{0,26}{1,8}{2,26}", 
                          values(ctr), decimals(ctr), 
                          Decimal.Round(values(ctr), decimals(ctr)))
      Next
   End Sub
End Module
' The example displays the following output:
'                   Argument  Digits                    Result
'                   --------  ------                    ------
'                       1.45       1                       1.4
'                       1.55       1                       1.6
'                 123.456789       4                  123.4568
'                 123.456789       6                123.456789
'                 123.456789       8                123.456789
'                   -123.456       0                      -123
'               -123.0000000       3                  -123.000
'               -123.0000000      11              -123.0000000
'     -9999999999.9999999999       9    -10000000000.000000000
'     -9999999999.9999999999      10    -9999999999.9999999999
'</Snippet12>
