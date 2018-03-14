
//<snippet1>
using namespace System;

int main()
{
   Console::WriteLine();
   
   //  Invoke this sample with an arbitrary set of command line arguments.
   array<String^>^ arguments = Environment::GetCommandLineArgs();
   Console::WriteLine( "GetCommandLineArgs: {0}", String::Join( ", ", arguments ) );
}
/*
This example produces output like the following:
    
    C:\>GetCommandLineArgs ARBITRARY TEXT
    
      GetCommandLineArgs: GetCommandLineArgs, ARBITRARY, TEXT
*/
//</snippet1>
