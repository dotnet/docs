// System.Diagnostics
//
// Requires .NET Framework version 1.2 or higher.

// The following example uses the sort command to sort a list
// of input text lines, and displays the sorted list to the console. 

//<Snippet1>
// Define the namespaces used by this sample.
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Diagnostics;
using namespace System::Threading;
using namespace System::ComponentModel;

ref class SortOutputRedirection
{
private:
   // Define static variables shared by class methods.
   static StringBuilder^ sortOutput = nullptr;
   static int numOutputLines = 0;

public:
   static void SortInputListText()
   {
      // Initialize the process and its StartInfo properties.
      // The sort command is a console application that
      // reads and sorts text input.

      Process^ sortProcess;
      sortProcess = gcnew Process;
      sortProcess->StartInfo->FileName = "Sort.exe";
      
      // Set UseShellExecute to false for redirection.
      sortProcess->StartInfo->UseShellExecute = false;
      
      // Redirect the standard output of the sort command.  
      // This stream is read asynchronously using an event handler.
      sortProcess->StartInfo->RedirectStandardOutput = true;
      sortOutput = gcnew StringBuilder;
      
      // Set our event handler to asynchronously read the sort output.
      sortProcess->OutputDataReceived += gcnew DataReceivedEventHandler( SortOutputHandler );
      
      // Redirect standard input as well.  This stream
      // is used synchronously.
      sortProcess->StartInfo->RedirectStandardInput = true;
      
      // Start the process.
      sortProcess->Start();
      
      // Use a stream writer to synchronously write the sort input.
      StreamWriter^ sortStreamWriter = sortProcess->StandardInput;
      
      // Start the asynchronous read of the sort output stream.
      sortProcess->BeginOutputReadLine();
      
      // Prompt the user for input text lines.  Write each 
      // line to the redirected input stream of the sort command.
      Console::WriteLine( "Ready to sort up to 50 lines of text" );

      String^ inputText;
      int numInputLines = 0;
      do
      {
         Console::WriteLine( "Enter a text line (or press the Enter key to stop):" );

         inputText = Console::ReadLine();
         if (  !String::IsNullOrEmpty( inputText ) )
         {
            numInputLines++;
            sortStreamWriter->WriteLine( inputText );
         }
      }
      while (  !String::IsNullOrEmpty( inputText ) && (numInputLines < 50) );

      Console::WriteLine( "<end of input stream>" );
      Console::WriteLine();
      
      // End the input stream to the sort command.
      sortStreamWriter->Close();
      
      // Wait for the sort process to write the sorted text lines.
      sortProcess->WaitForExit();

      if ( numOutputLines > 0 )
      {
         
         // Write the formatted and sorted output to the console.
         Console::WriteLine( " Sort results = {0} sorted text line(s) ",
            numOutputLines.ToString() );
         Console::WriteLine( "----------" );
         Console::WriteLine( sortOutput->ToString() );
      }
      else
      {
         Console::WriteLine( " No input lines were sorted." );
      }

      sortProcess->Close();
   }

private:
   static void SortOutputHandler( Object^ /*sendingProcess*/,
      DataReceivedEventArgs^ outLine )
   {
      // Collect the sort command output.
      if (  !String::IsNullOrEmpty( outLine->Data ) )
      {
         numOutputLines++;
         
         // Add the text to the collected output.
         sortOutput->AppendFormat( "\n[{0}] {1}",
            numOutputLines.ToString(), outLine->Data );
      }
   }
};

/// The main entry point for the application.
void main()
{
   try
   {
      SortOutputRedirection::SortInputListText();
   }
   catch ( InvalidOperationException^ e ) 
   {
      Console::WriteLine( "Exception:" );
      Console::WriteLine( e );
   }
}
// </Snippet1>

