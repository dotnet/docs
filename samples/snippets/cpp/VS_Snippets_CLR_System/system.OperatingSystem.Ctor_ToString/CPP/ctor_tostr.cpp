
//<Snippet1>
// Example for the OperatingSystem constructor and the 
// OperatingSystem::ToString( ) method.
using namespace System;

// Create and display an OperatingSystem object.
void BuildOSObj( PlatformID pID, Version^ ver )
{
   OperatingSystem^ os = gcnew OperatingSystem( pID,ver );
   Console::WriteLine( "   {0}", os->ToString() );
}

void BuildOperatingSystemObjects()
{
   
   // The Version object does not need to correspond to an 
   // actual OS version.
   Version^ verNull = gcnew Version;
   Version^ verMajMin = gcnew Version( 3,11 );
   Version^ verMMBld = gcnew Version( 5,25,625 );
   Version^ verMMBVer = gcnew Version( 5,6,7,8 );
   Version^ verString = gcnew Version( "3.5.8.13" );
   
   // All PlatformID members are shown here.
   BuildOSObj( PlatformID::Win32NT, verNull );
   BuildOSObj( PlatformID::Win32S, verMajMin );
   BuildOSObj( PlatformID::Win32Windows, verMMBld );
   BuildOSObj( PlatformID::WinCE, verMMBVer );
   BuildOSObj( PlatformID::Win32NT, verString );
}

int main()
{
   Console::WriteLine( "This example of the OperatingSystem constructor and \n"
   "OperatingSystem::ToString( ) generates the following "
   "output.\n" );
   Console::WriteLine( "Create and display several different "
   "OperatingSystem objects:\n" );
   BuildOperatingSystemObjects();
   Console::WriteLine( "\nThe OS version of the host computer is:\n\n   {0}", Environment::OSVersion->ToString() );
}

/*
This example of the OperatingSystem constructor and
OperatingSystem::ToString( ) generates the following output.

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
