'<Snippet3>
' Example of the TimeSpan.FromSeconds( Double ) method.
Imports System
Imports Microsoft.VisualBasic

Module FromSecondsDemo

    Sub GenTimeSpanFromSeconds( seconds As Double )

        ' Create a TimeSpan object and TimeSpan string from 
        ' a number of seconds.
        Dim interval As TimeSpan = _
            TimeSpan.FromSeconds( seconds )
        Dim timeInterval As String = interval.ToString( )

        ' Pad the end of the TimeSpan string with spaces if it 
        ' does not contain milliseconds.
        Dim pIndex As Integer = timeInterval.IndexOf( ":"c )
        pIndex = timeInterval.IndexOf( "."c, pIndex )
        If pIndex < 0 Then   timeInterval &= "        "

        Console.WriteLine( "{0,21}{1,26}", seconds, timeInterval )
    End Sub 

    Sub Main( )

        Console.WriteLine( "This example of " & _
            "TimeSpan.FromSeconds( Double )" & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,21}{1,18}", _
            "FromSeconds", "TimeSpan" )    
        Console.WriteLine( "{0,21}{1,18}", _
            "-----------", "--------" )    

        GenTimeSpanFromSeconds( 0.001 )
        GenTimeSpanFromSeconds( 0.0015 )
        GenTimeSpanFromSeconds( 12.3456 )
        GenTimeSpanFromSeconds( 123456.7898 )
        GenTimeSpanFromSeconds( 1234567898.7654 )
        GenTimeSpanFromSeconds( 1 )
        GenTimeSpanFromSeconds( 60 )
        GenTimeSpanFromSeconds( 3600 )
        GenTimeSpanFromSeconds( 86400 )
        GenTimeSpanFromSeconds( 1801220.2 )
    End Sub
End Module 

' This example of TimeSpan.FromSeconds( Double )
' generates the following output.
' 
'           FromSeconds          TimeSpan
'           -----------          --------
'                 0.001          00:00:00.0010000
'                0.0015          00:00:00.0020000
'               12.3456          00:00:12.3460000
'           123456.7898        1.10:17:36.7900000
'       1234567898.7654    14288.23:31:38.7650000
'                     1          00:00:01
'                    60          00:01:00
'                  3600          01:00:00
'                 86400        1.00:00:00
'             1801220.2       20.20:20:20.2000000
'</Snippet3>