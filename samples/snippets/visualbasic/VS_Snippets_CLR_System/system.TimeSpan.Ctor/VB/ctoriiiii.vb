'<Snippet4>
' Example of the 
' TimeSpan( Integer, Integer, Integer, Integer, Integer ) constructor. 
Imports System
Imports Microsoft.VisualBasic

Module TimeSpanCtorIIIIIDemo

    ' Create a TimeSpan object and display its value.
    Sub CreateTimeSpan( days As Integer, hours As Integer, _
        minutes As Integer, seconds As Integer, millisec As Integer )

        Dim elapsedTime As New TimeSpan( _
            days, hours, minutes, seconds, millisec )

        ' Format the constructor for display.
        Dim ctor As String = _
            String.Format( "TimeSpan( {0}, {1}, {2}, {3}, {4} )", _
                days, hours, minutes, seconds, millisec )

        ' Display the constructor and its value.
        Console.WriteLine( "{0,-48}{1,24}", _
            ctor, elapsedTime.ToString( ) )
    End Sub

    Sub Main( )

        Console.WriteLine( _
            "This example of the " & vbCrLf & _
            "TimeSpan( Integer, Integer, " & _
            "Integer, Integer, Integer ) " & vbCrLf & _
            "constructor generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-48}{1,16}", "Constructor", "Value" )
        Console.WriteLine( "{0,-48}{1,16}", "-----------", "-----" )

        CreateTimeSpan( 10, 20, 30, 40, 50 )
        CreateTimeSpan( -10, 20, 30, 40, 50 )
        CreateTimeSpan( 0, 0, 0, 0, 937840050 )
        CreateTimeSpan( 1111, 2222, 3333, 4444, 5555 )
        CreateTimeSpan( 1111, -2222, -3333, -4444, -5555 )
        CreateTimeSpan( 99999, 99999, 99999, 99999, 99999 )
    End Sub 
End Module 

' This example of the
' TimeSpan( Integer, Integer, Integer, Integer, Integer )
' constructor generates the following output.
' 
' Constructor                                                Value
' -----------                                                -----
' TimeSpan( 10, 20, 30, 40, 50 )                       10.20:30:40.0500000
' TimeSpan( -10, 20, 30, 40, 50 )                      -9.03:29:19.9500000
' TimeSpan( 0, 0, 0, 0, 937840050 )                    10.20:30:40.0500000
' TimeSpan( 1111, 2222, 3333, 4444, 5555 )           1205.22:47:09.5550000
' TimeSpan( 1111, -2222, -3333, -4444, -5555 )       1016.01:12:50.4450000
' TimeSpan( 99999, 99999, 99999, 99999, 99999 )    104236.05:27:18.9990000
'</Snippet4>