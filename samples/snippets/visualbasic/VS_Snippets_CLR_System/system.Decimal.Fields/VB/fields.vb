'<Snippet1>
' Example of the Decimal fields.
Imports System
Imports Microsoft.VisualBasic

Module DecimalFieldsDemo
    
    Sub Main( )

        Const numberFmt As String = "{0,-25}{1,45:N0}"
        Const exprFmt As String = "{0,-55}{1,15}"

        Console.WriteLine( _
            "This example of the fields of the Decimal structure" & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( numberFmt, "Field or Expression", "Value" )
        Console.WriteLine( numberFmt, "-------------------", "-----" )

        ' Display the values of the Decimal fields.
        Console.WriteLine( numberFmt, "Decimal.MaxValue", _
            Decimal.MaxValue )
        Console.WriteLine( numberFmt, "Decimal.MinValue", _
            Decimal.MinValue )
        Console.WriteLine( numberFmt, "Decimal.MinusOne", _
            Decimal.MinusOne )
        Console.WriteLine( numberFmt, "Decimal.One", _
            Decimal.One )
        Console.WriteLine( numberFmt, "Decimal.Zero", _
            Decimal.Zero )
        Console.WriteLine( )

        ' Display the values of expressions of the Decimal fields.
        Console.WriteLine( exprFmt, _
            "( Decimal.MinusOne + Decimal.One ) = Decimal.Zero", _
            ( Decimal.MinusOne + Decimal.One ) = Decimal.Zero )
        Console.WriteLine( exprFmt, _
            "Decimal.MaxValue + Decimal.MinValue", _
            Decimal.MaxValue + Decimal.MinValue )
        Console.WriteLine( exprFmt, _
            "Decimal.MinValue / Decimal.MaxValue", _
            Decimal.MinValue/Decimal.MaxValue )
        Console.WriteLine( "{0,-40}{1,30}", _
            "100000000000000D / Decimal.MaxValue", _
            100000000000000D / Decimal.MaxValue )
    End Sub 
End Module 

' This example of the fields of the Decimal structure
' generates the following output.
' 
' Field or Expression                                              Value
' -------------------                                              -----
' Decimal.MaxValue                79,228,162,514,264,337,593,543,950,335
' Decimal.MinValue               -79,228,162,514,264,337,593,543,950,335
' Decimal.MinusOne                                                    -1
' Decimal.One                                                          1
' Decimal.Zero                                                         0
' 
' ( Decimal.MinusOne + Decimal.One ) = Decimal.Zero                 True
' Decimal.MaxValue + Decimal.MinValue                                  0
' Decimal.MinValue / Decimal.MaxValue                                 -1
' 100000000000000D / Decimal.MaxValue     0.0000000000000012621774483536
'</Snippet1>