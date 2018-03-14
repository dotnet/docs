//<Snippet1>
// Example for the OperatingSystem.Platform and 
// OperatingSystem.Version properties.
using System;

class PlatformVersionDemo
{
    // Create an OperatingSystem object and display the Platform
    // and Version properties.
    static void BuildOSObj( PlatformID pID, Version ver )
    {
        OperatingSystem opSys   = new OperatingSystem( pID, ver );
        PlatformID platform     = opSys.Platform;
        Version version         = opSys.Version;

        Console.WriteLine( "   Platform: {0,-15} Version: {1}", 
            platform, version );
    } 
        
    static void BuildOperatingSystemObjects( )
    { 
        // The Version object does not need to correspond to an 
        // actual OS version.
        Version verNull     = new Version( );
        Version verString   = new Version( "3.5.8.13" );
        Version verMajMin   = new Version( 6, 10 );
        Version verMMBld    = new Version( 5, 25, 5025 );
        Version verMMBVer   = new Version( 5, 6, 7, 8 );
            
        // All PlatformID members are shown here.
        BuildOSObj( PlatformID.Win32NT, verNull );
        BuildOSObj( PlatformID.Win32S, verString );
        BuildOSObj( PlatformID.Win32Windows, verMajMin );
        BuildOSObj( PlatformID.WinCE, verMMBld );
        BuildOSObj( PlatformID.Win32NT, verMMBVer );
    } 
        
    static void Main( )
    {
        Console.WriteLine(
            "This example of OperatingSystem.Platform " +
            "and OperatingSystem.Version \n" +
            "generates the following output.\n" );
        Console.WriteLine(
            "Create several OperatingSystem objects " +
            "and display their properties:\n" );

        BuildOperatingSystemObjects( );
            
        Console.WriteLine(
            "\nThe operating system of the host computer is:\n" );

        BuildOSObj(
            Environment.OSVersion.Platform, 
            Environment.OSVersion.Version );
    } 
}

/*
This example of OperatingSystem.Platform and OperatingSystem.Version
generates the following output.

Create several OperatingSystem objects and display their properties:

Platform: Win32NT         Version: 0.0
Platform: Win32S          Version: 3.5.8.13
Platform: Win32Windows    Version: 6.10
Platform: WinCE           Version: 5.25.5025
Platform: Win32NT         Version: 5.6.7.8

The operating system of the host computer is:

Platform: Win32NT         Version: 5.1.2600.0
*/
//</Snippet1>

