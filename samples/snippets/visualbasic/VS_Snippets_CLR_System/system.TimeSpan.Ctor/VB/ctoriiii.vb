' <Snippet3>
Module Example
    ' Create a TimeSpan object and display its value.
    Sub CreateTimeSpan( days As Integer, hours As Integer, _
        minutes As Integer, seconds As Integer )

        Dim elapsedTime As New TimeSpan( _
            days, hours, minutes, seconds )

        ' Format the constructor for display.
        Dim ctor AS String = _
            String.Format( "TimeSpan( {0}, {1}, {2}, {3} )", _
                days, hours, minutes, seconds )

        ' Display the constructor and its value.
        Console.WriteLine( "{0,-44}{1,16}", _
            ctor, elapsedTime.ToString( ) )
    End Sub
    
    Sub Main()
        Console.WriteLine( "{0,-44}{1,16}", "Constructor", "Value" )
        Console.WriteLine( "{0,-44}{1,16}", "-----------", "-----" )

        CreateTimeSpan( 10, 20, 30, 40 )
        CreateTimeSpan( -10, 20, 30, 40 )
        CreateTimeSpan( 0, 0, 0, 937840 )
        CreateTimeSpan( 1000, 2000, 3000, 4000 )
        CreateTimeSpan( 1000, -2000, -3000, -4000 )
        CreateTimeSpan( 999999, 999999, 999999, 999999 )
    End Sub 
End Module 
' The example generates the following output:
'       Constructor                                            Value
'       -----------                                            -----
'       TimeSpan( 10, 20, 30, 40 )                       10.20:30:40
'       TimeSpan( -10, 20, 30, 40 )                      -9.03:29:20
'       TimeSpan( 0, 0, 0, 937840 )                      10.20:30:40
'       TimeSpan( 1000, 2000, 3000, 4000 )             1085.11:06:40
'       TimeSpan( 1000, -2000, -3000, -4000 )           914.12:53:20
'       TimeSpan( 999999, 999999, 999999, 999999 )  1042371.15:25:39
' </Snippet3>