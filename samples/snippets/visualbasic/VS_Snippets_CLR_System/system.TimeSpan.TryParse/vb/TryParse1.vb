' Example of the TimeSpan.Parse( String ) and TimeSpan.ToString( ) 
' methods.

' <Snippet1>
Module TryParse
    Sub ParseTimeSpan( intervalStr As String )
        ' Write the first part of the output line.
        Console.Write( "{0,20}   ", intervalStr )

        ' Parse the parameter, and then convert it back to a string.
         Dim intervalVal As TimeSpan 
         If TimeSpan.TryParse( intervalStr, intervalVal ) Then
            Dim intervalToStr As String = intervalVal.ToString( )
   
            ' Pad the end of the TimeSpan string with spaces if it 
            ' does not contain milliseconds.
            Dim pIndex As Integer = intervalToStr.IndexOf( ":"c )
            pIndex = intervalToStr.IndexOf( "."c, pIndex )
            If pIndex < 0 Then   intervalToStr &= "        "
   
            Console.WriteLine( "{0,21}", intervalToStr )
         ' Handle failure of TryParse method.
         Else
            Console.WriteLine("Parse operation failed.")
        End If
    End Sub 

    Public Sub Main( )
        Console.WriteLine( "{0,20}   {1,21}", _
            "String to Parse", "TimeSpan" )    
        Console.WriteLine( "{0,20}   {1,21}", _
            "---------------", "---------------------" )    

        ParseTimeSpan("0")
        ParseTimeSpan("14")
        ParseTimeSpan("1:2:3")
        ParseTimeSpan("0:0:0.250")
        ParseTimeSpan("10.20:30:40.50")
        ParseTimeSpan("99.23:59:59.9999999")
        ParseTimeSpan("0023:0059:0059.0099")
        ParseTimeSpan("23:0:0")
        ParseTimeSpan("24:0:0")
        ParseTimespan("0:59:0")
        ParseTimeSpan("0:60:0")
        ParseTimespan("0:0:59")
        ParseTimeSpan("0:0:60")
        ParseTimeSpan("10:")
        ParsetimeSpan("10:0")
        ParseTimeSpan(":10")
        ParseTimeSpan("0:10")
        ParseTimeSpan("10:20:")
        ParseTimeSpan("10:20:0")
        ParseTimeSpan(".123")
        ParseTimeSpan("0.12:00")
        ParseTimeSpan("10.")
        ParseTimeSpan("10.12")
        ParseTimeSpan("10.12:00")
    End Sub 
End Module 
' This example generates the following output:
'            String to Parse                TimeSpan
'            ---------------   ---------------------
'                          0        00:00:00
'                         14     14.00:00:00
'                      1:2:3        01:02:03
'                  0:0:0.250        00:00:00.2500000
'             10.20:30:40.50     10.20:30:40.5000000
'        99.23:59:59.9999999     99.23:59:59.9999999
'        0023:0059:0059.0099        23:59:59.0099000
'                     23:0:0        23:00:00
'                     24:0:0   Parse operation failed.
'                     0:59:0        00:59:00
'                     0:60:0   Parse operation failed.
'                     0:0:59        00:00:59
'                     0:0:60   Parse operation failed.
'                        10:   Parse operation failed.
'                       10:0        10:00:00
'                        :10   Parse operation failed.
'                       0:10        00:10:00
'                     10:20:   Parse operation failed.
'                    10:20:0        10:20:00
'                       .123   Parse operation failed.
'                    0.12:00        12:00:00
'                        10.   Parse operation failed.
'                      10.12   Parse operation failed.
'                   10.12:00     10.12:00:00
' </Snippet1>
