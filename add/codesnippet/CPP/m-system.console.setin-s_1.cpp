using namespace System;
using namespace System::IO;

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   const int tabSize = 4;
   String^ usageText = "Usage: INSERTTABS inputfile.txt outputfile.txt";
   StreamWriter^ writer = nullptr;
   if ( args->Length < 3 )
   {
      Console::WriteLine( usageText );
      return 1;
   }

   try
   {
      // Attempt to open output file.
      writer = gcnew StreamWriter( args[ 2 ] );
      // Redirect standard output from the console to the output file.
      Console::SetOut( writer );
      // Redirect standard input from the console to the input file.
      Console::SetIn( gcnew StreamReader( args[ 1 ] ) );
   }
   catch ( IOException^ e ) 
   {
      TextWriter^ errorWriter = Console::Error;
      errorWriter->WriteLine( e->Message );
      errorWriter->WriteLine( usageText );
      return 1;
   }

   String^ line;
   while ( (line = Console::ReadLine()) != nullptr )
   {
      String^ newLine = line->Replace( ((String^)"")->PadRight( tabSize, ' ' ), "\t" );
      Console::WriteLine( newLine );
   }

   writer->Close();
   
   // Recover the standard output stream so that a 
   // completion message can be displayed.
   StreamWriter^ standardOutput = gcnew StreamWriter( Console::OpenStandardOutput() );
   standardOutput->AutoFlush = true;
   Console::SetOut( standardOutput );
   Console::WriteLine( "INSERTTABS has completed the processing of {0}.", args[ 1 ] );
   return 0;
}
