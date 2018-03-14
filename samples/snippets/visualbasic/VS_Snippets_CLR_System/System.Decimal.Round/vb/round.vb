Module Example
    Const dataFmt As String = "{0,26}{1,8}{2,26}"

    ' Display Decimal.Round parameters and the result.
    Sub ShowDecimalRound( Argument As Decimal, Digits As Integer )

        Dim rounded As Decimal = Decimal.Round( Argument, Digits )

        Console.WriteLine( dataFmt, Argument, Digits, rounded )
    End Sub

    Sub Main()
        Console.WriteLine( "This example of the " & _
            "Decimal.Round( Decimal, Integer ) " & vbCrLf & _
            "method generates the following output." & vbCrLf )
        Console.WriteLine( dataFmt, "Argument", "Digits", "Result" )
        Console.WriteLine( dataFmt, "--------", "------", "------" )

        ' Create pairs of Decimal objects.
        ShowDecimalRound( 1.45D, 1 ) 
        ShowDecimalRound( 1.55D, 1 ) 
        ShowDecimalRound( 123.456789D, 4 ) 
        ShowDecimalRound( 123.456789D, 6 ) 
        ShowDecimalRound( 123.456789D, 8 ) 
        ShowDecimalRound( -123.456D, 0 ) 
        ShowDecimalRound( _
            New Decimal( 1230000000, 0, 0, True, 7 ), 3 )
        ShowDecimalRound( _
            New Decimal( 1230000000, 0, 0, True, 7 ), 11 )
        ShowDecimalRound( -9999999999.9999999999D, 9 )
        ShowDecimalRound( -9999999999.9999999999D, 10 )
    End Sub
End Module 
' This example of the Decimal.Round( Decimal, Integer )
' method generates the following output.
'
'                  Argument  Digits                    Result
'                  --------  ------                    ------
'                      1.45       1                       1.4
'                      1.55       1                       1.6
'                123.456789       4                  123.4568
'                123.456789       6                123.456789
'                123.456789       8                123.456789
'                  -123.456       0                      -123
'              -123.0000000       3                  -123.000
'              -123.0000000      11              -123.0000000
'    -9999999999.9999999999       9    -10000000000.000000000
'    -9999999999.9999999999      10    -9999999999.9999999999


