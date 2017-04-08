// <Snippet4>
using namespace System;
using namespace System::IO;

void main()
{
      // Change the directory to %WINDIR%
      Environment::CurrentDirectory = Environment::GetEnvironmentVariable( "windir" );
      DirectoryInfo^ info = gcnew DirectoryInfo( "." );

      Console::WriteLine("Directory Info:   {0}", info->FullName);
}
// The example displays output like the following:
//        Directory Info:   C:\windows
//</Snippet4>