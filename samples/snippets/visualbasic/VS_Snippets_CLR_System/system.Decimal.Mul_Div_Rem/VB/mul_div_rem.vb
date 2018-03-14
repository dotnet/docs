' <Snippet1>
Module DecimalMulDivRemDemo
    Const dataFmt As String = "{0,-35}{1,31}"

    ' Display Decimal parameters and their product, quotient, and 
    ' remainder.
    Sub ShowDecimalProQuoRem(left as Decimal, right as Decimal)
        Console.WriteLine()
        Console.WriteLine(dataFmt, "Decimal left", left )
        Console.WriteLine( dataFmt, "Decimal right", right )
        Console.WriteLine( dataFmt, 
            "Decimal.Multiply( left, right )", 
            Decimal.Multiply( left, right ) )
        Console.WriteLine( dataFmt, 
            "Decimal.Divide( left, right )", 
            Decimal.Divide( left, right ) )
        Console.WriteLine( dataFmt, 
            "Decimal.Remainder( left, right )", 
            Decimal.Remainder( left, right ) )
    End Sub

    Sub Main( )
        Console.WriteLine( "This example of the " & vbCrLf & 
            "  Decimal.Multiply( Decimal, Decimal ), " & vbCrLf & 
            "  Decimal.Divide( Decimal, Decimal ), and " & vbCrLf & 
            "  Decimal.Remainder( Decimal, Decimal ) " & vbCrLf & 
            "methods generates the following output. It displays " & 
            "the product, " & vbCrLf & "quotient, and remainder " & 
            "of several pairs of Decimal objects." )

        ' Create pairs of Decimal objects.
        ShowDecimalProQuoRem( 1000D, 7D ) 
        ShowDecimalProQuoRem( -1000D, 7D ) 
        ShowDecimalProQuoRem( 
            new Decimal( 1230000000, 0, 0, False, 7 ), 
            0.0012300D )
        ShowDecimalProQuoRem( 12345678900000000D, 
            0.0000000012345678D )
        ShowDecimalProQuoRem( 123456789.0123456789D, 
            123456789.1123456789D )
    End Sub
End Module 

' This example of the
'   Decimal.Multiply( Decimal, Decimal ),
'   Decimal.Divide( Decimal, Decimal ), and
'   Decimal.Remainder( Decimal, Decimal )
' methods generates the following output. It displays the product,
' quotient, and remainder of several pairs of Decimal objects.
' 
' Decimal left                                                  1000
' Decimal right                                                    7
' Decimal.Multiply( left, right )                               7000
' Decimal.Divide( left, right )       142.85714285714285714285714286
' Decimal.Remainder( left, right )                                 6
' 
' Decimal left                                                 -1000
' Decimal right                                                    7
' Decimal.Multiply( left, right )                              -7000
' Decimal.Divide( left, right )      -142.85714285714285714285714286
' Decimal.Remainder( left, right )                                -6
' 
' Decimal left                                           123.0000000
' Decimal right                                              0.00123
' Decimal.Multiply( left, right )                     0.151290000000
' Decimal.Divide( left, right )                            100000.00
' Decimal.Remainder( left, right )                                 0
' 
' Decimal left                                     12345678900000000
' Decimal right                                   0.0000000012345678
' Decimal.Multiply( left, right )          15241577.6390794200000000
' Decimal.Divide( left, right )       10000000729000059778004901.796
' Decimal.Remainder( left, right )                    0.000000000983
' 
' Decimal left                                  123456789.0123456789
' Decimal right                                 123456789.1123456789
' Decimal.Multiply( left, right )     15241578765584515.651425087878
' Decimal.Divide( left, right )       0.9999999991899999933660999449
' Decimal.Remainder( left, right )              123456789.0123456789
'</Snippet1>
