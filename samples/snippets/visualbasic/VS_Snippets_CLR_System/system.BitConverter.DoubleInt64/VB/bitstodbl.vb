'<Snippet1>
' Example of the BitConverter.Int64BitsToDouble method.
Imports System
Imports Microsoft.VisualBasic

Module Int64BitsToDoubleDemo

    Const formatter As String = "{0,20}{1,27:E16}"
 
    ' Reinterpret the Long argument as a Double.
    Sub LongBitsToDouble( argument As Long )

        Dim doubleValue    As Double
        doubleValue = BitConverter.Int64BitsToDouble( argument )

        ' Display the argument in hexadecimal.
        Console.WriteLine( formatter, _
            String.Format( "0x{0:X16}", argument ), doubleValue )
    End Sub 
       
    Sub Main( )

        Console.WriteLine( _
            "This example of the BitConverter.Int64BitsToDouble( " & _
            "Long ) " & vbCrLf & "method generates the " & _
            "following output." & vbCrLf )
        Console.WriteLine( formatter, "Long argument", _
            "Double value" )
        Console.WriteLine( formatter, "-------------", _
            "------------" )
          
        ' Convert Long values and display the results.
        LongBitsToDouble( 0 )
        LongBitsToDouble( &H3FF0000000000000 )
        LongBitsToDouble( &H402E000000000000 )
        LongBitsToDouble( &H406FE00000000000 )
        LongBitsToDouble( &H41EFFFFFFFE00000 )
        LongBitsToDouble( &H3F70000000000000 )
        LongBitsToDouble( &H3DF0000000000000 )
        LongBitsToDouble( &H0000000000000001 )
        LongBitsToDouble( &H000000000000FFFF )
        LongBitsToDouble( &H0000FFFFFFFFFFFF )
        LongBitsToDouble( &HFFFFFFFFFFFFFFFF )
        LongBitsToDouble( &HFFF0000000000000 )
        LongBitsToDouble( &H7FF0000000000000 )
        LongBitsToDouble( &HFFEFFFFFFFFFFFFF )
        LongBitsToDouble( &H7FEFFFFFFFFFFFFF )
        LongBitsToDouble( Long.MinValue )
        LongBitsToDouble( Long.MaxValue )
    End Sub 
End Module

' This example of the BitConverter.Int64BitsToDouble( Long )
' method generates the following output.
' 
'        Long argument               Double value
'        -------------               ------------
'   0x0000000000000000    0.0000000000000000E+000
'   0x3FF0000000000000    1.0000000000000000E+000
'   0x402E000000000000    1.5000000000000000E+001
'   0x406FE00000000000    2.5500000000000000E+002
'   0x41EFFFFFFFE00000    4.2949672950000000E+009
'   0x3F70000000000000    3.9062500000000000E-003
'   0x3DF0000000000000    2.3283064365386963E-010
'   0x0000000000000001    4.9406564584124654E-324
'   0x000000000000FFFF    3.2378592100206092E-319
'   0x0000FFFFFFFFFFFF    1.3906711615669959E-309
'   0xFFFFFFFFFFFFFFFF                        NaN
'   0xFFF0000000000000                  -Infinity
'   0x7FF0000000000000                   Infinity
'   0xFFEFFFFFFFFFFFFF   -1.7976931348623157E+308
'   0x7FEFFFFFFFFFFFFF    1.7976931348623157E+308
'   0x8000000000000000    0.0000000000000000E+000
'   0x7FFFFFFFFFFFFFFF                        NaN
'</Snippet1>