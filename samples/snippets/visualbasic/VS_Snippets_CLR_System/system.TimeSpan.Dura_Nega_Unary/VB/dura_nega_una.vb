'<Snippet1>
' Example of the TimeSpan.Duration( ) and TimeSpan.Negate( ) methods,
' and the TimeSpan Unary Negation and Unary Plus operators.
Imports System
Imports Microsoft.VisualBasic

Module DuraNegaUnaryDemo

    Const dataFmt As String = "{0,22}{1,22}{2,22}"

    Sub ShowDurationNegate( interval As TimeSpan )

        ' Display the TimeSpan value and the results of the 
        ' Duration and Negate methods.
        Console.WriteLine( dataFmt, _
            interval, interval.Duration( ), interval.Negate( ) )
    End Sub

    Sub Main( )

        Console.WriteLine( _
            "This example of TimeSpan.Duration( ), " & _
            "TimeSpan.Negate( ), " & vbCrLf & _
            "and the TimeSpan Unary Negation and " & _
            "Unary Plus operators " & vbCrLf & _
            "generates the following output." & vbCrLf )
        Console.WriteLine( dataFmt, _
            "TimeSpan", "Duration( )", "Negate( )" )    
        Console.WriteLine( dataFmt, _
            "--------", "-----------", "---------" )    

        ' Create TimeSpan objects and apply the Unary Negation
        ' and Unary Plus operators to them.
        ShowDurationNegate( new TimeSpan( 1 ) )
        ShowDurationNegate( new TimeSpan( -1234567 ) )
        ShowDurationNegate( TimeSpan.op_UnaryPlus( _
            new TimeSpan( 0, 0, 10, -20, -30 ) ) )
        ShowDurationNegate( TimeSpan.op_UnaryPlus( _
            new TimeSpan( 0, -10, 20, -30, 40 ) ) )
        ShowDurationNegate( TimeSpan.op_UnaryNegation( _
            new TimeSpan( 1, 10, 20, 40, 160 ) ) )
        ShowDurationNegate( TimeSpan.op_UnaryNegation( _
            new TimeSpan( -10, -20, -30, -40, -50 ) ) )
    End Sub 
End Module 

' This example of TimeSpan.Duration( ), TimeSpan.Negate( ),
' and the TimeSpan Unary Negation and Unary Plus operators
' generates the following output.
' 
'               TimeSpan           Duration( )             Negate( )
'               --------           -----------             ---------
'       00:00:00.0000001      00:00:00.0000001     -00:00:00.0000001
'      -00:00:00.1234567      00:00:00.1234567      00:00:00.1234567
'       00:09:39.9700000      00:09:39.9700000     -00:09:39.9700000
'      -09:40:29.9600000      09:40:29.9600000      09:40:29.9600000
'    -1.10:20:40.1600000    1.10:20:40.1600000    1.10:20:40.1600000
'    10.20:30:40.0500000   10.20:30:40.0500000  -10.20:30:40.0500000
'</Snippet1>