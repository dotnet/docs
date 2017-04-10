'<Snippet1>
' Example of the TimeSpan relational operators.
Imports System
Imports Microsoft.VisualBasic

Module TSRelationalOpsDemo
    
    Const dataFmt As String = "{0,-47}{1}"

    ' Compare TimeSpan parameters, and display them with the results.
    Sub CompareTimeSpans( Left As TimeSpan, Right As TimeSpan, _
        RightText As String )

        Console.WriteLine( )
        Console.WriteLine( dataFmt, "Right: " & RightText, Right )
        Console.WriteLine( dataFmt, _
            "TimeSpan.op_Equality( Left, Right )", _
            TimeSpan.op_Equality( Left, Right ) )
        Console.WriteLine( dataFmt, _
            "TimeSpan.op_GreaterThan( Left, Right )", _
            TimeSpan.op_GreaterThan( Left, Right ) )
        Console.WriteLine( dataFmt, _
            "TimeSpan.op_GreaterThanOrEqual( Left, Right )", _
            TimeSpan.op_GreaterThanOrEqual( Left, Right ) )
        Console.WriteLine( dataFmt, _
            "TimeSpan.op_Inequality( Left, Right )", _
            TimeSpan.op_Inequality( Left, Right ) )
        Console.WriteLine( dataFmt, _
            "TimeSpan.op_LessThan( Left, Right )", _
            TimeSpan.op_LessThan( Left, Right ) )
        Console.WriteLine( dataFmt, _
            "TimeSpan.op_LessThanOrEqual( Left, Right )", _
            TimeSpan.op_LessThanOrEqual( Left, Right ) )
    End Sub 
        
    Sub Main( )
        Dim Left As New TimeSpan( 2, 0, 0 )
            
        Console.WriteLine( _
            "This example of the TimeSpan relational operators " & _
            "generates " & vbCrLf & "the following output. It " & _
            "creates several different TimeSpan " & vbCrLf & _
            "objects and compares them with a 2-hour " & _
            "TimeSpan." & vbCrLf )
        Console.WriteLine( dataFmt, "Left: TimeSpan( 2, 0, 0 )", Left )
            
        ' Create objects to compare with a 2-hour TimeSpan.
        CompareTimeSpans( Left, New TimeSpan( 0, 120, 0 ), _
            "TimeSpan( 0, 120, 0 )" )
        CompareTimeSpans( Left, New TimeSpan( 2, 0, 1 ), _
            "TimeSpan( 2, 0, 1 )" )
        CompareTimeSpans( Left, New TimeSpan( 2, 0, - 1 ), _
            "TimeSpan( 2, 0, -1 )" )
        CompareTimeSpans( Left, TimeSpan.FromDays( 1.0 / 12.0 ), _
            "TimeSpan.FromDays( 1 / 12 )" )
    End Sub 
End Module 

' This example of the TimeSpan relational operators generates
' the following output. It creates several different TimeSpan
' objects and compares them with a 2-hour TimeSpan.
' 
' Left: TimeSpan( 2, 0, 0 )                      02:00:00
' 
' Right: TimeSpan( 0, 120, 0 )                   02:00:00
' TimeSpan.op_Equality( Left, Right )            True
' TimeSpan.op_GreaterThan( Left, Right )         False
' TimeSpan.op_GreaterThanOrEqual( Left, Right )  True
' TimeSpan.op_Inequality( Left, Right )          False
' TimeSpan.op_LessThan( Left, Right )            False
' TimeSpan.op_LessThanOrEqual( Left, Right )     True
' 
' Right: TimeSpan( 2, 0, 1 )                     02:00:01
' TimeSpan.op_Equality( Left, Right )            False
' TimeSpan.op_GreaterThan( Left, Right )         False
' TimeSpan.op_GreaterThanOrEqual( Left, Right )  False
' TimeSpan.op_Inequality( Left, Right )          True
' TimeSpan.op_LessThan( Left, Right )            True
' TimeSpan.op_LessThanOrEqual( Left, Right )     True
' 
' Right: TimeSpan( 2, 0, -1 )                    01:59:59
' TimeSpan.op_Equality( Left, Right )            False
' TimeSpan.op_GreaterThan( Left, Right )         True
' TimeSpan.op_GreaterThanOrEqual( Left, Right )  True
' TimeSpan.op_Inequality( Left, Right )          True
' TimeSpan.op_LessThan( Left, Right )            False
' TimeSpan.op_LessThanOrEqual( Left, Right )     False
' 
' Right: TimeSpan.FromDays( 1 / 12 )             02:00:00
' TimeSpan.op_Equality( Left, Right )            True
' TimeSpan.op_GreaterThan( Left, Right )         False
' TimeSpan.op_GreaterThanOrEqual( Left, Right )  True
' TimeSpan.op_Inequality( Left, Right )          False
' TimeSpan.op_LessThan( Left, Right )            False
' TimeSpan.op_LessThanOrEqual( Left, Right )     True
'</Snippet1>