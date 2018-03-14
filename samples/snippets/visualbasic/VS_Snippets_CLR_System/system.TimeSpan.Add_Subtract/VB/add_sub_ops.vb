'<Snippet2>
' Example of the TimeSpan Addition and Subtraction operators.
Imports System
Imports Microsoft.VisualBasic

Module TimeSpanAddSubOpsDemo
    
    Const dataFmt As String = "{0,-38}{1,24}"

    ' Pad the end of a TimeSpan string with spaces if it does not 
    ' contain milliseconds.
    Function Align( interval As TimeSpan ) As String

        Dim intervalStr As String = interval.ToString( )
        Dim pointIndex  As Integer = intervalStr.IndexOf( ":"c )

        pointIndex = intervalStr.IndexOf( "."c, pointIndex )
        If pointIndex < 0 Then intervalStr &= "        "
        Align = intervalStr
    End Function
    
    ' Display TimeSpan parameters and their sum and difference.
    Sub ShowTimeSpanSumDiff( Left as TimeSpan, Right as TimeSpan )

        Console.WriteLine( )
        Console.WriteLine( dataFmt, "TimeSpan Left", Align( Left ) )
        Console.WriteLine( dataFmt, "TimeSpan Right", Align( Right ) )
        Console.WriteLine( dataFmt, _
            "TimeSpan.op_Addition( Left, Right )", _
            Align( TimeSpan.op_Addition( Left, Right ) ) )
        Console.WriteLine( dataFmt, _
            "TimeSpan.op_Subtraction( Left, Right )", _
            Align( TimeSpan.op_Subtraction( Left, Right ) ) )
    End Sub

    Sub Main( )
        Console.WriteLine( _
            "This example of the TimeSpan Addition and " & _
            "Subtraction " & vbCrLf & "operators " & _
            "generates the following output by creating " & vbCrLf & _
            "several pairs of TimeSpan objects and calculating " & _
            "and " & vbCrLf & "displaying the sum " & _
            "and difference of each." )

        ' Create pairs of TimeSpan objects.
        ShowTimeSpanSumDiff( _
            new TimeSpan( 1, 20, 0 ), _
            new TimeSpan( 0, 45, 10 ) )
        ShowTimeSpanSumDiff( _
            new TimeSpan( 1, 10, 20, 30, 40 ), _
            new TimeSpan( -1, 2, 3, 4, 5 ) )
        ShowTimeSpanSumDiff( _
            new TimeSpan( 182, 12, 30, 30, 505 ), _
            new TimeSpan( 182, 11, 29, 29, 495 ) )
        ShowTimeSpanSumDiff( _
            new TimeSpan( 888888888888888 ), _
            new TimeSpan( 999999999999999 ) )
    End Sub
End Module 

' This example of the TimeSpan Addition and Subtraction
' operators generates the following output by creating
' several pairs of TimeSpan objects and calculating and
' displaying the sum and difference of each.
' 
' TimeSpan Left                                 01:20:00
' TimeSpan Right                                00:45:10
' TimeSpan.op_Addition( Left, Right )           02:05:10
' TimeSpan.op_Subtraction( Left, Right )        00:34:50
' 
' TimeSpan Left                               1.10:20:30.0400000
' TimeSpan Right                               -21:56:55.9950000
' TimeSpan.op_Addition( Left, Right )           12:23:34.0450000
' TimeSpan.op_Subtraction( Left, Right )      2.08:17:26.0350000
' 
' TimeSpan Left                             182.12:30:30.5050000
' TimeSpan Right                            182.11:29:29.4950000
' TimeSpan.op_Addition( Left, Right )       365.00:00:00
' TimeSpan.op_Subtraction( Left, Right )        01:01:01.0100000
' 
' TimeSpan Left                            1028.19:21:28.8888888
' TimeSpan Right                           1157.09:46:39.9999999
' TimeSpan.op_Addition( Left, Right )      2186.05:08:08.8888887
' TimeSpan.op_Subtraction( Left, Right )   -128.14:25:11.1111111
'</Snippet2>