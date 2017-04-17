// System.Diagnostics
//
// Requires .NET Framework version 1.2 or higher.

// The following example uses the net view command to list the 
// available network resources available on a remote computer, 
// and displays the results to the console. Specifying the optional
// error log file redirects error output to that file.

// <Snippet2>
// Define the namespaces used by this sample.
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Globalization;
using namespace System::IO;
using namespace System::Diagnostics;
using namespace System::Threading;
using namespace System::ComponentModel;

ref class ProcessNetStreamRedirection
{
private:
   // Define static variables shared by class methods.
   static StreamWriter^ streamError = nullptr;
   static String^ netErrorFile = "";
   static StringBuilder^ netOutput = nullptr;
   static bool errorRedirect = false;
   static bool errorsWritten = false;

public:
   static void RedirectNetCommandStreams()
   {
      String^ netArguments;
      Process^ netProcess;
      
      // Get the input computer name.
      Console::WriteLine( "Enter the computer name for the net view command:" );
      netArguments = Console::ReadLine()->ToUpper( CultureInfo::InvariantCulture );
      if ( String::IsNullOrEmpty( netArguments ) )
      {
         // Default to the help command if there is not an input argument.
         netArguments = "/?";
      }
      
      // Check if errors should be redirected to a file.
      errorsWritten = false;
      Console::WriteLine( "Enter a fully qualified path to an error log file" );
      Console::WriteLine( "  or just press Enter to write errors to console:" );
      netErrorFile = Console::ReadLine()->ToUpper( CultureInfo::InvariantCulture );
      if (  !String::IsNullOrEmpty( netErrorFile ) )
      {
         errorRedirect = true;
      }
      
      // Note that at this point, netArguments and netErrorFile
      // are set with user input.  If the user did not specify
      // an error file, then errorRedirect is set to false.

      // Initialize the process and its StartInfo properties.
      netProcess = gcnew Process;
      netProcess->StartInfo->FileName = "Net.exe";
      
      // Build the net command argument list.
      netProcess->StartInfo->Arguments = String::Format( "view {0}", netArguments );
      
      // Set UseShellExecute to false for redirection.
      netProcess->StartInfo->UseShellExecute = false;
      
      // Redirect the standard output of the net command.  
      // This stream is read asynchronously using an event handler.
      netProcess->StartInfo->RedirectStandardOutput = true;
      netProcess->OutputDataReceived += gcnew DataReceivedEventHandler( NetOutputDataHandler );
      netOutput = gcnew StringBuilder;
      if ( errorRedirect )
      {
         
         // Redirect the error output of the net command. 
         netProcess->StartInfo->RedirectStandardError = true;
         netProcess->ErrorDataReceived += gcnew DataReceivedEventHandler( NetErrorDataHandler );
      }
      else
      {
         
         // Do not redirect the error output.
         netProcess->StartInfo->RedirectStandardError = false;
      }

      Console::WriteLine( "\nStarting process: net {0}",
         netProcess->StartInfo->Arguments );
      if ( errorRedirect )
      {
         Console::WriteLine( "Errors will be written to the file {0}", netErrorFile );
      }
      
      // Start the process.
      netProcess->Start();
      
      // Start the asynchronous read of the standard output stream.
      netProcess->BeginOutputReadLine();

      if ( errorRedirect )
      {
         // Start the asynchronous read of the standard
         // error stream.
         netProcess->BeginErrorReadLine();
      }
      
      // Let the net command run, collecting the output.
      netProcess->WaitForExit();

      if ( streamError != nullptr )
      {
         // Close the error file.
         streamError->Close();
      }
      else
      {
         // Set errorsWritten to false if the stream is not
         // open.   Either there are no errors, or the error
         // file could not be opened.
         errorsWritten = false;
      }

      if ( netOutput->Length > 0 )
      {
         // If the process wrote more than just
         // white space, write the output to the console.
         Console::WriteLine( "\nPublic network shares from net view:\n{0}\n",
            netOutput->ToString() );
      }

      if ( errorsWritten )
      {
         // Signal that the error file had something 
         // written to it.
         array<String^>^errorOutput = File::ReadAllLines( netErrorFile );
         if ( errorOutput->Length > 0 )
         {
            Console::WriteLine( "\nThe following error output was appended to {0}.",
               netErrorFile );
            System::Collections::IEnumerator^ myEnum = errorOutput->GetEnumerator();
            while ( myEnum->MoveNext() )
            {
               String^ errLine = safe_cast<String^>(myEnum->Current);
               Console::WriteLine( "  {0}", errLine );
            }
         }
         Console::WriteLine();
      }

      netProcess->Close();

   }

private:
   static void NetOutputDataHandler( Object^ /*sendingProcess*/,
      DataReceivedEventArgs^ outLine )
   {
      // Collect the net view command output.
      if (  !String::IsNullOrEmpty( outLine->Data ) )
      {
         // Add the text to the collected output.
         netOutput->AppendFormat(  "\n  {0}", outLine->Data );
      }
   }

   static void NetErrorDataHandler( Object^ /*sendingProcess*/,
      DataReceivedEventArgs^ errLine )
   {
      // Write the error text to the file if there is something to 
      // write and an error file has been specified.

      if (  !String::IsNullOrEmpty( errLine->Data ) )
      {
         if (  !errorsWritten )
         {
            if ( streamError == nullptr )
            {
               // Open the file.
               try
               {
                  streamError = gcnew StreamWriter( netErrorFile,true );
               }
               catch ( Exception^ e ) 
               {
                  Console::WriteLine(  "Could not open error file!" );
                  Console::WriteLine( e->Message->ToString() );
               }
            }

            if ( streamError != nullptr )
            {
               // Write a header to the file if this is the first
               // call to the error output handler.
               streamError->WriteLine();
               streamError->WriteLine( DateTime::Now.ToString() );
               streamError->WriteLine(  "Net View error output:" );
            }
            errorsWritten = true;
         }

         if ( streamError != nullptr )
         {
            // Write redirected errors to the file.
            streamError->WriteLine( errLine->Data );
            streamError->Flush();
         }
      }
   }
};
// </Snippet2>

/// The main entry point for the application.
void main()
{
   try
   {
      ProcessNetStreamRedirection::RedirectNetCommandStreams();
   }
   catch ( InvalidOperationException^ e ) 
   {
      Console::WriteLine( "Exception:" );
      Console::WriteLine( e );
   }
}
