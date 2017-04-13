// System::Diagnostics::Process::StandardError
/*
The following example demonstrates property 'StandardError' of
'Process' class.

It starts a process(net.exe) which writes an error message on to the standard
error when a bad network path is given.This program gets 'StandardError' of
net.exe process and reads output from its stream reader.*/

#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::ComponentModel;
using namespace System::IO;

void GetStandardError( array<String^>^args )
{
   try
   {
// <Snippet1>
      Process^ myProcess = gcnew Process;
      ProcessStartInfo^ myProcessStartInfo = gcnew ProcessStartInfo( "net ",String::Concat( "use ", args[ 0 ] ) );

      myProcessStartInfo->UseShellExecute = false;
      myProcessStartInfo->RedirectStandardError = true;
      myProcess->StartInfo = myProcessStartInfo;
      myProcess->Start();

      StreamReader^ myStreamReader = myProcess->StandardError;
      // Read the standard error of net.exe and write it on to console.
      Console::WriteLine( myStreamReader->ReadLine() );
      myProcess->Close();
// </Snippet1>
   }
   catch ( Win32Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
   catch ( SystemException^ e ) 
   {
      Console::WriteLine( e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
}

void main( int argc, char *argv[] )
{
   if ( argc < 2 )
   {
      Console::WriteLine( "\nThis requires a machine name as a parameter which is not on the network." );
      Console::WriteLine( "\nUsage:" );
      Console::WriteLine( "Process_StandardError <\\\\machine name>" );
   }
   else
   {
      GetStandardError( Environment::GetCommandLineArgs() );
   }
   return;
}
