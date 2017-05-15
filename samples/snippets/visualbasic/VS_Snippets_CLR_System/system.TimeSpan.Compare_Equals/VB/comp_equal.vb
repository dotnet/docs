'<Snippet2>
' Example of the TimeSpan.Compare( TimeSpan, TimeSpan ) and 
' TimeSpan.Equals( TimeSpan, TimeSpan ) methods.
Imports System
Imports Microsoft.VisualBasic

Module TSCompareEqualsDemo
    
    Const dataFmt As String = "{0,-38}{1}"

    ' Compare TimeSpan parameters, and display them with the results.
    Sub CompareTimeSpans( Left as TimeSpan, Right as TimeSpan, _
        RightText as String )

        Console.WriteLine( )
        Console.WriteLine( dataFmt, "Right: " & RightText, Right )
        Console.WriteLine( dataFmt, "TimeSpan.Equals( Left, Right )", _
            TimeSpan.Equals( Left, Right ) )
        Console.WriteLine( dataFmt, _
            "TimeSpan.Compare( Left, Right )", _
            TimeSpan.Compare( Left, Right ) )
    End Sub

    Sub Main( )
        Dim Left as new TimeSpan( 2, 0, 0 )

        Console.WriteLine( _
            "This example of the TimeSpan.Equals( TimeSpan, " & _
            "TimeSpan ) and " & vbCrLf & "TimeSpan.Compare( " & _
            "TimeSpan, TimeSpan ) methods generates the " & vbCrLf & _
            "following output by creating several " & _
            "different TimeSpan " & vbCrLf & "objects and " & _
            "comparing them with a 2-hour TimeSpan." & vbCrLf )
        Console.WriteLine( dataFmt, "Left: TimeSpan( 2, 0, 0 )", Left )

        ' Create objects to compare with a 2-hour TimeSpan.
        CompareTimeSpans( Left, new TimeSpan( 0, 120, 0 ), _
            "TimeSpan( 0, 120, 0 )" )
        CompareTimeSpans( Left, new TimeSpan( 2, 0, 1 ), _
            "TimeSpan( 2, 0, 1 )" )
        CompareTimeSpans( Left, new TimeSpan( 2, 0, -1 ), _
            "TimeSpan( 2, 0, -1 )" )
        CompareTimeSpans( Left, new TimeSpan( 72000000000 ), _
            "TimeSpan( 72000000000 )" )
        CompareTimeSpans( Left, TimeSpan.FromDays( 1.0 / 12R ), _
            "TimeSpan.FromDays( 1 / 12 )" )
    End Sub 
End Module 

' This example of the TimeSpan.Equals( TimeSpan, TimeSpan ) and
' TimeSpan.Compare( TimeSpan, TimeSpan ) methods generates the
' following output by creating several different TimeSpan
' objects and comparing them with a 2-hour TimeSpan.
' 
' Left: TimeSpan( 2, 0, 0 )             02:00:00
' 
' Right: TimeSpan( 0, 120, 0 )          02:00:00
' TimeSpan.Equals( Left, Right )        True
' TimeSpan.Compare( Left, Right )       0
' 
' Right: TimeSpan( 2, 0, 1 )            02:00:01
' TimeSpan.Equals( Left, Right )        False
' TimeSpan.Compare( Left, Right )       -1
' 
' Right: TimeSpan( 2, 0, -1 )           01:59:59
' TimeSpan.Equals( Left, Right )        False
' TimeSpan.Compare( Left, Right )       1
' 
' Right: TimeSpan( 72000000000 )        02:00:00
' TimeSpan.Equals( Left, Right )        True
' TimeSpan.Compare( Left, Right )       0
' 
' Right: TimeSpan.FromDays( 1 / 12 )    02:00:00
' TimeSpan.Equals( Left, Right )        True
' TimeSpan.Compare( Left, Right )       0
'</Snippet2>