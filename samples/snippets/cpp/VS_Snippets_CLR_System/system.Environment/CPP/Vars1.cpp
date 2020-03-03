// <Snippet4>
using namespace System;
using namespace System::IO;

void main()
{
      if (Environment::OSVersion->Platform == PlatformID::Win32NT)
      {
            // Change the directory to %WINDIR%
            Environment::CurrentDirectory = Environment::GetEnvironmentVariable( "windir" );
            DirectoryInfo^ info = gcnew DirectoryInfo( "." );

            Console::WriteLine("Directory Info:   {0}", info->FullName);
      }
      else
      {
            Console::WriteLine("This example runs on Windows only.");
      }
}
// The example displays output like the following on a .NET implementation running on Windows:
//        Directory Info:   C:\windows
// The example displays the following output on a .NET implementation on Unix-based systems:
//        This example runs on Windows only.
//</Snippet4>