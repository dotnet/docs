'<Snippet1>
' Example for the OperatingSystem.Platform and 
' OperatingSystem.Version properties.
Imports System
Imports Microsoft.VisualBasic

Module PlatformVersionDemo
    
    ' Create an OperatingSystem object, and display the Platform
    ' and Version properties.
    Sub BuildOSObj( pID As PlatformID, ver As Version )

        Dim opSys       As New OperatingSystem( pID, ver )
        Dim platform    As PlatformID = opSys.Platform
        Dim version     As Version = opSys.Version

        Console.WriteLine( "   Platform: {0,-15} Version: {1}", _
            platform, version )
    End Sub 
        
    Sub BuildOperatingSystemObjects( )

        ' The Version object does not need to correspond to an 
        ' actual OS version.
        Dim verNull     As New Version( )
        Dim verString   As New Version( "3.5.8.13" )
        Dim verMajMin   As New Version( 6, 10 )
        Dim verMMBld    As New Version( 5, 25, 5025 )
        Dim verMMBVer   As New Version( 5, 6, 7, 8 )
            
        ' All PlatformID members are shown here.
        BuildOSObj( PlatformID.Win32NT, verNull )
        BuildOSObj( PlatformID.Win32S, verString )
        BuildOSObj( PlatformID.Win32Windows, verMajMin )
        BuildOSObj( PlatformID.WinCE, verMMBld )
        BuildOSObj( PlatformID.Win32NT, verMMBVer )
    End Sub 
        
    Sub Main( )
        Console.WriteLine( _
            "This example of OperatingSystem.Platform " & _
            "and OperatingSystem.Version " & vbCrLf & _
            "generates the following output." & vbCrLf )
        Console.WriteLine( _
            "Create several OperatingSystem objects " & _
            "and display their properties:" & vbCrLf )

        BuildOperatingSystemObjects( )
            
        Console.WriteLine(vbCrLf & _
            "The operating system of the host computer is: " & _
            vbCrLf )

        BuildOSObj( _
            Environment.OSVersion.Platform, _
            Environment.OSVersion.Version )
    End Sub 
End Module 

' This example of OperatingSystem.Platform and OperatingSystem.Version
' generates the following output.
' 
' Create several OperatingSystem objects and display their properties:
' 
'    Platform: Win32NT         Version: 0.0
'    Platform: Win32S          Version: 3.5.8.13
'    Platform: Win32Windows    Version: 6.10
'    Platform: WinCE           Version: 5.25.5025
'    Platform: Win32NT         Version: 5.6.7.8
' 
' The operating system of the host computer is:
' 
'    Platform: Win32NT         Version: 5.1.2600.0
'</Snippet1>
