
//<snippet1>
// This example demonstrates the PlatformID enumeration.
using namespace System;
int main()
{
   String^ msg1 = L"This is a Windows operating system.";
   String^ msg2 = L"This is a Unix operating system.";
   String^ msg3 = L"ERROR: This platform identifier is invalid.";
   
   // Assume this example is run on a Windows operating system.
   OperatingSystem^ os = Environment::OSVersion;
   PlatformID pid = os->Platform;
   switch ( pid )
   {
      case PlatformID::Win32NT:
      case PlatformID::Win32S:
      case PlatformID::Win32Windows:
      case PlatformID::WinCE:
         Console::WriteLine( msg1 );
         break;

      case PlatformID::Unix:
         Console::WriteLine( msg2 );
         break;

      default:
         Console::WriteLine( msg3 );
         break;
   }
   return 1;
}

/*
This example produces the following results:

This is a Windows operating system.
*/
//</snippet1>
