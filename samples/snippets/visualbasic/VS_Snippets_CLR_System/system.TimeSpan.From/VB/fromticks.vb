'<Snippet1>
' Example of the TimeSpan.FromTicks( Long ) method.
Imports System
Imports Microsoft.VisualBasic

Module FromTicksDemo

    Sub GenTimeSpanFromTicks( ticks As Long )

        ' Create a TimeSpan object and TimeSpan string from 
        ' a number of ticks.
        Dim interval As TimeSpan = TimeSpan.FromTicks( ticks )
        Dim timeInterval As String = interval.ToString( )

        ' Pad the end of the TimeSpan string with spaces if it 
        ' does not contain milliseconds.
        Dim pIndex As Integer = timeInterval.IndexOf( ":"c )
        pIndex = timeInterval.IndexOf( "."c, pIndex )
        If pIndex < 0 Then   timeInterval &= "        "
        
        Console.WriteLine( "{0,21}{1,26}", ticks, timeInterval )
    End Sub 

    Sub Main( )

        Console.WriteLine( _
            "This example of TimeSpan.FromTicks( Long )" & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,21}{1,18}", _
            "FromTicks", "TimeSpan" )    
        Console.WriteLine( "{0,21}{1,18}", _
            "---------", "--------" )    

        GenTimeSpanFromTicks( 1 )
        GenTimeSpanFromTicks( 12345 )
        GenTimeSpanFromTicks( 123456789 )
        GenTimeSpanFromTicks( 1234567898765 )
        GenTimeSpanFromTicks( 12345678987654321 )
        GenTimeSpanFromTicks( 10000000 )
        GenTimeSpanFromTicks( 600000000 )
        GenTimeSpanFromTicks( 36000000000 )
        GenTimeSpanFromTicks( 864000000000 )
        GenTimeSpanFromTicks( 18012202000000 )
    End Sub 
End Module 

' This example of TimeSpan.FromTicks( Long )
' generates the following output.
' 
'             FromTicks          TimeSpan
'             ---------          --------
'                     1          00:00:00.0000001
'                 12345          00:00:00.0012345
'             123456789          00:00:12.3456789
'         1234567898765        1.10:17:36.7898765
'     12345678987654321    14288.23:31:38.7654321
'              10000000          00:00:01
'             600000000          00:01:00
'           36000000000          01:00:00
'          864000000000        1.00:00:00
'        18012202000000       20.20:20:20.2000000
'</Snippet1>