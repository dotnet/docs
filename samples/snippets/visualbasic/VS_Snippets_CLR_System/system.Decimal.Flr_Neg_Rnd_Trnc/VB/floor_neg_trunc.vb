'<Snippet1>
' Example of the Decimal.Negate, Decimal.Floor, and Decimal.Truncate 
' methods. 
Imports System
Imports Microsoft.VisualBasic

Module DecimalFloorNegTruncDemo
    
    Const dataFmt As String = "{0,-30}{1,26}"

    ' Display Decimal parameters and their product, quotient, and 
    ' remainder.
    Sub ShowDecimalFloorNegTrunc( Argument as Decimal )

        Console.WriteLine( )
        Console.WriteLine( dataFmt, "Decimal Argument", Argument )
        Console.WriteLine( dataFmt, _
            "Decimal.Negate( Argument )", _
            Decimal.Negate( Argument ) )
        Console.WriteLine( dataFmt, _
            "Decimal.Floor( Argument )", _
            Decimal.Floor( Argument ) )
        Console.WriteLine( dataFmt, _
            "Decimal.Truncate( Argument )", _
            Decimal.Truncate( Argument ) )
    End Sub

    Sub Main( )
        Console.WriteLine( "This example of the " & vbCrLf & _
            "  Decimal.Negate( Decimal ), " & vbCrLf & _
            "  Decimal.Floor( Decimal ), and " & vbCrLf & _
            "  Decimal.Truncate( Decimal ) " & vbCrLf & _
            "methods generates the following output." )

        ' Create pairs of Decimal objects.
        ShowDecimalFloorNegTrunc( 0D ) 
        ShowDecimalFloorNegTrunc( 123.456D ) 
        ShowDecimalFloorNegTrunc( -123.456D ) 
        ShowDecimalFloorNegTrunc( _
            new Decimal( 1230000000, 0, 0, True, 7 ) )
        ShowDecimalFloorNegTrunc( -9999999999.9999999999D )
    End Sub
End Module 

' This example of the
'   Decimal.Negate( Decimal ),
'   Decimal.Floor( Decimal ), and
'   Decimal.Truncate( Decimal )
' methods generates the following output.
' 
' Decimal Argument                                       0
' Decimal.Negate( Argument )                             0
' Decimal.Floor( Argument )                              0
' Decimal.Truncate( Argument )                           0
' 
' Decimal Argument                                 123.456
' Decimal.Negate( Argument )                      -123.456
' Decimal.Floor( Argument )                            123
' Decimal.Truncate( Argument )                         123
' 
' Decimal Argument                                -123.456
' Decimal.Negate( Argument )                       123.456
' Decimal.Floor( Argument )                           -124
' Decimal.Truncate( Argument )                        -123
' 
' Decimal Argument                            -123.0000000
' Decimal.Negate( Argument )                   123.0000000
' Decimal.Floor( Argument )                           -123
' Decimal.Truncate( Argument )                        -123
' 
' Decimal Argument                  -9999999999.9999999999
' Decimal.Negate( Argument )         9999999999.9999999999
' Decimal.Floor( Argument )                   -10000000000
' Decimal.Truncate( Argument )                 -9999999999
'</Snippet1>