//<Snippet1>
// Example for the OperatingSystem constructor and the 
// OperatingSystem.ToString( ) method.
using System;

class OpSysConstructDemo 
{
    // Create and display an OperatingSystem object.
    static void BuildOSObj( PlatformID pID, Version ver )
    {
        OperatingSystem os = new OperatingSystem( pID, ver );

        Console.WriteLine( "   {0}", os.ToString( ) );
    }

    static void BuildOperatingSystemObjects( )
    {
        // The Version object does not need to correspond to an 
        // actual OS version.
        Version verNull     = new Version( );
        Version verMajMin   = new Version( 3, 11 );
        Version verMMBld    = new Version( 5, 25, 625 );
        Version verMMBVer   = new Version( 5, 6, 7, 8 );
        Version verString   = new Version( "3.5.8.13" );

        // All PlatformID members are shown here.
        BuildOSObj( PlatformID.Win32NT, verNull );
        BuildOSObj( PlatformID.Win32S, verMajMin );
        BuildOSObj( PlatformID.Win32Windows, verMMBld );
        BuildOSObj( PlatformID.WinCE, verMMBVer );
        BuildOSObj( PlatformID.Win32NT, verString );
    }

    public static void Main( ) 
    {
        Console.WriteLine( 
            "This example of the OperatingSystem constructor " +
            "and \nOperatingSystem.ToString( ) " +
            "generates the following output.\n" );
        Console.WriteLine( 
            "Create and display several different " +
            "OperatingSystem objects:\n" );

        BuildOperatingSystemObjects( );

        Console.WriteLine( 
            "\nThe OS version of the host computer is:\n\n   {0}", 
            Environment.OSVersion.ToString( ) );
    }
}

/*
This example of the OperatingSystem constructor and
OperatingSystem.ToString( ) generates the following output.

Create and display several different OperatingSystem objects:

   Microsoft Windows NT 0.0
   Microsoft Win32S 3.11
   Microsoft Windows 98 5.25.625
   Microsoft Windows CE 5.6.7.8
   Microsoft Windows NT 3.5.8.13

The OS version of the host computer is:

   Microsoft Windows NT 5.1.2600.0
*/
//</Snippet1>
