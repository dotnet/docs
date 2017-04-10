'<Snippet1>
' Example for the OperatingSystem constructor and the  
' OperatingSystem.ToString( ) method.
Imports System
Imports Microsoft.VisualBasic

Module OpSysConstructDemo
    
    ' Create and display an OperatingSystem object.
    Sub BuildOSObj( pID As PlatformID, ver As Version )

        Dim os As New OperatingSystem( pID, ver )

        Console.WriteLine( "   {0}", os.ToString( ) )
    End Sub 
        
    Sub BuildOperatingSystemObjects( )

        ' The Version object does not need to correspond to an 
        ' actual OS version.
        Dim verNull     As New Version( )
        Dim verMajMin   As New Version( 3, 11 )
        Dim verMMBld    As New Version( 5, 25, 625 )
        Dim verMMBVer   As New Version( 5, 6, 7, 8 )
        Dim verString   As New Version( "3.5.8.13" )
            
        ' All PlatformID members are shown here.
        BuildOSObj( PlatformID.Win32NT, verNull )
        BuildOSObj( PlatformID.Win32S, verMajMin )
        BuildOSObj( PlatformID.Win32Windows, verMMBld )
        BuildOSObj( PlatformID.WinCE, verMMBVer )
        BuildOSObj( PlatformID.Win32NT, verString )
    End Sub 
        
    Sub Main( )
        Console.WriteLine( _
            "This example of the OperatingSystem constructor " & _
            "and " & vbCrLf & "OperatingSystem.ToString( ) " & _
            "generates the following output." & vbCrLf )
        Console.WriteLine( _
            "Create and display several different " & _
            "OperatingSystem objects:" & vbCrLf )

        BuildOperatingSystemObjects( )
            
        Console.WriteLine(vbCrLf & _
            "The OS version of the host computer is: " & _
            vbCrLf & vbCrLf & "   {0}", _
            Environment.OSVersion.ToString( ) )
    End Sub
End Module 

' This example of the OperatingSystem constructor and
' OperatingSystem.ToString( ) generates the following output.
' 
' Create and display several different OperatingSystem objects:
' 
'    Microsoft Windows NT 0.0
'    Microsoft Win32S 3.11
'    Microsoft Windows 98 5.25.625
'    Microsoft Windows CE 5.6.7.8
'    Microsoft Windows NT 3.5.8.13
' 
' The OS version of the host computer is:
' 
'    Microsoft Windows NT 5.1.2600.0
'</Snippet1>
