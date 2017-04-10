'<Snippet5>
' Example of the TimeSpan.FromHours( Double ) method.
Imports System
Imports Microsoft.VisualBasic

Module FromHoursDemo

    Sub GenTimeSpanFromHours( hours As Double )

        ' Create a TimeSpan object and TimeSpan string from 
        ' a number of hours.
        Dim interval As TimeSpan = _
            TimeSpan.FromHours( hours )
        Dim timeInterval As String = interval.ToString( )

        ' Pad the end of the TimeSpan string with spaces if it 
        ' does not contain milliseconds.
        Dim pIndex As Integer = timeInterval.IndexOf( ":"c )
        pIndex = timeInterval.IndexOf( "."c, pIndex )
        If pIndex < 0 Then  timeInterval &= "        "

        Console.WriteLine( "{0,21}{1,26}", hours, timeInterval )
    End Sub 

    Sub Main( )

        Console.WriteLine( "This example of " & _
            "TimeSpan.FromHours( Double )" & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,21}{1,18}", _
            "FromHours", "TimeSpan" )    
        Console.WriteLine( "{0,21}{1,18}", _
            "---------", "--------" )    

        GenTimeSpanFromHours( 0.0000002 )
        GenTimeSpanFromHours( 0.0000003 )
        GenTimeSpanFromHours( 0.0012345 )
        GenTimeSpanFromHours( 12.3456789 )
        GenTimeSpanFromHours( 123456.7898765 )
        GenTimeSpanFromHours( 0.0002777 )
        GenTimeSpanFromHours( 0.0166666 )
        GenTimeSpanFromHours( 1 )
        GenTimeSpanFromHours( 24 )
        GenTimeSpanFromHours( 500.3389445 )
    End Sub 
End Module 

' This example of TimeSpan.FromHours( Double )
' generates the following output.
' 
'             FromHours          TimeSpan
'             ---------          --------
'                 2E-07          00:00:00.0010000
'                 3E-07          00:00:00.0010000
'             0.0012345          00:00:04.4440000
'            12.3456789          12:20:44.4440000
'        123456.7898765     5144.00:47:23.5550000
'             0.0002777          00:00:01
'             0.0166666          00:01:00
'                     1          01:00:00
'                    24        1.00:00:00
'           500.3389445       20.20:20:20.2000000
'</Snippet5>