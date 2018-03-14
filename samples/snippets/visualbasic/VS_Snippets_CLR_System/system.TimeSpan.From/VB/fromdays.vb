'<Snippet6>
' Example of the TimeSpan.FromDays( Double ) method.
Imports System
Imports Microsoft.VisualBasic

Module FromDaysDemo

    Sub GenTimeSpanFromDays( days As Double )

        ' Create a TimeSpan object and TimeSpan string from 
        ' a number of days.
        Dim interval As TimeSpan = _
            TimeSpan.FromDays( days )
        Dim timeInterval As String = interval.ToString( )

        ' Pad the end of the TimeSpan string with spaces if it 
        ' does not contain milliseconds.
        Dim pIndex As Integer = timeInterval.IndexOf( ":"c )
        pIndex = timeInterval.IndexOf( "."c, pIndex )
        If pIndex < 0 Then  timeInterval &= "        "

        Console.WriteLine( "{0,21}{1,26}", days, timeInterval )
    End Sub 

    Sub Main( )

        Console.WriteLine( "This example of " & _
            "TimeSpan.FromDays( Double )" & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,21}{1,18}", _
            "FromDays", "TimeSpan" )    
        Console.WriteLine( "{0,21}{1,18}", _
            "--------", "--------" )    

        GenTimeSpanFromDays( 0.000000006 )
        GenTimeSpanFromDays( 0.000000017 )
        GenTimeSpanFromDays( 0.000123456 )
        GenTimeSpanFromDays( 1.234567898 )
        GenTimeSpanFromDays( 12345.678987654 )
        GenTimeSpanFromDays( 0.000011574 )
        GenTimeSpanFromDays( 0.000694444 )
        GenTimeSpanFromDays( 0.041666666 )
        GenTimeSpanFromDays( 1 )
        GenTimeSpanFromDays( 20.84745602 )
    End Sub 
End Module 

' This example of TimeSpan.FromDays( Double )
' generates the following output.
' 
'              FromDays          TimeSpan
'              --------          --------
'                 6E-09          00:00:00.0010000
'               1.7E-08          00:00:00.0010000
'           0.000123456          00:00:10.6670000
'           1.234567898        1.05:37:46.6660000
'       12345.678987654    12345.16:17:44.5330000
'            1.1574E-05          00:00:01
'           0.000694444          00:01:00
'           0.041666666          01:00:00
'                     1        1.00:00:00
'           20.84745602       20.20:20:20.2000000
'</Snippet6>