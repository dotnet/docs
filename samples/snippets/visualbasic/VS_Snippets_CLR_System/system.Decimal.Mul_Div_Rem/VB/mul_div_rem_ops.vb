' <Snippet2>
Module DecimalMulDivRemOpsDemo
    
   Const dataFmt As String = "{0,-38}{1,31}"

   ' Display Decimal values and their product, quotient, and remainder.
   Sub ShowDecimalProQuoRem( left As Decimal, right As Decimal )
      Console.WriteLine( dataFmt, "Decimal left", left )
      Console.WriteLine( dataFmt, "Decimal right", right )

      Console.WriteLine(dataFmt, _
           "Decimal.op_Multiply(left, right)", 
            Decimal.op_Multiply(left, right))
      Console.WriteLine(dataFmt, 
            "Decimal.op_Division(left, right)", 
            Decimal.op_Division(left, right))
      Console.WriteLine(dataFmt, 
            "Decimal.op_Modulus(left, right)", 
            Decimal.op_Modulus(left, right))
      Console.WriteLine()
   End Sub

   Sub Main( )
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
' The example displays the following output:
'    Decimal left                                                     1000
'    Decimal right                                                       7
'    Decimal.op_Multiply(left, right)                                 7000
'    Decimal.op_Division(left, right)       142.85714285714285714285714286
'    Decimal.op_Modulus(left, right)                                     6
'    
'    Decimal left                                                    -1000
'    Decimal right                                                       7
'    Decimal.op_Multiply(left, right)                                -7000
'    Decimal.op_Division(left, right)      -142.85714285714285714285714286
'    Decimal.op_Modulus(left, right)                                    -6
'    
'    Decimal left                                              123.0000000
'    Decimal right                                                 0.00123
'    Decimal.op_Multiply(left, right)                       0.151290000000
'    Decimal.op_Division(left, right)                            100000.00
'    Decimal.op_Modulus(left, right)                             0.0000000
'    
'    Decimal left                                        12345678900000000
'    Decimal right                                      0.0000000012345678
'    Decimal.op_Multiply(left, right)            15241577.6390794200000000
'    Decimal.op_Division(left, right)       10000000729000059778004901.796
'    Decimal.op_Modulus(left, right)                        0.000000000983
'    
'    Decimal left                                     123456789.0123456789
'    Decimal right                                    123456789.1123456789
'    Decimal.op_Multiply(left, right)       15241578765584515.651425087878
'    Decimal.op_Division(left, right)       0.9999999991899999933660999449
'    Decimal.op_Modulus(left, right)                  123456789.0123456789
' </Snippet2>